using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class NewSize : Form
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public short Bombs { get; private set; }
        
        public NewSize(int rows, int columns, short bombs)
        {
            InitializeComponent();

            nud_rows.Value = rows;
            nud_columns.Value = columns;
            nud_bombs.Value = bombs;
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            Rows = (int)nud_rows.Value;
            Columns = (int)nud_columns.Value;
            Bombs = (short)nud_bombs.Value;

            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
