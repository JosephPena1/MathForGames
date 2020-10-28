using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;

        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }

        public static Scene GetScene(int index)
        {
            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }

        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for(int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;
            tempArray[index] = scene;
            _scenes = tempArray;

            return index;
        }

        public static bool RemoveScene(Scene scene)
        {
            if(scene == null)
            {
                return false;
            }

            bool sceneRemoved = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for(int i = 0; i < _scenes.Length; i++)
            {
                if(tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    sceneRemoved = true;
                }
            }

            if(sceneRemoved)
                _scenes = tempArray;

            return sceneRemoved;
        }

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index >= _scenes.Length)
                return;

            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();

            _currentSceneIndex = index;
        }

        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public Game()
        {
            _scenes = new Scene[0];
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Raylib.SetMouseScale(5, 5);
            Raylib.SetMousePosition(0, 0);
            //creates a new window for raylib
            Raylib.InitWindow(1024, 760, "Math Fer Games");
            Raylib.SetTargetFPS(60);

            //set up console window
            Console.CursorVisible = false;
            Console.Title = "Math Fer Games";

            Scene scene1 = new Scene();
            Scene scene2 = new Scene();


            Actor hole = new Actor(2, 0, Color.GRAY, 'P', ConsoleColor.Gray);
            hole.Velocity.X += 1;

            Player player = new Player(1, 0, Color.WHITE, '@', ConsoleColor.White);

            Entity bob = new Entity(5, 5, Color.RED, 'E', ConsoleColor.Red);

            Enemy enemy = new Enemy(10, 10, Color.BLUE, 'T', ConsoleColor.Blue);

            scene1.AddActor(hole);
            scene1.AddActor(bob);
            scene1.AddActor(enemy);
            scene1.AddActor(player);

            enemy.Target = player;
            scene2.AddActor(player);
            player.Speed = 1;

            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(scene1);
            AddScene(scene2);

            SetCurrentScene(startingSceneIndex);
        }

        //Called every frame.
        public void Update(float deltaTime)
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndDrawing();
        }

        //Called when the game ends.
        public void End()
        {
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
        }

        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!_gameOver  && !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
            }

            End();
        }
    }
}