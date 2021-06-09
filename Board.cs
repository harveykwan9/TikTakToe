using System;

class Board {

    public string[,] coord;

    public Board() {
        init();
        reset();
    }

    // Initialize 3x3 size of board
    private void init() {
        this.coord = new string[3,3];
    }

    // Sets board state to all " "
    public void reset() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                coord[i,j] = " ";
            }
        }
    }

    // Prints the board out to console
    // looks complicated, but it's to make the output look nice
    public void drawBoard() {
        for (int j = 0; j < 2; j++) {
            Console.Write(" " + this.coord[0,j] + " | ");
            Console.Write(this.coord[1,j] + " | ");
            Console.Write(this.coord[2,j] + " ");
            Console.WriteLine("\n-----------");
        }
        Console.Write(" " + this.coord[0,2] + " | ");
        Console.Write(this.coord[1,2] + " | ");
        Console.Write(this.coord[2,2] + " ");
        Console.WriteLine();
    }

}