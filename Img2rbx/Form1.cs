using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Img2rbx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.ShowDialog();
                textBox1.Text = OFD.FileName;
            }
        }
        string Result = "";
        string FileName = $"Result.lua";
        private async void button2_Click(object sender, EventArgs e)
        {
            var a = new Task(() =>
            {
                Bitmap bmp = new Bitmap(textBox1.Text);
                Size Size = bmp.Size;
                int x = Size.Width;
                int y = Size.Height;
                // Data type:
                // X Y R G B

                File.AppendAllText(FileName, $"{x},{y},");
                for (int cX = 1; cX < x; cX++)
                {
                    for (int cY = 1; cY < y; cY++)
                    {
                        Color c = bmp.GetPixel(cX, cY);
                        Write2List(cX, cY, c.R, c.G, c.B);
                    }
                }
                StatusText.Text = "Finished";
                Result.TrimEnd(',');
                File.WriteAllText("Result.lua", Result);
            });
            a.Start();
        }
        int index = 0;
        private void Write2List(int X, int Y, int R, int G, int B)
        {
            if(!(index > 10))
            {
                File.AppendAllText(FileName, $"{X},{Y},{R},{G},{B},");
            }
            else
            {
                index = 0;
                File.AppendAllText(FileName, $"{X},{Y},{R},{G},{B},\n");
            }
            /*
            if (!(index > 10))
            {
                Result = $"{Result}{X},{Y},{R},{G},{B},";
            }
            else
            {
                index = 0;
                Result = $"{Result}{X},{Y},{R},{G},{B},\n";
            }
            */
            index++;
        }
    }
}
