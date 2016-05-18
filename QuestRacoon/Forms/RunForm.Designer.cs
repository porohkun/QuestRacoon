namespace QuestRacoon
{
    partial class RunForm
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
            this.show = new QuestRacoon.ShowControl();
            this.SuspendLayout();
            // 
            // show
            // 
            this.show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.show.Location = new System.Drawing.Point(0, 0);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(400, 396);
            this.show.TabIndex = 0;
            this.show.Text = "showControl1";
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 396);
            this.Controls.Add(this.show);
            this.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "RunForm";
            this.Text = "RunForm";
            this.Shown += new System.EventHandler(this.RunForm_Shown);
            this.SizeChanged += new System.EventHandler(this.RunForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private ShowControl show;
    }
}