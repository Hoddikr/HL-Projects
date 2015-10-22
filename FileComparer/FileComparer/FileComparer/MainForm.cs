using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using HL.FileComparer.Dialogs;
using HL.FileComparer.Utilities;
using System.IO;

namespace HL.FileComparer
{
    public partial class MainForm : Form
    {                      
        private Dictionary<string, List<FileHashPair>> possibleMatches;        
        private BackgroundWorker worker;
        private FileType selectedPattern;
        private bool workerWasCancelled;
        private Stopwatch stopWatch;
        private Timer stopWatchTimer;

        public MainForm()
        {
            InitializeComponent();
            
            possibleMatches = new Dictionary<string, List<FileHashPair>>();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;           
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            foreach (var pattern in Settings.FileTypes)
            {
                cmbFileTypes.Items.Add(pattern.Description + " " + pattern.Pattern);
            }

            cmbFileTypes.SelectedIndex = 0;

            stopWatch = new Stopwatch();
            stopWatchTimer = new Timer();
            stopWatchTimer.Interval = 500;
            stopWatchTimer.Tick += StopWatchTimerOnTick;
        }

        private void StopWatchTimerOnTick(object sender, EventArgs eventArgs)
        {
            lblTimeElapsed.Text = (stopWatch.ElapsedMilliseconds/1000).ToString("D");
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCancel.Enabled = false;
            pbFilesProcessed.Value = 100;
            CheckEnabled(this, EventArgs.Empty);            

            if (workerWasCancelled)
            {
                workerWasCancelled = false;
                lblProgress.Text = Properties.Resources.Cancelled;
                return;
            }


            if (possibleMatches.Count == 0)
            {
                lblProgress.Text = "";
            }
            else
            {
                foreach (KeyValuePair<string, List<FileHashPair>> possibleMatch in possibleMatches)
                {                    
                    compareResultsControl.AddMatches(possibleMatch.Value);
                }
            }

            compareResultsControl.AutosizeMatches();
            compareResultsControl.Focus();
            
            lblResultCount.Text = string.Format(Properties.Resources.Results, compareResultsControl.MatchCount.ToString("D"));
            lblSpaceWasted.Text = GetTotalWastedSpaceInMb().ToString("N0") + " MB";
            
            StopAndResetWatch();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbFilesProcessed.Value = e.ProgressPercentage;
            ProgressInfo info = (ProgressInfo)e.UserState;
            lblProgress.Text = String.Format(Properties.Resources.ProcessingFile, info.FilesProcessed, info.TotalNumberOfFiles);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {            
            possibleMatches.Clear();

            possibleMatches = CompareUtils.GetAllPossibleFileMatches(folderBrowser.SelectedFolders, selectedPattern.Pattern, worker);
        }

        private void StopAndResetWatch()
        {
            stopWatchTimer.Stop();
            stopWatch.Stop();
            stopWatch.Reset();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!folderBrowser.ValidateSelectedFolders())
            {
                return;
            }

            stopWatch.Start();
            stopWatchTimer.Start();

            lblSpaceWasted.Text = "";

            compareResultsControl.ClearMatches();
            lblProgress.Text = Properties.Resources.SearchingForFiles;
            pbFilesProcessed.Value = 1;
            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            worker.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            workerWasCancelled = true;
            worker.CancelAsync();
            StopAndResetWatch();
        }

        private void CheckEnabled(object sender, EventArgs e)
        {
            btnStart.Enabled = folderBrowser.SelectedFolders != "";
            btnDeleteDuplicates.Enabled = possibleMatches.Count > 0;
        }

        private void cmbFileTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPattern = Settings.FileTypes[cmbFileTypes.SelectedIndex];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutFileComparerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new AboutDialog();
            dlg.ShowDialog(this);
        }

        private void compareResultsControl_MatchClicked(object sender, Controls.EventArguments.MatchClickEventArgs args)
        {
            foreach (FileHashPair file in args.Files)
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select, " + "\"" + file.FileName + "\"");
            }
        }

        private void btnDeleteDuplicates_Click(object sender, EventArgs e)
        {
            var dlgResult = MessageBox.Show("You are about to delete all duplicates found above. Only one copy in each box will be stored. PLEASE NOTE THAT THIS CAN NOT BE UNDONE.",
                                            "WARNING!",
                                            MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Warning);
            if (dlgResult == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var possibleMatchKey in possibleMatches.Keys)
                {
                    List<FileHashPair> fileList = possibleMatches[possibleMatchKey];
                    var filePaths = fileList.Select(x => x.FileName).ToList();
                    for (int i = 0; i < filePaths.Count - 1; i++)
                    {
                        var filePath = filePaths[i];
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting file " + filePath + ". Exception: " + ex);
                        }
                    }
                }
            }
        }

        private int GetTotalWastedSpaceInMb()
        {
            double totalWastedSpace = 0;

            foreach (var possibleMatchKey in possibleMatches.Keys)
            {
                List<FileHashPair> fileList = possibleMatches[possibleMatchKey];
                double singleFileSize = fileList[0].FileSizeMBytes;
                totalWastedSpace += singleFileSize * (fileList.Count - 1);
            }

            return (int)totalWastedSpace;
        }

        private void folderBrowser_SizeChanged(object sender, EventArgs e)
        {
            int delta = (folderBrowser.Bottom + 6) - compareResultsControl.Top;

            // Control is removed to prevent flickering and unnecessary re-drawing
            Controls.Remove(compareResultsControl);
            compareResultsControl.Top = compareResultsControl.Top + delta;
            compareResultsControl.Height = compareResultsControl.Height - delta;
            Controls.Add(compareResultsControl);
        }

        private void manageFileTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileTypesDialog dlg = new FileTypesDialog())
            {
                dlg.ShowDialog(this);
            }
        }
    }
}