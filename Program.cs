using Conect4_Console.GameManager;
using Conect4_Console.Models.Board;

Board board = new Board(6,7);

PlayerController players = new PlayerController();
players.InitiatePlayers();

GameController controller = new(players, board);

controller.GameLoop();