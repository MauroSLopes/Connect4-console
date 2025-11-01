using Conect4_Console.GameManager;

namespace Conect4_Console.Models.Board
{
    internal class Board
    {
        private int rows;
        private int columns;

        private char p1, p2;

        public BoardTypes[,] actualBoard { get; private set; }

        public Board(int numberRows, int numberColumns)
        {
            rows = numberRows;
            columns = numberColumns;

            CreateBoard();
        }

        public void CreateBoard()
        {
            // Create an empty board

            actualBoard = new BoardTypes[rows, columns];

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
                            currentCharacter = p1;
                            break;
                        case BoardTypes.P2:
                            currentCharacter = p2;
                            break;
                        default:
                            currentCharacter = ' ';
                            break;
                    }

                    Console.Write($" {currentCharacter} ");
                }
                Console.WriteLine();
            }

            for (int j = 0; j < actualBoard.GetLength(1); j++)
            {
                Console.Write($" {j + 1} ");
            }
        }

        public bool PlacePieceInColumn(int column, BoardTypes currentPlayer)
        {
            if (column > columns || column <= 0)
            {
                Console.WriteLine("Out of bounds");
                return false;
            }

            for (int i = 0; i < rows; i++)
            {
                if (i + 1 == rows || actualBoard[i + 1, column - 1] != BoardTypes.Empty)
                {
                    if (i == 0 && actualBoard[i, column - 1] != BoardTypes.Empty)
                    {
                        return false;
                    }

                    actualBoard[i, column - 1] = currentPlayer;
                    CheckPlayerWin(currentPlayer, [i, column - 1]);
                    return true;
                }
            }

            return false;
        }

        public void SetPlayerIcons(char p1, char p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        private void CheckPlayerWin(BoardTypes currentPlayer, int[] playerPosition)
        {
            CheckDiagonalWin(currentPlayer, playerPosition, Direction.invertedDiagonalDirection);
            CheckDiagonalWin(currentPlayer, playerPosition, Direction.diagonalDirection);
            CheckHorizontalWin(currentPlayer, playerPosition);
            CheckVerticalWin(currentPlayer, playerPosition);
            checkFullBoard();
        }

        private void CheckDiagonalWin(BoardTypes currentPlayer, int[] playerPosition, int[] direction)
        {
            int playerPiecesInRow = 0;
            int[] startPosition = FindCorner(playerPosition, direction);
            int[] invertedDirection = Direction.invertDirection(direction);

            int j = startPosition[1];

            for (int i = startPosition[0]; i < rows; i = i + invertedDirection[0])
            {

                if (actualBoard[i, j] == currentPlayer)
                {
                    playerPiecesInRow++;

                    if (playerPiecesInRow >= 4)
                    {
                        GameController.GameWinned = true;
                        return ;
                    }
                }
                else
                {
                    playerPiecesInRow = 0;
                }

                j = j + invertedDirection[1];

                if (j >= actualBoard.GetLength(1) || j < 0) return;
            }
        }

        private void CheckHorizontalWin(BoardTypes currentPlayer, int[] playerPosition)
        {
            int playerPiecesInRow = 0;
            int playerPositionRow = playerPosition[0];
            var direction = Direction.horizontalDirection;

            for (int i = 0; i < columns; i++)
            {
                if (actualBoard[playerPositionRow, i] == currentPlayer)
                {
                    playerPiecesInRow++;

                    if (playerPiecesInRow >= 4)
                    {
                        GameController.GameWinned = true;
                        return;
                    }
                }
                else
                {
                    playerPiecesInRow = 0;
                }
            }
        }

        private void CheckVerticalWin(BoardTypes currentPlayer, int[] playerPosition)
        {
            int playerPiecesInRow = 0;
            int playerPositionColumn = playerPosition[1];
            var direction = Direction.horizontalDirection;

            for (int i = 0; i < rows; i++)
            {
                if (actualBoard[i, playerPositionColumn] == currentPlayer)
                {
                    playerPiecesInRow++;

                    if (playerPiecesInRow >= 4)
                    {
                        GameController.GameWinned = true;
                        return;
                    }
                }
                else
                {
                    playerPiecesInRow = 0;
                }
            }
        }
            
        private void checkFullBoard()
        {
            int emptySlotsAvailable = 0;
            for (int i = 0; i < actualBoard.GetLength(0); i++)
            {
                for (int j = 0; j < actualBoard.GetLength(1); j++)
                {
                    if (actualBoard[i,j] == BoardTypes.Empty) emptySlotsAvailable++;
                }

            }

            if (!(emptySlotsAvailable > 0))
            {
                CreateBoard();
            }
        }

        public int[] FindCorner(int[] playerPosition, int[] direction)
        {

            int[] startPosition = new int[2];
            int diagonalSearchColumn = playerPosition[1];

            int columnLimit = direction[1] > 0 ? columns - 1 : 0;

            for (int i = playerPosition[0]; i >= 0 ; i = i + direction[0])
            {
                if (diagonalSearchColumn == columnLimit || i == 0)
                {
                    return startPosition = [i, diagonalSearchColumn];
                }

                diagonalSearchColumn = diagonalSearchColumn + direction[1];
            }

            return [0,0];
        }
    }
}
