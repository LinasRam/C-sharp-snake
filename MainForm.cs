using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_Snake
{
    public partial class MainForm : Form
    {
        private Snake snake;
        private Food food;
        private Rules rules;
        private Timer timer;
        private int score = 0;

        public MainForm()
        {
            InitializeComponent();

            rules = new Rules();
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Update;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (timer.Enabled == true)
            {
                food.draw(e);
                snake.draw(e);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    snake.changeDirection('U');
                    return true;
                case Keys.Down:
                    snake.changeDirection('D');
                    return true;
                case Keys.Left:
                    snake.changeDirection('L');
                    return true;
                case Keys.Right:
                    snake.changeDirection('R');
                    return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void Update(object sender, EventArgs e)
        {
            snake.move();
            if (snake.body[0].IntersectsWith(food.food))
            {
                snake.eat();
                food = new Food(snake);
                score++;
                labelScore.Text = string.Format("Score: {0}", score);
            }
            else if (rules.checkAllRules(snake))
            {
                timer.Stop();
            }
            pictureBox1.Invalidate();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            snake = new Snake();
            food = new Food(snake);
            score = 0;
            labelScore.Text = string.Format("Score: {0}", score);

            timer.Start();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        

    }
}
