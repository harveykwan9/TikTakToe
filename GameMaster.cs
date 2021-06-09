using System;

namespace tiktactoe 
{

class GameMaster 
    {
        private Board board;
        private int turn;

        public GameMaster() {
            board = new Board();
            turn = 1;
            mainMenuState();
        }

        // Main menu, asks several options
        // Start Game or Exit
        public void mainMenuState() {
            Console.WriteLine("\n");
            Console.WriteLine("Play TikTacToe? [Y|N]: ");
            string input = Console.ReadLine();
            if (input == "Y" || input == "y") {
                board.reset();
                gameState();
            } 
            else if (input == "N" || input == "n") {
                System.Environment.Exit(1);
            }
        }

        // Controls and draws during the in game state
        // checking - bounds, format, if cell is occupied
        // outputs error reason
        private void gameState() {
            Console.WriteLine("\n");
            board.drawBoard();
            Console.WriteLine("Player " + this.turn + " - Enter Coordinates [x,y]: ");
            string input = Console.ReadLine();
            string[] split = input.Split(',');
            int x;
            int y;
            try {
                x = Int32.Parse(split[0]);
                y = Int32.Parse(split[1]);
                try {
                    this.place(x,y);
                } catch (IndexOutOfRangeException) {
                    Console.WriteLine("\n");
                    Console.WriteLine("Error, out of bounds");
                    this.gameState();
                }
                
            } catch (FormatException) {
                Console.WriteLine("\n");
                Console.WriteLine("Error, invalid coordinate");
                this.gameState();
            }
        }

        // checks for all 8 win conditions
        // if win cond. met, throw you back to menu, and display last game board with a congrats message.
        // else do absolutely nothing
        private void winCond() {
            for (int i = 0; i < 3; i++) {
                if (board.coord[i,0] == board.coord[i,1] && board.coord[i,0] == board.coord[i,2] && board.coord[i,0] != " ") {
                    Console.WriteLine("\n");
                    board.drawBoard();
                    Console.WriteLine("Player " + this.turn + " wins! Congrats");
                    this.mainMenuState();
                }
                if (board.coord[0,i] == board.coord[1,i] && board.coord[0,i] == board.coord[2,i] && board.coord[0,i] != " ") {
                    Console.WriteLine("\n");
                    board.drawBoard();
                    Console.WriteLine("Player " + this.turn + " wins! Congrats");
                    this.mainMenuState();
                }
            }
            if (board.coord[0,0] == board.coord[1,1] && board.coord[0,0] == board.coord[2,2] && board.coord[1,1] != " ") {
                Console.WriteLine("\n");
                board.drawBoard();
                Console.WriteLine("Player " + this.turn + " wins! Congrats");
                this.mainMenuState();
            }
            if (board.coord[0,2] == board.coord[1,1] && board.coord[0,2] == board.coord[2,0] && board.coord[1,1] != " ") {
                Console.WriteLine("\n");
                board.drawBoard();
                Console.WriteLine("Player " + this.turn + " wins! Congrats");
                this.mainMenuState();
            }
        }

        // checks to see if the entire board is filled
        // if filed, throw you back to menu, and display a draw message
        // else do absolutely nothing
        private void isFilled() {
            int temp = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board.coord[i,j] != " ") {
                        temp++;
                        if (temp == 9) {
                            Console.WriteLine("\n");
                            board.drawBoard();
                            Console.WriteLine("Draw! Nobody wins :(");
                            this.mainMenuState();
                        }
                    }
                }
            }
        }

        // places players piece onto the board
        // after placement, checks for draws or wins - which will spit us back to menu
        // if not, we switch the turn, and continue gamestate.
        private void place(int x, int y) {
            if (board.coord[x,y] == " ") {
                if (this.turn == 1) {
                    board.coord[x,y] = "O";
                    this.isFilled();
                    this.winCond();
                    this.turn = 2;
                    this.gameState();
                } 
                else {
                    board.coord[x,y] = "X";
                    this.isFilled();
                    this.winCond();
                    this.turn = 1;
                    this.gameState();
                }
            }
            else {
                Console.WriteLine("\n");
                Console.WriteLine("Error, cell is occupied already");
                this.gameState();
            }
        }

    }

}