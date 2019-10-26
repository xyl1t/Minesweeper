using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows;

namespace Minesweeper
{
    public class Model
    {
        public delegate void Game();
        public delegate void Click(MouseButtons pressedButton, bool mouseDown, Block clickedBlock);

        /* events */
        public event Game GameOver;
        public event Game Win;
        public event Click OnBlockClick;


        int calls = 0; // clicked blocks
        int openCellsToWin; // blocks that have to be clicked to win

        Block[,] blocks; // all blocks
        public Block[,] Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        } 
        Block[] bombs; // bombs
        List<Block> flaged = new List<Block>(); // falged blocks
        Block currentBlock; // current clicked block
        Block[,] openBlocks = new Block[3, 3]; // 3x3 blocks when right + left clicking

        bool m_left = false, m_right = false, m_middle = false; // mouse left/right/middle click

        int rows, columns;
        short bombAmount;
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        public short BombAmount { get { return bombAmount; } }

        public Model(): this(12, 12) { }
        public Model(int rows, int columns): this(rows, columns, 20) { }
        public Model(int rows, int columns, short bombAmount)
        {
            this.rows = rows;
            this.columns = columns;
            this.bombAmount = bombAmount;

            openCellsToWin = rows * columns;

            CreateBlocks();
        }

        public Block[,] CreateBlocks()
        {
            if (blocks == null)
                blocks = new Block[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (blocks[x, y] == null)
                    {
                        blocks[x, y] = new Block(x, y);
                        blocks[x, y].State = BlockState.Closed;

                        blocks[x, y].MouseUp += new MouseEventHandler(block_MouseUp);
                        blocks[x, y].MouseDown += new MouseEventHandler(block_MouseDown);
                        blocks[x, y].MouseMove += new MouseEventHandler(block_MouseMove);
                    }
                    else
                    {
                        blocks[x, y].Type = BlockType.Empty;
                    }
                }
            }

        	Random random = new Random();

            int bx, by;
            if (bombAmount > (rows * columns))
                bombAmount -= 1;

            bombs = new Block[bombAmount];
            for (int i = 0; i < bombAmount; i++)
            {
                do
                {
                    bx = random.Next(0, columns);
                    by = random.Next(0, rows);
                } while (blocks[bx, by].Type == BlockType.Bomb);

                blocks[bx, by].Type = BlockType.Bomb;
                bombs[i] = blocks[bx, by];

                if (bx + 1 < columns)
                    blocks[bx + 1, by].TurnIntoNumber(); // right
                if (bx - 1 >= 0)
                    blocks[bx - 1, by].TurnIntoNumber(); // left
                if (by + 1 < rows)
                    blocks[bx, by + 1].TurnIntoNumber(); // bottom
                if (by - 1 >= 0)
                    blocks[bx, by - 1].TurnIntoNumber(); // top

                if (bx + 1 < columns && by + 1 < rows)
                    blocks[bx + 1, by + 1].TurnIntoNumber(); // bottom right
                if (bx + 1 < columns && by - 1 >= 0)
                    blocks[bx + 1, by - 1].TurnIntoNumber(); // top right

                if (bx - 1 >= 0 && by + 1 < rows)
                    blocks[bx - 1, by + 1].TurnIntoNumber(); // bottom left
                if (bx - 1 >= 0 && by - 1 >= 0)
                    blocks[bx - 1, by - 1].TurnIntoNumber(); // top left
            }

