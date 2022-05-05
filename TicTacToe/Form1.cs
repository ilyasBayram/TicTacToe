using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region variables
        int count = 0;
        int player = 0;
        int scoreX = 0;
        int scoreO = 0;
        bool result;
        bool drawResult;
        #endregion

        SoundPlayer SignsSound = new SoundPlayer();
        SoundPlayer PlayingSound = new SoundPlayer();

        

        // when the buttons are clicked "x" or "o" letters added those lists.
        #region lists
        List<string> fromLeftToRightFirst = new List<string>();
        List<string> fromLeftToRightSecond = new List<string>();
        List<string> fromLeftToRightThird = new List<string>();
        List<string> fromUpToDownFirst = new List<string>();
        List<string> fromUpToDownSecond = new List<string>();
        List<string> fromUpToDownThird = new List<string>();
        List<string> fromLeftToDownDiagonal = new List<string>();
        List<string> fromRightToDownDiagonal = new List<string>();
        #endregion

        #region methods
        private void ButtonsEnable()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            buttonRestart.Enabled = true;
        }

        private void ButtonsUnenable()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            buttonRestart.Enabled = false;
        }

        // According to first choose it detirmenise what signs of players will be.
        private void ChoosePlayer()
        {
            labelPlayerOne.Visible = true;
            labelPlayerTwo.Visible = true;
            labelPlayerMessage.Visible = false;
            if (count==1)
            {               
                labelPlayerOne.Text = "Player 2";              
                labelPlayerTwo.Text = "Player 1";
                player = 1;
            }
            else
            {
                labelPlayerOne.Text = "Player 1";
                labelPlayerTwo.Text = "Player 2";
                player = 2;
            }
            buttonO.Enabled = false;
            buttonX.Enabled = false;
            ButtonsEnable();
            
        }

        //It clears text of buttons and lists members.
        private void ButtonsAndListClear()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            fromLeftToRightFirst.Clear();
            fromLeftToRightSecond.Clear();
            fromLeftToRightThird.Clear();
            fromUpToDownFirst.Clear();
            fromUpToDownSecond.Clear();
            fromUpToDownThird.Clear();
            fromLeftToDownDiagonal.Clear();
            fromRightToDownDiagonal.Clear();


        }
       
        // It checks if memebers of lists are same. If so it adds score to player.
        private  bool GameCheck(List<string> a, List<string> b, List<string> c,
            List<string> d, List<string> e, List<string> f, List<string> g, List<string> h)
        {
            int index = 0;
           
            if (a.Count == 3 && index !=2)
            {
                index = 0;
                
                for (int i = 0; i < 2; i++)
                {
                    if (a[index]==a[index+1])
                    {
                        index++;
                    }
                }

            }
            if (b.Count == 3 && index != 2)
            {
                index = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (b[index] == b[index + 1])
                    {
                        index++;
                    }
                }
            }
            if (c.Count == 3 && index != 2)
            {
                index = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (c[index] == c[index + 1])
                    {
                        index++;
                    }
                }
            }
            if (d.Count == 3 && index != 2)
            {
                index = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (d[index] == d[index + 1])
                    {
                        index++;
                    }
                }
            }
            if (e.Count == 3 && index != 2)
            {
                index = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (e[index] == e[index + 1])
                    {
                        index++;
                    }
                }
            }
            if (f.Count == 3 && index != 2)
            {
                index = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (f[index] == f[index + 1]) 
                    {
                        index++;
                    }
                    
                }
            }
            if (g.Count == 3 && index != 2)
            {
                index = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (g[index] == g[index + 1])
                    {
                        index++;
                    }
                }
            }
            if (h.Count == 3 && index != 2)
            {
                index = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (h[index] == h[index + 1])
                    {
                        index++;
                    }
                }
            }

            if (index==2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }           

        private bool draw()
        {
            if (fromLeftToRightFirst.Count==3 && fromLeftToRightSecond.Count==3 && fromLeftToRightThird.Count==3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        private void PlayerChange()
        {
            if (player==2)
            {
                player = 1;
            }
            else if (player==1)
            {
                player = 2;
            }
        }

        // It checks if someone reach to score 3 and make game ready for next one.
        private void GameResult()
        {
            result = GameCheck(fromLeftToRightFirst, fromLeftToRightSecond, fromLeftToRightThird, fromUpToDownFirst,
             fromUpToDownSecond, fromUpToDownThird, fromLeftToDownDiagonal, fromRightToDownDiagonal);
            drawResult = draw();
            if (result == true && count == 1 && player == 2)
            {
                scoreX++;
                lblScoreX.Text = Convert.ToString(scoreX);
                ButtonsAndListClear();
                ButtonsEnable();
                PlayerChange();

            }
            else if (result == true && count == 1 && player == 1)
            {
                scoreO++;
                lblScoreO.Text = Convert.ToString(scoreO);
                ButtonsAndListClear();
                ButtonsEnable();
                PlayerChange();
            }
            else if (result == true && count == 2 && player == 1 )
            {
                scoreO++;
                lblScoreO.Text = Convert.ToString(scoreO);
                ButtonsAndListClear();
                ButtonsEnable();
                PlayerChange();
            }
            else if (result == true && count == 2 && player == 2)
            {
                scoreX++;
                lblScoreX.Text = Convert.ToString(scoreX);
                ButtonsAndListClear();
                ButtonsEnable();
                PlayerChange();
            }
            if (scoreO==3 || scoreX==3)
            {
                labelPlayerMessage.Text = "";
                labelPlayerMessage.Visible = true;
                if (scoreX==3)
                {
                    labelPlayerMessage.Text = "             X is the winner.";
                    scoreX = 0;
                }
                else if (scoreO==3)
                {
                    labelPlayerMessage.Text = "              O is the winner.";
                    scoreO = 0;
                }
               
                ButtonsUnenable();
                buttonX.Enabled = true;
                buttonO.Enabled = true;
                labelPlayerOne.Text = "";
                labelPlayerTwo.Text = "";
                lblScoreO.Text = "-";
                lblScoreX.Text = "-";
            }
            if (drawResult == true)
            {
                ButtonsAndListClear();
                ButtonsEnable();
                PlayerChange();
            }


        }

        private void ButtonSound()
        {
            SignsSound.SoundLocation = @"C:\Users\ilyas.bayram\source\repos\TicTacToe\TicTacToe\buttonClick.wav";
            SignsSound.Play();
        }

        #endregion

        #region buttons
        private void buttonO_Click(object sender, EventArgs e)
        {
            count = 2;
            ChoosePlayer();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            count = 1;
            ChoosePlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player==1)
            {
                fromLeftToRightFirst.Add("x");
                fromUpToDownFirst.Add("x");
                fromLeftToDownDiagonal.Add("x");
                button1.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightFirst.Add("o");
                fromUpToDownFirst.Add("o");
                fromLeftToDownDiagonal.Add("o");
                button1.Text = "O";
                player = 1;
            }           
            button1.Enabled = false;
            GameResult();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player == 1)
            {
                fromLeftToRightFirst.Add("x");
                fromUpToDownSecond.Add("x");
                button2.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightFirst.Add("o");
                fromUpToDownSecond.Add("o");
                button2.Text = "O";
                player = 1;
            }
            button2.Enabled = false;
            GameResult();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player == 1)
            {
                fromLeftToRightFirst.Add("x");
                fromUpToDownThird.Add("x");
                fromRightToDownDiagonal.Add("x");
                button3.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightFirst.Add("o");
                fromUpToDownThird.Add("o");
                fromRightToDownDiagonal.Add("o");
                button3.Text = "O";
                player = 1;
            }
            button3.Enabled = false;
            GameResult();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player == 1)
            {
                fromLeftToRightSecond.Add("x");
                fromUpToDownFirst.Add("x");
                button4.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightSecond.Add("o");
                fromUpToDownFirst.Add("o");
                button4.Text = "O";
                player = 1;
            }
            button4.Enabled = false;
            GameResult();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player == 1)
            {
                fromLeftToRightSecond.Add("x");
                fromUpToDownSecond.Add("x");
                fromLeftToDownDiagonal.Add("x");
                fromRightToDownDiagonal.Add("x");
                button5.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightSecond.Add("o");
                fromUpToDownSecond.Add("o");
                fromLeftToDownDiagonal.Add("o");
                fromRightToDownDiagonal.Add("o");
                button5.Text = "O";
                player = 1;
            }
            button5.Enabled = false;
            GameResult();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player == 1)
            {
                fromLeftToRightSecond.Add("x");
                fromUpToDownThird.Add("x");
                button6.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightSecond.Add("o");
                fromUpToDownThird.Add("o");
                button6.Text = "O";
                player = 1;
            }
            button6.Enabled = false;
            GameResult();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player == 1)
            {
                fromLeftToRightThird.Add("x");
                fromUpToDownFirst.Add("x");
                fromRightToDownDiagonal.Add("x");
                button7.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightThird.Add("o");
                fromUpToDownFirst.Add("o");
                fromRightToDownDiagonal.Add("o");
                button7.Text = "O";
                player = 1;
            }
            button7.Enabled = false;
            GameResult();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player == 1)
            {
                fromLeftToRightThird.Add("x");
                fromUpToDownSecond.Add("x");
                button8.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightThird.Add("o");
                fromUpToDownSecond.Add("o");
                button8.Text = "O";
                player = 1;
            }
            button8.Enabled = false;
            GameResult();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonSound();
            if (player == 1)
            {
                fromLeftToRightThird.Add("x");
                fromUpToDownThird.Add("x");
                fromLeftToDownDiagonal.Add("x");
                button9.Text = "X";
                player = 2;
            }
            else
            {
                fromLeftToRightThird.Add("o");
                fromUpToDownThird.Add("o");
                fromLeftToDownDiagonal.Add("o");
                button9.Text = "O";
                player = 1;
            }
            button9.Enabled = false;
            GameResult();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           ButtonsUnenable();

          
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {

            ButtonsUnenable();
            ButtonsAndListClear();
            buttonO.Enabled = true;
            buttonX.Enabled = true;
            labelPlayerOne.Text = "";
            labelPlayerTwo.Text = "";
            lblScoreO.Text = "-";
            lblScoreX.Text = "-";

        }
    }
    #endregion
}
