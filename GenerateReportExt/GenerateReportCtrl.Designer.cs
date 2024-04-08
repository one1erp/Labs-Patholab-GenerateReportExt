namespace GenerateReportExt
{
    partial class GenerateReportCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.listViewA = new System.Windows.Forms.ListView();
            this.listViewB = new System.Windows.Forms.ListView();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTitle.Location = new System.Drawing.Point(271, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(224, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "מסך הרצת דוחות";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnOK.Location = new System.Drawing.Point(403, 438);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "הפעל";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // listViewA
            // 
            this.listViewA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listViewA.FullRowSelect = true;
            this.listViewA.Location = new System.Drawing.Point(393, 82);
            this.listViewA.MultiSelect = false;
            this.listViewA.Name = "listViewA";
            this.listViewA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listViewA.RightToLeftLayout = true;
            this.listViewA.Size = new System.Drawing.Size(370, 340);
            this.listViewA.TabIndex = 6;
            this.listViewA.UseCompatibleStateImageBehavior = false;
            this.listViewA.View = System.Windows.Forms.View.Details;
            this.listViewA.SelectedIndexChanged += new System.EventHandler(this.listViewA_SelectedIndexChanged);
            this.listViewA.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // listViewB
            // 
            this.listViewB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listViewB.FullRowSelect = true;
            this.listViewB.Location = new System.Drawing.Point(20, 82);
            this.listViewB.MultiSelect = false;
            this.listViewB.Name = "listViewB";
            this.listViewB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listViewB.RightToLeftLayout = true;
            this.listViewB.Size = new System.Drawing.Size(370, 340);
            this.listViewB.TabIndex = 7;
            this.listViewB.UseCompatibleStateImageBehavior = false;
            this.listViewB.View = System.Windows.Forms.View.Details;
            this.listViewB.SelectedIndexChanged += new System.EventHandler(this.listViewB_SelectedIndexChanged);
            this.listViewB.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnClose.Location = new System.Drawing.Point(294, 438);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 25);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "יציאה";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // GenerateReportCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listViewB);
            this.Controls.Add(this.listViewA);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblTitle);
            this.Name = "GenerateReportCtrl";
            this.Size = new System.Drawing.Size(785, 477);
            this.Resize += new System.EventHandler(this.GenerateReportCtrl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView listViewA;
        private System.Windows.Forms.ListView listViewB;
        private System.Windows.Forms.Button btnClose;
     }
}
