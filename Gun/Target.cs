using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun
{
    public class Target
    {
        public int[,] XYtarget = new int[4, 2];
        
        public Target(int locationX, int locationY)
        {
            //X0
            XYtarget[0, 0] = locationX - 10;
            //Y0
            XYtarget[0, 1] = locationY - 10;
            //X1
            XYtarget[1, 0] = locationX - 10;
            //Y1
            XYtarget[1, 1] = locationY + 10;
            //X2
            XYtarget[2, 0] = locationX + 10;
            //Y2
            XYtarget[2, 1] = locationY + 10;
            //X3
            XYtarget[3, 0] = locationX + 10;
            //Y3
            XYtarget[3, 1] = locationY - 10;
        }
        public void DrawLineTarget(Graphics g)
        {
            Pen redPen = new Pen(Color.Red, 3);
            for (int i = 0; i<3;i++)
            {
                g.DrawLine(redPen, XYtarget[i, 0], XYtarget[i, 1], XYtarget[i + 1, 0], XYtarget[i + 1, 1]);
            }
            g.DrawLine(redPen, XYtarget[3, 0], XYtarget[3, 1], XYtarget[0, 0], XYtarget[0, 1]);

        }
    }
}
