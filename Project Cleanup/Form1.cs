using System;
using System.IO;
using System.Windows.Forms;

namespace Project_Cleanup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (string file in Directory.GetFiles(path))
            {
                string filetype = file.Split('.')[file.Split('.').Length - 1];
                string filename = file.Split('\\')[file.Split('\\').Length - 1];
                try
                {
                    string filedir = path + "\\Master Folder\\" + filetype;
                    Directory.CreateDirectory(filedir);
                    File.Move(path + "\\" + filename, filedir + "\\" + filename);
                }
                catch (Exception ex)
                {

                }
                
            }

            try
            {
                Directory.CreateDirectory(path + "\\Master Folder\\.folders");
            }catch (Exception ex)
            {

            }
            

            foreach (string file in Directory.GetDirectories(path))
            {
                string filename = file.Split('\\')[file.Split('\\').Length - 1];
                if (!filename.ToLower().Equals("master folder"))
                {
                    try
                    {
                        string filedir = path + "\\Master Folder\\.folders\\" + filename;
                        Directory.Move(file, filedir);
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }

            MessageBox.Show("Finished Desktop Cleanup!");

        }
    }
}
