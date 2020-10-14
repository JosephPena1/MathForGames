using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class GolfBall : Actor
    {
        public GolfBall(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }

        //
        public void MoveBall()
        {

        }

        public override void Update()
        {
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight - 1);

            base.Update();
        }
    }
}