using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gun
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        int x = 0, y = 0;
      
        double t = 0;// Время
        double v = 90;// Скорость
        const double g = 9.8;
        int shot = 0;
        RandomLine rl;

        Target tg;

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            
            rl = new RandomLine(this.pictureBox1.Height, 100);
            tg = new Target(735,338);// Рачположение цели на форме
           

            Paintpicture();

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 10;

        }
        private void Paintpicture()
        {
            Bitmap bmp = new Bitmap(984, 450);
            Graphics graph = Graphics.FromImage(bmp);

            rl.DrawLineInt(graph);

            tg.DrawLineTarget(graph);


            Draw_Bullet(graph);

            pictureBox1.Image = bmp;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            string flag ="";
            t += 0.1;
            double arad = (int)this.numericUpDown1.Value * Math.PI / 180;
            x = (int)(0 + (v * Math.Cos(arad)) * t);
            y = (int)(350-(v * Math.Sin(arad)) * t  +  g * t * t / 2);

            bool checkIn = check_bullet((int)x, (int)y);
            bool checktg = check_target((int)x, (int)y);
            if (checkIn == true) //Снаряд не попал в цель
            {
                timer.Enabled = !timer.Enabled;
                flag = "Промах!";
                x = 0;
                y = 0;
                t = 0;
                button1.Enabled = !button1.Enabled;
                numericUpDown1.Enabled = !numericUpDown1.Enabled;
            }
            if(checktg == true) //Снаряд попал в цель
            {
                timer.Enabled = !timer.Enabled;
                flag = "Попал!";
                MessageBox.Show("Победа!");
                x = 0;
                y = 0;
                t = 0;
                button1.Enabled = !button1.Enabled;
                numericUpDown1.Enabled = !numericUpDown1.Enabled;
            }
      
            this.Text = " Произведено выстрелов:"+ shot +" " + flag;

            Paintpicture();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            shot = shot + 1;
            timer.Enabled = !timer.Enabled;
            button1.Enabled = !button1.Enabled;
            numericUpDown1.Enabled = !numericUpDown1.Enabled;
        }
       

        void Draw_Bullet(Graphics g)
        {
            if (t > 0)
            {
                g.FillRectangle(Brushes.Red, new Rectangle((int)(x), (int)(y), 5, 5));
            }
        }

        bool check_bullet(int pointX, int pointY)
        {

            bool result = false;

            int j = 34;
            int[,] p = this.rl.XYarray;

            for (int i = 0; i < 34; i++)
            {
                if ((p[i,1] < pointY && p[j,1] >= pointY || p[j,1] < pointY && p[i,1] >= pointY) &&
                     (p[i,0] + (pointY - p[i,1]) / (p[j,1] - p[i,1]) * (p[j,0] - p[i,0]) < pointX))
                    result = !result;
                j = i;
            }
            return result;
        }
        bool check_target(int Xbul, int Ybul)
        {
            bool result = false;

            if (Xbul>=715 && Xbul<=735 && Ybul>=318 && Ybul <= 358)
            {
                result = !result;
            }

            return result;

        }
    }
}
