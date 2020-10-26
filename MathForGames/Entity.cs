using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Entity : Actor
    {
        public Entity(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
        }

        public Entity(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
        }

        public override void Update(float deltaTime)
        {
            Random random = new Random();
            int movement = random.Next(1, 5);

            int xVelocity = 0;
            int yVelocity = 0;

            //moves enemy in random direction
            switch (movement)
            {
                case 1:
                    xVelocity = 1;
                    break;
                case 2:
                    xVelocity = -1;
                    break;
                case 3:
                    yVelocity = -1;
                    break;
                case 4:
                    yVelocity = 1;
                    break;
                case 5:
                    yVelocity = 0;
                    break;
            }

            Velocity = new Vector2(xVelocity, yVelocity);
            Velocity = Velocity.Normalized;

            base.Update(deltaTime);
        }
    }
}