using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HL.FileComparer.Utilities;

namespace FileCompareTester
{
    public partial class TestForm : Form
    {      
        private bool comparingSingleFolder;

        public TestForm()
        {
            InitializeComponent();

            CompareUtils.HashProgressUpdate += CompareUtils_HashProgressUpdate;
        }


        void CompareUtils_HashProgressUpdate(int filesHashed, int totalNumberOfFiles)
        {
            progressBar1.Value = (filesHashed / totalNumberOfFiles) * 100;
        }

        private string Pattern
        {
            get
            {
                return tbPattern.Text;
            }
        }

        private void CheckEnabled(object sender, EventArgs args)
        {
            
        }

        private void ShowMatchReport(List<PossibleMatches> possibleMatches)
        {
            string matchReport = "";
       
            for (int i = 0 ; i < possibleMatches.Count; i++)
            {
                matchReport += "File match " + i + "\n";

                foreach (FileHashPair pair in possibleMatches[i].Files)
                {
                    matchReport += "\t" + pair.FileName + "\n";
                }

                matchReport += "\n\n";
            }

            MessageBox.Show(matchReport);
        }

        private void btnFindDuplicates_Click(object sender, EventArgs e)
        {
            comparingSingleFolder = true;
            backgroundWorker1.RunWorkerAsync();
        }        

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSelectFolder1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbFolder1.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSelectFolder2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbFolder2.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnFindTwoFolderDuplicates_Click(object sender, EventArgs e)
        {
            comparingSingleFolder = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (comparingSingleFolder)
            {
                List<PossibleMatches> allPossibleFileMatches = CompareUtils.GetAllPossibleFileMatches(tbFolder.Text, tbPattern.Text);
                ShowMatchReport(allPossibleFileMatches);
            }
            else
            {
                List<PossibleMatches> allPossibleFileMatches = CompareUtils.CompareFolders(tbFolder1.Text, tbFolder2.Text, Pattern);
                ShowMatchReport(allPossibleFileMatches);
            }
        }
    }
}
