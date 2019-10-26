namespace Minesweeper
{
    partial class Controller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.btn_new = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beginner9910BombsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flagAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unflagAllFlagedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_flags = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_new
            // 
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_new.Image = global::Minesweeper.Properties.Resources.smiley_happy;
            this.btn_new.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_new.Location = new System.Drawing.Point(95, 26);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(27, 27);
            this.btn_new.TabIndex = 6;
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(253, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginnerToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.enableTimeToolStripMenuItem,
            this.showAllToolStripMenuItem,
            this.flagAllToolStripMenuItem,
            this.unflagAllFlagedToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // beginnerToolStripMenuItem
            // 
            this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
            this.beginnerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.beginnerToolStripMenuItem.Text = "New Game";
            this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.beginnerToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginner9910BombsToolStripMenuItem,
            this.intermediToolStripMenuItem,
            this.expertToolStripMenuItem,
            this.customToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.optionsToolStripMenuItem.Text = "Game difficulty";
            // 
            // beginner9910BombsToolStripMenuItem
            // 
            this.beginner9910BombsToolStripMenuItem.Name = "beginner9910BombsToolStripMenuItem";
            this.beginner9910BombsToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.beginner9910BombsToolStripMenuItem.Text = "Beginner - 9 * 9 - 10 Bombs";
            this.beginner9910BombsToolStripMenuItem.Click += new System.EventHandler(this.beginner9910BombsToolStripMenuItem_Click);
            // 
            // intermediToolStripMenuItem
            // 
            this.intermediToolStripMenuItem.Name = "intermediToolStripMenuItem";
            this.intermediToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.intermediToolStripMenuItem.Text = "Intermediate - 16 * 16 - 40 Bombs";
            this.intermediToolStripMenuItem.Click += new System.EventHandler(this.intermediToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.expertToolStripMenuItem.Text = "Expert - 16 * 30 - 99 Bombs";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // enableTimeToolStripMenuItem
            // 
            this.enableTimeToolStripMenuItem.Checked = true;
            this.enableTimeToolStripMenuItem.CheckOnClick = true;
            this.enableTimeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableTimeToolStripMenuItem.Name = "enableTimeToolStripMenuItem";
            this.enableTimeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.enableTimeToolStripMenuItem.Text = "Enable Time flicker";
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.CheckOnClick = true;
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.showAllToolStripMenuItem.Text = "Show All";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // flagAllToolStripMenuItem
            // 
            this.flagAllToolStripMenuItem.Name = "flagAllToolStripMenuItem";
            this.flagAllToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.flagAllToolStripMenuItem.Text = "Flag all bombs";
            this.flagAllToolStripMenuItem.Click += new System.EventHandler(this.flagAllToolStripMenuItem_Click);
            // 
            // unflagAllFlagedToolStripMenuItem
            // 
            this.unflagAllFlagedToolStripMenuItem.Name = "unflagAllFlagedToolStripMenuItem";
            this.unflagAllFlagedToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.unflagAllFlagedToolStripMenuItem.Text = "Unflag all flaged";
            this.unflagAllFlagedToolStripMenuItem.Click += new System.EventHandler(this.unflagAllFlagedToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // howToPlayToolStripMenuItem
            // 
            this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
            this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.howToPlayToolStripMenuItem.Text = "How to play";
            this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lbl_time
            // 
            this.lbl_time.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(124, 33);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(117, 15);
            this.lbl_time.TabIndex = 9;
            this.lbl_time.Text = "0";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_flags
            // 
            this.lbl_flags.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_flags.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_flags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_flags.Location = new System.Drawing.Point(10, 33);
            this.lbl_flags.Name = "lbl_flags";
            this.lbl_flags.Size = new System.Drawing.Size(76, 15);
            this.lbl_flags.TabIndex = 9;
            this.lbl_flags.Text = "0";
            this.lbl_flags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(253, 248);
            this.Controls.Add(this.lbl_flags);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Controller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.SizeChanged += new System.EventHandler(this.Controller_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beginnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beginner9910BombsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_flags;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flagAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unflagAllFlagedToolStripMenuItem;
    }
}

