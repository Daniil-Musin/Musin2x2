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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateDeckPictureBox("Back");
            UpdateDeckCount(52);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool isSolvable(GL game, int waitTime = 0)
        {
            game.Start();
            UpdateDeckCount(game.deck.Count);
            while (game.Play())
            {
                UpdateDeckCount(game.deck.Count);
                UpdatePictureBoxes(game.cardsDrawn);
                System.Threading.Thread.Sleep(waitTime);
            }
            if (game.deck.Count < 1)
            {
                UpdateDeckPictureBox("");
                return true;
            }
            else
            {
                return false;
            }
          
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var text = isSolvable(new GL(), 500) ? "Пасьянс сошёлся; Успех" : "Пасьянс не сошёлся; Неудача";
            MessageBox.Show(text, "Результат расклада");
        }
        private void вероятностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deck_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Message", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
     
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void card4_Click(object sender, EventArgs e)
        {

        }

        private void card3_Click(object sender, EventArgs e)
        {

        }

     
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        int currDeckCount = 52;
        private void toolStripStatusLabel1_TextChanged(object sender, EventArgs e)
        {

        }
        void UpdateDeckCount(int count)
        {
            currDeckCount = count;
            toolStripStatusLabel1.Text = "Карт в колоде: " + currDeckCount.ToString();
            statusStrip1.Refresh();
        }

        void UpdatePictureBoxes(List<string> cards)
        {
          
            card1.Image = LoadImage(cards[0]);
            card1.Refresh();
            card2.Image = LoadImage(cards[1]);
            card2.Refresh();
            card3.Image = LoadImage(cards[2]);
            card3.Refresh();
            card4.Image = LoadImage(cards[3]);
            card4.Refresh();
        }

        void UpdateDeckPictureBox(string image)
        {
            deck.Image = LoadImage(image);
            deck.Refresh();
        }

        Image LoadImage(string resName)
        {
            return (Image)Properties.Resources.ResourceManager.GetObject(resName);
        }



    }

    class GL // game logic
    {
        const int tableSize = 4;
        

        string[] suits = {
            "D", "C", "H", "S" 
        };
        string[] ranks = { 
            "A", "K", "Q", "J", 
            "T", "9", "8", "7", "6", "5", "4", "3", "2"
        };
        public List<string> deck = new List<string>();
        public List<string> cardsDrawn = new List<string>();

        public GL()
        {
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(suit+rank);
                }
            }
        }

        public void Start()
        {
            deck = deck.OrderBy(a => Guid.NewGuid()).ToList(); // randomizes the order 
            for (int i = 0; i < tableSize; i++)
            {
                cardsDrawn.Add(DrawCard()); // draws first cards (4 by default)
            }
        }

        public string DrawCard()
        {
            string card = deck[0];
            deck.RemoveAt(0);
            return card;
        }

        public bool Play()
        {
            cardsDrawn.Sort();
            for (int i = 0; i < cardsDrawn.Count; i++)
            {
                if (i + 1 < cardsDrawn.Count)
                {
                    if (cardsDrawn[i][0] == cardsDrawn[i + 1][0])
                    {
                        cardsDrawn[i] = DrawCard();
                        cardsDrawn[i + 1] = DrawCard();
                        return true; // can be played
                    }
                }
            }

            return false; // must be stopped
        }


    }
}
