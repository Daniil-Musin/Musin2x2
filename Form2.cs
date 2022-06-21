using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Musin2x2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal successfulAttempts = 0;
            progressBar1.Maximum = (int)numberOfExperiments;
            progressBar1.Step = 1;
            for (int i = 0; i < numberOfExperiments; i++)
            {
                progressBar1.Value = i;
                progressBar1.Refresh();
                if (isSolvable(new GL()))
                {
                    successfulAttempts++;
                }
            }
            decimal ratio = (successfulAttempts / numberOfExperiments) * 100;
            label1.Text = String.Format("{0:F2}%", ratio);
        }

        bool isSolvable(GL game)
        {
            // without visual presentation
            game.Start();
            while (game.Play()) { }

            return game.deck.Count < 1;
        }

        decimal numberOfExperiments = 1;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numberOfExperiments = numericUpDown1.Value;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
