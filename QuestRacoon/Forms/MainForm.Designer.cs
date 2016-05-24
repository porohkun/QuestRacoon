namespace QuestRacoonWpf
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
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveQuestAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.workspaceContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuestDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveQuestDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.newQuestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openQuestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveQuestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.undoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.localesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.updArrowsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.playToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newQuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openQuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveQuestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workspace = new QuestRacoonWpf.WorkspaceControl();
            this.mainMenuStrip.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.workspaceContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.questToolStripMenuItem});
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
            // saveQuestAsToolStripMenuItem
            // 
            this.saveQuestAsToolStripMenuItem.Name = "saveQuestAsToolStripMenuItem";
            this.saveQuestAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveQuestAsToolStripMenuItem.Text = "Save Quest As...";
            this.saveQuestAsToolStripMenuItem.Click += new System.EventHandler(this.saveQuestAsToolStripMenuItem_Click);
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
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // questToolStripMenuItem
            // 
            this.questToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localesToolStripMenuItem});
            this.questToolStripMenuItem.Name = "questToolStripMenuItem";
            this.questToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.questToolStripMenuItem.Text = "Quest";
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQuestToolStripButton,
            this.openQuestToolStripButton,
            this.saveQuestToolStripButton,
            this.toolStripSeparator4,
            this.undoToolStripButton,
            this.redoToolStripButton,
            this.toolStripSeparator5,
            this.localesToolStripButton,
            this.updArrowsToolStripButton,
            this.toolStripSeparator6,
            this.playToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(571, 25);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
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
            // openQuestDialog
            // 
            this.openQuestDialog.Filter = "Racoon quest files|*.qrc|All files|*.*";
            // 
            // saveQuestDialog
            // 
            this.saveQuestDialog.Filter = "Racoon quest files|*.qrc|All files|*.*";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // newQuestToolStripButton
            // 
            this.newQuestToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newQuestToolStripButton.Image = global::QuestRacoonWpf.Properties.Resources.new_document;
            this.newQuestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newQuestToolStripButton.Name = "newQuestToolStripButton";
            this.newQuestToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newQuestToolStripButton.Text = "New Quest";
            this.newQuestToolStripButton.Click += new System.EventHandler(this.newQuestToolStripMenuItem_Click);
            // 
            // openQuestToolStripButton
            // 
            this.openQuestToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openQuestToolStripButton.Image = global::QuestRacoonWpf.Properties.Resources.open_document;
            this.openQuestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openQuestToolStripButton.Name = "openQuestToolStripButton";
            this.openQuestToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openQuestToolStripButton.Text = "Open Quest";
            this.openQuestToolStripButton.Click += new System.EventHandler(this.openQuestToolStripMenuItem_Click);
            // 
            // saveQuestToolStripButton
            // 
            this.saveQuestToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveQuestToolStripButton.Image = global::QuestRacoonWpf.Properties.Resources.disk;
            this.saveQuestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveQuestToolStripButton.Name = "saveQuestToolStripButton";
            this.saveQuestToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveQuestToolStripButton.Text = "Save Quest";
            this.saveQuestToolStripButton.Click += new System.EventHandler(this.saveQuestToolStripMenuItem_Click);
            // 
            // undoToolStripButton
            // 
            this.undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolStripButton.Enabled = false;
            this.undoToolStripButton.Image = global::QuestRacoonWpf.Properties.Resources.arrow_left;
            this.undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolStripButton.Name = "undoToolStripButton";
            this.undoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.undoToolStripButton.Text = "Undo";
            // 
            // redoToolStripButton
            // 
            this.redoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoToolStripButton.Enabled = false;
            this.redoToolStripButton.Image = global::QuestRacoonWpf.Properties.Resources.arrow_right;
            this.redoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoToolStripButton.Name = "redoToolStripButton";
            this.redoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.redoToolStripButton.Text = "Redo";
            // 
            // localesToolStripButton
            // 
            this.localesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.localesToolStripButton.Image = global::QuestRacoonWpf.Properties.Resources.locale;
            this.localesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.localesToolStripButton.Name = "localesToolStripButton";
            this.localesToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.localesToolStripButton.Text = "Locales";
            this.localesToolStripButton.Click += new System.EventHandler(this.localesToolStripMenuItem_Click);
            // 
            // updArrowsToolStripButton
            // 
            this.updArrowsToolStripButton.Checked = true;
            this.updArrowsToolStripButton.CheckOnClick = true;
            this.updArrowsToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.updArrowsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updArrowsToolStripButton.Image = global::QuestRacoonWpf.Properties.Resources.node_select_all_icon;
            this.updArrowsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updArrowsToolStripButton.Name = "updArrowsToolStripButton";
            this.updArrowsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.updArrowsToolStripButton.Text = "Update Arrows";
            this.updArrowsToolStripButton.Click += new System.EventHandler(this.updArrowsToolStripButton_Click);
            // 
            // playToolStripButton
            // 
            this.playToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.playToolStripButton.Image = global::QuestRacoonWpf.Properties.Resources.Play_icon;
            this.playToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.playToolStripButton.Name = "playToolStripButton";
            this.playToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.playToolStripButton.Text = "Test Quest";
            this.playToolStripButton.Click += new System.EventHandler(this.playToolStripButton_Click);
            // 
            // newQuestToolStripMenuItem
            // 
            this.newQuestToolStripMenuItem.Image = global::QuestRacoonWpf.Properties.Resources.new_document;
            this.newQuestToolStripMenuItem.Name = "newQuestToolStripMenuItem";
            this.newQuestToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newQuestToolStripMenuItem.Text = "New Quest";
            this.newQuestToolStripMenuItem.Click += new System.EventHandler(this.newQuestToolStripMenuItem_Click);
            // 
            // openQuestToolStripMenuItem
            // 
            this.openQuestToolStripMenuItem.Image = global::QuestRacoonWpf.Properties.Resources.open_document;
            this.openQuestToolStripMenuItem.Name = "openQuestToolStripMenuItem";
            this.openQuestToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openQuestToolStripMenuItem.Text = "Open Quest";
            this.openQuestToolStripMenuItem.Click += new System.EventHandler(this.openQuestToolStripMenuItem_Click);
            // 
            // saveQuestToolStripMenuItem
            // 
            this.saveQuestToolStripMenuItem.Image = global::QuestRacoonWpf.Properties.Resources.disk;
            this.saveQuestToolStripMenuItem.Name = "saveQuestToolStripMenuItem";
            this.saveQuestToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveQuestToolStripMenuItem.Text = "Save Quest";
            this.saveQuestToolStripMenuItem.Click += new System.EventHandler(this.saveQuestToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Image = global::QuestRacoonWpf.Properties.Resources.arrow_left;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Image = global::QuestRacoonWpf.Properties.Resources.arrow_right;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // localesToolStripMenuItem
            // 
            this.localesToolStripMenuItem.Image = global::QuestRacoonWpf.Properties.Resources.locale;
            this.localesToolStripMenuItem.Name = "localesToolStripMenuItem";
            this.localesToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.localesToolStripMenuItem.Text = "Locales";
            this.localesToolStripMenuItem.Click += new System.EventHandler(this.localesToolStripMenuItem_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Quest Racoon";
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
        private System.Windows.Forms.ContextMenuStrip workspaceContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newBlockToolStripMenuItem;
        private WorkspaceControl workspace;
        private System.Windows.Forms.OpenFileDialog openQuestDialog;
        private System.Windows.Forms.SaveFileDialog saveQuestDialog;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton newQuestToolStripButton;
        private System.Windows.Forms.ToolStripButton openQuestToolStripButton;
        private System.Windows.Forms.ToolStripButton saveQuestToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton undoToolStripButton;
        private System.Windows.Forms.ToolStripButton redoToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton localesToolStripButton;
        private System.Windows.Forms.ToolStripButton updArrowsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton playToolStripButton;
    }
}

