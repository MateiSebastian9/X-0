using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    


    public partial class joc : Form
    {
        int score1=0, score2=0;
        Font LargeFont = new Font("Arial", 50);
        bool player=false;
        Button [] matrice = new Button [20];
        Button Button1 = new Button();
        public void remiza()
        {
            for (int i = 0; i < 9; i++)
            {
                matrice[i].BackColor = Color.Orange;
                endgame();
            }
        }
        public void checkend()
        {
            int ok = 1,l=0;
            
            for (int i = 0; i < 3; i++)
            {
                if (matrice[i * 3].Text == matrice[(i * 3) + 1].Text && matrice[(i * 3) + 1].Text == matrice[(i * 3) + 2].Text && matrice[(i * 3) + 2].Text != "")
                {
                    matrice[i * 3].BackColor = Color.IndianRed;
                    matrice[(i * 3) + 1].BackColor = Color.IndianRed;
                    matrice[(i * 3) + 2].BackColor = Color.IndianRed;
                    if (player) score1 += 1;
                    else score2 += 1;
                    label4.Text = score1.ToString();
                    label5.Text = score2.ToString();
                    endgame();
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (matrice[(i * 3)+i].Text == matrice[(i+1)*3].Text && matrice[(i+1)+3].Text == matrice[(i+2)*3].Text && matrice[(i+2)*3].Text != "")
                {
                    matrice[i * 3)+ i].BackColor = Color.IndianRed;
                    matrice[(i * 3) + 1].BackColor = Color.IndianRed;
                    matrice[(i * 3) + 2].BackColor = Color.IndianRed;
                    if (player) score1 += 1;
                    else score2 += 1;
                    label4.Text = score1.ToString();
                    label5.Text = score2.ToString();
                    endgame();
                }
            }
            while (ok==1)
            {
                if (matrice[l].Text == "")
                    ok = 0;
                l++;
                if (l == 8) remiza();
            }
        }
        public joc()
        {
            InitializeComponent();
            label4.Text = "0";
            label5.Text = "0";
            for (int i = 0; i < 9; i++) {
                matrice[i] = new Button();
                matrice[i].Click += new EventHandler(button_Click);
                matrice[i].Top = (startbutton.Location.Y-640)+(((i/3)+1)*300);
                matrice[i].Parent = this;
                matrice[i].Height = 200;
                matrice[i].Width = 200;
                matrice[i].Left = 300 + startbutton.Location.X +300 * ((i % 3) + 1);
                matrice[i].Name = "";
                matrice[i].Text = matrice[i].Name;
        }
            endgame();
   
        }
            void endgame()
        {
            for(int i=0;i<9;i++)
            {
                matrice[i].Enabled = false;
            }
            startbutton.Enabled = true;
        }
            void startgame()
        {
            for (int i = 0; i < 9; i++)
            {
                matrice[i].Enabled = true;
                matrice[i].BackColor = Color.DimGray;
                matrice[i].ForeColor = Color.GhostWhite;
                matrice[i].Font = LargeFont;

                matrice[i].Text = "";
            }
            
        }
        private void startbutton_Click(object sender, EventArgs e)
        {
            startgame();
            startbutton.Enabled = false;
        }   
        private void Button1_Click(object sender, EventArgs e)
        {
            endgame();
            Console.WriteLine(sender);
        }

        private void joc_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            score1 = 0;
            score2 = 0;
            label4.Text = "0";
            label5.Text = "0";
        }

  

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text != "")
                return;
            if (player)
            {
                btn.Text = "0";
            }
            else btn.Text = "X";
            player = !player;
            checkend();
        }
    }
}
