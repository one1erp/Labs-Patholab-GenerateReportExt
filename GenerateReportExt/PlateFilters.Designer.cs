namespace GenerateReportExt
{
    partial class PlateFiltersFrm
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
            this.dTPickerCompletedOn = new System.Windows.Forms.DateTimePicker();
            this.dTPickerAuthorisedOn = new System.Windows.Forms.DateTimePicker();
            this.cmbLab = new System.Windows.Forms.ComboBox();
            this.txtPlateName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listBoxAuthorisedBy = new System.Windows.Forms.ListBox();
            this.listBoxTests = new System.Windows.Forms.ListBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.listViewPlates = new System.Windows.Forms.ListView();
            this.checkBoxLab = new System.Windows.Forms.CheckBox();
            this.checkBoxPlateName = new System.Windows.Forms.CheckBox();
            this.checkBoxTests = new System.Windows.Forms.CheckBox();
            this.checkBoxCompletedOn = new System.Windows.Forms.CheckBox();
            this.checkBoxAuthorisedOn = new System.Windows.Forms.CheckBox();
            this.checkBoxAuthorisedBy = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dTPickerCompletedOn
            // 
            this.dTPickerCompletedOn.Enabled = false;
            this.dTPickerCompletedOn.Location = new System.Drawing.Point(400, 35);
            this.dTPickerCompletedOn.Name = "dTPickerCompletedOn";
            this.dTPickerCompletedOn.Size = new System.Drawing.Size(180, 20);
            this.dTPickerCompletedOn.TabIndex = 0;
            this.dTPickerCompletedOn.ValueChanged += new System.EventHandler(this.dTPickerCompletedOn_ValueChanged);
            // 
            // dTPickerAuthorisedOn
            // 
            this.dTPickerAuthorisedOn.Enabled = false;
            this.dTPickerAuthorisedOn.Location = new System.Drawing.Point(400, 69);
            this.dTPickerAuthorisedOn.Name = "dTPickerAuthorisedOn";
            this.dTPickerAuthorisedOn.Size = new System.Drawing.Size(180, 20);
            this.dTPickerAuthorisedOn.TabIndex = 1;
            this.dTPickerAuthorisedOn.ValueChanged += new System.EventHandler(this.dTPickerAuthorisedOn_ValueChanged);
            // 
            // cmbLab
            // 
            this.cmbLab.Enabled = false;
            this.cmbLab.Location = new System.Drawing.Point(24, 36);
            this.cmbLab.Name = "cmbLab";
            this.cmbLab.Size = new System.Drawing.Size(193, 21);
            this.cmbLab.TabIndex = 4;
            this.cmbLab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLab_MouseClick);
            // 
            // txtPlateName
            // 
            this.txtPlateName.Enabled = false;
            this.txtPlateName.Location = new System.Drawing.Point(24, 70);
            this.txtPlateName.Name = "txtPlateName";
            this.txtPlateName.Size = new System.Drawing.Size(193, 20);
            this.txtPlateName.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSearch.Location = new System.Drawing.Point(499, 428);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 21);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "חפש";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listBoxAuthorisedBy
            // 
            this.listBoxAuthorisedBy.Enabled = false;
            this.listBoxAuthorisedBy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBoxAuthorisedBy.FormattingEnabled = true;
            this.listBoxAuthorisedBy.ItemHeight = 15;
            this.listBoxAuthorisedBy.Location = new System.Drawing.Point(401, 103);
            this.listBoxAuthorisedBy.Name = "listBoxAuthorisedBy";
            this.listBoxAuthorisedBy.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAuthorisedBy.Size = new System.Drawing.Size(179, 64);
            this.listBoxAuthorisedBy.TabIndex = 8;
            // 
            // listBoxTests
            // 
            this.listBoxTests.Enabled = false;
            this.listBoxTests.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBoxTests.FormattingEnabled = true;
            this.listBoxTests.ItemHeight = 15;
            this.listBoxTests.Location = new System.Drawing.Point(24, 103);
            this.listBoxTests.Name = "listBoxTests";
            this.listBoxTests.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxTests.Size = new System.Drawing.Size(193, 64);
            this.listBoxTests.TabIndex = 14;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Enabled = false;
            this.btnGenerateReport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnGenerateReport.Location = new System.Drawing.Point(368, 428);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(91, 21);
            this.btnGenerateReport.TabIndex = 15;
            this.btnGenerateReport.Text = "הפעל דוח";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // listViewPlates
            // 
            this.listViewPlates.FullRowSelect = true;
            this.listViewPlates.HideSelection = false;
            this.listViewPlates.Location = new System.Drawing.Point(24, 185);
            this.listViewPlates.MultiSelect = false;
            this.listViewPlates.Name = "listViewPlates";
            this.listViewPlates.Size = new System.Drawing.Size(716, 231);
            this.listViewPlates.TabIndex = 16;
            this.listViewPlates.UseCompatibleStateImageBehavior = false;
            this.listViewPlates.View = System.Windows.Forms.View.Details;
            this.listViewPlates.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewPlates_ColumnClick);
            // 
            // checkBoxLab
            // 
            this.checkBoxLab.AutoSize = true;
            this.checkBoxLab.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxLab.Location = new System.Drawing.Point(277, 31);
            this.checkBoxLab.Name = "checkBoxLab";
            this.checkBoxLab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxLab.Size = new System.Drawing.Size(74, 22);
            this.checkBoxLab.TabIndex = 17;
            this.checkBoxLab.Text = "מעבדה:";
            this.checkBoxLab.UseVisualStyleBackColor = true;
            this.checkBoxLab.CheckedChanged += new System.EventHandler(this.checkBoxLab_CheckedChanged);
            // 
            // checkBoxPlateName
            // 
            this.checkBoxPlateName.AutoSize = true;
            this.checkBoxPlateName.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxPlateName.Location = new System.Drawing.Point(223, 68);
            this.checkBoxPlateName.Name = "checkBoxPlateName";
            this.checkBoxPlateName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxPlateName.Size = new System.Drawing.Size(128, 22);
            this.checkBoxPlateName.TabIndex = 18;
            this.checkBoxPlateName.Text = " שם\\חלק מהשם:";
            this.checkBoxPlateName.UseVisualStyleBackColor = true;
            this.checkBoxPlateName.CheckedChanged += new System.EventHandler(this.checkBoxPlateName_CheckedChanged);
            // 
            // checkBoxTests
            // 
            this.checkBoxTests.AutoSize = true;
            this.checkBoxTests.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxTests.Location = new System.Drawing.Point(276, 103);
            this.checkBoxTests.Name = "checkBoxTests";
            this.checkBoxTests.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxTests.Size = new System.Drawing.Size(75, 22);
            this.checkBoxTests.TabIndex = 19;
            this.checkBoxTests.Text = "בדיקות:";
            this.checkBoxTests.UseVisualStyleBackColor = true;
            this.checkBoxTests.CheckedChanged += new System.EventHandler(this.checkBoxTests_CheckedChanged);
            // 
            // checkBoxCompletedOn
            // 
            this.checkBoxCompletedOn.AutoSize = true;
            this.checkBoxCompletedOn.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxCompletedOn.Location = new System.Drawing.Point(618, 31);
            this.checkBoxCompletedOn.Name = "checkBoxCompletedOn";
            this.checkBoxCompletedOn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxCompletedOn.Size = new System.Drawing.Size(124, 22);
            this.checkBoxCompletedOn.TabIndex = 20;
            this.checkBoxCompletedOn.Text = "נבדקה בתאריך:";
            this.checkBoxCompletedOn.UseVisualStyleBackColor = true;
            this.checkBoxCompletedOn.CheckedChanged += new System.EventHandler(this.checkBoxCompletedOn_CheckedChanged);
            // 
            // checkBoxAuthorisedOn
            // 
            this.checkBoxAuthorisedOn.AutoSize = true;
            this.checkBoxAuthorisedOn.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxAuthorisedOn.Location = new System.Drawing.Point(617, 67);
            this.checkBoxAuthorisedOn.Name = "checkBoxAuthorisedOn";
            this.checkBoxAuthorisedOn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxAuthorisedOn.Size = new System.Drawing.Size(125, 22);
            this.checkBoxAuthorisedOn.TabIndex = 21;
            this.checkBoxAuthorisedOn.Text = "אושרה בתאריך:";
            this.checkBoxAuthorisedOn.UseVisualStyleBackColor = true;
            this.checkBoxAuthorisedOn.CheckedChanged += new System.EventHandler(this.checkBoxAuthorisedOn_CheckedChanged);
            // 
            // checkBoxAuthorisedBy
            // 
            this.checkBoxAuthorisedBy.AutoSize = true;
            this.checkBoxAuthorisedBy.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxAuthorisedBy.Location = new System.Drawing.Point(630, 102);
            this.checkBoxAuthorisedBy.Name = "checkBoxAuthorisedBy";
            this.checkBoxAuthorisedBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxAuthorisedBy.Size = new System.Drawing.Size(112, 22);
            this.checkBoxAuthorisedBy.TabIndex = 22;
            this.checkBoxAuthorisedBy.Text = "אושרה על ידי:";
            this.checkBoxAuthorisedBy.UseVisualStyleBackColor = true;
            this.checkBoxAuthorisedBy.CheckedChanged += new System.EventHandler(this.checkBoxAuthorisedBy_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancel.Location = new System.Drawing.Point(258, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 21);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "בטל";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnRefresh.Location = new System.Drawing.Point(149, 428);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(73, 21);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.Text = "חזור";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // PlateFiltersFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 457);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.checkBoxAuthorisedBy);
            this.Controls.Add(this.checkBoxAuthorisedOn);
            this.Controls.Add(this.checkBoxCompletedOn);
            this.Controls.Add(this.checkBoxTests);
            this.Controls.Add(this.checkBoxPlateName);
            this.Controls.Add(this.checkBoxLab);
            this.Controls.Add(this.listViewPlates);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.listBoxTests);
            this.Controls.Add(this.listBoxAuthorisedBy);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPlateName);
            this.Controls.Add(this.cmbLab);
            this.Controls.Add(this.dTPickerAuthorisedOn);
            this.Controls.Add(this.dTPickerCompletedOn);
            this.Name = "PlateFiltersFrm";
            this.Text = "חיפוש פלטות";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dTPickerCompletedOn;
        private System.Windows.Forms.DateTimePicker dTPickerAuthorisedOn;
        private System.Windows.Forms.ComboBox cmbLab;
        private System.Windows.Forms.TextBox txtPlateName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox listBoxAuthorisedBy;
        private System.Windows.Forms.ListBox listBoxTests;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ListView listViewPlates;
        private System.Windows.Forms.CheckBox checkBoxLab;
        private System.Windows.Forms.CheckBox checkBoxPlateName;
        private System.Windows.Forms.CheckBox checkBoxTests;
        private System.Windows.Forms.CheckBox checkBoxCompletedOn;
        private System.Windows.Forms.CheckBox checkBoxAuthorisedOn;
        private System.Windows.Forms.CheckBox checkBoxAuthorisedBy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
    }
}