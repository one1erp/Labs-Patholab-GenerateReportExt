namespace GenerateReportExt
{
    partial class SampleFiltersFrm
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
            this.listViewSamples = new System.Windows.Forms.ListView();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dTPickerCompletedOn = new System.Windows.Forms.DateTimePicker();
            this.dTPickerCreatedOn = new System.Windows.Forms.DateTimePicker();
            this.txtSampleName = new System.Windows.Forms.TextBox();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.radioButtonStandart = new System.Windows.Forms.RadioButton();
            this.radioButtonPositive = new System.Windows.Forms.RadioButton();
            this.checkBoxCreatedOn = new System.Windows.Forms.CheckBox();
            this.checkBoxCompletedOn = new System.Windows.Forms.CheckBox();
            this.checkBoxSampleName = new System.Windows.Forms.CheckBox();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewSamples
            // 
            this.listViewSamples.FullRowSelect = true;
            this.listViewSamples.HideSelection = false;
            this.listViewSamples.Location = new System.Drawing.Point(22, 161);
            this.listViewSamples.MultiSelect = false;
            this.listViewSamples.Name = "listViewSamples";
            this.listViewSamples.Size = new System.Drawing.Size(662, 237);
            this.listViewSamples.TabIndex = 19;
            this.listViewSamples.UseCompatibleStateImageBehavior = false;
            this.listViewSamples.View = System.Windows.Forms.View.Details;
            this.listViewSamples.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewSamples_ColumnClick);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Enabled = false;
            this.btnGenerateReport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnGenerateReport.Location = new System.Drawing.Point(339, 408);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(96, 21);
            this.btnGenerateReport.TabIndex = 18;
            this.btnGenerateReport.Text = "הפעל דוח";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSearch.Location = new System.Drawing.Point(475, 408);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 21);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "חפש";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dTPickerCompletedOn
            // 
            this.dTPickerCompletedOn.Enabled = false;
            this.dTPickerCompletedOn.Location = new System.Drawing.Point(359, 73);
            this.dTPickerCompletedOn.Name = "dTPickerCompletedOn";
            this.dTPickerCompletedOn.Size = new System.Drawing.Size(180, 20);
            this.dTPickerCompletedOn.TabIndex = 21;
            this.dTPickerCompletedOn.ValueChanged += new System.EventHandler(this.dTPickerCompletedOn_ValueChanged);
            // 
            // dTPickerCreatedOn
            // 
            this.dTPickerCreatedOn.Enabled = false;
            this.dTPickerCreatedOn.Location = new System.Drawing.Point(359, 30);
            this.dTPickerCreatedOn.Name = "dTPickerCreatedOn";
            this.dTPickerCreatedOn.Size = new System.Drawing.Size(180, 20);
            this.dTPickerCreatedOn.TabIndex = 20;
            this.dTPickerCreatedOn.ValueChanged += new System.EventHandler(this.dTPickerCreatedOn_ValueChanged);
            // 
            // txtSampleName
            // 
            this.txtSampleName.Enabled = false;
            this.txtSampleName.Location = new System.Drawing.Point(359, 117);
            this.txtSampleName.Name = "txtSampleName";
            this.txtSampleName.Size = new System.Drawing.Size(180, 20);
            this.txtSampleName.TabIndex = 24;
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.Enabled = false;
            this.listBoxStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.ItemHeight = 15;
            this.listBoxStatus.Location = new System.Drawing.Point(23, 73);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxStatus.Size = new System.Drawing.Size(186, 64);
            this.listBoxStatus.TabIndex = 27;
            // 
            // radioButtonStandart
            // 
            this.radioButtonStandart.AutoSize = true;
            this.radioButtonStandart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonStandart.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonStandart.Location = new System.Drawing.Point(162, 13);
            this.radioButtonStandart.Name = "radioButtonStandart";
            this.radioButtonStandart.Size = new System.Drawing.Size(102, 22);
            this.radioButtonStandart.TabIndex = 28;
            this.radioButtonStandart.TabStop = true;
            this.radioButtonStandart.Text = "מנות תקינות";
            this.radioButtonStandart.UseVisualStyleBackColor = true;
            // 
            // radioButtonPositive
            // 
            this.radioButtonPositive.AutoSize = true;
            this.radioButtonPositive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonPositive.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPositive.Location = new System.Drawing.Point(163, 41);
            this.radioButtonPositive.Name = "radioButtonPositive";
            this.radioButtonPositive.Size = new System.Drawing.Size(101, 22);
            this.radioButtonPositive.TabIndex = 29;
            this.radioButtonPositive.TabStop = true;
            this.radioButtonPositive.Text = "מנות חריגות";
            this.radioButtonPositive.UseVisualStyleBackColor = true;
            // 
            // checkBoxCreatedOn
            // 
            this.checkBoxCreatedOn.AutoSize = true;
            this.checkBoxCreatedOn.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxCreatedOn.Location = new System.Drawing.Point(563, 28);
            this.checkBoxCreatedOn.Name = "checkBoxCreatedOn";
            this.checkBoxCreatedOn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxCreatedOn.Size = new System.Drawing.Size(118, 22);
            this.checkBoxCreatedOn.TabIndex = 30;
            this.checkBoxCreatedOn.Text = "נוצרה בתאריך:";
            this.checkBoxCreatedOn.UseVisualStyleBackColor = true;
            this.checkBoxCreatedOn.CheckedChanged += new System.EventHandler(this.checkBoxCreatedOn_CheckedChanged);
            // 
            // checkBoxCompletedOn
            // 
            this.checkBoxCompletedOn.AutoSize = true;
            this.checkBoxCompletedOn.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxCompletedOn.Location = new System.Drawing.Point(557, 70);
            this.checkBoxCompletedOn.Name = "checkBoxCompletedOn";
            this.checkBoxCompletedOn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxCompletedOn.Size = new System.Drawing.Size(124, 22);
            this.checkBoxCompletedOn.TabIndex = 31;
            this.checkBoxCompletedOn.Text = "נבדקה בתאריך:";
            this.checkBoxCompletedOn.UseVisualStyleBackColor = true;
            this.checkBoxCompletedOn.CheckedChanged += new System.EventHandler(this.checkBoxCompletedOn_CheckedChanged);
            // 
            // checkBoxSampleName
            // 
            this.checkBoxSampleName.AutoSize = true;
            this.checkBoxSampleName.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxSampleName.Location = new System.Drawing.Point(553, 111);
            this.checkBoxSampleName.Name = "checkBoxSampleName";
            this.checkBoxSampleName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxSampleName.Size = new System.Drawing.Size(128, 22);
            this.checkBoxSampleName.TabIndex = 32;
            this.checkBoxSampleName.Text = "שם\\ חלק מהשם:";
            this.checkBoxSampleName.UseVisualStyleBackColor = true;
            this.checkBoxSampleName.CheckedChanged += new System.EventHandler(this.checkBoxSampleName_CheckedChanged);
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.checkBoxStatus.Location = new System.Drawing.Point(215, 71);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStatus.Size = new System.Drawing.Size(85, 22);
            this.checkBoxStatus.TabIndex = 33;
            this.checkBoxStatus.Text = "מצב מנה:";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            this.checkBoxStatus.CheckedChanged += new System.EventHandler(this.checkBoxStatus_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancel.Location = new System.Drawing.Point(230, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 21);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "בטל";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnRefresh.Location = new System.Drawing.Point(120, 408);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(73, 21);
            this.btnRefresh.TabIndex = 35;
            this.btnRefresh.Text = "חזור";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // SampleFiltersFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 435);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.checkBoxStatus);
            this.Controls.Add(this.checkBoxSampleName);
            this.Controls.Add(this.checkBoxCompletedOn);
            this.Controls.Add(this.checkBoxCreatedOn);
            this.Controls.Add(this.radioButtonPositive);
            this.Controls.Add(this.radioButtonStandart);
            this.Controls.Add(this.listBoxStatus);
            this.Controls.Add(this.txtSampleName);
            this.Controls.Add(this.dTPickerCompletedOn);
            this.Controls.Add(this.dTPickerCreatedOn);
            this.Controls.Add(this.listViewSamples);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnSearch);
            this.Enabled = false;
            this.Name = "SampleFiltersFrm";
            this.Text = "חיפוש מנות";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewSamples;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dTPickerCompletedOn;
        private System.Windows.Forms.DateTimePicker dTPickerCreatedOn;
        private System.Windows.Forms.TextBox txtSampleName;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.RadioButton radioButtonStandart;
        private System.Windows.Forms.RadioButton radioButtonPositive;
        private System.Windows.Forms.CheckBox checkBoxCreatedOn;
        private System.Windows.Forms.CheckBox checkBoxCompletedOn;
        private System.Windows.Forms.CheckBox checkBoxSampleName;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
    }
}