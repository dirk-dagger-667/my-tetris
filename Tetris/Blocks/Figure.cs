﻿namespace Tetris.Blocks
{
    using System;
    
    using Tetris.Blocks.Contracts;

    public class Figure : IFigure
    {
        private int positionX;
        private int positionY;

        public Figure(int coordX, int coordY)
        {
            this.PositionX = coordX;
            this.PositionY = coordY;
            this.Blocks = new byte[1, 1];
        }

        public byte[,] Blocks { get; set; }

        public int PositionX 
        {
            get
            {
                return this.positionX;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The X position of the shape cannot be negative");
                }

                this.positionX = value;
            }
        }

        public int PositionY
        {
            get
            {
                return this.positionY;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The X position of the shape cannot be negative");
                }

                this.positionY = value;
            }
        }

        public IFigure CloneShape()
        {
            var clonedShape = new Figure(this.PositionX, this.PositionY);
            clonedShape.Blocks = new byte[this.Blocks.GetLength(0), this.Blocks.GetLength(1)];

            for (int row = 0; row < clonedShape.Blocks.GetLength(0); row++)
            {
                for (int col = 0; col < clonedShape.Blocks.GetLength(1); col++)
                {
                    clonedShape.Blocks[row, col] = this.Blocks[row, col];
                }
            }

            return clonedShape;
        }
    }
}
