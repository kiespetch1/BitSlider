using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BitSlider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        private void ChooseFile_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"c:\";
                openFileDialog.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;


                    var a = (int) new FileInfo(filePath).Length;
                    var name = Path.GetFileName(filePath);
                    var workingPath = Path.GetDirectoryName(filePath);
                    var filePath2 = $"{workingPath}\\converted_{name}";
                    var resultName = Path.GetFileName(filePath2);
                    var array = new byte[a];
                    using (FileStream fsSource = new FileStream(filePath,
                               FileMode.Open, FileAccess.Read))
                    {
                        int b = fsSource.Read(array, 0, a);
                    }

                    using (var fstream = new FileStream(filePath2, FileMode.Create))
                    {
                        foreach (byte ab in array)
                        {
                            fstream.WriteByte((byte) (ab + 1));
                        }
                    }
                    Label label1 = new Label();
                    label1.Location = new Point(44, 63);
                    label1.Name = "label1";
                    label1.Size = new Size(224, 40);
                    label1.TabIndex = 1;
                    label1.Text = $"Выбранный файл: {name}";
                    label1.TextAlign = ContentAlignment.MiddleCenter;
                    Controls.Add(label1);
                    
                    Label label2 = new Label();
                    label2.Location = new Point(44, 112);
                    label2.Name = "label2";
                    label2.Size = new Size(224, 40);
                    label2.TabIndex = 2;
                    label2.Text = $"Конвертированный файл: {resultName}";
                    label2.TextAlign = ContentAlignment.MiddleCenter;
                    Controls.Add(label2);
                    
                }
            }
        }

        
    }
}