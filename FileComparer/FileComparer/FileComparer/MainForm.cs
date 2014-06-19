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

        private string Path2
        {
            get
            {
                return tbFolderPath2.Text.Trim();
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

            string report = "";

            if (possibleMatches.Count == 0)
            {
                report = "Nothing found";
                lblProgress.Text = "";
            }
            else
            {
                foreach (KeyValuePair<string, List<FileHashPair>> possibleMatch in possibleMatches)
                {
                    foreach (FileHashPair pair in possibleMatch.Value)
                    {
                        report += pair.FileName + " ";
                    }
                    report += "\r\n\r\n";
                }
            }
            
            richTextBox1.Text = report;
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

            if (Path2 != "")
            {
                possibleMatches = CompareUtils.CompareFolders(Path1, Path2, selectedPattern.Pattern, worker);
            }
            else
            {
                possibleMatches = CompareUtils.GetAllPossibleFileMatches(Path1, selectedPattern.Pattern, worker);
            }            
        }    

        private void btnStart_Click(object sender, EventArgs e)
        {
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
            btnStart.Enabled = Path1 != "" ||
                            (Path1 != "" && Path2 != "");
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

        private void btnSelectFolder2_Click(object sender, EventArgs e)
        {
            if (Path2 != "")
            {
                fdbBrowseFolder.SelectedPath = Path2;
            }

            if (fdbBrowseFolder.ShowDialog() == DialogResult.OK)
            {
                tbFolderPath2.Text = fdbBrowseFolder.SelectedPath;
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
    }
}