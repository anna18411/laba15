using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace NotepadCSharp
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
            mnuSaveAs.Enabled = false;
        }
       
        private void exetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
       
        private void mnuNew_Click(object sender, EventArgs e)
        {
            blank frm = new blank();
            frm.DocName = "Untitled " + ++openDocuments;
            frm.Text = frm.DocName;
            frm.MdiParent = this;
            frm.Show();
        }
        private int openDocuments = 0;

        private void mnuArrangeIcons_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, System.EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }


        private void frmmain_Load(object sender, EventArgs e)
        {

        }


    
    private void MnuCut_Click(object sender, EventArgs e)
    {

        blank frm = (blank)this.ActiveMdiChild;// создаем переменную frm, которой присваиваем активную форму, то есть то окно, которое у нас выбрано, тем самым обращаясь к коду blank
        frm.Cut();//теперь через эту переменную обращаемся в код формы blanc, где активируем уже заданную функцию
    }

    private void MnuCopy_Click(object sender, EventArgs e)
    {
        blank frm = (blank)this.ActiveMdiChild;// создаем переменную frm, которой присваиваем активную форму, то есть то окно, которое у нас выбрано, тем самым обращаясь к коду blank
        frm.Copy();//теперь через эту переменную обращаемся в код формы blanc, где активируем уже заданную функцию
    }

    private void MnuPaste_Click(object sender, EventArgs e)
    {
        blank frm = (blank)this.ActiveMdiChild;// создаем переменную frm, которой присваиваем активную форму, то есть то окно, которое у нас выбрано, тем самым обращаясь к коду blank
        frm.Paste();//теперь через эту переменную обращаемся в код формы blanc, где активируем уже заданную функцию
    }

    private void MnuDelete_Click(object sender, EventArgs e)
    {
        blank frm = (blank)this.ActiveMdiChild;// создаем переменную frm, которой присваиваем активную форму, то есть то окно, которое у нас выбрано, тем самым обращаясь к коду blank
        frm.Delete();//теперь через эту переменную обращаемся в код формы blanc, где активируем уже заданную функцию
    }

    private void MnuSelectAll_Click(object sender, EventArgs e)
    {
        blank frm = (blank)this.ActiveMdiChild; // создаем переменную frm, которой присваиваем активную форму, то есть то окно, которое у нас выбрано, тем самым обращаясь к коду blank
        frm.SelectAll(); //теперь через эту переменную обращаемся в код формы blanc, где активируем уже заданную функцию
    }


    private void mnuOpen_Click(object sender, System.EventArgs e)
    {
        //Можно программно задавать доступные для обзора расширения файлов 
        //openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
        //Если выбран диалог открытия файла, выполняем условие
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            //Создаем новый документ
            blank frm = new blank();
            //Вызываем метод Open формы blank
            frm.Open(openFileDialog1.FileName);
            //Указываем, что родительской формой является форма frmmain
            frm.MdiParent = this;
            //Присваиваем переменной DocName имя открываемого файла
            frm.DocName = openFileDialog1.FileName;
            //Свойству Text формы присваиваем переменную DocName
            frm.Text = frm.DocName;
            //Вызываем форму frm
            frm.Show();
        }
    }
        private void MnuSave_Click(object sender, EventArgs e)
        {

            //Переключаем фокус на данную форму.
            blank frm = (blank)this.ActiveMdiChild;
            //Вызываем метод Save формы blank
            frm.Save(frm.DocName);
            frm.IsSaved = true;
        }


        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            //Если выбран диалог открытия файла, выполняем условие
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Переключаем фокус на данную форму.
                blank frm = (blank)this.ActiveMdiChild;
                //Вызываем метод Save формы blank
                frm.Save(saveFileDialog1.FileName);
                //Указываем, что родительской формой является форма frmmain
                frm.MdiParent = this;
                //Присваиваем переменной FileName имя сохраняемого файла
                frm.DocName = saveFileDialog1.FileName;
                //Свойству Text формы присваиваем переменную DocName
                frm.Text = frm.DocName;
                frm.IsSaved = true;
            }
            mnuSaveAs.Enabled = true;

        }

        private void MnuFont_Click(object sender, EventArgs e)
        {
            //Переключаем фокус на данную форму.
            blank frm = (blank)this.ActiveMdiChild;
            //Указываем, что родительской формой является форма frmmain 
            frm.MdiParent = this;
            //Вызываем диалог
            fontDialog1.ShowColor = true;
            //Связываем свойства SelectionFont и SelectionColor элемента RichTextBox 
            //с соответствующими свойствами диалога
            fontDialog1.Font = frm.richTextBox1.SelectionFont;
            fontDialog1.Color = frm.richTextBox1.SelectionColor;
            //Если выбран диалог открытия файла, выполняем условие
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionFont = fontDialog1.Font;
                frm.richTextBox1.SelectionColor = fontDialog1.Color;
            }
            //Показываем форму
            frm.Show();

        }

        private void MnuColor_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            colorDialog1.Color = frm.richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionColor = colorDialog1.Color;
            }
            frm.Show();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuFind_Click(object sender, EventArgs e)
        {
            //Создаем новый экземпляр формы FindForm
            FindForm frm = new FindForm();
            //Если выбран результат DialogResult.Cancel, закрываем форму (до этого 
            //мы использовали DialogResult.OK)
            if (frm.ShowDialog(this) == DialogResult.Cancel) return;
            ////Переключаем фокус на данную форму.
            blank form = (blank)this.ActiveMdiChild;
            ////Указываем, что родительской формой является форма frmmain 
            form.MdiParent = this;
            //Вводим переменную для поиска в определенной части текста —
            //поиск слова будет осуществляться от текущей позиции курсора
            int start = form.richTextBox1.SelectionStart;
            //Вызываем предопределенный метод Find элемента richTextBox1.
            form.richTextBox1.Find(frm.FindText, start, frm.FindCondition);

        }

        private void MnuAboutProgramm_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }

        

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "project.chm";
                SysInfo.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

