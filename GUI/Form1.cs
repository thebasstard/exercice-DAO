using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;


namespace GUI
{
    public partial class Form1 : Form
    {

        string action = "";

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Width = 540;

            ClientDAO data = new ClientDAO();

            listBox1.DisplayMember = "NomComplet";
            listBox1.ValueMember = "Id";     
            listBox1.DataSource = data.List();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Width = 838;

            action = "ajouter";

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Width = 838;

            try
            {
                action = "modifier";

                int id = (int)listBox1.SelectedValue;

                ClientDAO data = new ClientDAO();

                Client cli = data.Find(id);

                textBox1.Text = cli.Nom;
                textBox2.Text = cli.Prenom;
                textBox3.Text = cli.Ville;
            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Width = 838;

            try
            {


                if (listBox1.SelectedIndex != -1)
                {

                    action = "supprimer";

                    int id = (int)listBox1.SelectedValue;

                    ClientDAO data = new ClientDAO();

                    Client cli = data.Find(id);

                    textBox1.Text = cli.Nom;
                    textBox2.Text = cli.Prenom;
                    textBox3.Text = cli.Ville;
                }
                
        
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (action == "ajouter")
            {
                Client c = new Client();
                c.Nom = textBox1.Text;
                c.Prenom = textBox2.Text;
                c.Ville = textBox3.Text;

                ClientDAO data = new ClientDAO();

                data.Insert(c);

                listBox1.DataSource = data.List();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }

            if (action == "modifier")
            {
                Client c = new Client();
                c.Nom = textBox1.Text;
                c.Prenom = textBox2.Text;
                c.Ville = textBox3.Text;
                c.Id = (int)listBox1.SelectedValue;

                ClientDAO data = new ClientDAO();

                data.Update(c);

                listBox1.DataSource = data.List();
            }

            if (action == "supprimer")
            {
                Client c = new Client();
                c.Nom = textBox1.Text;
                c.Prenom = textBox2.Text;
                c.Ville = textBox3.Text;
                c.Id = (int)listBox1.SelectedValue;

                ClientDAO data = new ClientDAO();

                data.Delete(c);

                listBox1.DataSource = data.List();

            }          
        }
    }
}
