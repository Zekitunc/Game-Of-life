using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_porject2_Game_Of_Life
{
    internal class Generation :Cell
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public Cell[,] Cells { get; set; }

        public Generation(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Cells = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    Cells[i, j] = new Cell();// for null exception
        }

        public Generation(int rows, int cols, int numLivingCells)
        {
            Rows = rows;
            Cols = cols;
            Cells = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    Cells[i, j] = new Cell(); // for null exception

            // Initialize the board with random living cells
            Random rand = new Random();
            for (int i = 0; i < numLivingCells; i++)
            {
                int row = rand.Next(rows);
                int col = rand.Next(cols);
                if (!Cells[row, col].IsAlive)
                {
                    Cells[row, col].IsAlive = true;
                }
                else
                   i--;
            }
        }

        public Generation(int rows, int cols, double density)
        {
            Rows = rows;
            Cols = cols;
            Cells = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    Cells[i, j] = new Cell();// for null exception

            // Initialize the board with living cells based on the given density
            double numLivingCells = rows * cols * density / 100;
            Random rand = new Random();
            for (int i = 0; i < numLivingCells; i++)
            {
                int row = rand.Next(rows);
                int col = rand.Next(cols);
                if (!Cells[row, col].IsAlive)
                {
                    Cells[row, col].IsAlive = true;
                }
                else
                    i--;
            }
        }

        public Generation(int rows, int cols, string boardString)
        {
            Rows = rows;
            Cols = cols;
            Cells = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    Cells[i, j] = new Cell();// for null exception

            // Initialize the board based on the given string
            int index = 0;
            for (int satır = 0; satır < rows; satır++)
            {
                for (int sütün = 0; sütün < cols; sütün++)
                {
                    Cells[satır, sütün].IsAlive = (boardString[index] == '1');
                    index++;
                }
                if (boardString.Length-index>index)
                    index += 4;
            }
        }

        public static bool operator ==(Generation g1, Generation g2)
        {
            if (g1.Rows != g2.Rows || g1.Cols != g2.Cols)
            {
                return false;
            }

            for (int i = 0; i < g1.Rows; i++)
            {
                for (int j = 0; j < g1.Cols; j++)
                {
                    if (g1.Cells[i, j].IsAlive != g2.Cells[i, j].IsAlive)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Generation g1, Generation g2)
        {
            return !(g1 == g2);
        }

        public override string ToString()
        {
           
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sb.Append(Cells[i, j].IsAlive ? '1' : '0');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public Generation GenerateNextGeneration(int numSteps)
        {
            Generation currentGen = this;
            for (int step = 0; step < numSteps; step++)
            {
                Generation nextGen = new Generation(Rows, Cols);
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        int numNeighbors = GetNumNeighbors(currentGen, i, j);
                        bool isAlive = currentGen.Cells[i, j].IsAlive;
                        if (isAlive)
                        {
                            // Cell is alive
                            if (numNeighbors == 2 || numNeighbors == 3)
                            {
                                // Cell stays alive
                                nextGen.Cells[i, j] = new Cell(true);
                            }
                            else
                            {
                                // Cell dies
                                nextGen.Cells[i, j] = new Cell(false);
                            }
                        }
                        else
                        {
                            // Cell is dead
                            if (numNeighbors == 3)
                            {
                                // Cell becomes alive
                                nextGen.Cells[i, j] = new Cell(true);
                            }
                            else
                            {
                                // Cell stays dead
                                nextGen.Cells[i, j] = new Cell(false);
                            }
                        }
                    }
                }
                currentGen = nextGen;
            }
            return currentGen;
        }

        private int GetNumNeighbors(Generation gen, int row, int col)
        {
            int count = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < Rows && j >= 0 && j < Cols && (i != row || j != col))
                    {
                        if (gen.Cells[i, j].IsAlive)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