            return blocks;
        }

        void block_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                m_left = true;
            if (e.Button == MouseButtons.Right)
                m_right = true;
            if (e.Button == MouseButtons.Middle)
                m_middle = true;

            currentBlock = sender as Block;

            /* if LEFT mouse button AND RIGHT mouse button are clicked */
            if (m_left == true && m_right == true)
            {
                short x = Convert.ToInt16((e.X + ((Block)sender).X * 16) / 16), y = Convert.ToInt16((e.Y + ((Block)sender).Y * 16) / 16);

                int startX = -1;
                int endX = 2;
                int startY = -1;
                int endY = 2;

                if (x - 1 < 0)
                    startX = 0;
                if (x + 1 > columns - 1)
                    endX = 1;
                if (y + 1 > rows - 1)
                    endY = 1;
                if (y - 1 < 0)
                    startY = 0;

                for (int i = x + startX; i < x + endX; i++)
                    for (int j = y + startY; j < y + endY; j++)
                    {
                        if ((j >= 0 && j <= rows - 1) && (i >= 0 && i <= columns - 1))
                        {
                            if (i - x + 1 == 1 && j - y + 1 == 1)
                                currentBlock = blocks[i, j];

                            openBlocks[i - x + 1, j - y + 1] = blocks[i, j].Open();
                        }
                    }
                if (OnBlockClick != null)
                    OnBlockClick(MouseButtons.Right | MouseButtons.Left, true, currentBlock);
            }
            /* if only LEFT mouse button was clicked */
            else if (m_left)
            {
                if (currentBlock.State != BlockState.Flaged && currentBlock.State != BlockState.Opened)
                    currentBlock.Open();
                if (OnBlockClick != null)
                    OnBlockClick(MouseButtons.Left,true, currentBlock);
            }
            /* if only RIGHT mouse button was clicked */
            else if (m_right)
            {
                if (currentBlock.State != BlockState.Opened)
                {
                    // if the block IS flaged
                    if (currentBlock.State != BlockState.Flaged)
                    {
                        currentBlock.Flag();
                        flaged.Add(currentBlock);
                    }
                    // if the block IS NOT flaged
                    else
                    {
                        currentBlock.UnFlag();
                        flaged.Remove(currentBlock);
                    }

                }
                if (OnBlockClick != null)
                    OnBlockClick(MouseButtons.Right, true, currentBlock);
            }
        }
        void block_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_left && !m_right)
            {
                if (currentBlock.State == BlockState.Closed)
                    currentBlock.Close();

                short x, y;

                if ((e.X + ((Block)sender).X * 16) / 16 < 0)
                    x = 0;
                else
                    x = Convert.ToInt16((e.X + ((Block)sender).X * 16) / 16);
                if ((e.Y + ((Block)sender).Y * 16) / 16 < 0)
                    y = 0;
                else
                    y = Convert.ToInt16((e.Y + ((Block)sender).Y * 16) / 16);

                if (x < blocks.GetUpperBound(0) + 1 && y < blocks.GetUpperBound(1) + 1)
                    currentBlock = blocks[x, y];

                if (currentBlock.State == BlockState.Closed)
                    currentBlock.Open();
            }
            if ((m_left && m_right)||m_middle)
            {
                short x = Convert.ToInt16((e.X + ((Block)sender).X * 16) / 16), y = Convert.ToInt16((e.Y + ((Block)sender).Y * 16) / 16);

                int startX = -1;
                int endX = 2;
                int startY = -1;
                int endY = 2;

                if (x - 1 < 0)
                    startX = 0;
                if (x + 1 > columns - 1)
                    endX = 1;
                if (y + 1 > rows - 1)
                    endY = 1;
                if (y - 1 < 0)
                    startY = 0;

                for (int i = x + startX; i < x + endX; i++)
                    for (int j = y + startY; j < y + endY; j++)
                    {
                        if ((j >= 0 && j <= rows - 1) && (i >= 0 && i <= columns - 1))
                        {
                            if (openBlocks[i - x + 1, j - y + 1] != null &&
                                (openBlocks[i - x + 1, j - y + 1].X != blocks[i, j].X || openBlocks[i - x + 1, j - y + 1].Y != blocks[i, j].Y) &&
                                openBlocks[i - x + 1, j - y + 1].State != BlockState.Opened &&
                                openBlocks[i - x + 1, j - y + 1].State != BlockState.Flaged)
                                openBlocks[i - x + 1, j - y + 1].Close();

                        }
                    }
                for (int i = x + startX; i < x + endX; i++)
                    for (int j = y + startY; j < y + endY; j++)
                    {
                        if ((j >= 0 && j <= rows - 1) && (i >= 0 && i <= columns - 1))
                        {
                            if (i - x + 1 == 1 && j - y + 1 == 1)
                                currentBlock = blocks[i, j];

                                openBlocks[i - x + 1, j - y + 1] = blocks[i, j].Open();
                        }
                    }

            }
        }
        bool enableWin = true;
        void block_MouseUp(object sender, MouseEventArgs e)
        {
            /* if LEFT mouse button AND RIGHT mouse button are clicked */
            if ((m_left && m_right) || m_middle)
            {
                if (OnBlockClick != null)
                    OnBlockClick(MouseButtons.Right | MouseButtons.Left, false, currentBlock);

                int flags = getFlagsAmount(currentBlock.X, currentBlock.Y);
                if (currentBlock.Type != BlockType.Bomb &&
                    flags == blocks[currentBlock.X, currentBlock.Y].Number &&
                    blocks[currentBlock.X, currentBlock.Y].State != BlockState.Flaged &&
                    blocks[currentBlock.X, currentBlock.Y].State == BlockState.Opened)
                {
                    int startX = -1;
                    int endX = 2;
                    int startY = -1;
                    int endY = 2;

                    if (currentBlock.X - 1 < 0)
                        startX = 0;
                    if (currentBlock.X + 1 > columns - 1)
                        endX = 1;
                    if (currentBlock.Y + 1 > rows - 1)
                        endY = 1;
                    if (currentBlock.Y - 1 < 0)
                        startY = 0;

                    for (int i = currentBlock.X + startX; i < currentBlock.X + endX; i++)
                        for (int j = currentBlock.Y + startY; j < currentBlock.Y + endY; j++)
                        {
                            if (blocks[i, j].Type == BlockType.Bomb && blocks[i, j].State == BlockState.Closed)
                                enableWin = false;

                            BlockClick(i, j);

                        }
                    enableWin = true;
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            if (openBlocks[i, j] != null)
                                openBlocks[i, j].Reset();
                }
            }
            /* if only LEFT mouse button was clicked */
            else if (m_left)
            {
                if (OnBlockClick != null)
                    OnBlockClick(MouseButtons.Left, false, currentBlock);

                BlockClick(currentBlock.X, currentBlock.Y);
            }

            m_left = false;
            m_right = false;
            m_middle = false;
        }

        short getFlagsAmount(int i, int j)
        {
            short flags = 0;

            int startX = -1;
            int endX = 2;
            int startY = -1;
            int endY = 2;

            if (blocks[i, j].X - 1 < 0)
                startX = 0;
            if (blocks[i, j].X+ 1 > columns - 1)
                endX = 1;
            if (blocks[i, j].Y + 1 > rows - 1)
                endY = 1;
            if (blocks[i, j].Y- 1 < 0)
                startY = 0;

            for (int x = blocks[i, j].X + startX; x < blocks[i, j].X + endX; x++)
                for (int y = blocks[i, j].Y + startY; y < blocks[i, j].Y + endY; y++)
                        if (blocks[x, y].State == BlockState.Flaged)
                            flags++;


            return flags;
        }

        public bool BlockClick(int x, int y)
        {
            bool openedBlock = false;
            if (blocks[x, y].State != BlockState.Flaged && blocks[x,y].State != BlockState.Opened)
            {
                blocks[x, y].OpenFull();
                openedBlock = true;
                if (blocks[x, y].Type == BlockType.Empty)
                {
                    blocks[x, y].Close();
                    flood(x, y);
                }

                else if (blocks[x, y].Type == BlockType.Bomb && GameOver != null)
                {
                    blocks[x, y].Type = BlockType.BombPressed;
                    for (int i = 0; i < bombAmount; i++)
                        if(bombs[i].State != BlockState.Flaged)
                            HardClick(bombs[i].X, bombs[i].Y);

                    for(int i = 0; i < flaged.Count;i++)
                        if (flaged[i].Type != BlockType.Bomb &&flaged[i].State == BlockState.Flaged)
                        {
                            flaged[i].Type = BlockType.WrongBomb;
                            HardClick(flaged[i].X, flaged[i].Y);
                        }
                    if(GameOver != null)
                        GameOver();
                    Debug.Print("Game Over");
                }
                else
                    calls++;

                Debug.Print(calls.ToString());
                if (calls + bombAmount >= openCellsToWin && Win != null && enableWin)
                {
                    Win();
                    for (int i = 0; i < BombAmount; i++ )
                        if (bombs[i].State == BlockState.Closed && bombs[i].State != BlockState.Flaged)
                            bombs[i].Flag();
                    Debug.Print("Win");
                }
            }
            return openedBlock;
        }
        private void HardClick(int x, int y)
        {
            if (blocks[x, y].State == BlockState.Flaged)
                blocks[x, y].UnFlag();

            blocks[x, y].OpenFull();
        }
        void flood(int x, int y)
        {
            if (x > columns - 1) return;
            if (x < 0) return;
            if (y > rows - 1) return;
            if (y < 0) return;

            if (blocks[x, y].State != BlockState.Closed || blocks[x, y].Type != BlockType.Empty) 
            {
                if (blocks[x, y].State != BlockState.Opened)
                {
                    blocks[x, y].OpenFull(); 
                    calls++;
                }
                return;
            }

            if (blocks[x, y].State != BlockState.Opened)
            {
                blocks[x, y].OpenFull();
                calls++;
            }

            flood(x - 1, y + 1);
            flood(x + 1, y - 1);
            flood(x + 1, y + 1);
            flood(x - 1, y - 1);

            flood(x + 1, y);
            flood(x, y + 1);
            flood(x, y - 1);
            flood(x - 1, y);
        }

        public void NewGame(int rows, int columns, short bombs)
        {
            if (this.rows != rows || this.columns != columns)
                blocks = null;

            this.rows = rows;
            this.columns = columns;
            this.bombAmount = bombs;

            openCellsToWin = rows * columns;
            calls = 0;

            CreateBlocks();
        }
        public void HardOpenAll()
        {
            calls = 0;
            for (int i = 0; i < Columns; i++)
                for (int j = 0; j < Rows; j++)
                    HardClick(i, j);
        }
        public void CloseAll()
        {
            for (int i = 0; i < Columns; i++)
                for (int j = 0; j < Rows; j++)
                    Blocks[i, j].Close();
        }

        public void FlagAllBombs()
        {
            for (int i = 0; i < bombs.Length; i++)
                if (bombs[i].State != BlockState.Flaged)
                {
                    flaged.Add(bombs[i]);
                    bombs[i].Flag();
                }
        }

        public void UnFlagAll()
        {
            for (int i = 0; i < flaged.Count; i++)
                if (flaged[i].State == BlockState.Flaged)
                    flaged[i].UnFlag();
        }
    }
}
