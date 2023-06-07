using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*---------------------------------------------------------------------------------------------------
 * Students:
 * Nadav benassor   301785663
 * Avraham michaeli 203835749
 ---------------------------------------------------------------------------------------------------*/
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //--------------------------------------------------------------------------------------------
        /// Project variables
        //--------------------------------------------------------------------------------------------
        //Line variables
        private static bool Two_Points_Selected = false;
        private static Point FirstPoint  = new Point();
        private static Point SecondPoint = new Point();

        //Curve variables
        private static int Fourth_Points_Selected = 0;
        private static Point ThirdPoint = new Point();
        private static Point FourthPoint = new Point();

        //--------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();

            //MessageBox.Show("Hello!\n" + "Choose the wanted form the combobox!");
            string[] forms = {"Line" , "Circle", "Curve"};

            this.comboBox1.Items.AddRange(forms);
        }
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// The function will reterive the X,Y coordinates from the mouse event
        /// </summary>
        //--------------------------------------------------------------------------------------------
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
        
            //Line
            if(this.comboBox1.Text.Equals("Line"))
            {
                //Only one point selected until now
                if (Two_Points_Selected == false)
                {
                    Two_Points_Selected = true;
                    MessageBox.Show("First point selected! , select another one");
                    FirstPoint.X = e.X;
                    FirstPoint.Y = e.Y;
                }
                else //Two points selected
                {
                    Two_Points_Selected = false;
                    SecondPoint.X = e.X;
                    SecondPoint.Y = e.Y;

                    DrawLine line = new DrawLine(FirstPoint, SecondPoint, this.panel1.CreateGraphics());
                }
            }
            //=======================================================================================
            //Circle
            else if (this.comboBox1.Text.Equals("Circle"))
            {
                //Only the circle center point was selected
                if (Two_Points_Selected == false)
                {
                    Two_Points_Selected = true;
                    MessageBox.Show("The circle point was selected!\nSelect another point as the radius");
                    FirstPoint.X = e.X;
                    FirstPoint.Y = e.Y;
                }
                else //Circle radius was selected
                {
                    Two_Points_Selected = false;
                    
                    //Calculate the radius length
                    int x = Math.Abs(e.X - FirstPoint.X);
                    x = x * x;

                    int y = Math.Abs(e.Y - FirstPoint.Y);
                    y = y * y;
                    double leng = (x + y);
                    leng = Math.Sqrt(leng);

                    int raduis = (int) leng;
                    Circle c = new Circle(FirstPoint.X, FirstPoint.Y, raduis , this.panel1.CreateGraphics());
                }
            }
            // Curve
            else if (this.comboBox1.Text.Equals("Curve"))
            {
                Graphics gg = this.panel1.CreateGraphics();
                switch (Fourth_Points_Selected)
                {
                    case 0:
                        Fourth_Points_Selected++;
                        FirstPoint.X = e.X;
                        FirstPoint.Y = e.Y;
                        gg.DrawRectangle(new Pen(Color.Red), e.X, e.Y, 20, 20);
                        break;
                    case 1:
                        Fourth_Points_Selected++;
                        SecondPoint.X = e.X;
                        SecondPoint.Y = e.Y;
                        gg.DrawRectangle(new Pen(Color.Red), e.X, e.Y, 20, 20);
                        break;
                    case 2:
                        Fourth_Points_Selected++;
                        ThirdPoint.X = e.X;
                        ThirdPoint.Y = e.Y;
                        gg.DrawRectangle(new Pen(Color.Red), e.X, e.Y, 20, 20);
                        break;
                    case 3:
                        Fourth_Points_Selected = 0;
                        FourthPoint.X = e.X;
                        FourthPoint.Y = e.Y;
                        gg.DrawRectangle(new Pen(Color.Red), e.X, e.Y, 20, 20);

                        // the defult  blue points on the bezier curve will be 30 points. and the number can be changed in run time.
                        int number_of_sections_selected= 30;
                        if(number_of_sections_tb.Text=="")
                        {
                            number_of_sections_selected = 30;
                        }
                        else
                        {
                            // input check. checks if the value that was written is currect
                            bool pared = int.TryParse(number_of_sections_tb.Text,out int input);
                            if (pared)
                                number_of_sections_selected = input;
                        }
                            
                        Curve _Curve = new Curve(number_of_sections_selected, FirstPoint, SecondPoint,ThirdPoint,FourthPoint,this.panel1.CreateGraphics());
                    break;
                }
            }

        }
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Clear the panel. 
        /// </summary>
        //--------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( this.comboBox1.Text.Equals("Line") )
            {
                MessageBox.Show("Select to points on the panel"); 
            }
            else if (this.comboBox1.Text.Equals("Circle"))
            {
                MessageBox.Show("Select one points on the panel and enter the circle radius");
            }
            else if (this.comboBox1.Text.Equals("Curve"))
            {
                MessageBox.Show("Select 4 points on the panel");
            }
        }

       
        //--------------------------------------------------------------------------------------------
    }
}
