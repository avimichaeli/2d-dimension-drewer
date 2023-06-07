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
    class Curve
    {
		static Graphics g;
        // draw blue points that between them will be a line , the line will be created by drawline function. 
		public static void PutPixel(float x, float y)
		{
			g.DrawRectangle(new Pen(Color.Blue), x, y, 2, 2);
		}
		
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		public Curve(int number_of_sections_selected,Point p1 , Point p2, Point p3, Point p4, Graphics graphics)
        {
            // defenition of beziuer matrix //
            int first_demention_x = 0 ;
            int second_demention_x = 0 ; 
            int third_demention_x = 0 ;
            int forth_demention_x = 0 ;

            int first_demention_y = 0 ;
            int second_demention_y = 0 ;
            int third_demention_y = 0 ;
            int forth_demention_y = 0 ;

            first_demention_x = (-p1.X) + (3 * p2.X) - (3 * p3.X) + (p4.X);
            second_demention_x = (3 * p1.X) - (6 * p2.X) + (3 * p3.X);
            third_demention_x = (-3 * p1.X) + (3 * p2.X);
            forth_demention_x = p1.X;

            first_demention_y = (-p1.Y) + (3 * p2.Y) - (3 * p3.Y) + (p4.Y);
            second_demention_y = (3 * p1.Y) - (6 * p2.Y) + (3 * p3.Y);
            third_demention_y = (-3 * p1.Y) + (3 * p2.Y);
            forth_demention_y = p1.Y;

            // defenition of bezier matrix //

            // the steps between the bleu points, x,y coodrinates.
            double X_Step = 0.0, Y_Step = 0.0;

            g = graphics;

            // this will be the 't' parametet. that between 0-1, and will be increase in every iteration of the for loop.
            double selected_number_ponts;
            selected_number_ponts = 0;

            // 2 points that will be used in drawline function to create a line between 2 bleu points of the bezier curve
            Point first_point_between_bezier_curve_points_selected=new Point(0,0);
            Point second_point_between_bezier_curve_points_selected = new Point(0, 0);

            // the for loop of t between 0-1.
            for (int i = 0; i <= number_of_sections_selected+1; i++)           
            {

                // x, y vectors of the bezier matrix.
                X_Step = first_demention_x * Math.Pow(selected_number_ponts, 3) + second_demention_x * Math.Pow(selected_number_ponts, 2) + third_demention_x * selected_number_ponts + forth_demention_x;
                Y_Step = first_demention_y * Math.Pow(selected_number_ponts, 3) + second_demention_y * Math.Pow(selected_number_ponts, 2) + third_demention_y * selected_number_ponts + forth_demention_y;
                selected_number_ponts = selected_number_ponts + (double) 1 / number_of_sections_selected;

                // every two blue points a line will be between them , that is the coolection of lines that creates the bezier curve.
                if (i % 2 == 0)
                    first_point_between_bezier_curve_points_selected = new Point((int)X_Step, (int)Y_Step);
                else
                {
                    second_point_between_bezier_curve_points_selected = new Point((int)X_Step, (int)Y_Step);
                    DrawLine drawLine = new DrawLine(first_point_between_bezier_curve_points_selected, second_point_between_bezier_curve_points_selected,g);
                }

                PutPixel((float)X_Step, (float)Y_Step);
            }
        }
		//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	}
}

             
