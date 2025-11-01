using Conect4_Console.GameManager;
using Conect4_Console.Models.Board;

namespace Conect4_Console.View
{
    internal class GameWinView
    {
        public static void Win(BoardTypes playerTurn, PlayerController playersIcons )
        {
            Console.WriteLine("\n- Game Over -");
            Console.WriteLine($"Player {(playerTurn == BoardTypes.P1 ? playersIcons.players[1] : playersIcons.players[0])} Win");
            Console.WriteLine("EZ");
            Console.ReadLine();
        }
    }
}
