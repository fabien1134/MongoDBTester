namespace MongoDBTester
{
    partial class frmCollegeMemberManager
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.ssStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tspbExecutionState = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDisplayCollegeMembers = new System.Windows.Forms.Button();
            this.btnInitialiseMongoDB = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.ssStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnInitialiseMongoDB);
            this.pnlFooter.Controls.Add(this.btnDisplayCollegeMembers);
            this.pnlFooter.Controls.Add(this.ssStatusStrip);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 350);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 100);
            this.pnlFooter.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.dgvResult);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(800, 350);
            this.pnlBody.TabIndex = 1;
            // 
            // ssStatusStrip
            // 
            this.ssStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbExecutionState,
            this.tsslStatus});
            this.ssStatusStrip.Location = new System.Drawing.Point(0, 78);
            this.ssStatusStrip.Name = "ssStatusStrip";
            this.ssStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.ssStatusStrip.TabIndex = 0;
            // 
            // tspbExecutionState
            // 
            this.tspbExecutionState.Name = "tspbExecutionState";
            this.tspbExecutionState.Size = new System.Drawing.Size(100, 16);
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // btnDisplayCollegeMembers
            // 
            this.btnDisplayCollegeMembers.Location = new System.Drawing.Point(228, 19);
            this.btnDisplayCollegeMembers.Name = "btnDisplayCollegeMembers";
            this.btnDisplayCollegeMembers.Size = new System.Drawing.Size(136, 46);
            this.btnDisplayCollegeMembers.TabIndex = 1;
            this.btnDisplayCollegeMembers.Text = "Display College Members";
            this.btnDisplayCollegeMembers.UseVisualStyleBackColor = true;
            this.btnDisplayCollegeMembers.Click += new System.EventHandler(this.btnDisplayCollegeMembers_Click);
            // 
            // btnInitialiseMongoDB
            // 
            this.btnInitialiseMongoDB.Location = new System.Drawing.Point(370, 19);
            this.btnInitialiseMongoDB.Name = "btnInitialiseMongoDB";
            this.btnInitialiseMongoDB.Size = new System.Drawing.Size(136, 46);
            this.btnInitialiseMongoDB.TabIndex = 2;
            this.btnInitialiseMongoDB.Text = "Initialise MongoDB";
            this.btnInitialiseMongoDB.UseVisualStyleBackColor = true;
            this.btnInitialiseMongoDB.Click += new System.EventHandler(this.btnInitialiseMongoDB_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.Size = new System.Drawing.Size(800, 350);
            this.dgvResult.TabIndex = 0;
            // 
            // frmCollegeMemberManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Name = "frmCollegeMemberManager";
            this.Text = "College Member Manager";
            this.Load += new System.EventHandler(this.frmCollegeMemberManager_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ssStatusStrip.ResumeLayout(false);
            this.ssStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnInitialiseMongoDB;
        private System.Windows.Forms.Button btnDisplayCollegeMembers;
        private System.Windows.Forms.StatusStrip ssStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar tspbExecutionState;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgvResult;
    }
}

