using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessButOnlyHorse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button[,] board = new Button[10, 10];
            CreateBoard(board);
        }

        private void CreateBoard(Button[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i,j] = CreateButton(i,j);
                }
            }
        }

        private Button CreateButton(int satir, int sutun)
        {
            Button button = new Button();
            button.Size = new Size(30, 30);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            button.Margin = new Padding(0, 0, 0, 0);
            button.BackColor = (satir % 2 == 0) ? (sutun%2==0 ? Color.WhiteSmoke: Color.White) : (sutun%2==0 ? Color.White: Color.WhiteSmoke);
            panel_board.Controls.Add(button);
            return button;
            
        }
    }
}
