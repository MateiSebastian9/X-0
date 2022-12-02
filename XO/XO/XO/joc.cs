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
       

        int score1 = 0, score2 = 0;
        Font LargeFont = new Font("Arial", 50);
        bool player = false;
        Button[] matrice = new Button[20];
        Button Button1 = new Button();
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
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
            int ok = 1, l = 0;

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
                if (matrice[i].Text == matrice[i+3].Text && matrice[i + 3].Text == matrice[i + 6].Text && matrice[i + 6].Text != "")
                {
                    matrice[i+3].BackColor = Color.IndianRed;
                    matrice[i+6].BackColor = Color.IndianRed;
                    matrice[i].BackColor = Color.IndianRed;
                    if (player) score1 += 1;
                    else score2 += 1;
                    label4.Text = score1.ToString();
                    label5.Text = score2.ToString();
                    endgame();
                }

            }
            if (matrice[0].Text == matrice[4].Text && matrice[4].Text == matrice[8].Text && matrice[4].Text!="")
            {
                matrice[0].BackColor = Color.IndianRed;
                matrice[4].BackColor = Color.IndianRed;
                matrice[8].BackColor = Color.IndianRed;
                if (player) score1 += 1;
                else score2 += 1;
                label4.Text = score1.ToString();
                label5.Text = score2.ToString();
                endgame();
            }
            if (matrice[2].Text == matrice[4].Text && matrice[4].Text == matrice[6].Text && matrice[4].Text != "")
            {
                matrice[2].BackColor = Color.IndianRed;
                matrice[4].BackColor = Color.IndianRed;
                matrice[6].BackColor = Color.IndianRed;
                if (player) score1 += 1;
                else score2 += 1;
                label4.Text = score1.ToString();
                label5.Text = score2.ToString();
                endgame();
            }
            while (ok == 1)
                {
                    if (l <= 8)
                    {
                        if (matrice[l].Text == "")
                            ok = 0;
                        l++;
                    }
                    else
                    {
                        remiza();
                        ok = 0;
                    }
                }
            
        }
        void initSizes()
        {
            label4.Text = "0";
            label5.Text = "0";
            label4.Top = screenHeight /10;
            label5.Top = screenHeight / 10;
            label4.Left = screenWidth / 35;
            label5.Left = screenWidth / 10;
            label2.Top = screenHeight / 16;
            label3.Top = screenHeight / 16;
            label2.Left = screenWidth / 70;
            label3.Left = screenWidth / 13;
            startbutton.Top = screenHeight / 2;
            startbutton.Left = screenWidth / 20;
        }
        public joc()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            initSizes();
            for (int i = 0; i < 9; i++) {
                matrice[i] = new Button();
                matrice[i].Click += new EventHandler(button_Click);
                matrice[i].Top = (startbutton.Location.Y-screenHeight*2/3)+(((i/3)+1)* screenHeight / 4);
                matrice[i].Parent = this;
                matrice[i].Height = screenHeight/5;
                matrice[i].Width = screenHeight/5;
                matrice[i].Left = screenWidth/6 + startbutton.Location.X + screenWidth/6 * ((i % 3) + 1);
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
            button2.Top = screenHeight / 20;
            button2.Left = screenHeight / 20;
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            score1 = 0;
            score2 = 0;
            label4.Text = "0";
            label5.Text = "0";
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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
