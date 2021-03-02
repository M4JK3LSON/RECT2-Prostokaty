using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RECT2___Prostokąty
{
    public class Prostokaty
    {
       public  int x1;
       public  int x2;
       public  int y1;
       public  int y2;
       public int wyzszy_x;
       public int wyzszy_y;
        public int mniejszy_x;
        public int mniejszy_y;
        

        public Prostokaty()
        {

        }

        public Prostokaty (int _x1,int _y1,int _x2, int _y2)
        {
            x1 = _x1;
            y1 = _y1;
            x2 = _x2;
            y2 = _y2;
            wyzszyx(_x1, _x2);
            wyzszyy(_y1, _y2);
           
        }
        public void wyzszyx(int x1,int x2)
        {
            if (x1 > x2)
            {
                wyzszy_x = x1;
                mniejszy_x = x2;
            }
            else
            {
                wyzszy_x = x2;
                mniejszy_x = x1;
            }
        }

        public void wyzszyy(int y1, int y2)
        {
            if (y1 > y2)
            {
                wyzszy_y= y1;
                mniejszy_y = y2;
            }
            else
            {
                wyzszy_y = y2;
                mniejszy_y = y1;
            }
        }
    }
}
