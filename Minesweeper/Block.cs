using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Minesweeper.Properties;

namespace Minesweeper
{
    public partial class Block : UserControl
    {
        public BlockState State {get; set;}
        BlockType type;
        public BlockType Type 
        {
            get { return type; }
            set 
            {
                type = value;
                if (type != BlockType.Number)
                    number = 0;
            } 
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        byte number;
        public byte Number
        {
            get { return number; }
            set
            {
                if (value < 0 || value > 9) return;
                if (type == BlockType.Number)
                    number = (byte)value; 
            }
        }

        void setImage()
        {
        	switch(State)
        	{
        		case BlockState.Closed:
                    this.BackgroundImage = Resources.Block;
        			break;
        		case BlockState.Flaged:
                    this.BackgroundImage = Resources.Flaged;
        			break;
        		case BlockState.Opened:
        			setImage(type);
        			break;

        	}
        }
        void setImage(BlockType type)
        {
            switch (type)
            {
                case BlockType.Bomb:
                    this.BackgroundImage = Resources.Bomb;
                    break;

                case BlockType.BombPressed:
                    this.BackgroundImage = Resources.BombExploded;
                    break;

                case BlockType.Empty:
                    this.BackgroundImage = Resources.Empty;
                    break;

                case BlockType.WrongBomb:
                    this.BackgroundImage = Resources.WrongBomb;
                    break;

                case BlockType.Number:
                    if (Number == 0)
                        this.BackgroundImage = Resources.Empty;
                    else if (Number == 1)
                        this.BackgroundImage = Resources.Nmb_one;
                    else if (Number == 2)
                        this.BackgroundImage = Resources.Nmb_two;
                    else if (Number == 3)
                        this.BackgroundImage = Resources.Nmb_three;
                    else if (Number == 4)
                        this.BackgroundImage = Resources.Nmb_four;
                    else if (Number == 5)
                        this.BackgroundImage = Resources.Nmb_five;
                    else if (Number == 6)
                        this.BackgroundImage = Resources.Nmb_six;
                    else if (Number == 7)
                        this.BackgroundImage = Resources.Nmb_seven;
                    else if (Number == 8)
                        this.BackgroundImage = Resources.Nmb_eight;
                    else if (Number == 9)
                        this.BackgroundImage = Resources.Nmb_nine;
                    break;
            }
        }

        public Block(int x, int y)
        {
            InitializeComponent();

            this.X = x;
            this.Y = y;
        }

        public void TurnIntoNumber()
        {
            if (this.Type == BlockType.Empty)
                type = BlockType.Number;
                
            number++;
        }
        public Block Open()
        {
            if (this.State != BlockState.Opened && this.State != BlockState.Flaged)
                setImage(BlockType.Empty);
            return this;
        }
        public void OpenFull()
        {
            if (this.State != BlockState.Flaged)
            {
                State = BlockState.Opened;
                
                setImage();
            }

        }
        public void Flag()
        {
            if(State != BlockState.Opened)
        	    State = BlockState.Flaged;
        	setImage();
        }
        public void UnFlag()
        {
        	State = BlockState.Closed;
        	setImage();
        }
        
        public void Close()
        {
            State = BlockState.Closed;
            setImage();
        }

        public void Reset()
        {
            setImage();
        }
    }
}
