using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_Snake
{
    class Food
    {
        private int x, y;
        private int width = 20, height = 20;
        public Rectangle food;
        Random random = new Random();

        public Food(Snake snake)
        {
            generateXY(snake);
            food = new Rectangle(x, y, width, height);
        }

        public void draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, food);
        }

        private void generateXY(Snake snake)
        {
            x = random.Next(20) * 20;
            y = random.Next(20) * 20;
            for (int i = 0; i < snake.body.Length; i++)
            {
                if (snake.body[i].X == x || snake.body[i].Y == y)
                    generateXY(snake);
            }
        }

    }
}
