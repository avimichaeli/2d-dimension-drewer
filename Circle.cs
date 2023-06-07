using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/*---------------------------------------------------------------------------------------------------
 * Students:
 * Nadav benassor   301785663
 * Avraham michaeli 203835749
 ---------------------------------------------------------------------------------------------------*/
namespace WindowsFormsApp1
{
    class Circle
    {
		static Graphics g;
		//--------------------------------------------------------------------------------------------
		/// <summary>
		/// The function will draw a circle on the panel
		/// (x,y) coordinates are the mid point of the circle.
		/// </summary>
		//--------------------------------------------------------------------------------------------
		public static void PutPixel(float x, float y)
		{
			g.DrawRectangle(new Pen(Color.Green), x, y, 2, 2);
		}

		public Circle(int X_Circle , int Y_Circle , int r , Graphics graphics)
        {
			g = graphics;

			int d, x, y;

			d = 3 - (2 * r);
			x = 0;
			y = r;

            while (y >= x)
            {
                x++;

                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }
                PutPixel(X_Circle + x, Y_Circle + y);
                PutPixel(X_Circle - x, Y_Circle + y);
                PutPixel(X_Circle + x, Y_Circle - y);
                PutPixel(X_Circle - x, Y_Circle - y);
                PutPixel(X_Circle + y, Y_Circle + x);
                PutPixel(X_Circle - y, Y_Circle + x);
                PutPixel(X_Circle + y, Y_Circle - x);
                PutPixel(X_Circle - y, Y_Circle - x);

            }
        }
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	}
}
