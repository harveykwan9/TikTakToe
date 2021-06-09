using System;

namespace tiktactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello Ana!");
            // Board board = new Board();
            // board.coord[2,1] = "0";
            // board.drawBoard();
            GameMaster game = new GameMaster();
            game.mainMenuState();
        }
    }
}
