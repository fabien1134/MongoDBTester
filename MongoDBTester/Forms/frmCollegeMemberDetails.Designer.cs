namespace MongoDBTester.Forms
{
    partial class frmCollegeMemberDetails
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ssStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tspbExecutionState = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvCollegeMember = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCollegeMemberGridviewLabel = new System.Windows.Forms.Label();
            this.dgvQualifications = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblQualificationsLabel = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.ssStatusStrip.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollegeMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQualifications)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnUpdate);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Controls.Add(this.ssStatusStrip);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 350);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 100);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(300, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(159, 40);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(343, 52);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.ssStatusStrip.Text = "statusStrip1";
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
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.dgvCollegeMember);
            this.pnlBody.Controls.Add(this.lblCollegeMemberGridviewLabel);
            this.pnlBody.Controls.Add(this.dgvQualifications);
            this.pnlBody.Controls.Add(this.lblQualificationsLabel);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(800, 350);
            this.pnlBody.TabIndex = 1;
            // 
            // dgvCollegeMember
            // 
            this.dgvCollegeMember.AllowUserToAddRows = false;
            this.dgvCollegeMember.AllowUserToDeleteRows = false;
            this.dgvCollegeMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollegeMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colMemberName,
            this.colAge,
            this.colType});
            this.dgvCollegeMember.Location = new System.Drawing.Point(12, 37);
            this.dgvCollegeMember.Name = "dgvCollegeMember";
            this.dgvCollegeMember.Size = new System.Drawing.Size(776, 42);
            this.dgvCollegeMember.TabIndex = 3;
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colMemberName
            // 
            this.colMemberName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemberName.HeaderText = "Name";
            this.colMemberName.Name = "colMemberName";
            // 
            // colAge
            // 
            this.colAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAge.HeaderText = "Age";
            this.colAge.Name = "colAge";
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            // 
            // lblCollegeMemberGridviewLabel
            // 
            this.lblCollegeMemberGridviewLabel.AutoSize = true;
            this.lblCollegeMemberGridviewLabel.Location = new System.Drawing.Point(348, 21);
            this.lblCollegeMemberGridviewLabel.Name = "lblCollegeMemberGridviewLabel";
            this.lblCollegeMemberGridviewLabel.Size = new System.Drawing.Size(80, 13);
            this.lblCollegeMemberGridviewLabel.TabIndex = 2;
            this.lblCollegeMemberGridviewLabel.Text = "CollegeMember";
            // 
            // dgvQualifications
            // 
            this.dgvQualifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQualifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colGrade});
            this.dgvQualifications.Location = new System.Drawing.Point(12, 137);
            this.dgvQualifications.Name = "dgvQualifications";
            this.dgvQualifications.Size = new System.Drawing.Size(776, 196);
            this.dgvQualifications.TabIndex = 1;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colGrade
            // 
            this.colGrade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGrade.HeaderText = "Grade";
            this.colGrade.Name = "colGrade";
            // 
            // lblQualificationsLabel
            // 
            this.lblQualificationsLabel.AutoSize = true;
            this.lblQualificationsLabel.Location = new System.Drawing.Point(348, 121);
            this.lblQualificationsLabel.Name = "lblQualificationsLabel";
            this.lblQualificationsLabel.Size = new System.Drawing.Size(70, 13);
            this.lblQualificationsLabel.TabIndex = 0;
            this.lblQualificationsLabel.Text = "Qualifications";
            // 
            // frmCollegeMemberDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Name = "frmCollegeMemberDetails";
            this.Text = "frmCollegeMemberDetails";
            this.Load += new System.EventHandler(this.frmCollegeMemberDetails_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ssStatusStrip.ResumeLayout(false);
            this.ssStatusStrip.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollegeMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQualifications)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.StatusStrip ssStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar tspbExecutionState;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblQualificationsLabel;
        private System.Windows.Forms.DataGridView dgvQualifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrade;
        private System.Windows.Forms.DataGridView dgvCollegeMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.Label lblCollegeMemberGridviewLabel;
    }
}