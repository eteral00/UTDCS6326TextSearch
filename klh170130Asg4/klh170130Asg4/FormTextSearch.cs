/*
 * Written by Khoa L. D. Ho (klh170130) 
 * for Assignment 4 for class CS6326 Falll 2019, by Professor J. Cole, at UT Dallas,
 * starting Oct 13, 2019, using Visual Studio 2017 on OS Windows 8.1
 * 
 * Text Search Program
 * This program is used to search text from a user-specified input file.
 * 
 * Fist, the user will select an input file, which should be a text file. 
 * Then, the user will enter the search key, i.e text to be searched, and click Search Button
 * The program will search the text from file using another thread (background worker) and keep displaying the results and progress on UI screen
 *
 * 
 * This is the Form module, which contains handlers for the UI (Wins Form)
 * 
 */



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace klh170130Asg4
{
    public partial class TextSearch : Form
    {
        AppLogics thisAppLogics;
        TechServices thisTechServices;
        bool boolSearching;
        bool loadFileSuccess;
        DateTime startSearch;

        static string statusLabel = "Status";
        static string errorLabel = "Error";
        static string noFileMsg = "Error: No input file selected. Please select an input file, i.e. a text file (*.txt). ";
        static string errorFileMsg = "Error: Please verify that the following input file exists and is in the correct format, i.e. a text file (*.txt): ";
        static string noKeyMsg = "Error: No search term provided. Please enter a term to search.";
        static string successLabel = "Success";
        static string successMsg = "The program has finished searching.";
        static string resultMsg = "The number of results found: ";
        static string cancelLabel = "Cancelled";
        static string cancelMsg = "The search was cancelled before completion.";
        static string percentMsg = "% completed.";
        static string opCompTimeMsg = "The Search lasted ";


        public TextSearch()
        {
            InitializeComponent();
            this.thisAppLogics = new AppLogics();
            this.thisTechServices = new TechServices();
        }

        /* Handler for main form load
         */
        private void TextSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            this.boolSearching = false;
            
        }

        /* Handler for Browse button click
         * open a dialog for user to select input file, filter = text files/ *.txt
         */
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            OpenFileDialog ofdFile = new OpenFileDialog();
            ofdFile.Multiselect = false;
            ofdFile.Filter = "Text Files|*.txt";
            ofdFile.InitialDirectory = Application.StartupPath;
            DialogResult drFile = ofdFile.ShowDialog();

            if (drFile == DialogResult.OK)
            {
                filePath = ofdFile.FileName;
                this.txtFilePath.Text = filePath;

                this.txtSearchKey.Focus();
            }

        }

        /* Handler for Search button click
         */
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            // if not searching, start searching
            if (!boolSearching)
            {
                // clear the list view first, before starting
                lsvResults.Items.Clear();

                /* validating the input
                 */
                if (this.txtFilePath.Text.Trim() == string.Empty)
                {
                    string errMsg = noFileMsg;
                    this.txtFilePath.SelectAll();
                    this.erpSearch.SetError(this.txtFilePath, errMsg);
                    this.tssMainLabel.Text = errMsg;
                    return;
                }
                
                this.erpSearch.SetError(this.txtFilePath, string.Empty);
                
                if (this.txtSearchKey.Text.Trim() == string.Empty)
                {
                    
                    string errMsg = noKeyMsg;
                    this.txtSearchKey.SelectAll();
                    this.erpSearch.SetError(this.txtSearchKey, errMsg);
                    this.tssMainLabel.Text = errMsg;
                    return;
                }
                
                this.erpSearch.SetError(this.txtSearchKey, string.Empty);
                
                
                //load file
                this.loadFileSuccess = this.thisTechServices.loadFile(txtFilePath.Text);
                if (this.loadFileSuccess)
                // only search if load file was successful
                {
                    this.erpSearch.SetError(this.txtFilePath, string.Empty);

                    this.thisAppLogics.resetSearcher(); // reset the applogics control variable

                    // set up the handlers for bgwSearch
                    this.bgwSearch.DoWork += bgwSearch_DoWork;
                    this.bgwSearch.ProgressChanged += bgwSearch_ProgressChanged;
                    this.bgwSearch.RunWorkerCompleted += bgwSearch_RunWorkerCompleted;
                    this.bgwSearch.WorkerReportsProgress = true;

                    // modify the UI to reflect state changes:
                    this.txtFilePath.Enabled = false;
                    this.btnBrowse.Enabled = false;
                    this.txtSearchKey.Enabled = false;
                    this.btnSearch.Text = "Cancel";


                    // actually start running the bg worker()
                    this.boolSearching = true;
                    this.startSearch = DateTime.Now; // timing
                    this.bgwSearch.RunWorkerAsync(this.thisAppLogics);
                }
                else
                {
                    // unable to load file, report error
                    string errMsg = errorFileMsg + " " + txtFilePath.Text;
                    this.txtFilePath.SelectAll();
                    this.erpSearch.SetError(this.txtFilePath, errMsg);
                    this.tssMainLabel.Text = errMsg;

                    return;
                }

            }
            else // is already searching, then try cancelling
            {
                if (bgwSearch.IsBusy)
                {
                    this.bgwSearch.CancelAsync();
                }
            }
            
        }




        /* Handlers for background worker(s)
         */

        /* DoWork handler for bgwSearch
         */
        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {            
            bool boolFinished = false;
            

            while ( (!boolFinished) )
            {
                boolFinished = this.thisAppLogics.searchLine(this.thisTechServices, this.txtSearchKey.Text);

                double dbProgress = ((double)this.thisAppLogics.cumReadLength / (double)this.thisTechServices.fileLength)*100;
                int intProgress = Convert.ToInt32(Math.Round(dbProgress));
                this.bgwSearch.ReportProgress(intProgress,this.thisAppLogics);

                if (this.bgwSearch.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Thread.Sleep(1); // pause 1 milisecond as required

                //e.Result = this.thisAppLogics; // assign results, kind of unecessary in this case, though
            }
            

        }

        /* ProgressChanged handler for bgwSearch
         */
        private void bgwSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tspMainProgress.Value = e.ProgressPercentage;
            
            while (this.thisAppLogics.resultQueue.Count != 0 )
            // dequeue items in result queue and display on list view
            {
                Tuple<int, string> matchTup = this.thisAppLogics.resultQueue.Dequeue();
                ListViewItem lviResult = new ListViewItem(matchTup.Item1.ToString());
                lviResult.SubItems.Add(matchTup.Item2.ToString());

                this.lsvResults.Items.Add(lviResult);
                tssMainLabel.Text = statusLabel + ": " + this.tspMainProgress.Value.ToString() + percentMsg + resultMsg + this.thisAppLogics.matchCount.ToString();
            }
            
        }

        /* Completion handler for bgwSearch
         * modify the UI to reflect changes
         */
        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimeSpan searchDuration = DateTime.Now - this.startSearch;
            string strSearchDuration;
            if (searchDuration.TotalSeconds >= 60.0)
            {
                strSearchDuration = Math.Round(searchDuration.TotalMinutes,2).ToString() + " minutes.";
            }
            else
            {
                strSearchDuration = Math.Round(searchDuration.TotalSeconds,3).ToString() + " seconds.";
            }
             
            // close file
            this.thisTechServices.closeFile();
            
            // change status bar/strip
            if (e.Cancelled) 
            // if the operation was cancelled before it could finish
            {
                tssMainLabel.Text = statusLabel + ": " + cancelMsg + " " + resultMsg + this.thisAppLogics.matchCount.ToString() + ". " + opCompTimeMsg + strSearchDuration;
            }
            else
            // else, the operation was not cancelled, or it finished before it could be cancelled
            {
                tssMainLabel.Text = statusLabel + ": " + successLabel + ". " + successMsg + " " + resultMsg + this.thisAppLogics.matchCount.ToString() + ". " + opCompTimeMsg + strSearchDuration;
                
            }

            
            // update progress
            this.tspMainProgress.Value = 100;


            // change status flag
            this.boolSearching = false;

            // change textboxes and buttons
            this.txtFilePath.Enabled = true;
            this.btnBrowse.Enabled = true;
            this.txtSearchKey.Enabled = true;
            this.btnSearch.Text = "Search";


        }




        /* Validating input fields
        * May be redundant
        */
        private void txtFilePath_Validating(object sender, CancelEventArgs e)
        {
            
            if (this.txtFilePath.Text.Trim() == string.Empty)
            {
                string errMsg = noFileMsg;
                e.Cancel = true;
                this.txtFilePath.SelectAll();
                this.erpSearch.SetError(this.txtFilePath, errMsg);
            }
        }

        private void txtFilePath_Validated(object sender, EventArgs e)
        {
            this.erpSearch.SetError(this.txtFilePath, string.Empty);
        }

        private void txtSearchKey_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtSearchKey.Text.Trim() == string.Empty)
            {
                string errMsg = noKeyMsg;
                e.Cancel = true;
                this.txtSearchKey.SelectAll();
                this.erpSearch.SetError(this.txtSearchKey, errMsg);
            }
        }

        private void txtSearchKey_Validated(object sender, EventArgs e)
        {
            this.erpSearch.SetError(this.txtSearchKey, string.Empty);
        }

        /* handler for file path text changed
         * clear the erpSearch
         */
        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            this.erpSearch.SetError(this.txtFilePath, string.Empty);
        }

        /* Misc handlers for housekeeping and convenience
         * 
         */

        private void txtSearchKey_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.txtSearchKey.Text.CompareTo("(Enter search term)") == 0 )
            {
                this.txtSearchKey.Clear();
            }
            
        }
        private void txtSearchKey_Enter(object sender, EventArgs e)
        {
            if (this.txtSearchKey.Text.CompareTo("(Enter search term)") == 0)
            {
                this.txtSearchKey.Clear();
            }
        }

        private void txtSearchKey_Leave(object sender, EventArgs e)
        {
            if (this.txtSearchKey.Text.Trim() == string.Empty)
            {
                this.txtSearchKey.Text = "(Enter search term)";
            }
        }

        private void txtFilePath_MouseDown(object sender, MouseEventArgs e)
        {
            if(this.txtFilePath.Text.CompareTo("(Select input file - a text file, *.txt )") == 0)
            {
                this.txtFilePath.Clear();
            }
        }

        private void txtFilePath_Enter(object sender, EventArgs e)
        {
            if (this.txtFilePath.Text.CompareTo("(Select input file - a text file, *.txt )") == 0)
            {
                this.txtFilePath.Clear();
            }
        }


        private void txtFilePath_Leave(object sender, EventArgs e)
        {
            if (this.txtFilePath.Text.Trim() == string.Empty)
            {
                this.txtFilePath.Text = "(Select input file - a text file, *.txt )";
            }
        }

        private void txtSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            // enter key was pressed
            {
                this.btnSearch.Focus();
            }
        }
    }
}
