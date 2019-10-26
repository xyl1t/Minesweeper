using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Minesweeper.Properties;

namespace Minesweeper
{
    public partial class Controller : Form
    {
        Model model;
        View view;

        int rows = 9, columns = 9;
        short bombAmount = 10;
        short bombLeft;
        Timer time = new Timer();
        Timer winAnimation = new Timer();
        public Controller()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(198, 198, 198);
            model = new Model(rows, columns, bombAmount);
            model.Win += new Model.Game(model_Win);
            model.GameOver += new Model.Game(model_GameOver);
            model.OnBlockClick += new Model.Click(model_OnBlockClick);

            view = new View(model);
            view.Location = new Point(10, 55);
            this.Size = new Size(view.Size.Width + 30, view.Size.Height + 97);
            this.Controls.Add(view);

            time.Interval = 1000;
            time.Tick += new EventHandler(time_Tick);

            winAnimation.Interval = 100;
            winAnimation.Tick += new EventHandler(winAnimation_Tick);
            
            bombLeft = bombAmount;
            lbl_flags.Text = bombLeft.ToString();

            lbl_time.Text = "000"; 
            lbl_flags.Text = "";
            for (int i = 0; i < 3 - (bombAmount + 1).ToString().Length; i++)
                lbl_flags.Text += "0";
            lbl_flags.Text += bombAmount.ToString();
        }


        void model_OnBlockClick(MouseButtons pressedButton, bool mouseDown, Block clickedBlock)
        {
            if (time.Enabled != true && pressedButton == MouseButtons.Left && !mouseDown && clickedBlock.State == BlockState.Closed)
                time.Enabled = true;

            if ((pressedButton == MouseButtons.Right)&& (clickedBlock.State == BlockState.Closed || clickedBlock.State == BlockState.Flaged))
            {
                bombLeft = (clickedBlock.State == BlockState.Flaged) ? (short)(bombLeft - 1) : (short)(bombLeft + 1);

                lbl_flags.Text = "";
                if (bombLeft < 0)
                    lbl_flags.Text += "-";
                for (int i = 0; i < 3 - Math.Abs(bombLeft).ToString().Length; i++)
                    lbl_flags.Text += "0";

                if (bombLeft < 0) 
                    lbl_flags.Text += Math.Abs(bombLeft).ToString();
                else
                    lbl_flags.Text += bombLeft.ToString();
            }

            if ((pressedButton == MouseButtons.Left || (pressedButton == (MouseButtons.Left | MouseButtons.Right))) && mouseDown)
                btn_new.Image = Resources.smiley_afraid;
            else if ((pressedButton == MouseButtons.Left || (pressedButton == (MouseButtons.Left | MouseButtons.Right))) && !mouseDown)
                btn_new.Image = Resources.smiley_happy;
        }

        int tickTime;
        void time_Tick(object sender, EventArgs e)
        {
            tickTime = int.Parse(lbl_time.Text);
            lbl_time.Text = "";
            for (int i = 0; i < 3 - (tickTime+1).ToString().Length; i++)
            {
                lbl_time.Text += "0";
            }
            tickTime++;
            lbl_time.Text += tickTime.ToString();
        }

        void model_Win()
        {
            tickTime = 0;
            time.Enabled = false;
            view.Enabled = false;
            btn_new.Image = Resources.smiley_win;

            winAnimation.Enabled = enableTimeToolStripMenuItem.Checked;
        }
        int repeat = 6;
        void winAnimation_Tick(object sender, EventArgs e)
        {
            if (repeat > 0)
            {
                if (repeat % 2 == 0)
                    lbl_time.BackColor = Color.LightGreen;
                else
                    lbl_time.BackColor = SystemColors.Control;
                repeat--;
            }
            else
            {
                repeat = 6;
                winAnimation.Enabled = false;
            }
        }

        void model_GameOver()
        {
            tickTime = 0;
            time.Enabled = false;
            view.Enabled = false;

            btn_new.Image = Resources.smiley_gameover;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void NewGame()
        {
            view.Enabled = true;
            btn_new.Image = Resources.smiley_happy;
            bool newView = false;
            if (model.Rows != rows || model.Columns != columns)
                newView = true;

            model.NewGame(rows, columns, bombAmount);

            if (newView)
            {
                view.NewGame();
                this.Size = new Size(view.Size.Width + 30, view.Size.Height + 97);
            }


            tickTime = 0;
            time.Enabled = false;
            lbl_time.Text = "000";
            lbl_flags.Text = "000";

            lbl_flags.Text = "";
            for (int i = 0; i < 3 - (bombAmount + 1).ToString().Length; i++)
                lbl_flags.Text += "0";
            lbl_flags.Text += bombAmount.ToString();


            bombLeft = bombAmount;

            if (showAllToolStripMenuItem.Checked)
                model.HardOpenAll();
            else
                model.CloseAll();
        }

        private void beginner9910BombsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rows != 9 || columns != 9 || bombAmount != 10)
            {
                rows = 9;
                columns = 9;
                bombAmount = 10;

                NewGame();
            }
        }

        private void intermediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rows != 16 || columns != 16 || bombAmount != 40)
            {
                rows = 16;
                columns = 16;
                bombAmount = 40;

                NewGame();
            }
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rows != 16 || columns != 30 || bombAmount != 99)
            {
                rows = 16;
                columns = 30;
                bombAmount = 99;

                NewGame();
            }
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSize customSize = new NewSize(rows, columns, bombAmount);
            if(customSize.ShowDialog() == DialogResult.OK)
            {
                if (rows != 16 || columns != 30 || bombAmount != 99)
                {
                    rows = customSize.Rows;
                    columns = customSize.Columns;
                    bombAmount = customSize.Bombs;

                    NewGame();
                }
            }
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_flags.Text = "";
            for (int i = 0; i < 3 - (bombAmount + 1).ToString().Length; i++)
                lbl_flags.Text += "0";
            lbl_flags.Text += bombAmount.ToString();

            if (showAllToolStripMenuItem.Checked)
                model.HardOpenAll();
            else
                model.CloseAll();

            flagAllToolStripMenuItem.Enabled = !flagAllToolStripMenuItem.Enabled;
            unflagAllFlagedToolStripMenuItem.Enabled = !unflagAllFlagedToolStripMenuItem.Enabled;
        }

        private void Controller_SizeChanged(object sender, EventArgs e)
        {
            btn_new.Location = new Point((this.Width -10 ) / 2 - btn_new.Size.Width / 2, btn_new.Location.Y);

            lbl_flags.Size = new Size((this.Width - 10) / 2 - 30, 15);
            lbl_time.Location = new Point((this.Width - 10) / 2 + 20, lbl_time.Location.Y);
            lbl_time.Size = new Size((this.Width - 10) / 2 - 30, 15); 
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.instructables.com/id/How-to-play-minesweeper/");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void flagAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.FlagAllBombs();

            bombLeft = 0;
            lbl_flags.Text = "000";
        }
        private void unflagAllFlagedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.UnFlagAll();

            bombLeft = bombAmount;
            lbl_flags.Text = "";
            for (int i = 0; i < 3 - (bombAmount + 1).ToString().Length; i++)
                lbl_flags.Text += "0";
            lbl_flags.Text += bombAmount.ToString();

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}