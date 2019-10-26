using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Minesweeper
{
    public partial class View : UserControl
    {
        Model model;

        public View(Model model)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(128, 128, 128);
            this.model = model;
            NewGame();
        }

        public void NewGame()
        {
            if (this.model != null)
                Controls.Clear();

            for (int x = 0; x < model.Columns; x++)
                for (int y = 0; y < model.Rows; y++)
                {
                    model.Blocks[x, y].Location = new Point(x * 16 + 2, y * 16 + 2);
                    this.Controls.Add(model.Blocks[x, y]);
                }
            

            this.Size = new Size(model.Columns * 16 + 4, model.Rows * 16 + 4);
            this.Invalidate();
        }

        private void View_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.White, 0, this.Height - 1, this.Width - 1, this.Height - 1);
            e.Graphics.DrawLine(Pens.White, 1, this.Height - 2, this.Width - 1, this.Height - 2);
            e.Graphics.DrawLine(Pens.White, this.Width - 1, 0, this.Width - 1, this.Height - 1);
            e.Graphics.DrawLine(Pens.White, this.Width - 2, 1, this.Width - 2, this.Height - 1);
        }
    }
}