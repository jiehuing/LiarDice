using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiarDice.Properties;

namespace LiarDice
{
    public partial class Form1 : Form
    {
        int Dice1, Dice2, Dice3, Dice4, Dice5;
        int time=0;
        Random rng;
        System.Media.SoundPlayer rollingDice = new System.Media.SoundPlayer(@"C:\Users\ngjh9\source\repos\LiarDice\Resources\Rolling Dice.wav");
        System.Media.SoundPlayer rollingDiceStopping = new System.Media.SoundPlayer(@"C:\Users\ngjh9\source\repos\LiarDice\Resources\Rolling Dice Stopping.wav");


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time%11==0)
            {
                rollingDice.Play();
            }

            time += 1;
            if (time == 30)
            {
                rollingDiceStopping.Play();
                rollingDice.Stop();
                timer1.Stop();
                time = 0;
            }
            else
            {
                //Generate new dice numbers
                rng = new Random();
                if (time < 22)
                {
                    Dice1 = rng.Next(1, 6);
                }
                if (time<24)
                {
                    Dice2 = rng.Next(1, 6);
                }
                if(time<26)
                {
                    Dice3 = rng.Next(1, 6);
                }
                if (time<28)
                {
                    Dice4 = rng.Next(1, 6);
                }
                Dice5 = rng.Next(1, 6);


                //Attach picture to dice face
                attachPicture(Dice1, pictureBox1);
                attachPicture(Dice2, pictureBox2);
                attachPicture(Dice3, pictureBox3);
                attachPicture(Dice4, pictureBox4);
                attachPicture(Dice5, pictureBox5);
            }
        }

        private void attachPicture(int dice, PictureBox pictureBox)
        {
            switch (dice)
            {
                case 1:
                    pictureBox.Image = Resources.dice1;
                    break;
                case 2:
                    pictureBox.Image = Resources.dice2;
                    break;
                case 3:
                    pictureBox.Image = Resources.dice3;
                    break;
                case 4:
                    pictureBox.Image = Resources.dice4;
                    break;
                case 5:
                    pictureBox.Image = Resources.dice5;
                    break;
                case 6:
                    pictureBox.Image = Resources.dice6;
                    break;

            }
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
