using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count = 0;
        int player = 1;
       
       private void choosePlayer(int player)
        {
            labelPlayerOne.Visible = true;
            labelPlayerTwo.Visible = true;
            labelPlayerMessage.Visible = false;
            if (player==1)
            {               
                labelPlayerOne.Text = "Player 1";              
                labelPlayerTwo.Text = "Player 2";               
            }
            else
            {
                labelPlayerOne.Text = "Player 2";
                labelPlayerTwo.Text = "Player 1";
            }
            buttonO.Enabled = false;
            buttonX.Enabled = false;
        }
        
        private void activeControl()
        {
            this.ActiveControl = null;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Visible = true;
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            count = 1;
            choosePlayer(count);
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            count = 2;
            choosePlayer(count);
        }
    }
}
