using cg22_model.Models;
using cg22_model.Models.ColorSpacesSpaces;

namespace cg22_project_3_guys_1_computer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRGB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHSL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHSV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemYCbCr601 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemYCbCr709 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemYCoCg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCMY = new System.Windows.Forms.ToolStripMenuItem();
            this.colorStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemComponentAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemComponent1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemComponent2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemComponent3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.toolStripMenuItem1,
            this.colorStreamToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1278, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripSeparator,
            this.сохранитьToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("открытьToolStripMenuItem.Image")));
            this.открытьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.открытьToolStripMenuItem.Text = "&Открыть";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(258, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьToolStripMenuItem.Image")));
            this.сохранитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.сохранитьToolStripMenuItem.Text = "&Сохранить";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(258, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRGB,
            this.toolStripMenuItemHSL,
            this.toolStripMenuItemHSV,
            this.toolStripMenuItemYCbCr601,
            this.toolStripMenuItemYCbCr709,
            this.toolStripMenuItemYCoCg,
            this.toolStripMenuItemCMY});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(226, 29);
            this.toolStripMenuItem1.Text = "Цветовые пространства";
            // 
            // toolStripMenuItemRGB
            // 
            this.toolStripMenuItemRGB.Checked = true;
            this.toolStripMenuItemRGB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemRGB.Name = "toolStripMenuItemRGB";
            this.toolStripMenuItemRGB.Size = new System.Drawing.Size(196, 34);
            this.toolStripMenuItemRGB.Text = "RGB";
            this.toolStripMenuItemRGB.Click += new System.EventHandler(this.toolStripMenuItemRGB_Click);
            // 
            // toolStripMenuItemHSL
            // 
            this.toolStripMenuItemHSL.Name = "toolStripMenuItemHSL";
            this.toolStripMenuItemHSL.Size = new System.Drawing.Size(196, 34);
            this.toolStripMenuItemHSL.Text = "HSL";
            this.toolStripMenuItemHSL.Click += new System.EventHandler(this.toolStripMenuItemHSL_Click);
            // 
            // toolStripMenuItemHSV
            // 
            this.toolStripMenuItemHSV.Name = "toolStripMenuItemHSV";
            this.toolStripMenuItemHSV.Size = new System.Drawing.Size(196, 34);
            this.toolStripMenuItemHSV.Text = "HSV";
            this.toolStripMenuItemHSV.Click += new System.EventHandler(this.toolStripMenuItemHSV_Click);
            // 
            // toolStripMenuItemYCbCr601
            // 
            this.toolStripMenuItemYCbCr601.Name = "toolStripMenuItemYCbCr601";
            this.toolStripMenuItemYCbCr601.Size = new System.Drawing.Size(196, 34);
            this.toolStripMenuItemYCbCr601.Text = "YCbCr.601";
            this.toolStripMenuItemYCbCr601.Click += new System.EventHandler(this.toolStripMenuItemYCbCr601_Click);
            // 
            // toolStripMenuItemYCbCr709
            // 
            this.toolStripMenuItemYCbCr709.Name = "toolStripMenuItemYCbCr709";
            this.toolStripMenuItemYCbCr709.Size = new System.Drawing.Size(196, 34);
            this.toolStripMenuItemYCbCr709.Text = "YCbCr.709";
            this.toolStripMenuItemYCbCr709.Click += new System.EventHandler(this.toolStripMenuItemYCbCr709_Click);
            // 
            // toolStripMenuItemYCoCg
            // 
            this.toolStripMenuItemYCoCg.Name = "toolStripMenuItemYCoCg";
            this.toolStripMenuItemYCoCg.Size = new System.Drawing.Size(196, 34);
            this.toolStripMenuItemYCoCg.Text = "YCoCg";
            this.toolStripMenuItemYCoCg.Click += new System.EventHandler(this.toolStripMenuItemYCoCg_Click);
            // 
            // toolStripMenuItemCMY
            // 
            this.toolStripMenuItemCMY.Name = "toolStripMenuItemCMY";
            this.toolStripMenuItemCMY.Size = new System.Drawing.Size(196, 34);
            this.toolStripMenuItemCMY.Text = "CMY";
            this.toolStripMenuItemCMY.Click += new System.EventHandler(this.toolStripMenuItemCMY_Click);
            // 
            // colorStreamToolStripMenuItem
            // 
            this.colorStreamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemComponentAll,
            this.toolStripMenuItemComponent1,
            this.toolStripMenuItemComponent2,
            this.toolStripMenuItemComponent3});
            this.colorStreamToolStripMenuItem.Enabled = false;
            this.colorStreamToolStripMenuItem.Name = "colorStreamToolStripMenuItem";
            this.colorStreamToolStripMenuItem.Size = new System.Drawing.Size(160, 29);
            this.colorStreamToolStripMenuItem.Text = "Цветовой канал";
            // 
            // toolStripMenuItemComponentAll
            // 
            this.toolStripMenuItemComponentAll.Checked = true;
            this.toolStripMenuItemComponentAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemComponentAll.Name = "toolStripMenuItemComponentAll";
            this.toolStripMenuItemComponentAll.Size = new System.Drawing.Size(160, 34);
            this.toolStripMenuItemComponentAll.Text = "Все";
            this.toolStripMenuItemComponentAll.Click += new System.EventHandler(this.toolStripMenuItemComponentAll_Click);
            // 
            // toolStripMenuItemComponent1
            // 
            this.toolStripMenuItemComponent1.Name = "toolStripMenuItemComponent1";
            this.toolStripMenuItemComponent1.Size = new System.Drawing.Size(160, 34);
            this.toolStripMenuItemComponent1.Text = "Red";
            this.toolStripMenuItemComponent1.Click += new System.EventHandler(this.toolStripMenuItemComponent1_Click);
            // 
            // toolStripMenuItemComponent2
            // 
            this.toolStripMenuItemComponent2.Name = "toolStripMenuItemComponent2";
            this.toolStripMenuItemComponent2.Size = new System.Drawing.Size(160, 34);
            this.toolStripMenuItemComponent2.Text = "Green";
            this.toolStripMenuItemComponent2.Click += new System.EventHandler(this.toolStripMenuItemComponent2_Click);
            // 
            // toolStripMenuItemComponent3
            // 
            this.toolStripMenuItemComponent3.Name = "toolStripMenuItemComponent3";
            this.toolStripMenuItemComponent3.Size = new System.Drawing.Size(160, 34);
            this.toolStripMenuItemComponent3.Text = "Blue";
            this.toolStripMenuItemComponent3.Click += new System.EventHandler(this.toolStripMenuItemComponent3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 944);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CG22";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;

        private FloatImage shownFloatImage;
        private FloatImage trueFloatImage;
        private IColorSpace currentColorSpace;

        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItemRGB;
        private ToolStripMenuItem toolStripMenuItemHSL;
        private ToolStripMenuItem toolStripMenuItemHSV;
        private ToolStripMenuItem toolStripMenuItemYCbCr601;
        private ToolStripMenuItem toolStripMenuItemYCbCr709;
        private ToolStripMenuItem toolStripMenuItemYCoCg;
        private ToolStripMenuItem toolStripMenuItemCMY;
        private ToolStripMenuItem colorStreamToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemComponentAll;
        private ToolStripMenuItem toolStripMenuItemComponent1;
        private ToolStripMenuItem toolStripMenuItemComponent2;
        private ToolStripMenuItem toolStripMenuItemComponent3;
    }
}