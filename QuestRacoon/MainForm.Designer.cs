namespace QuestRacoon
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveQuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveQuestAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.workspaceContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workspace = new QuestRacoon.WorkspaceControl();
            this.mainMenuStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.workspaceContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(571, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQuestToolStripMenuItem,
            this.openQuestToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveQuestToolStripMenuItem,
            this.saveQuestAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newQuestToolStripMenuItem
            // 
            this.newQuestToolStripMenuItem.Name = "newQuestToolStripMenuItem";
            this.newQuestToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newQuestToolStripMenuItem.Text = "New Quest";
            // 
            // openQuestToolStripMenuItem
            // 
            this.openQuestToolStripMenuItem.Name = "openQuestToolStripMenuItem";
            this.openQuestToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openQuestToolStripMenuItem.Text = "Open Quest";
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // saveQuestToolStripMenuItem
            // 
            this.saveQuestToolStripMenuItem.Name = "saveQuestToolStripMenuItem";
            this.saveQuestToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveQuestToolStripMenuItem.Text = "Save Quest";
            // 
            // saveQuestAsToolStripMenuItem
            // 
            this.saveQuestAsToolStripMenuItem.Name = "saveQuestAsToolStripMenuItem";
            this.saveQuestAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveQuestAsToolStripMenuItem.Text = "Save Quest As...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(571, 25);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // workspaceContextMenu
            // 
            this.workspaceContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBlockToolStripMenuItem});
            this.workspaceContextMenu.Name = "workspaceContextMenu";
            this.workspaceContextMenu.Size = new System.Drawing.Size(131, 26);
            // 
            // newBlockToolStripMenuItem
            // 
            this.newBlockToolStripMenuItem.Name = "newBlockToolStripMenuItem";
            this.newBlockToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.newBlockToolStripMenuItem.Text = "New Block";
            this.newBlockToolStripMenuItem.Click += new System.EventHandler(this.newBlockToolStripMenuItem_Click);
            // 
            // workspace
            // 
            this.workspace.BackColor = System.Drawing.SystemColors.ControlDark;
            this.workspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspace.Location = new System.Drawing.Point(0, 49);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(571, 404);
            this.workspace.TabIndex = 2;
            this.workspace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.workspace_MouseDown);
            this.workspace.MouseMove += new System.Windows.Forms.MouseEventHandler(this.workspace_MouseMove);
            this.workspace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.workspace_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 453);
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.workspaceContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newQuestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openQuestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveQuestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveQuestAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ContextMenuStrip workspaceContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newBlockToolStripMenuItem;
        private WorkspaceControl workspace;
    }
}

