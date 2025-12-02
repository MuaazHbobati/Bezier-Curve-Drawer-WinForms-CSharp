using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;                  //*************************************************//
using System.Drawing;               //********** Libraries included by default ********//
using System.Linq;                  //*************************************************//
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier_Curves
{
    // Note: //
    /* This homework is divided into 4 classes, Inheritance and objects were used in programming to take advantage of OOP concepts */


    public partial class Form1 : Form      // This class relates to the interface and inherits from the Form class //
    {
        private bool Is_Draw_Button_Clicked = false; // This variable for know whether the allow drawing button was pressed or not (T,F)  //
        private Points Points_Obj;                   // This object for manage points from points class //
        private Drawing Drawing_Obj;                 // This object for manage drawing from drawing class //

        public Form1()                               // Definition of the constructor method for this class //
        {
            InitializeComponent();                   // Initializing form components //
            Points_Obj = new Points(25, 5);          // Assigning the max num of points that can be drawn //
            Drawing_Obj = new Drawing(Points_Obj);   // Link a points object to a drawing object //
        }

        private void btn_Drw_Click(object sender, EventArgs e)                     // Event when the draw btn is clicked //
        {
            Is_Draw_Button_Clicked = true;           // Make this variable true when the user ckick drw btn //
        }

        private void panel2_Paint(object sender, PaintEventArgs e)                 // Event when repainting the panel2 //
        {
            Drawing_Obj.Draw_The_Points_on_Panel(e.Graphics, this.Font);  // Call the method for draw points on panel2 //
        }

        private void btn_Clear_Click(object sender, EventArgs e)                   // Event when the clear btn is clicked //
        {
            if (Is_Draw_Button_Clicked == true && Points_Obj.Get_The_Num_of_Points() >= 1)
            {
                if (MessageBox.Show("Are you serious about cleaning?", "Confirm the clear process", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Is_Draw_Button_Clicked = false;         // Make this variable false when the user ckick clear btn // 
                    Points_Obj.Clear_The_Points();          // Call method for delete the points stored in points obj //
                    panel2.Invalidate();                    // Redraw the panel2 //
                };
            }
        }

        private void btn_De_Casteljau_Click(object sender, EventArgs e)             // Event when the de casteljau btn is clicked //
        {
            if (Points_Obj.Get_The_Num_of_Points() > 1)               // Check if num of points more than 1 //
            {
                using (Graphics g = panel2.CreateGraphics())          // Create a graphics obj for draw on panel2 //
                {
                    Drawing_Obj.Draw_Bezier_Curves_For_All_Points(g); // Call method for drw all curves //
                    Drawing_Obj.Draw_The_Bounding_Rectangle(g);       // And call method for drw frame around points //
                }
            }
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)              // Event when the panel2 is clicked by user //
        {
            if (Is_Draw_Button_Clicked) // This condition does't allow to click on the panel2 if does't click drawing btn //
            {
                Points_Obj.Add_This_Point(e.X, e.Y);   // method for add a new point to points obj //
                panel2.Invalidate();                   // Redraw panel2 after adding a new point //
            }
            else MessageBox.Show("Hey my friend! \n\n You must click on the Draw Points button  ;).");
        }
    }

    public class Drawing                 // This class to manage drawing //
    {
        private Points Points_Obj;

        public Drawing(Points Points_Obj)   // Constructor for the Drawing class which called by form1 class//
        {
            this.Points_Obj = Points_Obj;   // Link the points obj from form1 whith this point obj //
        }

        public void Draw_The_Points_on_Panel(Graphics g, Font font)     // This method to draw points on the panel //
        {
            float[,] points = Points_Obj.Get_The_Points();           // get the stored points from points class by points  obj //
            int Num_of_Points = Points_Obj.Get_The_Num_of_Points();  // get the num of points from points class by points obj //

            for (int i = 0; i < Num_of_Points; i++)   // This is loop for print all points in panel2 //
            {
                string The_Place_of_Point = "(" + points[i, 0] + "," + points[i, 1] + ")";                    // The Form of the place of x,y like this: (x,y) (132,43) //
                Draw_String(g, The_Place_of_Point, font, Brushes.Blue, points[i, 0] + 8, points[i, 1] - 3);   // Draw any string on panel2 //
                Draw_Circle(g, Brushes.Orange, points[i, 0] - 4, points[i, 1] - 4, 7, 7);                     // Draw the point as a circle on panel2 //

            }
        }

        public void Draw_The_Bounding_Rectangle(Graphics g)             // This Method for draw the bounding rectangle (Frame) around all points //
        {
            float[,] points = Points_Obj.Get_The_Points();          // array to get the stored points //
            int Num_of_Points = Points_Obj.Get_The_Num_of_Points(); // get the num of points //

            if (Num_of_Points == 0)                                 // if no points, go out //
                return;

            float Min_Value_of_X = points[0, 0], Max_Value_of_X = points[0, 0];  // Variabels to finding the min and max coordinates for x,y // 
            float Min_Value_of_Y = points[0, 1], Max_Value_of_Y = points[0, 1];

            for (int i = 1; i < Num_of_Points; i++)  // For loop to cheack all points to determine boundaries //
            {
                if (points[i, 0] < Min_Value_of_X)
                    Min_Value_of_X = points[i, 0];
                if (points[i, 0] > Max_Value_of_X)
                    Max_Value_of_X = points[i, 0];
                if (points[i, 1] < Min_Value_of_Y)
                    Min_Value_of_Y = points[i, 1];
                if (points[i, 1] > Max_Value_of_Y)
                    Max_Value_of_Y = points[i, 1];
            }

            // To create the rectangle: //

            RectangleF Frame = new RectangleF(Min_Value_of_X, Min_Value_of_Y, Max_Value_of_X - Min_Value_of_X, Max_Value_of_Y - Min_Value_of_Y); // bounding//
            Draw_Rectangle(g, new Pen(Color.Red, 3), Frame);                                                                                     // drawing //
        }

        public void Draw_Bezier_Curves_For_All_Points(Graphics g)                // Method to draw all bezier curves //
        {
            float[,] points = Points_Obj.Get_The_Points();           // get the stored points from points object //
            int Num_of_Points = Points_Obj.Get_The_Num_of_Points();  // get the num of points from points object //

            for (int j = 2; j <= Num_of_Points; j++)                 // This is loop for print all bezier curves on panel2 //
            {
                Draw_Bezier_Curve_For_One_Point(g, points, j);       // And this metod to print bezier curve for each loop//
            }
        }

        private void Draw_Bezier_Curve_For_One_Point(Graphics g, float[,] points, int count)
        {
            int Continuation_of_The_Line = 100;                      //This variable control in num of point on bezier curve //
                                                                     // like this: .  .   .  .  . or ....... or  ------ etc  //

            for (int i = 0; i < Continuation_of_The_Line; i++)       // This is loop for draw each point on bezier curves //
            {
                float t = i / (float)Continuation_of_The_Line;       // Calculate t  between 0 and 1 //
                Coordinate point = De_Casteljau(points, count, t);   // Calculate the point using De Casteljau //
                Draw_Circle(g, Brushes.Red, point.X, point.Y, 3, 3);
            }
        }

        private Coordinate De_Casteljau(float[,] points, int count, float t) // To calculate the point using De Casteljau //
        {
            float[,] tempPoints = new float[count, 2];
            Copy_Array(points, tempPoints, count * 2);  // Copy the original points to the temporary //
            int c = count;

            /* The de Casteljau's algorithm */

            for (int k = 1; k < c; k++)
            {
                for (int i = 0; i < c - k; i++)
                {
                    tempPoints[i, 0] = (1 - t) * tempPoints[i, 0] + t * tempPoints[i + 1, 0];  // for x //
                    tempPoints[i, 1] = (1 - t) * tempPoints[i, 1] + t * tempPoints[i + 1, 1];  // for y //
                }
            }

            return new Coordinate(tempPoints[0, 0], tempPoints[0, 1]);
        }

        private void Draw_String(Graphics g, string text, Font font, Brush brush, float x, float y)   // This method to draw string on panel2 //
        {
            g.DrawString(text, font, brush, x, y);
        }

        private void Draw_Circle(Graphics g, Brush brush, float x, float y, float width, float height) // This method to draw circles //
        {
            g.FillEllipse(brush, x, y, width, height);
        }

        private void Draw_Rectangle(Graphics g, Pen pen, RectangleF rect)                              // This method to draw rectangles //
        {
            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void Copy_Array(float[,] source, float[,] destination, int length)                     // This method copy point arrays //
        {
            for (int i = 0; i < length / 2; i++)
            {
                destination[i, 0] = source[i, 0];
                destination[i, 1] = source[i, 1];
            }
        }
    }

    public class Points                  // This class to manage point //
    {
        private float[,] points;
        private int Max_Points;          // Max num of points //
        private int Max_Draw_Points;       // Max numb of drawable points //
        private int The_Num_of_Points;

        public Points(int Max_Points, int Max_Drawing_Points)    // Constructor for the Points class //
        {
            // Link this class components whith another //

            this.Max_Points = Max_Points;
            this.Max_Draw_Points = Max_Drawing_Points;
            points = new float[Max_Points, 2];
            The_Num_of_Points = 0;
        }
        public void Add_This_Point(float x, float y)             // This method to add a new point //
        {
            if (The_Num_of_Points < Max_Draw_Points)   //To limit the num of drawing points //
            {
                points[The_Num_of_Points, 0] = x;
                points[The_Num_of_Points, 1] = y;
                The_Num_of_Points++;
            }
        }

        public void Clear_The_Points()                           // This method to remove the stored points //
        {
            The_Num_of_Points = 0;
        }

        public int Get_The_Num_of_Points()                      //  This method to get the num pf points //
        {
            return The_Num_of_Points;
        }

        public float[,] Get_The_Points()                       // This method to get the stored points array //
        {
            return points;
        }
    }

    public class Coordinate              // This class to represent or coordinate point //
    {
        // Encapsulation the variabels //
        public float X { get; set; }
        public float Y { get; set; }

        public Coordinate(float x, float y) // Constructor for the Points class //
        {
            X = x;
            Y = y;
        }
    }
}