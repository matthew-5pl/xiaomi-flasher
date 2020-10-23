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

namespace xiaomi_flasher
{
    public partial class Form1 : Form
    {
        private string fileContent;
        private string filePath;

        public Form1()
        {
            InitializeComponent();
            
    }
        
         
        private void button1_Click(object sender, EventArgs e)
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


       
    private void button2_Click(object sender, EventArgs e)
        {
            string file = listBox1.SelectedItem.ToString();
            string slash = "/";
            string fullFileName = fileContent + slash + file;
            Process.Start(fullFileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
