using System;
using System.Drawing;
using System.Windows.Forms;


namespace MouseGraphics
{
    public partial class Form1 : Form
    {
        //Initialize variables
        static int ellipseWidth, ellipseHeight = 1;
        static bool drawAreaClick = false;

        //Initialize Graphics,Pen,Brush
        Pen myPen = new Pen(Color.Black, 1);
        Pen brushBoarder = new Pen(Color.White);
        SolidBrush selectedColor = new SolidBrush(Color.Black);
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            brushBoarder.Width = 1;
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 100;
            trackBar1.TickFrequency = 10;

            DisplayLine("Brush size is " + ellipseHeight.ToString());

        }

        // All-purpose method for displaying a line of text in the
        // text boxes - from MSDN
        private void DisplayLine(string line)
        {
            textBox2.Invalidate();
            textBox2.Clear();
            textBox2.AppendText(line);
            textBox2.AppendText(Environment.NewLine);
        }

        //Create graphics for the control
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = canvas.CreateGraphics();

        }

        //Clear and reset Drawing area
        private void clear_btn_Click(object sender, EventArgs e)
        {
            canvas.Invalidate();
            canvas.Refresh();
            textBox2.Invalidate();
            textBox2.Clear();
            drawAreaClick = false;
        }

        //Enable/Disable drawing and display Brush size
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
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

        //Create Color Dialog option
        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = new SolidBrush(colorDialog.Color);
            }
        }


        //Set Brush size with trackBar
        private void trackBar1_Value(object sender, EventArgs e)
        {
            ellipseWidth = (int)(trackBar1.Value);
            ellipseHeight = (int)(trackBar1.Value);
            DisplayLine("Brush size is " + ellipseHeight.ToString());
        }


        //Set Brush size with MouseWheel and update text
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

        }

        //Draw to canvas when ever the mouse has moved
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

        }









        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
