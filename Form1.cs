using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextReda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Multiline = true; // разрешаем многострочный текст
                                       // textBox1 занимает всю свободную поверхность форм
            textBox1.ReadOnly = false;
            textBox1.Dock = DockStyle.Fill;
            // включаем вертикальную и горизонтальную полосы прокрутки
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.WordWrap = false; // запрещаем перенос строк
            textBox1.Clear();
            this.Text = "Текстовый редактор 3000";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        }
        // Обработчик события Click пункта меню Открыть

        // Вспомогательный метод для записи текста в файл
        private void Запись()
        {
            try
            { // Создание экземпляра StreamWriter для записи в файл:
                var Писатель = new System.IO.StreamWriter(saveFileDialog1.FileName, false,
                System.Text.Encoding.GetEncoding(1251));
                // - здесь заказ кодовой страницы Winl251 для русских букв
                Писатель.Write(textBox1.Text);
                Писатель.Close();
                //textBox1.Modified = false;
            }
            catch (System.Exception Ситуация)
            { // Отчет обо всех возможных ошибках
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }
       
       
        // Обработчик события FormClosing формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(textBox1.Modified == false) return; // Если текст модифицирован, то спросить, записывать ли файл
            DialogResult MBox = MessageBox.Show("Текст был изменен.\nСохранить изменения?",
            "Простой редактор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            // YES — диалог; NO — выход; CANCEL — редактировать
            if (MBox == DialogResult.No) return;
            if (MBox == DialogResult.Cancel) e.Cancel = true;
            if (MBox == DialogResult.Yes)
            {
                if (openFileDialog1.FileName == "")
                    сохранитьКакToolStripMenuItem_Click_1(sender, e);
                else
                    saveFileDialog1.FileName = openFileDialog1.FileName;
                Запись();
                return;
            } // DialogResult.Yes
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            //if (openFileDialog1.FileName == null) return;
            // Чтение текстового файла: try
            try
            { // Создание экземпляра StreamReader для чтения из файла
                var Читатель = new System.IO.StreamReader(openFileDialog1.FileName,
                System.Text.Encoding.GetEncoding(1251));
                // здесь заказ кодовой страницы Winl251 для русских букв
                textBox1.Text = Читатель.ReadToEnd();
                Читатель.Close();
            }
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация + "\nНет такого файла", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Exception Ситуация)
            {
                // Отчет о других ошибках
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) Запись();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private FontDialog fnt = new FontDialog();

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fnt.ShowDialog() == DialogResult.OK){
                textBox1.Font = fnt.Font;
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
                сохранитьКакToolStripMenuItem_Click_1(sender, e);
            else
                saveFileDialog1.FileName = openFileDialog1.FileName;
            Запись();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //textBox1.Modified = true;
            textBox1.Select();
            textBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //textBox1.Modified = true;
            textBox1.Paste();
        }

        private void toolStripTextBox2_Click_1(object sender, EventArgs e)
        {

        }
        bool bl = false;
        private void toolStripTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (toolStripTextBox2.Text.Length > 0 && (e.KeyChar == (char)Keys.Enter))
            {
                
                bl = true;
                textBox1.Focus();
                string a = toolStripTextBox2.Text;
                search_1 = textBox1.Text;
                int b = textBox1.Text.IndexOf(a);
                if (b !=-1)
                {
                    int b1 = a.Length;
                    textBox1.Select(b, b1);
                    search_1.Remove(b, b1);
                    for(int i = 0; i < b1; i++)
                    {
                        search_1.Insert(b, ((char)4).ToString());
                    }
                }
               textBox1.ReadOnly = true;

            }
        }

        string search_1; // доп. текст, где мы заменяем символы которые использовали
        int k = 0;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            //textBox1.Modified = true;

            if (e.KeyChar == (char)Keys.Enter && bl)
            {
                
                string a = toolStripTextBox2.Text; // то что ищем

                int n = search_1.IndexOf(a);

                if (n == -1) { search_1 = textBox1.Text; return; } // если мы дошли до конца поиска - вернем все символы и поищем обратно
                search_1 = search_1.Remove(n, a.Length);
                //Console.WriteLine("Строка : {0}", str);
                textBox1.Select(n, a.Length);
                    string add = "";

                    for (int i = 0; i < a.Length; i++)
                    {
                        add += ((char)4).ToString();
                    }
                search_1 = search_1.Insert(n, add);
                  

            }
            else return;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            bl = false;
            textBox1.ReadOnly = false;
        }

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (переносПоСловамToolStripMenuItem.Checked == false)
            {
                переносПоСловамToolStripMenuItem.Checked = true;
                textBox1.WordWrap = true;
            }
            else
            {
                переносПоСловамToolStripMenuItem.Checked = false;
                textBox1.WordWrap = false;
            }
        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }
    }
}