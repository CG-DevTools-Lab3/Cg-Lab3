using cg22_model.Models;

namespace cg22_project_3_guys_1_computer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            îòêðûòüToolStripMenuItem.Click += OpenFile;
            ñîõðàíèòüToolStripMenuItem.Click += SaveAsFile;
        }

        // TODO: Check for memory leak (bitmap.Dispose)
        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            Bitmap bitmap = new Bitmap(1, 1);
            try
            {
                var reader = new FileReaderSaver();
                bitmap.Dispose();
                bitmap = reader.OpenFile(filename); // "..\\..\\..\\..\\testPNM.pnm"
                pictureBox1.Image = bitmap;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SaveAsFile(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Empty file!");
                return;
            }

            saveFileDialog1.Filter = "Portable Any Map|*.pnm";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            if (saveFileDialog1.FileName != "")
            {
                try
                {
                    string filename = saveFileDialog1.FileName;
                    var saver = new FileReaderSaver();
                    var formatProperty = pictureBox1.Image.GetPropertyItem(4096);
                    var magicNumber = new string(new char[] { Convert.ToChar(formatProperty.Value[0]), Convert.ToChar(formatProperty.Value[1]) });
                    saver.SaveAs(filename, magicNumber, new Bitmap(pictureBox1.Image));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Empty filename!");
            }

            return;
        }
    }
}