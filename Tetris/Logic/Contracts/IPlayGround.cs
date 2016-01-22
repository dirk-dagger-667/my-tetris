namespace Tetris.Logic.Contracts
{
    using System;

    public interface IPlayGround
    {
        byte[,] Grid { get; set; }
    }
}
