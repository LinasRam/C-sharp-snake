using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Snake
{
    class Rules
    {
        public Rules()
        {
            
        }

        private bool hitWall(Snake snake)
        {
            if (snake.body[0].X < 0 || snake.body[0].X > 380 ||
                snake.body[0].Y < 0 || snake.body[0].Y > 380)
                return true;
            else return false;
        }

        private bool hitItself(Snake snake)
        {
            for (int i = 1; i < snake.body.Length; i++)
            {
                if (snake.body[0].IntersectsWith(snake.body[i]))
                    return true;
            }
            return false;
        }

        public bool checkAllRules(Snake snake)
        {
            if (hitWall(snake) || hitItself(snake))
                return true;
            else return false;
        }

    }
}
