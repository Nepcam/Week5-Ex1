using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace PracTest2
{
    public partial class Form1 : Form
    {
        //Name: Cameron Nepe
        //Id: 1262199

        //The day number that Saturday falls on
        const int SATURDAY = 6;
        //The number of days to display in the planner
        const int NUM_DAYS = 7;
        //The minimum number of hours to display
        const int MIN_HOURS = 1;
        //The maximum number of hours to display
        const int MAX_HOURS = 24;
        //the colour of a weekday appointment (a variable since Color datatype cannot be a const)
        Color WEEK_DAY_COLOR = Color.White;
        //the colour of a weekend appointment (a variable since Color datatype cannot be a const)
        Color WEEK_END_COLOR = Color.LightBlue;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxNumOfHours.Clear();
            pictureBoxDisplay.Refresh();
            textBoxNumOfHours.Focus();
        }

        private void btnDrawPlanner_Click(object sender, EventArgs e)
        {
            //Where to draw the graphics
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            //Brush to fill blocks
            SolidBrush br = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.Black, 3);
            //Declare variables
            int numOfHours;
            int numOfDays = 7;
            //x position of appointment block
            int x = 0;
            //y position of appointment block
            int y = 0;

            try
            {
                //GET the number of hours
                numOfHours = int.Parse(textBoxNumOfHours.Text);
                //IF number of hours is valid THEN
                if (numOfHours <= MAX_HOURS)
                {
                    //Calculate width of appointment
                    int apptWidth = pictureBoxDisplay.Width / NUM_DAYS;
                    //Calculate height of appointment
                    int apptHeight = pictureBoxDisplay.Height / numOfHours;
                    //FOR each hour to draw
                    for (int row = 1; row <= numOfHours; row++)
                    {
                        //FOR each day to draw
                        for (int col = 1; col <= numOfDays; col++)
                        {
                            //IF day is Saturday OR day is Sunday THEN
                            if (col == SATURDAY || col == 7)
                            {
                                //Set colour to Light Blue
                                br.Color = Color.LightBlue;
                            }
                            else
                            {
                                //Set colour to White
                                br.Color = Color.White;
                            }//ENDIF
                             //Draw appointment at current x and y position
                             paper.FillRectangle(br, x, y, apptWidth, apptHeight);
                             paper.DrawRectangle(pen, x, y, apptWidth, apptHeight);
                            //Shift x position to right by appointment width
                            x+= apptWidth;                           
                        }//ENDFOR
                         //Shift y position down by appointment height
                         y += apptHeight;
                        //Shift x position to beginning of row
                        x = 0;
                    }//ENDFOR
                }
                else 
                {
                    //DISPLAY error message
                    MessageBox.Show("Enter a number of hours please");
                }
            }
            catch (Exception ex)
            {
                //Display error message
                MessageBox.Show(ex.Message);
                //Clear number of hours textbox
                textBoxNumOfHours.Clear();
                pictureBoxDisplay.Refresh();
                //Give focus to the number of hours textbox
                textBoxNumOfHours.Focus();
            }//End Try
        }
    }
}
