using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;


/*---------------------------------------------------------------------------------------------------
 * Students:
 * Nadav benassor   301785663
 * Avraham michaeli 203835749
 ---------------------------------------------------------------------------------------------------*/
namespace WindowsFormsApp1
{
    class DrawLine
    {
        //--------------------------------------------------------------------------------------------
        /// Project variables
        //--------------------------------------------------------------------------------------------
        
        private static Point FirstPoint = new Point();
        private static Point SecondPoint = new Point();
        private static Graphics g;
       
    // draw line function
        public DrawLine(Point p1 , Point p2 , Graphics graphics)
        {
            FirstPoint  = p1;
            SecondPoint = p2;
            g = graphics;

            DDA();
        }
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// The function will draw one point(pixel) on the panel
        /// In (x,y) coordinates.
        /// </summary>
        //--------------------------------------------------------------------------------------------
        public static void PutPixel(float x, float y)
        {
            g.DrawRectangle(new Pen(Color.Red), x, y, 5, 5);
        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// DDA algorithm will draw a line from the two givin points 
        /// </summary>
        //--------------------------------------------------------------------------------------------
        public static void DDA()
        {
            //Step 1 - calculate the delta X and Y values
            float dx = Math.Abs(FirstPoint.X - SecondPoint.X);
            float dy = Math.Abs(FirstPoint.Y - SecondPoint.Y);

            //Step 2 - calculate the number of "steps"
            int steps = 0;
            if (dx > dy)
            {
                steps = int.Parse((Math.Abs(dx).ToString()));
            }
            else
            {
                steps = int.Parse((Math.Abs(dy).ToString()));
            }

            //Step 3 - calculate the "size" of each step
            float X_Inc = (float)(((float)dx / (float)steps));
            float Y_Inc = (float)((float)dy / (float)steps);

            float x = FirstPoint.X + X_Inc;
            float y = FirstPoint.Y + Y_Inc;

            //Step 4 - cases were the draw line points are:
            //         1.Drawing "Backwords".
            //         2/Drawing "Bottem up".
            if (FirstPoint.X > SecondPoint.X)
            {
                X_Inc = X_Inc * -1;
            }
            if (FirstPoint.Y > SecondPoint.Y)
            {
                Y_Inc = Y_Inc * -1;
            }

            //Step 5 - draw the fixels
            for (int i = 0; i < steps; i++)
            {
                 PutPixel(x, y);
                x += X_Inc;
                y += Y_Inc;
            }

        }
    }
}
