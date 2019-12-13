using System;
using System.IO;
using System.Linq;
 
public class Board
{
    public static int[,] CreateBoard(int[,] board, int numRows, int numCols){
        for (int r = 0; r < numRows; r++)        //calculate value at each spot
            for (int c = 0; c < numCols; c++)
            {
                int locMines = 0;
                if (board[r, c] != -1)
                {
                    if (r > 0 && c > 0 && board[r - 1, c - 1] == -1)  //check each neighbor only if legal
                        locMines++;
                    if (r > 0 && board[r - 1, c] == -1)
                        locMines++;
                    if (r > 0 && c < numCols - 1 && board[r - 1, c + 1] == -1)
                        locMines++;
                    if (c > 0 && board[r, c - 1] == -1)
                        locMines++;
                    if (c < numCols - 1 && board[r, c + 1] == -1)
                        locMines++;
                    if (r < numRows - 1 && c > 0 && board[r + 1, c - 1] == -1)
                        locMines++;
                    if (r < numRows - 1 && board[r + 1, c] == -1)
                        locMines++;
                    if (r < numRows - 1 && c < numCols - 1 && board[r + 1, c + 1] == -1)
                        locMines++;
                    board[r, c] = locMines;
                }
            }
        return board;
    }
 
    public static void DisplayBoard(int[,] board, int numRows, int numCols){ //display used in print_board
        for (int i = 0; i < numRows; i++)
            {
                string row = "";
                for (int j = 0; j < numCols; j++)
                {
                    if(board[i, j] == -1)
                        row += "M ";
                    else
                        row += board[i, j] + " ";
                }
                Console.WriteLine(row.Trim());
            }
    }
    public static void DisplayBoard(string[,] board, int numRows, int numCols){  //overloaded display
    //used in play game, displayes the userBoard
        for (int i = 0; i < numRows; i++){
            string row = "";
            for (int j = 0; j < numCols; j++)
                row += board[i, j] + " ";
            Console.WriteLine(row.Trim());
        }
    }
//used in play game when something is revealed that is not a mine
    public static void Reveal(int r, int c, int[,] board, string[,] userBoard, int numRows, int numCols){
        if(r >= numRows || c >= numCols){
            Console.WriteLine("Invalid row or column");
            return;
        }
        if(board[r, c] != 0){               //reveal single number if not 0
            userBoard[r, c] = board[r, c] + "";
            return;
        }
        /*
        Go through every neighbor just like CreateBoard(), but set the userBoard value at any
        spot that is 0 to that value, and then call the Reveal() method on that spot. Avoids 
        repeat work and infnite loops by only checking neighbors that are unrevealed in
        userBoard, because things that have already been revealed should have already
        been through the process. 
         */
        else if(board[r,c] == 0){
            userBoard[r,c] = "0";
            if (r > 0 && c > 0 )  //check each neighbor only if 0
                if((board[r - 1, c - 1] != -1) && (userBoard[r - 1, c - 1].Equals("-"))){
                    userBoard[r - 1,c - 1] = "0";
                    Reveal(r - 1, c - 1, board, userBoard, numRows, numCols);
                }
            if (r > 0)
                if(board[r - 1, c] != -1 && userBoard[r - 1, c].Equals("-")){
                    userBoard[r - 1,c] = "0";
                    Reveal(r - 1, c, board, userBoard, numRows, numCols);
                }
            if (r > 0 && c < numCols - 1)
                if(board[r - 1, c + 1] != -1 && userBoard[r - 1, c + 1].Equals("-")){
                    userBoard[r - 1,c + 1] = "0";
                    Reveal(r - 1, c + 1, board, userBoard, numRows, numCols);
                }
            if (c > 0)
                if(board[r, c - 1] != -1 && userBoard[r, c - 1].Equals("-")){
                    userBoard[r,c - 1] = "0";
                    Reveal(r, c - 1, board, userBoard, numRows, numCols);
                }
            if (c < numCols - 1)
                if(board[r, c + 1] != -1 && userBoard[r, c + 1].Equals("-")){
                    userBoard[r,c + 1] = "0";
                    Reveal(r, c + 1, board, userBoard, numRows, numCols);
                }
            if (r < numRows - 1 && c > 0)
                if(board[r + 1, c - 1] != -1 && userBoard[r + 1, c - 1].Equals("-")){
                    userBoard[r + 1,c - 1] = "0";
                    Reveal(r + 1, c - 1, board, userBoard, numRows, numCols);
                }
            if (r < numRows - 1)
                if (board[r + 1, c] != -1 && userBoard[r + 1, c].Equals("-")){
                    userBoard[r + 1,c] = "0";
                    Reveal(r + 1, c, board, userBoard, numRows, numCols);
                }
            if (r < numRows - 1 && c < numCols - 1)
                if(board[r + 1, c + 1] != -1 && userBoard[r + 1, c + 1].Equals("-")){
                    userBoard[r + 1,c + 1] = "0";
                    Reveal(r + 1, c + 1, board, userBoard, numRows, numCols);        
                } 
        }
        else
            return;
    }
    public static void PrintBoard()
    {
        int numTests = Convert.ToInt32(Console.ReadLine());
        for (int t = 0; t < numTests; t++)                  //get data and insert mines
        {
            string[] nums = Console.ReadLine().Split(' ');
            int numRows = Convert.ToInt32(nums[0]);
            int numCols = Convert.ToInt32(nums[1]);
            int numMines = Convert.ToInt32(nums[2]);
            // TODO: create the board
            //Begin my code
            int[,] board = new int[numRows, numCols];
            //End my code
            for (int m = 0; m < numMines; m++)
            {
                string[] coords = Console.ReadLine().Split(' ');
                int row = Convert.ToInt32(coords[0]);
                int col = Convert.ToInt32(coords[1]);
                // TODO: add mine at row/col to the board
                //Begin my code
                board[row, col] = -1;
                //End my code
            }
            board = CreateBoard(board, numRows, numCols);
            DisplayBoard(board, numRows, numCols);
            //End my code
          //  Console.WriteLine(board);
        }
    }
 
 
 
