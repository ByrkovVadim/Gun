using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun
{
    public class RandomLine
    {
        public int[,] XYarray = new int[35, 2];
        
        public int step = 25;
        public RandomLine(int height, int random)
        {

            Random rnd = new Random();
            
            XYarray[0, 0] = 0;
            XYarray[0, 1] = height;
            XYarray[1, 0] = 0;
            XYarray[1, 1] = 350;
            XYarray[2, 0] = step;
            XYarray[2, 1] = 350;

            
            for (int i = 3; i < 34; i++)
            {
                if (i == 29)
                {
                    XYarray[i, 0] = i * step;
                    XYarray[i, 1] = 350;
                    continue;
                }
                if (i == 30)
                {
                    XYarray[i, 0] = i * step;
                    XYarray[i, 1] = 350;
                    continue;
                }
                // X
                XYarray[i, 0] = i * step;
                // Y
                XYarray[i, 1] = height - random + rnd.Next(random) - 30;
               
            }
            

            XYarray[34, 0] = 35*step;
            XYarray[34, 1] = height;

        }

        public void DrawLineInt(Graphics g)
        {
            // Create pen.
            Pen greenPen = new Pen(Color.Green, 3);

           for(int i=0;i<34;i++)
            {

                g.DrawLine(greenPen, XYarray[i, 0], XYarray[i, 1], XYarray[i + 1, 0], XYarray[i + 1, 1]);
            }


            g.DrawLine(greenPen, XYarray[34, 0], XYarray[34, 1], XYarray[0, 0], XYarray[0, 1]);
        }
       


    }
}
