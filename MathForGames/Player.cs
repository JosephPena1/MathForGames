using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        public float _speed = 1;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }

        public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {

        }

        public override void Update(float deltaTime)
        {

            int xVelocity = Raylib.GetMouseX();
            int yVelocity = Raylib.GetMouseY();

            Velocity = new Vector2(xVelocity, yVelocity);
            Velocity = Velocity.Normalized * Speed;

            base.Update(deltaTime);
        }
    }
}