    public static void PlayGame()
    {
//Begin my code
        string[] nums = Console.ReadLine().Split(' ');
        int numRows = Convert.ToInt32(nums[0]);
        int numCols = Convert.ToInt32(nums[1]);
        int numMines = Convert.ToInt32(nums[2]);
        int[,] board = new int[numRows, numCols];
        for (int m = 0; m < numMines; m++)
        {
            string[] coords = Console.ReadLine().Split(' ');
            int row = Convert.ToInt32(coords[0]);
            int col = Convert.ToInt32(coords[1]);
            board[row, col] = -1;
        }
        board = CreateBoard(board, numRows, numCols);  //create the board, but still -1, not M
        string[,] userBoard = new string[numRows, numCols];  //create initial board that user accesses
        for (int r = 0; r < numRows; r++)
            for (int c = 0; c < numCols; c++)
                userBoard[r, c] = "-";
        int numActions = 0;
        bool playing = true;
        while(numActions < numRows * numCols && playing){  //playing the game, exit if all possible moves made
            Console.WriteLine("Enter the number of actions you want to take");
            string stringNumMoves = Console.ReadLine();
            int numMoves = int.Parse(stringNumMoves);
 
            for(int i = 0; i < numMoves; i++){ //only go through number of moves
                Console.WriteLine("Enter the command you want. R or M, x and y starting from 0");
                string[] command = Console.ReadLine().Split(' ');
                string action = command[0] + "";
                int row = Convert.ToInt32(command[1]);
                int col = Convert.ToInt32(command[2]);
                Console.WriteLine($"{action} {row} {col}"); //string interpolation. git gud
                
                //These are the three actions. Reveal a mine, mark a mine, or reveal a number
                 
                if(action.Equals("R") && board[row,col] == -1){ //if there is a mine there, done
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("Below is the actual board.");
                    DisplayBoard(board, numRows, numCols);
                    playing = false;
                    break;
                }
                else if(action.Equals("M")){ //only marking, display after setting val
                    userBoard[row, col] = "M";
                    DisplayBoard(userBoard, numRows, numCols);
                }
                else if(action.Equals("R")){
                    Reveal(row, col, board, userBoard, numRows, numCols);  //recursive reveal
                    DisplayBoard(userBoard, numRows, numCols);  //display after
                }
                else{
                    Console.WriteLine("Invalid input, exiting"); //if input not right
                    playing = false;
                    break;
                }
                numActions++;
            }
        }
        Console.WriteLine("The game is finished.");
    }
 
 
    public static void Main(string[] args)
    {
        // This redirects the program to read standard in (i.e. the Console, 
        // which is equivalent to System.in in Java) from the given file.
        // This is one of a *very few* places where it's actually OK to catch
        // and ignore an exception
        try
        {
            Console.SetIn(new StreamReader("minetest7.txt"));
        }
        catch (Exception e)
        {
            // ignore!
            // We will just read from standard in if the file cannot be found and read
        }
 
        string inputType = Console.ReadLine();
        if (inputType.Equals("print_board"))
        {
 
            PrintBoard();
        }
        else if (inputType.Equals("play_game"))
        {
            PlayGame();
        }
        else
        {
            throw new System.InvalidOperationException($"{inputType} is not a valid Minesweeper input file type"); 
        }
 
    }
}
