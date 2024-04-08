namespace GenerateReportExt
{
    partial class ParamListFrm
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
            this.listViewIds = new System.Windows.Forms.ListView();
            this.btnListOK = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblTitleReport = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewIds
            // 
            this.listViewIds.Location = new System.Drawing.Point(24, 103);
            this.listViewIds.Name = "listViewIds";
            this.listViewIds.Size = new System.Drawing.Size(505, 245);
            this.listViewIds.TabIndex = 0;
            this.listViewIds.UseCompatibleStateImageBehavior = false;
            this.listViewIds.View = System.Windows.Forms.View.Details;
            // 
            // btnListOK
            // 
            this.btnListOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnListOK.Location = new System.Drawing.Point(290, 354);
            this.btnListOK.Name = "btnListOK";
            this.btnListOK.Size = new System.Drawing.Size(91, 21);
            this.btnListOK.TabIndex = 1;
            this.btnListOK.Text = "הפעל דוח";
            this.btnListOK.UseVisualStyleBackColor = true;
            this.btnListOK.Click += new System.EventHandler(this.btnListOK_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtBarcode.Location = new System.Drawing.Point(117, 66);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(202, 24);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblBarcode.Location = new System.Drawing.Point(30, 65);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(81, 18);
            this.lblBarcode.TabIndex = 3;
            this.lblBarcode.Text = "Barcode :";
            // 
            // lblTitleReport
            // 
            this.lblTitleReport.AutoSize = true;
            this.lblTitleReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTitleReport.Location = new System.Drawing.Point(180, 18);
            this.lblTitleReport.Name = "lblTitleReport";
            this.lblTitleReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitleReport.Size = new System.Drawing.Size(0, 22);
            this.lblTitleReport.TabIndex = 4;
            this.lblTitleReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancel.Location = new System.Drawing.Point(163, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 21);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "בטל";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ParamListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 399);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitleReport);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.btnListOK);
            this.Controls.Add(this.listViewIds);
            this.Name = "ParamListFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewIds;
        private System.Windows.Forms.Button btnListOK;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblTitleReport;
        private System.Windows.Forms.Button btnCancel;
    }
}