using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CirclesApp
{
    public partial class Fo : Form
    {
        Form2 settings;
        Form3 help;
        public Color color1 = Color.Black;
        public Color color2 = Color.Black;
        public int count = 1;
        public int radius = 10;
        Graphics gr;
        Bitmap image;
        Point currentPoint;
        bool IsActive = true;

        public Fo()
        {
            InitializeComponent();
            Init();
        }

        public void Active()
        {
            IsActive = true;
            menuStrip1.Enabled = true;
        }

        public void Inactive()
        {
            IsActive = false;
            menuStrip1.Enabled = false;
        }

        public void Init()
        {
            image = new Bitmap(pictureBox1.Width, pictureBox1.Height); // создаем растровое изображение
            gr = Graphics.FromImage(image);
            pictureBox1.Image = image;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            settings = new Form2(this);
            settings.Show();
            Inactive();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            help = new Form3(this);
            help.Show();
            Inactive();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsActive)
            {
                currentPoint = e.Location;
                int red = (count == 1 ? 0 : (color2.R - color1.R) / (count - 1));
                int green = (count == 1 ? 0 : (color2.G - color1.G) / (count - 1));
                int blue = (count == 1 ? 0 : (color2.B - color1.B) / (count - 1));

                for (int i = 0; i < count; i++)
                {
                    Color current = Color.FromArgb(color1.R + red * i, color1.G + green * i, color1.B + blue * i);
                    SolidBrush brush = new SolidBrush(current);
                    Rectangle bound = new Rectangle(currentPoint.X - radius, currentPoint.Y - radius, radius * 2, radius * 2);
                    gr.FillEllipse(brush, bound);
                    currentPoint.X += radius;
                }
                pictureBox1.Image = image;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Сохранить изображение как...";
            saveDialog.OverwritePrompt = true; // предупреждение, если пользователь указывает имя уже существующего файла
            saveDialog.CheckPathExists = true; // предупреждение, если пользователь указывает несуществующий путь
            saveDialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";           
            saveDialog.ShowHelp = true; // кнопка "Справка" в диалоговом окне

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
