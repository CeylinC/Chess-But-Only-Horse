using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessButOnlyHorse
{
    public partial class Form1 : Form
    {
        Button[,] board;
        bool firstClick;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Button[10, 10];
            firstClick = true;
            CreateBoard(); 
        }

        private void CreateBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i,j] = CreateButton();
                    
                }
            }
            ColorBoard();
        }

        private Button CreateButton()
        {
            Button button = new Button();

            //Görünüm
            button.Size = new Size(30, 30);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            button.Margin = new Padding(0, 0, 0, 0);
            button.Tag = false;
            button.TabStop = false;

            //Fonksiyon
            button.Click += ClickButton;

            panel_board.Controls.Add(button);
            
            return button;
            
        }

        private void ColorBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i,j].BackColor = (i % 2 == 0) ? (j % 2 == 0 ? Color.WhiteSmoke : Color.White) : (j % 2 == 0 ? Color.White : Color.WhiteSmoke);
                    if ((bool)board[i,j].Tag)
                    {
                        board[i, j].BackColor = Color.Green;
                    }
                    if (!firstClick)
                    {
                        board[i, j].Enabled = false;
                    }
                }
            }
        }
        private void ClickButton(object sender, EventArgs e)
        {
            ColorBoard();
            Button clickedButton = (Button)sender;
            if (firstClick || !(bool)clickedButton.Tag)
            {
                firstClick = false;
                clickedButton.Tag = true;
                DisplayMove(clickedButton);

            }
        }

        private void ButtonControl(Dictionary<char, int> location, int i, int j)
        {
            if (location['y'] - i >= 0)
            {
                if (location['x'] - j >= 0)
                {
                    if (!(bool)board[location['y'] - i, location['x'] - j].Tag)
                    {
                        board[location['y'] - i, location['x'] - j].BackColor = Color.MediumPurple;
                        board[location['y'] - i, location['x'] - j].Enabled= true;
                    }
                }
                if (location['x'] + j < board.GetLength(1))
                {
                    if (!(bool)board[location['y'] - i, location['x'] + j].Tag)
                    {
                        board[location['y'] - i, location['x'] + j].BackColor = Color.MediumPurple;
                        board[location['y'] - i, location['x'] + j].Enabled = true;
                    }
                }
            }

            if (location['y'] + i < board.GetLength(0))
            {
                if (location['x'] - j >= 0)
                {
                    if (!(bool)board[location['y'] + i, location['x'] - j].Tag)
                    {
                        board[location['y'] + i, location['x'] - j].BackColor = Color.MediumPurple;
                        board[location['y'] + i, location['x'] - j].Enabled = true;
                    }
                }
                if (location['x'] + j < board.GetLength(1))
                {
                    if (!(bool)board[location['y'] + i, location['x'] + j].Tag)
                    {
                        board[location['y'] + i, location['x'] + j].BackColor = Color.MediumPurple;
                        board[location['y'] + i, location['x'] + j].Enabled = true;
                    }
                }
            }
        }

        private void DisplayMove(Button clickedButton)
        {
            Dictionary<char, int> location = FindButton(clickedButton);
            ColorBoard();
            ButtonControl(location, 1, 2);
            ButtonControl(location, 2, 1);
        }

        private Dictionary<char, int> FindButton(Button clickedButton)
        {
            Dictionary<char, int> button = new Dictionary<char, int>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].Equals(clickedButton))
                    {
                        Console.WriteLine($"Satır: {i + 1} Sütun: {j + 2} Tıklandı");
                        clickedButton.BackColor = Color.Purple;
                        button.Add('y', i);
                        button.Add('x', j);
                        return button;
                    }
                }
            }
            return null;
        }
    }
}
