using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game_Caro
{
    public partial class Form1 : Form
    {
        DrawChessBroad draw;
        public Form1()
        {
            InitializeComponent();
            draw = new DrawChessBroad(pnlChessBroad,txtlbName,pcbMark);
            draw.EndedGame += Draw_EndedGame;
            draw.PlayerMarked += Draw_PlayerMarked;

            pgbCoolDown.Maximum = Const.CoolDownTime;
            pgbCoolDown.Value = 0;

            tmCoolDown.Interval = Const.CoolDownIterval;

            NewGame();      
        }

        void NewGame()
        {
            tmCoolDown.Stop();
            pgbCoolDown.Value = 0;
            draw.DrawChessBoard();            
        }
        void QuitGame()
        {
                Application.Exit();                    
        }
        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBroad.Enabled = false;
            MessageBox.Show("Kết thúc game");
        }
        private void Draw_PlayerMarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();
            pgbCoolDown.Value = 0;
        }

        private void Draw_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            pgbCoolDown.PerformStep();
            if (pgbCoolDown.Value >= pgbCoolDown.Maximum)
            {
                EndGame();
            }   
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuitGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát game ?", "Thông báo", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
