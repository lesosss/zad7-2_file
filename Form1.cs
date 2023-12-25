using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;//
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad7_2_file
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            //добавляем текст из TextBox в List
            lst.Items.Add(txt.Text);
            //очистка
            txt.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //получение пути файла из TextBox
            string fileName = txtFileName.Text;

            //проверка на наличие файла
            if (File.Exists(fileName))
            {
                //существует
                File.Delete(fileName);
            }

            // Используем конструкцию using для автоматического закрытия FileStream и BinaryWriter после использования
            // создаем файл или перезаписываем существующий
            using (FileStream fs = File.Create(fileName, 1024)) //работа с файлами

            // класс для работы с данными файла в двоичной виде
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                // если список не окончен Записываем каждый элемент из элемента управления ListBox в файл
                for (var i = 0; i < lst.Items.Count; i++)
                {
                    bw.Write(lst.Items[i].ToString());
                }

                bw.Close();
                fs.Close();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //получить путь к файлу
            string fileName = txtFileName.Text;
            //очищение строки файла
            lstFromfile.Items.Clear();

            using (FileStream fs = new FileStream(fileName, FileMode.Open))

            using (BinaryReader br = new BinaryReader(fs))
            {

                while (br.PeekChar() != -1)
                {
                    //добавляем в элемент ListBox каждую строку прочитанную с помощью BR
                    lstFromfile.Items.Add(br.ReadString());
                }
                
                br.Close();
                fs.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
