using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using HL.FileComparer.Dialogs;
using HL.FileComparer.Utilities;

namespace HL.FileComparer
{
    public partial class MainForm : Form
    {                      
        private Dictionary<string, List<FileHashPair>> possibleMatches;        
        private BackgroundWorker worker;
        private SearchPattern selectedPattern;
        private bool workerWasCancelled;

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

            foreach (var pattern in Settings.SearchPatterns)
            {
                cmbFileTypes.Items.Add(pattern.Description + " " + pattern.Pattern);
            }

            cmbFileTypes.SelectedIndex = 0;
        }        

        private string Path1
        {
            get
            {
                return tbFolderPath1.Text.Trim();
            }
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

            tbResultCount.Text = compareResultsControl.MatchCount.ToString("D");
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

            string paths = tbFolderPath1.Text.Trim() + ";" + tbFolderPath2.Text.Trim();

            if (paths.EndsWith(";"))
            {
                paths = paths.Substring(0, paths.Length - 1);
            }

            possibleMatches = CompareUtils.GetAllPossibleFileMatches(paths, selectedPattern.Pattern, worker);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
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
        }

        private void CheckEnabled(object sender, EventArgs e)
        {
            btnStart.Enabled = Path1 != "";
        }

        private void btnSelectFolder1_Click(object sender, EventArgs e)
        {
            if (Path1 != "")
            {
                fdbBrowseFolder.SelectedPath = Path1;
            }

            if (fdbBrowseFolder.ShowDialog() == DialogResult.OK)
            {
                tbFolderPath1.Text = fdbBrowseFolder.SelectedPath;
            }
        }


        private void cmbFileTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPattern = Settings.SearchPatterns[cmbFileTypes.SelectedIndex];
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

    }
}