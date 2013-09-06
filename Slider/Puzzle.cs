using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slider
{
    class Puzzle
    {
        private int numRows, numCols;
        private int[,] numGrid = new int[10, 10];
        private int[,] orgGrid = new int[10, 10];

        public Puzzle() { }
        //initialize
        public Puzzle(int rows, int cols)
        {
            numRows = rows;
            numCols = cols;

            for (int i = 0, value = 1; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++, value++)
                {
                    numGrid[i, j] = value;
                    orgGrid[i, j] = value;
                }
            }        
        }
        public int get_rows()
        {
            return numRows;
        }

        public int get_cols()
        {
            return numCols;
        }

        public int[,] get_grid()
        {
            return numGrid;
        }

        public void MoveRowRight(int moveRow)
        {
            int colIndex = numCols - 1;
            int temp = numGrid[moveRow, colIndex];
            //move right
            while (colIndex > 0)
            {
                numGrid[moveRow, colIndex] = numGrid[moveRow, --colIndex];
            }
            numGrid[moveRow, colIndex] = temp;
        }

        public void MoveColDown(int moveCol)
        {
            int rowIndex = numRows - 1;
            int temp = numGrid[rowIndex, moveCol];
            //move down
            while (rowIndex > 0)
            {
                numGrid[rowIndex, moveCol] = numGrid[--rowIndex, moveCol];
            }
            numGrid[rowIndex, moveCol] = temp;
        }

        public void Shuffle(int seed)
        {
            int numMoves = numRows * numCols;
            int numDir = numRows + numCols;
            int direction, randRow, randCol;
            Random r = new Random(seed);
            for (int i = 0; i < numMoves; i++)
            {
                // randomly select whether we move a row or a column
                direction = r.Next() % numDir;
                if (direction < numRows)
                {
                    // move a randomly selected row right
                    randRow = r.Next() % numRows;
                    MoveRowRight(randRow);
                }
                else
                {
                    // move a randomly selected column down
                    randCol = r.Next() % numCols;
                    MoveColDown(randCol);
                }
            }
        }

        public bool isSolved()
        {
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (numGrid[i, j] != orgGrid[i, j])
                        return false;
                }
            }
            return true;
        }
    }
}
