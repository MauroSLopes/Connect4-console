using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conect4_Console.Board
{
    internal class Board
    {
        private int rows;
        private int columns;

        public BoardTypes[,] actualBoard { get; private set; }

        public Board(int numberRows, int numberColumns)
        {
            this.rows = numberRows;
            this.columns = numberColumns;

            CreateBoard();
        }

        public void CreateBoard()
        {
            // Create an empty board

            actualBoard = new BoardTypes[rows,columns];

            for (int i = 0; i < actualBoard.GetLength(0); i++)
            {
                for (int j = 0; j < actualBoard.GetLength(1); j++)
                {
                    actualBoard[i, j] = BoardTypes.Empty;
                }
                
            }
        }

        public void ShowBoard()
        {
            // Show board in screen
            for (int i = 0; i < actualBoard.GetLength(0); i++)
            {
                for (int j = 0; j < actualBoard.GetLength(1); j++)
                {
                    char currentCharacter;
                    switch (actualBoard[i, j])
                    {
                        case BoardTypes.Empty:
                            currentCharacter = '#';
                            break;
                        case BoardTypes.P1:
                            currentCharacter = 'O';
                            break;
                        case BoardTypes.P2:
                            currentCharacter = 'X';
                            break;
                        default:
                            currentCharacter = ' ';
                            break;
                    }

                    Console.Write($" {currentCharacter} ");
                }
                Console.WriteLine();
            }
        }

        public void ChangeBoardCell(int row, int column, BoardTypes newType)
        {
            if (row > actualBoard.GetLength(0) - 1)
            {
                Console.WriteLine("Out of bounds");
                return;
            }

            if(column > actualBoard.GetLength(1) - 1)
            {
                Console.WriteLine("Out of bounds");
                return;
            }

            actualBoard[row, column] = newType;
        }
    }
}
