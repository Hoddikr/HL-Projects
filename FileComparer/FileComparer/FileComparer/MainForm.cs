using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileComparer.Dialogs;
using HoddiLara.FileCompareUtilities;

namespace FileComparer
{
    public partial class MainForm : Form
    {
        //C:\Users\hordur\Pictures
        //C:\Users\hordur\Pictures\Rússland\2011-08-30

        private string path1 = "";
        private string path2 = "";
        private SearchPattern currentPattern;                
        private List<PossibleMatches> possibleMatches;        
        private BackgroundWorker worker;

        public MainForm()
        {
            InitializeComponent();
            
            possibleMatches = new List<PossibleMatches>();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbFilesProcessed.Value = 100;            

            string report = "";

            foreach (PossibleMatches possibleMatch in possibleMatches)
            {
                foreach (FileHashPair pair in possibleMatch.Files)
                {
                    report += pair.FileName + " ";
                }
                report += "\r\n\r\n";
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
            possibleMatches = CompareUtils.CompareFolders(path1, path2, currentPattern.Pattern, worker);
        }    

        private void NewSearch()
        {
            var dlg = new NewCompareDialog();

            dlg.ShowDialog(this);

            path1 = dlg.FolderPath1;
            path2 = dlg.FolderPath2;
            currentPattern = dlg.SelectedPattern;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            NewSearch();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            worker.RunWorkerAsync();
        }        
    }
}