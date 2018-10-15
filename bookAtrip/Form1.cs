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

namespace HomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Have A Nice Trip !");
            Application.Exit();

        }
 
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < numericUpDown2.Value)
            {
                numericUpDown2.Value = numericUpDown2.Value - 1;
                
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            if (numericUpDown2.Value >numericUpDown1.Value){
                numericUpDown2.Value = numericUpDown2.Value -1;
            MessageBox.Show("You only have put " + numericUpDown1.Value.ToString() + " Tickets");
            }
            if (numericUpDown2.Value > 0)
            {
                label7.Visible = true;
                pictureBox1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                label7.Visible = false;
                pictureBox1.Visible = false;
                button2.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            openFileDialog1.InitialDirectory = Application.StartupPath;
                button1.Enabled = false;
                label7.Visible = false;
                pictureBox1.Visible = false;
                button2.Visible = false;

        }

        private void appearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                this.BackColor = colorDialog1.Color;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "trip.jpg";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != null)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("epib.txt");
                sw.WriteLine("Tickets: " + numericUpDown1.Value.ToString());
                sw.WriteLine("Students: " + numericUpDown2.Value.ToString());
                sw.WriteLine("Arrival Day: " + dateTimePicker1.Text);
                sw.WriteLine("Departure Day: " + monthCalendar1.SelectionStart.ToString());
                sw.Write("Facilities: ");
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++) sw.Write(checkedListBox1.CheckedItems[i].ToString() + " ");
                sw.WriteLine("");
                sw.Write("Beds: ");
                if (radioButton1.Checked == true)
                {
                    sw.Write("1");
                }
                else if (radioButton2.Checked == true)
                {
                    sw.Write("2");
                }
                else if (radioButton3.Checked == true)
                {
                    sw.Write("3");
                }
                else if (radioButton4.Checked == true)
                {
                    sw.Write("4");
                }

                sw.Close();
            }
            catch (Exception a)
            {
                Console.WriteLine("Exception: " + a.Message);
            }
            //Mystiko arxeio !
            try
            {
                StreamWriter sout = new StreamWriter("old.txt");
                sout.WriteLine(numericUpDown1.Value.ToString());
                sout.WriteLine(numericUpDown2.Value.ToString());
                sout.WriteLine(dateTimePicker1.Value.Day);
                sout.WriteLine(dateTimePicker1.Value.Month);
                sout.WriteLine(dateTimePicker1.Value.Year);
                sout.WriteLine(monthCalendar1.SelectionStart.Day.ToString());
                sout.WriteLine(monthCalendar1.SelectionStart.Month.ToString());
                sout.WriteLine(monthCalendar1.SelectionStart.Year.ToString());
                sout.WriteLine(checkedListBox1.CheckedItems.Count);
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    if (checkedListBox1.CheckedItems[i].ToString() == "All inclusive") sout.WriteLine(1);
                    if (checkedListBox1.CheckedItems[i].ToString() == "Suite") sout.WriteLine(2);
                    if (checkedListBox1.CheckedItems[i].ToString() == "Inside Pool") sout.WriteLine(3);
                    if (checkedListBox1.CheckedItems[i].ToString() == "MiniBar") sout.WriteLine(4);
                }


                if (radioButton1.Checked == true)
                {
                    sout.Write("1");
                }
                else if (radioButton2.Checked == true)
                {
                    sout.Write("2");
                }
                else if (radioButton3.Checked == true)
                {
                    sout.Write("3");
                }
                else if (radioButton4.Checked == true)
                {
                    sout.Write("4");
                }
                sout.WriteLine("");
                if (checkBox1.Checked) sout.WriteLine("1");
        
                sout.Close();
            }
            catch (Exception er)
            {
                Console.WriteLine("Exception: " + er.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            String line;
            try
            {
                //tickets
                StreamReader sr = new StreamReader("old.txt");
                line = sr.ReadLine();
                numericUpDown1.Value = Int32.Parse(line);
                line = sr.ReadLine();
                numericUpDown2.Value = Int32.Parse(line);
                //Dates
                int Day = Int32.Parse(sr.ReadLine());
                int Month = Int32.Parse(sr.ReadLine());
                int Year = Int32.Parse(sr.ReadLine());
                dateTimePicker1.Value = new DateTime(Year, Month, Day);
                //Calendar
                 Day = Int32.Parse(sr.ReadLine());
                 Month = Int32.Parse(sr.ReadLine());
                 Year = Int32.Parse(sr.ReadLine());
                monthCalendar1.SelectionEnd = new DateTime(Year, Month, Day);
                monthCalendar1.SelectionStart = new DateTime(Year, Month, Day);
                //Facilities
                checkedListBox1.SetItemChecked(0, false);
                checkedListBox1.SetItemChecked(1, false);
                checkedListBox1.SetItemChecked(2, false);
                checkedListBox1.SetItemChecked(3, false);
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                int y = Int32.Parse(sr.ReadLine());
                for (int i = 0; i < y; i++)
                {
                    line = sr.ReadLine();
                    if (line == "1") checkedListBox1.SetItemChecked(0, true);
                    if (line == "2") checkedListBox1.SetItemChecked(1, true);
                    if (line == "3") checkedListBox1.SetItemChecked(2, true);
                    if (line == "4") checkedListBox1.SetItemChecked(3, true);

                }
                //Radios
                line = sr.ReadLine();
                
                if (line == "1")
                {
                    radioButton1.Checked = true;
                    MessageBox.Show(line);
                }
                if (line == "2") radioButton2.Checked=true;
                if (line == "3") radioButton3.Checked = true;
                if (line == "4") radioButton4.Checked=true;
                
                //Terms
                if (sr.ReadLine() == "1") checkBox1.Checked = true;
                sr.Close();
                
            }
            catch (Exception eR)
            {
                Console.WriteLine("Exception: " + eR.Message);
            }
            richTextBox1.Text = File.ReadAllText("epib.txt");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By Teo");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
