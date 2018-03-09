using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MouseGraphics
{
    public partial class Form1 : Form
    {
        static int center_x, center_y;
        static int ellipseWidth, ellipseHeight = 1;
        static bool drawAreaClick = false;

        
        

        Pen myPen = new Pen(Color.Black, 1);
        
        
        Graphics g;
        SolidBrush selectedColor = new SolidBrush(Color.Black);
        Pen brushBoarder = new Pen(Color.Red);
        //ColorDialog ColorDialog;
        

        public Form1()
        {
            InitializeComponent();
            center_x = canvas.Width / 2;
            center_y = canvas.Height / 2;
            //selectedColor = new SolidBrush(Color.Black);
            brushBoarder = new Pen(Brushes.White);
            brushBoarder.Width = 1;

            trackBar1.Minimum = 1;
            trackBar1.Maximum = 100;
            trackBar1.TickFrequency = 10;

            DisplayLine("Brush size is " + ellipseHeight.ToString());


        }

        


        // All-purpose method for displaying a line of text in the
        // text boxe.
        private void DisplayLine(string line)
        {
            textBox2.Invalidate();
            textBox2.Clear();
            textBox2.AppendText(line);
            textBox2.AppendText(Environment.NewLine);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = canvas.CreateGraphics();
            
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            canvas.Invalidate();
            canvas.Refresh();
            textBox2.Invalidate();
            textBox2.Clear();
            drawAreaClick = false;
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            //ellipseHeight = Int32.Parse(textBrushHeight.Text);
            //ellipseWidth = Int32.Parse(textBrushWidth.Text);

            if (drawAreaClick == false)
            {
                drawAreaClick = true;
                textBox2.Clear();
                DisplayLine("Brush size is " + ellipseHeight.ToString());

            }
            else
            {
                drawAreaClick = false;
                textBox2.Clear();
                DisplayLine("Brush size is " + ellipseHeight.ToString()); ;
            }
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = new SolidBrush(colorDialog.Color); 
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ellipseWidth = (int)(trackBar1.Value);
            ellipseHeight = (int)(trackBar1.Value);
        }

        private void trackBar1_Value(object sender, EventArgs e)
        {
            ellipseWidth = (int)(trackBar1.Value);
            ellipseHeight = (int)(trackBar1.Value);
            DisplayLine("Brush size is " + ellipseHeight.ToString());
        }

        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta <= 0)
            {
                ellipseWidth = ellipseWidth + 5;
                ellipseHeight = ellipseHeight + 5;
                DisplayLine("Brush size is " + ellipseHeight.ToString());
            }
            else
            {
                ellipseWidth = ellipseWidth - 5;
                ellipseHeight = ellipseHeight - 5;
                DisplayLine("Brush size is " + ellipseHeight.ToString());
            }
           
            //MessageBox.Show("Mouse Wheel" + ellipseHeight);
            
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (drawAreaClick == true)
            {
                g.FillEllipse(selectedColor, e.Location.X, e.Location.Y, ellipseWidth, ellipseHeight);
                g.DrawEllipse(brushBoarder, e.Location.X, e.Location.Y, ellipseWidth, ellipseHeight);
                
            }
            else
            {
                return;
            }
            
                //g.Dispose();
                        
        }

        


            


        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
