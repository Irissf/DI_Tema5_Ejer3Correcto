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

namespace ReproductorDeImagenes
{
    public partial class Form1 : Form
    {
        private List<Image> imagenesDelFichero = new List<Image>();
        int num;

        public Form1()
        {
            InitializeComponent();
        }

        private void userControl11_ClickEnPuse(object sender, EventArgs e)
        {

            if (reproductor.PausePlay)
            {
                //si estaba en pause 
                timer1.Enabled = false;
                reproductor.PausePlay = false;
                menuStrip1.Enabled = true;

            }
            else
            {
                //si estaba en play
                timer1.Enabled = true;
                reproductor.PausePlay = true;
                menuStrip1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            reproductor.Yy++;
            GestionImagenes();
        }

        private void reproductor_DesbordaTiempo(object sender, EventArgs e)
        {
            
            reproductor.Xx++;

        }

        private void cargarGaleriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imagenesDelFichero.Clear();
            num = 0;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string path;
            FileInfo[] imagenes;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                imagenes = directoryInfo.GetFiles();
                if (!reproductor.PausePlay)
                {
                    for (int i = 0; i < imagenes.Length; i++)
                    {
                        try
                        {
                            Image image = Image.FromFile(imagenes[i].FullName);
                            imagenesDelFichero.Add(image);
                        }
                        catch (OutOfMemoryException) { }
                        catch (FileNotFoundException) { }
                        catch (ArgumentException) { }

                    }
                }
            }
            if(imagenesDelFichero.Count == 0)
            {
                MessageBox.Show("No hay imágenes en ese directorio");
            }
        }

        private void GestionImagenes()
        {
            if (num == imagenesDelFichero.Count)
            {
                num = 0;
            }
            if (imagenesDelFichero.Count > 0)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = imagenesDelFichero[num];
            }

            num++;



        }
    }
}
