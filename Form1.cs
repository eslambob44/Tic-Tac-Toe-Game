using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] Player1Choices = new int[9];
        int[] Player2Choices = new int[9];
        enum enGameWinner {InProgress=2 , Player1=0 , Player2=1 ,Draw=3 };
        enGameWinner GameWinner = enGameWinner.InProgress;
        enum enPlayerTurn {Player1 , Player2 ,GameOver };
        enPlayerTurn PlayerTurn = enPlayerTurn.Player1;
        int Player1Plays = 0;
        int Player2Plays = 0;

        bool IsArrayInArray(int[] SmallArray , int[] BigArray)
        {
            for(int i=0;i<SmallArray.Length; i++)
            {
                
                    if (IsNumberInArray(SmallArray[i], BigArray))
                    {
                        return true;
                    }
                
            }
            return false;
        }

        
        

        bool IsNumberInArray(int Number , int[] Array)
        {
            foreach (int i in Array) 
            {
                if (i == Number) return true;
            }
            return false;
        }
        void ChangePlayerTurn()
        {
            PlayerTurn=(PlayerTurn == enPlayerTurn.Player1) ? enPlayerTurn.Player2 : enPlayerTurn.Player1;
            lblTurn.Text = PlayerTurn.ToString();
        }

        bool CheckPhotoChosen(PictureBox ChosenPicture)
        {
            return (IsNumberInArray(Convert.ToInt32(ChosenPicture.Tag), Player1Choices)
                    || IsNumberInArray(Convert.ToInt32(ChosenPicture.Tag), Player2Choices));
        }

        bool ChangePhoto(PictureBox ChosenBox)
        {
            if (CheckPhotoChosen(ChosenBox)) return false;

            ChosenBox.Image = (PlayerTurn == enPlayerTurn.Player1) ? Resources.X : Resources.O;
            return true;
        }

        void ChangeWInPictureBoxBackTGreen(int[] Result)
        {
            if(IsNumberInArray( Convert.ToInt32(pictureBox1.Tag) ,Result))
            {
                pictureBox1.BackColor = Color.Lime;
                
            }

            if (IsNumberInArray(Convert.ToInt32(pictureBox2.Tag), Result))
            {
                pictureBox1.BackColor = Color.Lime;
                
            }

            if (IsNumberInArray(Convert.ToInt32(pictureBox3.Tag), Result))
            {
                pictureBox1.BackColor = Color.Lime;
               
            }

            if (IsNumberInArray(Convert.ToInt32(pictureBox4.Tag), Result))
            {
                pictureBox1.BackColor = Color.Lime;
                
            }

            if (IsNumberInArray(Convert.ToInt32(pictureBox5.Tag), Result))
            {
                pictureBox1.BackColor = Color.Lime;
                
            }

            if (IsNumberInArray(Convert.ToInt32(pictureBox6.Tag), Result))
            {
                pictureBox1.BackColor = Color.Lime;
                
            }

            if (IsNumberInArray(Convert.ToInt32(pictureBox7.Tag), Result))
            {
                pictureBox1.BackColor = Color.Lime;
                
            }

            if (IsNumberInArray(Convert.ToInt32(pictureBox8.Tag), Result))
            {
                pictureBox1.BackColor = Color.Lime;
                
            }

            if (IsNumberInArray(Convert.ToInt32(pictureBox9.Tag), Result))
            {
                pictureBox1.BackColor = Color.Lime;
                
            }
        }

        void CheckWinner()
        {
            if(Player2Plays+Player1Plays==9)
            {
                GameWinner = enGameWinner.Draw;
                lblWinner.Text = "Draw";
                PlayerTurn = enPlayerTurn.GameOver;
                lblTurn.Text = "Game Over";
                return;
            }

            if(PlayerTurn==enPlayerTurn.Player1)
            {
                if (Player1Plays < 3) return;
                else
                {
                    
                }
            }
            else if(PlayerTurn==enPlayerTurn.Player2) { }
            {
                if(Player2Plays < 3) return;
                else
                {
                    
                }
            }



        }

        void EnterPlayerChoices(int Number )
        {
            if(PlayerTurn == enPlayerTurn.Player1)
            {
                Player1Choices[Player1Plays] = Number;
            }
            else
            {
                Player2Choices[Player2Plays] = Number;
            }
        }

        void IncreasePlayerPlays()
        {
            if( PlayerTurn == enPlayerTurn.Player1)
            {
                Player1Plays++;
            }
            else
            {
                Player2Plays++;
            }
        }

        void PlayRound(PictureBox ChosenBox)
        {
            if(PlayerTurn==enPlayerTurn.GameOver)
            {
                MessageBox.Show($"{GameWinner} Win","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!ChangePhoto(ChosenBox))
            {
                MessageBox.Show("Already Chosen","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EnterPlayerChoices(Convert.ToInt32(ChosenBox.Tag));
            IncreasePlayerPlays();
            CheckWinner();
            if (PlayerTurn == enPlayerTurn.GameOver)
            {
                return;
            }
            ChangePlayerTurn();
        }

        void RestartGame()
        {
            GameWinner = enGameWinner.InProgress;
            PlayerTurn = enPlayerTurn.Player1;
            Player1Plays = 0;
            Player2Plays = 0;
            Player1Choices = new int[9];
            Player2Choices = new int[9];
            lblTurn.Text=PlayerTurn.ToString();
            lblWinner.Text="In Progress";
            pictureBox1.Image = Resources.question_mark_96;
            pictureBox2.Image = Resources.question_mark_96;
            pictureBox3.Image = Resources.question_mark_96;
            pictureBox4.Image = Resources.question_mark_96;
            pictureBox5.Image = Resources.question_mark_96;
            pictureBox6.Image = Resources.question_mark_96;
            pictureBox7.Image = Resources.question_mark_96;
            pictureBox8.Image = Resources.question_mark_96;
            pictureBox9.Image = Resources.question_mark_96;


            pictureBox1.BackColor = Color.Black;
            pictureBox2.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Black;
            pictureBox4.BackColor = Color.Black;
            pictureBox5.BackColor = Color.Black;
            pictureBox6.BackColor = Color.Black;
            pictureBox7.BackColor = Color.Black;
            pictureBox8.BackColor = Color.Black;
            pictureBox9.BackColor = Color.Black;
        }
        void DrawVerticalLines(PaintEventArgs e , Pen pen)
        {
            e.Graphics.DrawLine(pen, 450, 125, 450, 525);
            e.Graphics.DrawLine(pen, 600, 125, 600, 525);
        }

        void DrawHorizontalLines(PaintEventArgs e, Pen pen)
        {
            e.Graphics.DrawLine(pen, 325, 250, 725, 250);
            e.Graphics.DrawLine(pen, 325, 400, 725, 400);
        }

        void DrawGameLines(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 15);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            DrawHorizontalLines(e, pen);
            DrawVerticalLines(e, pen);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGameLines(e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox) sender);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox)sender);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox)sender);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox)sender);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox)sender);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox)sender);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox)sender);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox)sender);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PlayRound((PictureBox)sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
