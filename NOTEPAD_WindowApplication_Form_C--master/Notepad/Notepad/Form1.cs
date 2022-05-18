using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {

            InitializeComponent();

        }
       // string pt = "";  
        // Stack<string> undoList = new Stack<string>();

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Font=fontDialog1.Font;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage();
            RichTextBox richtextBox = new RichTextBox();
            richtextBox.Dock = DockStyle.Fill;
            richtextBox.Multiline = true;
            tabPage.Controls.Add(richtextBox);
            tabPage.Text = "tabPage1";
            tabPage.UseVisualStyleBackColor = true;
            tabControl1.Controls.Add(tabPage);
            tabControl1.SelectedTab = tabPage;
            richtextBox.TextChanged += new EventHandler(this.richTextBox1_TextChanged);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count=0;
            openFileDialog1.InitialDirectory = "D:";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
           // Form1 form = new Form1();

           if (openFileDialog1.ShowDialog() == DialogResult.OK)  
            {
                TabPage tabPage = new TabPage();
                RichTextBox richtextBox = new RichTextBox();
                richtextBox.Dock = DockStyle.Fill;
                richtextBox.Multiline = true;
                tabPage.Controls.Add(richtextBox);
                tabPage.Text = "tabPage1";
                tabPage.UseVisualStyleBackColor = true;
                tabControl1.Controls.Add(tabPage);
                tabControl1.SelectedTab = tabPage;
                this.Text = this.Text + openFileDialog1.FileName;
               using (StreamReader sr = File.OpenText(openFileDialog1.FileName))  
                {  
                    string s = "";  
                    while ((s = sr.ReadLine()) != null)
                    {
                        richtextBox.AppendText(s + Environment.NewLine);

                        count = count + s.Length + 1;  
                    }  
                }  

           }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

           // String Filename = "";
            saveFileDialog1.Title= "Save";
             if (File.Exists(saveFileDialog1.FileName))
             {
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
             }
            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                (tabControl1.SelectedTab.Controls[0] as RichTextBox).SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

            // String Filename = "";
            saveFileDialog1.Title = "Save as";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                (tabControl1.SelectedTab.Controls[0] as RichTextBox).SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form f = new Form(){Height=100,Width=500,Text="Notepad"};
            f.Show();
          //  f.MdiParent = this;
            Label l1 = new Label() { Left = 0, Top = 0,Height=20,Width=200,Text = "Do you Want to Save?" };
            Button save = new Button(){Left = 50, Top=20, Text="Save" };
            Button DonotSave = new Button() { Left = 150, Top = 20, Text = "DonotSave" };
            Button Cancle= new Button(){Left = 300, Top=20, Text="Save" };
            f.Controls.Add(l1);
            f.Controls.Add(save);
            f.Controls.Add(DonotSave);
            f.Controls.Add(Cancle);
            save.Click += (ob,eve) =>
            {
                    f.Close();
                    saveFileDialog1.InitialDirectory = "D:";
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

                    // String Filename = "";
                    saveFileDialog1.Title = "Save";
                    if (File.Exists(saveFileDialog1.FileName))
                    {
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                    else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.Text = this.Text + saveFileDialog1.FileName;
                    (tabControl1.SelectedTab.Controls[0] as RichTextBox).SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                     this.Close();
           };

            DonotSave.Click += (ob, eve) =>
            {
                f.Close();
                this.Close();
            };
            
            Cancle.Click += (ob, eve) =>
            {
                  f.Close();
            };
        }
        

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectedText);// cut selected text
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectedText = String.Empty;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clipboard.SetText(richTextBox1.SelectedText);//copy all the text of textbox
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //String a = Clipboard.GetText();
            //richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, a);//past at select pointer
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Paste();
        }
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Clipboard.SetText(richTextBox1.SelectedText);// cut selected text of textboxt
            // richTextBox1.SelectedText = String.Empty;
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectedText);//copy selected text of textbox
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            String a = Clipboard.GetText();
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Text = (tabControl1.SelectedTab.Controls[0] as RichTextBox).Text.Insert((tabControl1.SelectedTab.Controls[0] as RichTextBox).SelectionStart, a);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Text = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Undo();
           
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            (tabControl1.SelectedTab.Controls[0] as RichTextBox).Redo();
           
        }

        private void fullWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage();
            RichTextBox richtextBox = new RichTextBox();
            richtextBox.Dock = DockStyle.Fill;
            richtextBox.Multiline = true;
            tabPage.Controls.Add(richtextBox);
            tabPage.Text = "tabPage1";
            tabPage.UseVisualStyleBackColor = true;
            tabControl1.Controls.Add(tabPage);
            tabControl1.SelectedTab = tabPage;
            richtextBox.TextChanged += new EventHandler(this.richTextBox1_TextChanged);
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if ((tabControl1.SelectedTab.Controls[0] as RichTextBox).TextLength != 0)
            {
                toolStripLabel2.Text = "Ln 1 Col " + (tabControl1.SelectedTab.Controls[0] as RichTextBox).TextLength;
            }
        }
    }
}
