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
        int score = 0, size = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Button[10, 10];
            firstClick = true;
            score= 0;
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
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
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
        private void ClearBoard()
        {
            panel_board.Controls.Clear();
            switch (size)
            {
                case 5:
                    panel_board.Size = new Size(150, 150);
                    break;
                case 6:
                    panel_board.Size = new Size(200, 200);
                    break;
                case 7:
                    panel_board.Size = new Size(220, 220);
                    break;
                case 8:
                    panel_board.Size = new Size(255, 255);
                    break;
                case 9:
                    panel_board.Size = new Size(280, 280);
                    break;
                case 10:
                    panel_board.Size = new Size(300, 300);
                    break;
                default:
                    break;
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j].Tag = false;
                    board[i, j].Enabled = true;
                    panel_board.Controls.Add(board[i,j]);

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
                label_score.Text = $"Score: {++score}";
                DisplayMove(clickedButton);

            }
        }
        private bool ButtonControl(Dictionary<char, int> location, int i, int j)
        {
            bool a = false, b = false, c = false, d = false; //Hareket etme hakkı sıfırlanırsa kaybetmiş olacak
            if (location['y'] - i >= 0)
            {
                if (location['x'] - j >= 0)
                {
                    if (!(bool)board[location['y'] - i, location['x'] - j].Tag)
                    {
                        board[location['y'] - i, location['x'] - j].BackColor = Color.MediumPurple;
                        board[location['y'] - i, location['x'] - j].Enabled= true;
                        a = true;
                    }
                }
                if (location['x'] + j < size)
                {
                    if (!(bool)board[location['y'] - i, location['x'] + j].Tag)
                    {
                        board[location['y'] - i, location['x'] + j].BackColor = Color.MediumPurple;
                        board[location['y'] - i, location['x'] + j].Enabled = true;
                        b = true;
                    }
                }
            }

            if (location['y'] + i < size)
            {
                if (location['x'] - j >= 0)
                {
                    if (!(bool)board[location['y'] + i, location['x'] - j].Tag)
                    {
                        board[location['y'] + i, location['x'] - j].BackColor = Color.MediumPurple;
                        board[location['y'] + i, location['x'] - j].Enabled = true;
                        c = true;
                    }
                }
                if (location['x'] + j < size)
                {
                    if (!(bool)board[location['y'] + i, location['x'] + j].Tag)
                    {
                        board[location['y'] + i, location['x'] + j].BackColor = Color.MediumPurple;
                        board[location['y'] + i, location['x'] + j].Enabled = true;
                        d = true;
                    }
                }
            }
            return a||b||c||d;
        }
        private void DisplayMove(Button clickedButton)
        {
            ColorBoard();
            Dictionary<char, int> location = FindButton(clickedButton);
            if (!(ButtonControl(location, 2, 1) | ButtonControl(location, 1, 2)))
            {
                if (FinishGameControl())
                {
                    MessageBox.Show("!!!Winner!!!");
                }
                else
                {
                    DisplayGameOver();
                }
            }
            
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
        private void button_play_Click(object sender, EventArgs e)
        {
            score = 0;
            firstClick = true;
            ClearBoard();
            ColorBoard();
        }
        private void button_size_Click(object sender, EventArgs e)
        {
            size = (size == 10) ? 5 : ++size;
            button_size.Text = $"{size}x{size}";
        }
        private void DisplayGameOver()
        {
            MessageBox.Show($"Game Over\nScore: {score}");
        }
        private bool FinishGameControl()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!(bool)board[i, j].Tag)
                    {
                        return false; //oyun bitmedi
                    }
                }
            }
            return true; //oyun bitti
        }
    }
}
