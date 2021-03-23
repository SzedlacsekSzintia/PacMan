using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Form1 : Form
    {
        Model model;

        public Form1()
        {
            model = new Model();
           

            InitializeComponent();

            button1.Click += (s, e) =>
            {
                Form2 play = new Form2(model);
                play.Show();
                this.Hide();
                play.FormClosed += ThisClosed;
            };

            button2.Click += (s, e) =>
            {
                Application.Exit();
            };

        }

        private void ThisClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }


    }
}
