namespace klh170130Asg4
{
    partial class TextSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.tspMainProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tssMainLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblSearchKey = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lsvResults = new System.Windows.Forms.ListView();
            this.clhLineNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bgwSearch = new System.ComponentModel.BackgroundWorker();
            this.erpSearch = new System.Windows.Forms.ErrorProvider(this.components);
            this.stsMain.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.CausesValidation = false;
            this.txtFilePath.Location = new System.Drawing.Point(85, 6);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(766, 21);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.Text = "(Select input file - a text file, *.txt )";
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            this.txtFilePath.Enter += new System.EventHandler(this.txtFilePath_Enter);
            this.txtFilePath.Leave += new System.EventHandler(this.txtFilePath_Leave);
            this.txtFilePath.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtFilePath_MouseDown);
            this.txtFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilePath_Validating);
            this.txtFilePath.Validated += new System.EventHandler(this.txtFilePath_Validated);
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchKey.CausesValidation = false;
            this.txtSearchKey.Location = new System.Drawing.Point(85, 36);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(766, 21);
            this.txtSearchKey.TabIndex = 2;
            this.txtSearchKey.Text = "(Enter search term)";
            this.txtSearchKey.Enter += new System.EventHandler(this.txtSearchKey_Enter);
            
            this.txtSearchKey.Leave += new System.EventHandler(this.txtSearchKey_Leave);
            this.txtSearchKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSearchKey_MouseDown);
            this.txtSearchKey.Validating += new System.ComponentModel.CancelEventHandler(this.txtSearchKey_Validating);
            this.txtSearchKey.Validated += new System.EventHandler(this.txtSearchKey_Validated);
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspMainProgress,
            this.tssMainLabel});
            this.stsMain.Location = new System.Drawing.Point(0, 659);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(944, 22);
            this.stsMain.TabIndex = 3;
            this.stsMain.Text = "stsMain";
            // 
            // tspMainProgress
            // 
            this.tspMainProgress.Name = "tspMainProgress";
            this.tspMainProgress.Size = new System.Drawing.Size(100, 16);
            this.tspMainProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // tssMainLabel
            // 
            this.tssMainLabel.Name = "tssMainLabel";
            this.tssMainLabel.Size = new System.Drawing.Size(827, 17);
            this.tssMainLabel.Spring = true;
            this.tssMainLabel.Text = "Status: Ready";
            this.tssMainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlControl
            // 
            this.pnlControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlControl.Controls.Add(this.btnSearch);
            this.pnlControl.Controls.Add(this.btnBrowse);
            this.pnlControl.Controls.Add(this.lblSearchKey);
            this.pnlControl.Controls.Add(this.lblFileName);
            this.pnlControl.Controls.Add(this.txtFilePath);
            this.pnlControl.Controls.Add(this.txtSearchKey);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(944, 69);
            this.pnlControl.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(857, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.CausesValidation = false;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(857, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblSearchKey
            // 
            this.lblSearchKey.AutoSize = true;
            this.lblSearchKey.Location = new System.Drawing.Point(12, 39);
            this.lblSearchKey.Name = "lblSearchKey";
            this.lblSearchKey.Size = new System.Drawing.Size(66, 15);
            this.lblSearchKey.TabIndex = 4;
            this.lblSearchKey.Text = "Search for:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(67, 15);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "File Name:";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lsvResults);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 69);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(944, 590);
            this.pnlMain.TabIndex = 5;
            // 
            // lsvResults
            // 
            this.lsvResults.CausesValidation = false;
            this.lsvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhLineNo,
            this.clhText});
            this.lsvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvResults.Location = new System.Drawing.Point(0, 0);
            this.lsvResults.Name = "lsvResults";
            this.lsvResults.Size = new System.Drawing.Size(944, 590);
            this.lsvResults.TabIndex = 4;
            this.lsvResults.UseCompatibleStateImageBehavior = false;
            this.lsvResults.View = System.Windows.Forms.View.Details;
            // 
            // clhLineNo
            // 
            this.clhLineNo.Text = "Line No.";
            // 
            // clhText
            // 
            this.clhText.Text = "Text";
            this.clhText.Width = 874;
            // 
            // bgwSearch
            // 
            this.bgwSearch.WorkerReportsProgress = true;
            this.bgwSearch.WorkerSupportsCancellation = true;
            // 
            // erpSearch
            // 
            this.erpSearch.ContainerControl = this;
            // 
            // TextSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(944, 681);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.stsMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TextSearch";
            this.Text = "Text Search";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TextSearch_Load);
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel tssMainLabel;
        private System.Windows.Forms.ToolStripProgressBar tspMainProgress;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Label lblSearchKey;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListView lsvResults;
        private System.Windows.Forms.ColumnHeader clhLineNo;
        private System.Windows.Forms.ColumnHeader clhText;
        private System.ComponentModel.BackgroundWorker bgwSearch;
        private System.Windows.Forms.ErrorProvider erpSearch;
    }
}

