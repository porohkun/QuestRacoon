namespace QuestRacoonWpf
{
    partial class Block
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.bodyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerLabel.Location = new System.Drawing.Point(-1, -1);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(142, 30);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "header";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.headerLabel.DoubleClick += new System.EventHandler(this.headerLabel_DoubleClick);
            this.headerLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.headerLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            this.headerLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);
            // 
            // bodyLabel
            // 
            this.bodyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bodyLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bodyLabel.Location = new System.Drawing.Point(-1, 28);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(142, 113);
            this.bodyLabel.TabIndex = 1;
            this.bodyLabel.Text = "body";
            this.bodyLabel.DoubleClick += new System.EventHandler(this.headerLabel_DoubleClick);
            this.bodyLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.bodyLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            this.bodyLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);
            // 
            // Block
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.headerLabel);
            this.Name = "Block";
            this.Size = new System.Drawing.Size(140, 140);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label bodyLabel;
    }
}
