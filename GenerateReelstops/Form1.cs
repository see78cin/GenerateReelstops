using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using System.Xml;
using System.IO;

namespace GenerateReelstops
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }


        public ListBox REEL1
        {

            get { return Reel1;

            }
        }
        public ListBox REEL2
        {

            get
            {
                return Reel2;

            }
        }

        public ListBox REEL3
        {

            get
            {
                return Reel3;

            }
        }
        public ListBox REEL4
        {

            get
            {
                return Reel4;

            }
        }
        public ListBox REEL5
        {

            get
            {
                return Reel5;

            }
        }






        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void PopulateReels(string tempReels, ListBox tmplist, TextBox tmptext) // Used when Populate reels with no virtual weights
        {
            tmplist.Items.Clear();
            tmptext.Clear();

            string Reelvalues = tempReels;


            string[] ReelSet = Reelvalues.Split(' ');
            foreach (string tmpReel in ReelSet)
            {
                tmplist.Items.Add(tmpReel);

            }

        }






        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Reel1.SelectedIndex);
            if (checkBox2.Checked)
                textBox12.Text = ((Reelstop)Reel1.SelectedItem).Range;
        }

        //private void button1_Click(object sender, EventArgs e)
        // {


        //  try
        //  {
        //    string temp1 = Reel1.SelectedIndex + " " + Reel2.SelectedIndex + " " + Reel3.SelectedIndex + " " + Reel4.SelectedIndex + " " +
        //                Reel5.SelectedIndex;
        //    string temp2 = Reel1.SelectedItem.ToString() + " " + Reel2.SelectedItem.ToString() + " " + Reel3.SelectedItem.ToString() + " " + Reel4.SelectedItem.ToString() + " " +
        //               Reel5.SelectedItem.ToString();



        //  }


        // catch (NullReferenceException)
        // {

        //   MessageBox.Show("Please check that reelstop is selected for each reel");

        // }

        // }

        private void Reel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Reel2.SelectedIndex);
            if (checkBox2.Checked)
                textBox13.Text = ((Reelstop)Reel2.SelectedItem).Range;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Reel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Reel3.SelectedIndex);
            if (checkBox2.Checked)
                textBox14.Text = ((Reelstop)Reel3.SelectedItem).Range;
        }

        private void Reel4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(Reel4.SelectedIndex);
            if (checkBox2.Checked)
                textBox15.Text = ((Reelstop)Reel4.SelectedItem).Range;
        }

        private void Reel5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(Reel5.SelectedIndex);
            if (checkBox2.Checked)
                textBox16.Text = ((Reelstop)Reel5.SelectedItem).Range;
        }


        private void PopulateReels(string[] Symbol, double[] LowRange, double[] HiRange, ListBox tmplist)
        {
            List<Reelstop> reel = new List<Reelstop>();

            for (int count = 0; count < Symbol.Length; count++)
            {
                reel.Add(new Reelstop(Symbol[count], LowRange[count], HiRange[count]));

            }

            tmplist.DataSource = reel;


            tmplist.DisplayMember = "Range";
            tmplist.DisplayMember = "Symbols";


        }
        private void button2_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "xml file|*.xml";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                MainReels tmp = new MainReels();


                tmp.setup(openFile.FileName); //calls MainReels method

                if (!checkBox2.Checked)
                {
                    PopulateReels(tmp.GetReel1(), Reel1, textBox1);
                    PopulateReels(tmp.GetReel2(), Reel2, textBox2);
                    PopulateReels(tmp.GetReel3(), Reel3, textBox3);
                    PopulateReels(tmp.GetReel4(), Reel4, textBox4);
                    PopulateReels(tmp.GetReel5(), Reel5, textBox5);
                    // dataGridView1.ColumnCount = 5;
                    // dataGridView1.Columns.Add(new DataGridViewColumn());



                }
                else
                {
                    try
                    {
                        PopulateReels(tmp.GetReel1Array(), tmp.GetHighRange(tmp.Getweight1()), tmp.GetLowRange(tmp.GetHighRange(tmp.Getweight1()), tmp.Getweight1()), Reel1);
                        PopulateReels(tmp.GetReel2Array(), tmp.GetHighRange(tmp.Getweight2()), tmp.GetLowRange(tmp.GetHighRange(tmp.Getweight2()), tmp.Getweight2()), Reel2);
                        PopulateReels(tmp.GetReel3Array(), tmp.GetHighRange(tmp.Getweight3()), tmp.GetLowRange(tmp.GetHighRange(tmp.Getweight3()), tmp.Getweight3()), Reel3);
                        PopulateReels(tmp.GetReel4Array(), tmp.GetHighRange(tmp.Getweight4()), tmp.GetLowRange(tmp.GetHighRange(tmp.Getweight4()), tmp.Getweight4()), Reel4);
                        PopulateReels(tmp.GetReel5Array(), tmp.GetHighRange(tmp.Getweight5()), tmp.GetLowRange(tmp.GetHighRange(tmp.Getweight5()), tmp.Getweight5()), Reel5);
                        Reel1.DisplayMember = "Symbols";
                        Reel2.DisplayMember = "Symbols";
                        Reel3.DisplayMember = "Symbols";
                        Reel4.DisplayMember = "Symbols";
                        Reel5.DisplayMember = "Symbols";


                    }
                    catch (NullReferenceException)
                    {

                        MessageBox.Show("Please verify that your reelstrips have weights. Uncheck physical reel box if your game do not have weighted reels");
                    }


                }

            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(listBox1.SelectedIndex);
            if (checkBox1.Checked)
                textBox9.Text = ((Reelstop)listBox1.SelectedItem).Range;

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox7.Text = Convert.ToString(listBox2.SelectedIndex);
            if (checkBox1.Checked)
                textBox10.Text = ((Reelstop)listBox2.SelectedItem).Range;

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox8.Text = Convert.ToString(listBox3.SelectedIndex);
            if (checkBox1.Checked)
                textBox11.Text = ((Reelstop)listBox3.SelectedItem).Range;

        }

        private void button4_Click(object sender, EventArgs e)
        {


            try
            {
                string temp1 = Reel1.SelectedIndex + " " + Reel2.SelectedIndex + " " + Reel3.SelectedIndex;
                string temp2 = Reel1.SelectedItem.ToString() + " " + Reel2.SelectedItem.ToString() + " " + Reel3.SelectedItem.ToString();



            }


            catch (NullReferenceException)
            {

                MessageBox.Show("Please check that reelstop is selected for each reel");

            }




        }

        private void button3_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "xml file|*.xml";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                MainReels tmp = new MainReels();

                tmp.setup(openFile.FileName); //calls MainReels method
                if (!checkBox1.Checked)
                {

                    PopulateReels(tmp.GetReel1(), listBox1, textBox6);
                    PopulateReels(tmp.GetReel2(), listBox2, textBox7);
                    PopulateReels(tmp.GetReel3(), listBox3, textBox8);

                }
                else
                {
                    try
                    {
                        PopulateReels(tmp.GetReel1Array(), tmp.GetHighRange(tmp.Getweight1()), tmp.GetLowRange(tmp.GetHighRange(tmp.Getweight1()), tmp.Getweight1()), listBox1);
                        PopulateReels(tmp.GetReel2Array(), tmp.GetHighRange(tmp.Getweight2()), tmp.GetLowRange(tmp.GetHighRange(tmp.Getweight2()), tmp.Getweight2()), listBox2);
                        PopulateReels(tmp.GetReel3Array(), tmp.GetHighRange(tmp.Getweight3()), tmp.GetLowRange(tmp.GetHighRange(tmp.Getweight3()), tmp.Getweight3()), listBox3);
                        listBox1.DisplayMember = "Symbols";
                        listBox2.DisplayMember = "Symbols";
                        listBox3.DisplayMember = "Symbols";

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Please verify that your reelstrips have weights. Uncheck physical reel box if your game do not have weighted reels");
                    }

                }
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // listBox1.DataSource = null;

            // listBox2.DataSource = null;
            // listBox3.DataSource = null;
            // listBox1.Items.Clear();
            //  listBox2.Items.Clear();
            //  listBox3.Items.Clear();
            //  textBox6.Clear();
            // textBox9.Clear();
            // textBox7.Clear();
            // textBox10.Clear();
            //  textBox8.Clear();
            // textBox11.Clear();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //Reel1.DataSource = null;
            //  Reel2.DataSource = null;
            // Reel3.DataSource = null;
            //  Reel4.DataSource = null;
            // Reel5.DataSource = null;
            //// Reel1.Items.Clear();
            // Reel2.Items.Clear();
            // Reel3.Items.Clear();
            //Reel4.Items.Clear();
            // Reel5.Items.Clear();
            // textBox1.Clear();
            // textBox2.Clear();
            //textBox3.Clear();
            //textBox4.Clear();
            // textBox5.Clear();
            //  textBox12.Clear();
            //  textBox13.Clear();
            //   textBox14.Clear();
            //   textBox15.Clear();
            //  textBox16.Clear();

        }

        // private void button4_Click_1(object sender, EventArgs e)
        //  {

        //  listBox1.DataSource = null;
        // listBox2.DataSource = null;
        // listBox3.DataSource = null;
        //  listBox1.Items.Clear();
        //  listBox2.Items.Clear();
        //  listBox3.Items.Clear();
        //  textBox6.Clear();
        //  textBox9.Clear();
        //  textBox7.Clear();
        //  textBox10.Clear();
        //  textBox8.Clear();
        //  textBox11.Clear();

        // }

        private void button5_Click(object sender, EventArgs e)
        {
            Reel1.DataSource = null;
            Reel2.DataSource = null;
            Reel3.DataSource = null;
            Reel4.DataSource = null;
            Reel5.DataSource = null;
            Reel1.Items.Clear();
            Reel2.Items.Clear();
            Reel3.Items.Clear();
            Reel4.Items.Clear();
            Reel5.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox18.Clear();
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "xml file|*.xml";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Weight tmp = new Weight();

                tmp.setupWeight(openFile.FileName); //calls Weight method


                string c = processW2(tmp.Weightlist, textBox18, tmp);
                textBox18.Text = c;

            }
        }
        public static string processW2(XmlNodeList tmpNodlist, TextBox textboxs, Weight Wt)
        {
            string txt = "";
            for (int x = 0; x < tmpNodlist.Count; x++)
            {

                textboxs.Text = tmpNodlist[x].Attributes["name"].Value + "\r\n";
                // Console.WriteLine(tmpNodlist[x].Attributes["name"].Value + "\r\n");
                List<double> countvalue = new List<double>();

                List<string> value = new List<string>();
                foreach (XmlNode node in tmpNodlist[x])
                {

                    if (node.Name == "weightentry")
                    {
                        countvalue.Add(Convert.ToInt32(node.Attributes["count"].Value));
                        value.Add(node.Attributes["value"].Value);

                    }

                }

                List<double> high = Wt.GetHighRange2(countvalue);
                double[] low = Wt.GetLowRange2(high, countvalue);
                string[] val = value.ToArray();
                double[] higharray = high.ToArray();
                double[] weights = countvalue.ToArray();

                for (int count = 0; count < high.Count; count++)
                {

                    textboxs.AppendText("Weight " + weights[count] + " " + Convert.ToString(low[count]) + " -----  " + Convert.ToString(higharray[count]) + "   " + val[count] + "\r\n");

                }

                txt += textboxs.Text + "\r\n";
            }

            return txt;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox17.Clear();
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "xml file|*.xml";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Weight tmp = new Weight();

                tmp.setupWeight(openFile.FileName); //calls Weight method to setup node list
                string c = processW2(tmp.Weightlist, textBox17, tmp);
                textBox17.Text = c;





            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            StringBuilder symbol = new StringBuilder();

            if (!checkBox2.Checked)
            {

                Reel1.SelectedItems.Clear();
                for (int i = 0; i < Reel1.Items.Count; i++)
                {
                    Reel1.SetSelected(i, true);
                    symbol.Append(Reel1.SelectedItem);
                    symbol.AppendLine();
                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }

            else
            {
                Reel1.SelectedItems.Clear();
                for (int i = 0; i < Reel1.Items.Count; i++)
                {
                    Reel1.SetSelected(i, true);
                    string tmp = ((Reelstop)Reel1.SelectedItem).Range;
                    symbol.Append(tmp);
                    symbol.AppendLine();

                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }
               
            


        }
    
        

        private void button4_Click_1(object sender, EventArgs e)
        {
            StringBuilder symbol = new StringBuilder();


            try
            {
                Reel2.SelectedItems.Clear();
                for (int i = 0; i < Reel2.Items.Count; i++)
                {
                    Reel2.SetSelected(i, true);
                    symbol.Append(Reel2.SelectedItem);
                    symbol.AppendLine();
                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please import reels");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            StringBuilder symbol = new StringBuilder();


            try
            {
                Reel3.SelectedItems.Clear();
                for (int i = 0; i < Reel3.Items.Count; i++)
                {
                    Reel3.SetSelected(i, true);
                    symbol.Append(Reel3.SelectedItem);
                    symbol.AppendLine();
                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please import reels");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StringBuilder symbol = new StringBuilder();


            try
            {
                Reel4.SelectedItems.Clear();
                for (int i = 0; i < Reel4.Items.Count; i++)
                {
                    Reel4.SetSelected(i, true);
                    symbol.Append(Reel4.SelectedItem);
                    symbol.AppendLine();
                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please import reels");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            StringBuilder symbol = new StringBuilder();


            try
            {
                Reel5.SelectedItems.Clear();
                for (int i = 0; i < Reel5.Items.Count; i++)
                {
                    Reel5.SetSelected(i, true);
                    symbol.Append(Reel5.SelectedItem);
                    symbol.AppendLine();
                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please import reels");
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            StringBuilder symbol = new StringBuilder();


            try
            {
                listBox1.SelectedItems.Clear();
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, true);
                    symbol.Append(listBox1.SelectedItem);
                    symbol.AppendLine();
                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please import reels");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            StringBuilder symbol = new StringBuilder();


            try
            {
                listBox2.SelectedItems.Clear();
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox2.SetSelected(i, true);
                    symbol.Append(listBox2.SelectedItem);
                    symbol.AppendLine();
                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please import reels");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            StringBuilder symbol = new StringBuilder();


            try
            {
                listBox3.SelectedItems.Clear();
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    listBox3.SetSelected(i, true);
                    symbol.Append(listBox3.SelectedItem);
                    symbol.AppendLine();
                }
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, symbol.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please import reels");
            }
        }
    }

}
