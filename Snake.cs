using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_Snake
{
    class Snake
    {
        public enum Direction
        {
            Up, Down, Left, Right
        };
        private int width = 20, height = 20;
        public Rectangle[] body;
        public Direction direction;

        public Snake()
        {
            Rectangle rectangle = new Rectangle(180, 180, width, height);
            List<Rectangle> bodyList = new List<Rectangle>();
            bodyList.Add(rectangle);
            body = bodyList.ToArray();
            direction = Direction.Right;
        }

        public void draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangles(Brushes.Green, body);
        }

        public void changeDirection(int c)
        {
            switch (c)
            {
                case 'U':
                    if (direction != Direction.Down)
                        direction = Direction.Up;
                    break;
                case 'D':
                    if (direction != Direction.Up)
                        direction = Direction.Down;
                    break;
                case 'L':
                    if (direction != Direction.Right)
                        direction = Direction.Left;
                    break;
                case 'R':
                    if (direction != Direction.Left)
                        direction = Direction.Right;
                    break;
            }
        }

        public void move()
        {
            moveSnake();
            switch (direction)
            {
                case Direction.Up:
                    body[0].Y -= 20;
                    break;
                case Direction.Down:
                    body[0].Y += 20;
                    break;
                case Direction.Left:
                    body[0].X -= 20;
                    break;
                case Direction.Right:
                    body[0].X += 20;;
                    break;
            }
        }

        public void eat()
        {
            Rectangle temp = body[body.Length - 1];
            List<Rectangle> bodyList = body.ToList();
            bodyList.Add(temp);
            body = bodyList.ToArray();
        }

        private void moveSnake()
        {
            for (int i = body.Length - 1; i > 0; i--)
            {
                body[i] = body[i - 1];
            }
        }

    }
}
