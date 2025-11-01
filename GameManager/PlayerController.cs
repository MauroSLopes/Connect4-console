using Conect4_Console.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conect4_Console.GameManager
{
    internal class PlayerController
    {
        public char[] players { get; private set; }

        public void InitiatePlayers()
        {
            View.PlayerCreation.Player1CreationMenu();
            var p1 = Console.ReadLine()![0];
            View.PlayerCreation.Player2CreationMenu();
            var p2 = Console.ReadLine()![0];
            Console.Clear();
            players = new char[2]
            {
                p1,
                p2,
            };
        }


    }
}
