using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotepadCSharp
{
   
    public partial class blank : Form
    {
        public blank()
        {
            InitializeComponent();
            //Свойству Text панели sbTime устанавливаем системное время, 
            // конвертировав его в тип String
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            //В тексте всплывающей подсказки выводим текущую дату
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());
        }
        private string BufferText = "";
        public string DocName = "";
        public bool IsSaved = false;

        public void Cut()
        {
            if (richTextBox1.SelectedText != "")
                this.BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }
        public void Copy()
        {
            this.BufferText = richTextBox1.SelectedText;
        }

        // Вставка
        public void Paste()
        {
            richTextBox1.SelectedText = this.BufferText;
        }
        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }

        // Удаление
        public void Delete()
        {
            richTextBox1.SelectedText = "";
            this.BufferText = "";
        }

        private void cmnuCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void cmnuCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void cmnupaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void cmnudelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void cmnuselectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        //Создаем метод Open, в качестве параметра объявляем строку адреса файла.
        public void Open(string OpenFileName)
        {
            //Если файл не выбран, возвращаемся назад (появится встроенное предупреждение)
            if (OpenFileName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamReader и передаем ему переменную 
                //OpenFileName
                StreamReader sr = new StreamReader(OpenFileName);
                //Читаем весь файл и записываем его в richTextBox1
                richTextBox1.Text = sr.ReadToEnd();
                // Закрываем поток
                sr.Close();
                //Переменной DocName присваиваем адресную строку
                DocName = OpenFileName;
            }
        }
        //Создаем метод Save, в качестве параметра объявляем строку адреса файла.
        public void Save(string SaveFileName)
        {
            //Если файл не выбран, возвращаемся назад (появится встроенное предупреждение)
            if (SaveFileName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamWriter и передаем ему переменную 
                //OpenFileName
                StreamWriter sw = new StreamWriter(SaveFileName);
                //Содержимое richTextBox1 записываем в файл
                sw.WriteLine(richTextBox1.Text);
                //Закрываем поток
                sw.Close();
                //Устанавливаем в качестве имени документа название сохраненного файла
                DocName = SaveFileName;
            }
        }

        private void blank_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSaved == false)
                //Появляется диалоговое окно, предлагающее сохранить документ.
                if (MessageBox.Show("Сохранить текстовый документ " + this.DocName + "?",
                "Message", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                //Если была нажата кнопка Yes, вызываем метод Save
                {
                    this.Save(this.DocName);
                }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Свойству Text панели sbAmount устанавливаем надпись "Аmount of symbols" 
            //и длину текста в RichTextBox.
            sbAmount.Text = richTextBox1.Text.Length.ToString() + " Символов";
        }

        private void blank_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
        }

    }
}
