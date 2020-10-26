using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows;

namespace xiaomi_flasher
{

    public partial class Form1 : Form
    {
        int mov;
        int movX;
        int movY;
        int movX2;
        int movY2;
        int mov2;
        

        private HashSet<Control> controlsToMove = new HashSet<Control>();
        private string fileContent;
        private string filePath;
        private string file;


        public Form1()
        {
            InitializeComponent();
        }


        public void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
           
            mov = 1;
            
            movX = e.X;
            
            movY = e.Y;

        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
            {
                

                listBox1.Items.Clear();
                
                

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.SelectedPath;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.ToString();

                    fileContent = openFileDialog.SelectedPath;

                    



                    foreach (var file in Directory.EnumerateFiles(fileContent))
                    {
                        string extension = Path.GetExtension(file);

                        if (string.Compare(extension, ".bat", true) == 0)
                        {
                            listBox1.Items.Add(Path.GetFileName(file));
                        }

                        
                        


                    }
                }
                
            }
        }


       
    private void pictureBox2_Click(object sender, EventArgs e)
        {
            string file = listBox1.SelectedItem.ToString();
            string slash = "/";
            string fullFileName = fileContent + slash + file;
            Process.Start(fullFileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
