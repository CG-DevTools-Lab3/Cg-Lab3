using System.Diagnostics;
using System.Runtime.CompilerServices;
using cg22_model.Models;
using cg22_model.Models.ColorSpacesSpaces;

namespace cg22_project_3_guys_1_computer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            currentColorSpace = new RGB();
            открытьToolStripMenuItem.Click += OpenFile;
            сохранитьToolStripMenuItem.Click += SaveAsFile;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem)
        {
            selectedMenuItem.Checked = true;
            
            foreach (var ltoolStripMenuItem in (from object
                             item in selectedMenuItem.Owner.Items
                         let ltoolStripMenuItem = item as ToolStripMenuItem
                         where ltoolStripMenuItem != null
                         where !item.Equals(selectedMenuItem)
                         select ltoolStripMenuItem))
                (ltoolStripMenuItem).Checked = false;
            
            selectedMenuItem.Owner.Show();
        }

        public void SetStreamsNames(string[] names)
        {
            toolStripMenuItemComponent1.Text = names[0];
            toolStripMenuItemComponent2.Text = names[1];
            toolStripMenuItemComponent3.Text = names[2];
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            try
            {
                var reader = new FileReaderSaver();

                trueFloatImage = API.OpenImage(filename, currentColorSpace);
                shownFloatImage = trueFloatImage;

                pictureBox1.Image = shownFloatImage.GetBitmap();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
            colorStreamToolStripMenuItem.Enabled = true;
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
                    API.SaveImage(filename, shownFloatImage);
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

        private void toolStripMenuItemRGB_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemRGB.Checked)
            {
                return;
            }

            if (trueFloatImage == null)
            {
                UncheckOtherToolStripMenuItems(toolStripMenuItemRGB);
                currentColorSpace = new RGB();
                SetStreamsNames(currentColorSpace.GetComponentsNames());
            }
            else
            {
                if (trueFloatImage.ToRGB())
                {
                    shownFloatImage = trueFloatImage;
                    pictureBox1.Image = shownFloatImage.GetBitmap();
                    UncheckOtherToolStripMenuItems(toolStripMenuItemRGB);
                    UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
                    currentColorSpace = new RGB();
                    SetStreamsNames(currentColorSpace.GetComponentsNames());
                    MessageBox.Show("�������������� �������");
                }
                else
                {
                    MessageBox.Show("�������������� �� �������");
                }
            }
        }

        private void toolStripMenuItemHSL_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemHSL.Checked)
            {
                return;
            }

            if (trueFloatImage == null)
            {
                UncheckOtherToolStripMenuItems(toolStripMenuItemHSL);
                currentColorSpace = new HSL();
                SetStreamsNames(currentColorSpace.GetComponentsNames());
            }
            else
            {
                if (trueFloatImage.ToHSL())
                {
                    shownFloatImage = trueFloatImage;
                    pictureBox1.Image = shownFloatImage.GetBitmap();
                    UncheckOtherToolStripMenuItems(toolStripMenuItemHSL);
                    UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
                    currentColorSpace = new HSL();
                    SetStreamsNames(currentColorSpace.GetComponentsNames());
                    MessageBox.Show("�������������� �������");
                }
                else
                {
                    MessageBox.Show("�������������� �� �������");
                }
            }
        }

        private void toolStripMenuItemHSV_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemHSV.Checked)
            {
                return;
            }

            if (trueFloatImage == null)
            {
                UncheckOtherToolStripMenuItems(toolStripMenuItemHSV);
                currentColorSpace = new HSV();
                SetStreamsNames(currentColorSpace.GetComponentsNames());
            }
            else
            {
                if (trueFloatImage.ToHSV())
                {
                    shownFloatImage = trueFloatImage;
                    pictureBox1.Image = shownFloatImage.GetBitmap();
                    UncheckOtherToolStripMenuItems(toolStripMenuItemHSV);
                    UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
                    currentColorSpace = new HSV();
                    SetStreamsNames(currentColorSpace.GetComponentsNames());
                    MessageBox.Show("�������������� �������");
                }
                else
                {
                    MessageBox.Show("�������������� �� �������");
                }
            }
        }

        private void toolStripMenuItemYCbCr601_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemYCbCr601.Checked)
            {
                return;
            }

            if (trueFloatImage == null)
            {
                UncheckOtherToolStripMenuItems(toolStripMenuItemYCbCr601);
                currentColorSpace = new YCbCr601();
                SetStreamsNames(currentColorSpace.GetComponentsNames());
            }
            else
            {
                if (trueFloatImage.ToYCbCr601())
                {
                    shownFloatImage = trueFloatImage;
                    pictureBox1.Image = shownFloatImage.GetBitmap();
                    UncheckOtherToolStripMenuItems(toolStripMenuItemYCbCr601);
                    UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
                    currentColorSpace = new YCbCr601();
                    SetStreamsNames(currentColorSpace.GetComponentsNames());
                    MessageBox.Show("�������������� �������");
                }
                else
                {
                    MessageBox.Show("�������������� �� �������");
                }
            }
        }

        private void toolStripMenuItemYCbCr709_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemYCbCr709.Checked)
            {
                return;
            }

            if (trueFloatImage == null)
            {
                UncheckOtherToolStripMenuItems(toolStripMenuItemYCbCr709);
                currentColorSpace = new YCbCr709();
                SetStreamsNames(currentColorSpace.GetComponentsNames());
            }
            else
            {
                if (trueFloatImage.ToYCbCr709())
                {
                    shownFloatImage = trueFloatImage;
                    pictureBox1.Image = shownFloatImage.GetBitmap();
                    UncheckOtherToolStripMenuItems(toolStripMenuItemYCbCr709);
                    UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
                    currentColorSpace = new YCbCr709();
                    SetStreamsNames(currentColorSpace.GetComponentsNames());
                    MessageBox.Show("�������������� �������");
                }
                else
                {
                    MessageBox.Show("�������������� �� �������");
                }
            }
        }

        private void toolStripMenuItemYCoCg_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemYCoCg.Checked)
            {
                return;
            }

            if (trueFloatImage == null)
            {
                UncheckOtherToolStripMenuItems(toolStripMenuItemYCoCg);
                currentColorSpace = new YCoCg();
                SetStreamsNames(currentColorSpace.GetComponentsNames());
            }
            else
            {
                if (trueFloatImage.ToYCoCg())
                {
                    shownFloatImage = trueFloatImage;
                    pictureBox1.Image = shownFloatImage.GetBitmap();
                    UncheckOtherToolStripMenuItems(toolStripMenuItemYCoCg);
                    UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
                    currentColorSpace = new YCoCg();
                    SetStreamsNames(currentColorSpace.GetComponentsNames());
                    MessageBox.Show("�������������� �������");
                }
                else
                {
                    MessageBox.Show("�������������� �� �������");
                }
            }
        }

        private void toolStripMenuItemCMY_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemCMY.Checked)
            {
                return;
            }

            if (trueFloatImage == null)
            {
                UncheckOtherToolStripMenuItems(toolStripMenuItemCMY);
                currentColorSpace = new CMY();
                SetStreamsNames(currentColorSpace.GetComponentsNames());
            }
            else
            {
                if (trueFloatImage.ToCMY())
                {
                    shownFloatImage = trueFloatImage;
                    pictureBox1.Image = shownFloatImage.GetBitmap();
                    UncheckOtherToolStripMenuItems(toolStripMenuItemCMY);
                    UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
                    currentColorSpace = new CMY();
                    SetStreamsNames(currentColorSpace.GetComponentsNames());
                    MessageBox.Show("�������������� �������");
                }
                else
                {
                    MessageBox.Show("�������������� �� �������");
                }
            }
        }

        private void toolStripMenuItemComponentAll_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemComponentAll.Checked)
            {
                return;
            }

            UncheckOtherToolStripMenuItems(toolStripMenuItemComponentAll);
            shownFloatImage = trueFloatImage;
            pictureBox1.Image = trueFloatImage.GetBitmap();
        }

        private void toolStripMenuItemComponent1_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemComponent1.Checked)
            {
                return;
            }

            UncheckOtherToolStripMenuItems(toolStripMenuItemComponent1);
            shownFloatImage = trueFloatImage.GetFloatImageComponent1();
            pictureBox1.Image = shownFloatImage.GetBitmap();
        }

        private void toolStripMenuItemComponent2_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemComponent2.Checked)
            {
                return;
            }

            UncheckOtherToolStripMenuItems(toolStripMenuItemComponent2);
            shownFloatImage = trueFloatImage.GetFloatImageComponent2();
            pictureBox1.Image = shownFloatImage.GetBitmap();
        }

        private void toolStripMenuItemComponent3_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemComponent3.Checked)
            {
                return;
            }

            UncheckOtherToolStripMenuItems(toolStripMenuItemComponent3);
            shownFloatImage = trueFloatImage.GetFloatImageComponent3();
            pictureBox1.Image = shownFloatImage.GetBitmap();
        }
    }
}