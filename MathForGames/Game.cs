using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static ConsoleKey GetNextKey()
        {
            //if user hasn't pressed a key return
            if (!Console.KeyAvailable)
            {
                return 0;
            }

            return Console.ReadKey(true).Key;
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            _scene = new Scene();

            GolfBall ball = new GolfBall(10, 0, '∙', ConsoleColor.White);
            ball.Velocity.Y = 1;

            Actor hole = new Actor(10, 15, 'P', ConsoleColor.Red);

            //Actor actor = new Actor(0, 0, 'Ω', ConsoleColor.Green);
            //actor.Velocity.X = 1;

            Player player = new Player(1, 0, '@', ConsoleColor.Red);

            if (ball.Position.X == hole.Position.X & ball.Position.Y == hole.Position.Y)
            {
                ball.Velocity.Y = 0;
                ball.Velocity.X = 0;
                Game.SetGameOver(true);
            }

            _scene.AddActor(hole);
            _scene.AddActor(ball);
            _scene.AddActor(player);
        }

        //Called every frame.
        public void Update()
        {
            _scene.Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
        }

        //Called when the game ends.
        public void End()
        {

        }

        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                Console.CursorVisible = false;
                Update();
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
                Thread.Sleep(150);
            }

            End();
        }
    }
}