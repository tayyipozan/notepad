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
        private void fontToolStripMenuItem_Click(object sender, EventArgs e) //Font dialogbox for set size,style of font
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font=fontDialog1.Font;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)//new manu for open new Form
        {   
                 this.richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) //open manu for open existing Form
        {
            int count=0;
            openFileDialog1.InitialDirectory = "D:";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
         
            richTextBox1.Text = "";
             if (openFileDialog1.ShowDialog() == DialogResult.OK)  
            {
                this.Text = this.Text + openFileDialog1.FileName;
               using (StreamReader sr = File.OpenText(openFileDialog1.FileName))  
                {  
                    string s = "";  
                    while ((s = sr.ReadLine()) != null)  
                    {  
                        this.richTextBox1.AppendText(s + Environment.NewLine);  
 
                        count = count + s.Length + 1;  
                    }  
                }  

           }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //Save manu for Save Form
        {
            saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

           // String Filename = "";
            saveFileDialog1.Title= "Save";
             if (File.Exists(saveFileDialog1.FileName)) //File name Exist the only save changes
             {
                 richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
             }
            else if (saveFileDialog1.ShowDialog() == DialogResult.OK) //Save file with new name
            {
                this.Text = this.Text + saveFileDialog1.FileName;
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) //SaveAs menu for save file with new name
        {
            saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.Title = "Save as";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //Exit manu for Exit current form
        {
            
            Form f = new Form(){Height=100,Width=500,Text="Notepad"}; //Custom Form created at runnin time of form
            f.Show();
            f.MdiParent = this; 
            
            //Add all control in Custom Form
            Label l1 = new Label() { Left = 0, Top = 0,Height=20,Width=200,Text = "Do you Want to Save?" };
            Button save = new Button(){Left = 50, Top=20, Text="Save" };
            Button DonotSave = new Button() { Left = 150, Top = 20, Text = "DonotSave" };
            Button Cancle= new Button(){Left = 300, Top=20, Text="Save" };
            
            f.Controls.Add(l1);
            f.Controls.Add(save);
            f.Controls.Add(DonotSave);
            f.Controls.Add(Cancle);
            save.Click += (ob,eve) => //Save Event subscribe in Custom Form
            {
                    f.Close();
                    saveFileDialog1.InitialDirectory = "D:";
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

                    saveFileDialog1.Title = "Save";
                    if (File.Exists(saveFileDialog1.FileName))
                    {
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                    else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.Text = this.Text + saveFileDialog1.FileName;
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                     this.Close();
           };

            DonotSave.Click += (ob, eve) => //Don'tSave Event subsribe in Custom Form
            {
                f.Close();
                this.Close();
            };
            
            Cancle.Click += (ob, eve) => //Exit Event subscribe in custom Form
            {
                  f.Close();
            };
        }
        

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText(richTextBox1.SelectedText);// cut selected text
            //richTextBox1.SelectedText = String.Empty;
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clipboard.SetText(richTextBox1.SelectedText);//copy all the text of textbox
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)  //past at select pointer
        {
            //String a = Clipboard.GetText();
            //richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, a);
            richTextBox1.Paste();
        }
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)// cut selected text of textboxt
        {
           // Clipboard.SetText(richTextBox1.SelectedText);
           // richTextBox1.SelectedText = String.Empty;
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)  //copy selected text of textbox
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)  //past at select pointer
        {

            String a = Clipboard.GetText();
            richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, a);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) //delete selected text
        {
            richTextBox1.SelectedText = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) //Undo changes of textbox
        {
                richTextBox1.Undo();
        }
       private void redoToolStripMenuItem_Click(object sender, EventArgs e)  //Redo changes of textbox
        {
               richTextBox1.Redo();
        }
        
        private void fullWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            richTextBox1.Width = 1401;
            richTextBox1.Height = 699;
        }
        private void Maximize_Click(object sender, EventArgs e)
        {
            richTextBox1.Width = 1401;
            richTextBox1.Height = 699;
        }
    }
}
