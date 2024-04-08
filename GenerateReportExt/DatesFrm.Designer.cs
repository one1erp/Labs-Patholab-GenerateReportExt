namespace GenerateReportExt
{
    partial class DatesFrm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendarFrom = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendarTo = new System.Windows.Forms.MonthCalendar();
            this.lbltitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnOK.Location = new System.Drawing.Point(173, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 21);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "הפעל דוח";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(346, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = ": מתאריך";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // monthCalendarFrom
            // 
            this.monthCalendarFrom.Location = new System.Drawing.Point(258, 95);
            this.monthCalendarFrom.MaxSelectionCount = 1;
            this.monthCalendarFrom.Name = "monthCalendarFrom";
            this.monthCalendarFrom.TabIndex = 4;
            this.monthCalendarFrom.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarFrom_DateSelected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(114, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = ": עד תאריך";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // monthCalendarTo
            // 
            this.monthCalendarTo.Location = new System.Drawing.Point(38, 95);
            this.monthCalendarTo.MaxSelectionCount = 1;
            this.monthCalendarTo.Name = "monthCalendarTo";
            this.monthCalendarTo.TabIndex = 6;
            this.monthCalendarTo.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarTo_DateSelected);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lbltitle.Location = new System.Drawing.Point(156, 20);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(174, 26);
            this.lbltitle.TabIndex = 7;
            this.lbltitle.Text = " חישוב נתוני הדוח ";
            // 
            // DatesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 394);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.monthCalendarTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monthCalendarFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DatesFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendarFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendarTo;
        private System.Windows.Forms.Label lbltitle;
    }
}