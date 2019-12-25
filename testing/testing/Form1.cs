using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class OpponentKiller : Form
    {
        public OpponentKiller()
        {
            InitializeComponent();
            FillButton();

        }
        // true 1 player; false 2 player
        bool playerTurn = true;
        int playOneScore = 0;
        int playTwoScore = 0;
        int buttonsDeActive = 1;

        int numberOfAnswers = 12;

        bool gameStarted = false;

        private void button1_Click(object sender, EventArgs e)
        {

            
           
         
                Button btn = sender as Button;
                btn.Enabled = false;

                if (playerTurn)
                {
                    playOneScore = playOneScore + int.Parse(btn.Text);
                    label1.Text = playOneScore.ToString();
                    playerTurn = false;
                }
                else
                {
                    playTwoScore = playTwoScore + int.Parse(btn.Text);
                    label2.Text = playTwoScore.ToString();
                    playerTurn = true;
                }


                FireOnOff(btn.Tag.ToString(), true);



            if (playOneScore == 300)
            {
                label3.Text = "Killer One flawless !!!";
                TurnOff();
            }
            else if (playTwoScore == 300)
            {
                label3.Text = "Killer Two flawless !!!";
                TurnOff();
            }

            if (radioHard.Checked)
            {

                Random rand = new Random();

                for (int i = 0; i < grpBox.Controls.Count; i++)
                {
                    grpBox.Controls[i].Enabled = true;

                    grpBox.Controls[i].Text = rand.Next(1, 100).ToString();
                }

            }

            if (buttonsDeActive == numberOfAnswers)
                {
                    label3.Text = "Finish";

                    double winOne = Math.Abs(playOneScore - 300);
                    double wineTwo = Math.Abs(playTwoScore - 300);

                    if (winOne < wineTwo)
                    {
                        label3.Text = "Killer One Win!";
                    }
                    else
                    {
                        label3.Text = "Killer Two Win!";
                    }
                }

                buttonsDeActive++;
            
        }

        private void TurnOff()
        {
            var PictureBox = grpBox.Controls.OfType<PictureBox>();

            foreach (PictureBox item in PictureBox)
            {
                  item.Visible = true;
            }
        }

        private void FillButton()
        {
            Random rand = new Random();

            for (int i = 0; i < grpBox.Controls.Count; i++)
            {
                grpBox.Controls[i].Enabled = true;

                grpBox.Controls[i].Text = rand.Next(1, 100).ToString();

                FireOnOff(grpBox.Controls[i].Tag.ToString(), false);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            RestartGame();
            

        }

        private void RestartGame()
        {
            label1.Text = "0";
            label2.Text = "0";

            playOneScore = 0;
            playTwoScore = 0;

            buttonsDeActive = 1;
            label3.Text = "300 Bullet";

            playerTurn = true;

            FillButton();
        }

        private void FireOnOff(string tag, bool turn)
        {
            var PictureBox = grpBox.Controls.OfType<PictureBox>();

            foreach (PictureBox item in PictureBox)
            {
                if (tag == item.Tag)
                {
                    item.Visible = turn;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rules of the game: Players  picking numbers.The player whose sum of numbers will be closer to the number 300 - wins. The player who scores 300 points before the end of the match wins.");

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioHard_CheckedChanged(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void radioNormalMode_CheckedChanged(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game disigner - Gizo" + Environment.NewLine + "Programmer - Alex" + Environment.NewLine + "Tester - Nutsa");
        }
    }
}
