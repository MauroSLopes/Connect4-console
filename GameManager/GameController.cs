using Conect4_Console.Models.Board;
using Conect4_Console.View;

namespace Conect4_Console.GameManager
{
    internal class GameController
    {
        private PlayerController players;
        private Board board;
        private BoardTypes currentPlayer = BoardTypes.P1;
        public static bool GameWinned = false;


        public GameController(PlayerController players, Board board)
        {
            this.players = players;
            this.board = board;

            board.SetPlayerIcons(players.players[0], players.players[1]);
        }

        public void GameLoop()
        {
            bool validMoveTest = false;
            while (true)
            {
                while (!validMoveTest)
                {
                    try {
                        Console.Clear();
                        board.ShowBoard();

                        Console.WriteLine($"\n{(currentPlayer == BoardTypes.P1 ? "1" : "2")} Player turn");

                        Console.WriteLine("Select a column to place your piece.");
                        int selectedColumn = Convert.ToInt32(Console.ReadLine()!);
                        validMoveTest = board.PlacePieceInColumn(selectedColumn, currentPlayer);
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                ChangeCurrentPlayer();
                validMoveTest = false;

                if (GameWinned)
                {
                    Console.Clear();
                    board.ShowBoard();
                    GameWinView.Win(currentPlayer, players);
                    return;
                }
            }
        }

        void ChangeCurrentPlayer()
        {
            currentPlayer = currentPlayer == BoardTypes.P1 ? BoardTypes.P2 : BoardTypes.P1;
        }
    }
}
