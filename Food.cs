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

        public Food()
        {
            Random random = new Random();
            x = random.Next(20) * 20;
            y = random.Next(20) * 20;
            food = new Rectangle(x, y, width, height);
        }

        public void draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, food);
        }

    }
}
