using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour
{

    public partial class Form1 : Form
    {

        public const int NumOfRows = 7;
        public const int NumOfColumn = 8;
        public enum Value { EMPTY, PLAYER1, PLAYER2 };
        private Value[][] matrix;
        private bool turn = false;
        private bool isComputerEasy = false;
        private bool isComputerMedium = false;
        private bool isComputerHard = false;
        private bool play = false;
        private Color colorOfPlayer1 = Color.Blue;
        private Color colorOfPlayer2 = Color.Red;
        private Color colorOfComputer = Color.Yellow;
        private int player1Score = 0;
        private int player2Score = 0;
        private void initializeColorOfPlayer1()
        {
            PictureBox pictureBox = this.player1;
            Image DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
            pictureBox.Image = DrawArea;
            Graphics g = Graphics.FromImage(DrawArea);
            Pen myPen = new Pen(Brushes.Black, 2);
            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
            SolidBrush brush = new SolidBrush(colorOfPlayer1);
            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
        }
        private void initializeColorOfPlayer2()
        {
            PictureBox pictureBox = this.player2;
            Image DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
            pictureBox.Image = DrawArea;
            Graphics g = Graphics.FromImage(DrawArea);
            Pen myPen = new Pen(Brushes.Black, 2);
            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
            SolidBrush brush = new SolidBrush(colorOfPlayer2);
            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
        }
        private void initializeColorOfComputer()
        {
            PictureBox pictureBox = this.player2;
            Image DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
            pictureBox.Image = DrawArea;
            Graphics g = Graphics.FromImage(DrawArea);
            Pen myPen = new Pen(Brushes.Black, 2);
            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
            SolidBrush brush = new SolidBrush(colorOfComputer);
            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
        }
        private void initializeColorOfGroupBox()
        {
            foreach (Control control in this.groupBox.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)control;
                    Image DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
                    pictureBox.Image = DrawArea;
                    Graphics g = Graphics.FromImage(DrawArea);
                    Pen myPen = new Pen(Brushes.Black, 2);
                    g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
                    SolidBrush brush = new SolidBrush(Color.Orange);
                    g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
                }
            }
        }
        private void initializeColorOfGame()
        {
            foreach (Control control in this.game.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)control;
                    Image DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
                    pictureBox.Image = DrawArea;
                    Graphics g = Graphics.FromImage(DrawArea);
                    Pen myPen = new Pen(Brushes.Black, 2);
                    g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
                    SolidBrush brush = new SolidBrush(Color.Orange);
                    g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
                }
            }
        }
        private void initializeMatrix()
        {
            matrix = new Value[NumOfRows][];
            for (int i = 0; i < NumOfRows; i++)
            {
                matrix[i] = new Value[NumOfColumn];
                for (int j = 0; j < NumOfColumn; j++)
                {
                    matrix[i][j] = new Value();
                    matrix[i][j] = Value.EMPTY;
                }
            }
        }
        public Form1()
        {
            initializeMatrix();
            InitializeComponent();
            initializeColorOfPlayer1();
            initializeColorOfPlayer2();
            initializeColorOfGroupBox();
            initializeColorOfGame();
        }
        private void pictureBoxEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
            pictureBox.Image = DrawArea;
            Graphics g = Graphics.FromImage(DrawArea);
            Pen myPen = new Pen(Brushes.Black, 2);
            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
            SolidBrush brush;
            if (turn == false) brush = new SolidBrush(this.colorOfPlayer1);
            else brush = new SolidBrush(this.colorOfPlayer2);
            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
        }
        private void pictureBoxLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
            pictureBox.Image = DrawArea;
            Graphics g = Graphics.FromImage(DrawArea);
            Pen myPen = new Pen(Brushes.Black, 2);
            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
            SolidBrush brush = new SolidBrush(Color.Orange);
            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
        }
        private void easyComputer()
        {
            Random random = new Random();
            int num = random.Next(0, NumOfColumn);
            String nameOfPB = "pb";
            nameOfPB += num;
            PictureBox pictureBox = null;
            SolidBrush brush;

            DateTime now = DateTime.Now;
            while ((DateTime.Now - now).Seconds < 0.5);

            Image DrawArea;
            Graphics g;
            Pen myPen;

            int i, temp = -1;
            int j = num;

            for (i = 0; i < NumOfRows;)
            {
                if (matrix[i][j] == Value.EMPTY)
                {
                    temp = i;
                    i++;
                }
                else break;
            }

            if (temp == -1)
            {
                MessageBox.Show("Invalid move!");
                bool found = false;
                for (int k = 0; k < NumOfColumn; k++)
                    if (matrix[0][k] == Value.EMPTY) { found = true; break; }
                if (found == true)
                {
                    MessageBox.Show("EndGame!");
                    initializeMatrix();
                    initializeColorOfGroupBox();
                    initializeColorOfGame();
                    if (this.isComputerEasy || this.isComputerMedium || this.isComputerHard) turn = false;
                }
            }
            else
            {
                if (turn == false)
                {
                    matrix[temp][j] = Value.PLAYER1;
                    brush = new SolidBrush(this.colorOfPlayer1);
                    turn = true;
                }
                else
                {
                    matrix[temp][j] = Value.PLAYER2;
                    brush = new SolidBrush(this.colorOfComputer);
                    turn = false;
                }
                foreach (Control control in this.game.Controls)
                {
                    if (control is PictureBox)
                    {
                        pictureBox = (PictureBox)control;
                        if (pictureBox.Name[10] == temp + '0' && pictureBox.Name[11] == j + '0')
                        {
                            DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
                            pictureBox.Image = DrawArea;
                            g = Graphics.FromImage(DrawArea);
                            myPen = new Pen(Brushes.Black, 2);
                            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
                            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
                        }
                    }
                }
                if (this.isWeHaveWinner() == true)
                {
                    if (turn == false)
                    {
                        player2Score++;
                        MessageBox.Show("Player2 is winner!\n");
                    }
                    else
                    {
                        player1Score++;
                        MessageBox.Show("Player1 is winner!\n");
                    }
                    initializeMatrix();
                    initializeColorOfGroupBox();
                    initializeColorOfGame();
                    if (this.isComputerEasy || this.isComputerMedium || this.isComputerHard) turn = false;
                }
            }
        }
        private int getNumber()
        {
            Random random = new Random();
            int temp = 0;
            int maxPlayer1 = 0;
            for(int i = 0; i < NumOfRows; i++)
            {
                for(int j = 0; j < NumOfColumn; j++)
                {

                    if (matrix[i][j] == Value.EMPTY || matrix[i][j] == Value.PLAYER2) continue;
                    int critical = 0;
                    if (j >= 3)
                    {
                        if (matrix[i][j] == matrix[i][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i][j - 3]) critical++;
                    }
                    if (critical == 1 || critical == 2)
                    { 
                        if (random.Next(0, 2) == 1) maxPlayer1 = j - 1;
                        else
                        {
                            if (random.Next(0, 2) == 1) maxPlayer1 = j - 3;
                            else maxPlayer1 = j - 2;
                        }
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4)
                    {
                        if (matrix[i][j] == matrix[i][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i][j + 3]) critical++;
                    }
                    if (critical == 1 || critical == 2)
                    {
                        if (random.Next(0, 2) == 1) maxPlayer1 = j + 1;
                        else
                        {
                            if (random.Next(0, 2) == 1) maxPlayer1 = j + 3;
                            else maxPlayer1 = j + 2;
                        }
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j]) critical++;
                    }
                    if (critical == 1 || critical == 2)
                    {
                        maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j]) critical++;
                    }
                    if (critical == 1 || critical == 2)
                    {
                        maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j >= 3 && i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j - 3]) critical++;
                    }
                    if (critical == 1 || critical == 2)
                    {
                        if (random.Next(0, 2) == 1) maxPlayer1 = j - 1;
                        else
                        {
                            if (random.Next(0, 2) == 1) maxPlayer1 = j - 3;
                            else maxPlayer1 = j - 2;
                        }
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4 && i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j + 3]) critical++;
                    }
                    if (critical == 1 || critical == 2)
                    {
                        if (random.Next(0, 2) == 1) maxPlayer1 = j + 1;
                        else
                        {
                            if (random.Next(0, 2) == 1) maxPlayer1 = j + 3;
                            else maxPlayer1 = j + 2;
                        }
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j >= 3 && i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j - 3]) critical++;
                    }
                    if (critical == 1 || critical == 2)
                    {
                        if (random.Next(0, 2) == 1) maxPlayer1 = j - 1;
                        else
                        {
                            if (random.Next(0, 2) == 1) maxPlayer1 = j - 3;
                            else maxPlayer1 = j - 2;
                        }
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4 && i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j + 3]) critical++;
                    }
                    if (critical == 1 || critical == 2)
                    {
                        if (random.Next(0, 2) == 1) maxPlayer1 = j + 1;
                        else
                        {
                            if (random.Next(0, 2) == 1) maxPlayer1 = j + 3;
                            else maxPlayer1 = j + 2;
                        }
                        return maxPlayer1;
                    }
                }
            }

            temp = random.Next(0, NumOfColumn);
            return temp;
        }
        private int getCriticalHard()
        {
            int maxPlayer1 = 0;
            for (int i = 0; i < NumOfRows; i++)
            {
                for (int j = 0; j < NumOfColumn; j++)
                {

                    if (matrix[i][j] == Value.EMPTY || matrix[i][j] == Value.PLAYER2) continue; 
                    int critical = 0;
                    if (j >= 3)
                    {
                        if (matrix[i][j] == matrix[i][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i][j - 3]) critical++;
                    }
                    if (critical == 2)
                    {
                        if (matrix[i][j - 4] == Value.EMPTY) maxPlayer1 = j - 4;
                        else maxPlayer1 = j + 1;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4)
                    {
                        if (matrix[i][j] == matrix[i][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i][j + 3]) critical++;
                    }
                    if (critical == 2)
                    {
                        if (matrix[i][j + 4] == Value.EMPTY) maxPlayer1 = j + 4;
                        else maxPlayer1 = j - 1;
                        return maxPlayer1; 
                    }
                    critical = 0;
                    if (i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j]) critical++;
                    }
                    if (critical == 2)
                    {
                        maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j]) critical++;
                    }
                    if (critical == 2)
                    {
                        maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j >= 3 && i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j - 3]) critical++;
                    }
                    if (critical == 2)
                    {
                        if (matrix[i][j - 4] == Value.EMPTY) maxPlayer1 = j - 4;
                        else maxPlayer1 = j + 1;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4 && i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j + 3]) critical++;
                    }
                    if (critical == 2)
                    {
                        if (matrix[i][j + 4] == Value.EMPTY) maxPlayer1 = j + 4;
                        else maxPlayer1 = j - 1;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j >= 3 && i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j - 3]) critical++;
                    }
                    if (critical == 2)
                    {
                        if (matrix[i][j + 4] == Value.EMPTY) maxPlayer1 = j - 4;
                        else maxPlayer1 = j + 1;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4 && i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j + 3]) critical++;
                    }
                    if (critical == 2)
                    {
                        if (matrix[i][j + 4] == Value.EMPTY) maxPlayer1 = j + 4;
                        else maxPlayer1 = j - 1;
                        return maxPlayer1;
                    }
                }
            }
            return -1;
        }
        private int getHard()
        {
            int maxPlayer1 = 0;
            for (int i = 0; i < NumOfRows; i++)
            {
                for (int j = 0; j < NumOfColumn; j++)
                {

                    if (matrix[i][j] == Value.EMPTY || matrix[i][j] == Value.PLAYER2) continue;
                    int critical = 0;
                    if (j >= 3)
                    {
                        if (matrix[i][j] == matrix[i][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i][j - 3]) critical++;
                    }
                    if (critical == 1)
                    {
                        if (matrix[i][j - 3] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else if (matrix[i][j - 2] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 1;
                        }
                        else if (matrix[i][j - 3] == matrix[i][j - 2] && matrix[i][j - 2] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 1;
                        }
                        else if (matrix[i][j - 1] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else if (matrix[i][j - 3] == matrix[i][j - 1] && matrix[i][j - 1] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4)
                    {
                        if (matrix[i][j] == matrix[i][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i][j + 3]) critical++;
                    }
                    if (critical == 1)
                    {
                        if (matrix[i][j + 3] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else if (matrix[i][j + 2] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 1;
                        }
                        else if (matrix[i][j + 3] == matrix[i][j + 2] && matrix[i][j + 2] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 1;
                        }
                        else if (matrix[i][j + 1] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else if (matrix[i][j + 3] == matrix[i][j + 1] && matrix[i][j + 1] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j]) critical++;
                    }
                    if (critical == 1)
                    {
                        maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j]) critical++;
                    }
                    if (critical == 1)
                    {
                        maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j >= 3 && i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j - 3]) critical++;
                    }
                    if (critical == 1)
                    {
                        if (matrix[i][j - 3] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else if (matrix[i][j - 2] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 1;
                        }
                        else if (matrix[i][j - 3] == matrix[i][j - 2] && matrix[i][j - 2] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 1;
                        }
                        else if (matrix[i][j - 1] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else if (matrix[i][j - 3] == matrix[i][j - 1] && matrix[i][j - 1] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4 && i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i + 2][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i + 3][j + 3]) critical++;
                    }
                    if (critical == 1)
                    {
                        if (matrix[i][j + 3] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else if (matrix[i][j + 2] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 1;
                        }
                        else if (matrix[i][j + 3] == matrix[i][j + 2] && matrix[i][j + 2] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 1;
                        }
                        else if (matrix[i][j + 1] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else if (matrix[i][j + 3] == matrix[i][j + 1] && matrix[i][j + 1] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j >= 3 && i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j - 1]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j - 2]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j - 3]) critical++;
                    }
                    if (critical == 1)
                    {
                        if (matrix[i][j - 3] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else if (matrix[i][j - 2] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 1;
                        }
                        else if (matrix[i][j - 3] == matrix[i][j - 2] && matrix[i][j - 2] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 1;
                        }
                        else if (matrix[i][j - 1] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else if (matrix[i][j - 3] == matrix[i][j - 1] && matrix[i][j - 1] != Value.EMPTY)
                        {
                            maxPlayer1 = j - 2;
                        }
                        else maxPlayer1 = j;
                        return maxPlayer1;
                    }
                    critical = 0;
                    if (j <= 4 && i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j + 1]) critical++;
                        if (matrix[i][j] == matrix[i - 2][j + 2]) critical++;
                        if (matrix[i][j] == matrix[i - 3][j + 3]) critical++;
                    }
                    if (critical == 1)
                    {
                        if (matrix[i][j + 3] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else if (matrix[i][j + 2] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 1;
                        }
                        else if (matrix[i][j + 3] == matrix[i][j + 2] && matrix[i][j + 2] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 1;
                        }
                        else if (matrix[i][j + 1] == matrix[i][j] && matrix[i][j] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else if (matrix[i][j + 3] == matrix[i][j + 1] && matrix[i][j + 1] != Value.EMPTY)
                        {
                            maxPlayer1 = j + 2;
                        }
                        else maxPlayer1 = j;
                        return maxPlayer1;
                    }
                }
            }
            return -1;
        }
        private int attack()
        {
            Random rand = new Random();
            return rand.Next(0, NumOfColumn);
        }
        private int getNumberHard()
        {
            int i = getCriticalHard();
            if (i != -1) return i;
            i = getHard();
            if (i != -1) return i;
            i = attack();
            return i;
        }
        private void medijumComputer()
        {
            int num = getNumber();
            String nameOfPB = "pb";
            nameOfPB += num;
            PictureBox pictureBox = null;
            SolidBrush brush;

            DateTime now = DateTime.Now;
            while ((DateTime.Now - now).Seconds < 0.5) ;

            Image DrawArea;
            Graphics g;
            Pen myPen;

            int i, temp = -1;
            int j = num;

            for (i = 0; i < NumOfRows;)
            {
                if (matrix[i][j] == Value.EMPTY)
                {
                    temp = i;
                    i++;
                }
                else break;
            }

            if (temp == -1)
            {
                for (int k = 0; k < NumOfColumn; k++)
                    if (matrix[0][k] == Value.EMPTY) temp = k;
            }

            if (temp == -1)
            {
                MessageBox.Show("Invalid move!");
                bool found = false;
                for (int k = 0; k < NumOfColumn; k++)
                    if (matrix[0][k] == Value.EMPTY){ found = true; break; }
                if (found == true)
                {
                    MessageBox.Show("EndGame!");
                    initializeMatrix();
                    initializeColorOfGroupBox();
                    initializeColorOfGame();
                    if (this.isComputerEasy || this.isComputerMedium || this.isComputerHard) turn = false;
                }
            }
            else
            {
                if (turn == false)
                {
                    matrix[temp][j] = Value.PLAYER1;
                    brush = new SolidBrush(this.colorOfPlayer1);
                    turn = true;
                }
                else
                {
                    matrix[temp][j] = Value.PLAYER2;
                    brush = new SolidBrush(this.colorOfComputer);
                    turn = false;
                }
                foreach (Control control in this.game.Controls)
                {
                    if (control is PictureBox)
                    {
                        pictureBox = (PictureBox)control;
                        if (pictureBox.Name[10] == temp + '0' && pictureBox.Name[11] == j + '0')
                        {
                            DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
                            pictureBox.Image = DrawArea;
                            g = Graphics.FromImage(DrawArea);
                            myPen = new Pen(Brushes.Black, 2);
                            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
                            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
                        }
                    }
                }
                if (this.isWeHaveWinner() == true)
                {
                    if (turn == false)
                    {
                        player2Score++;
                        MessageBox.Show("Player2 is winner!\n");
                    }
                    else
                    {
                        player1Score++;
                        MessageBox.Show("Player1 is winner!\n");
                    }
                    initializeMatrix();
                    initializeColorOfGroupBox();
                    initializeColorOfGame();
                    if (this.isComputerEasy || this.isComputerMedium || this.isComputerHard) turn = false;
                }
            }
        }
        private void hardComputer()
        {
            int num = getNumberHard();
            String nameOfPB = "pb";
            nameOfPB += num;
            PictureBox pictureBox = null;
            SolidBrush brush;

            DateTime now = DateTime.Now;
            while ((DateTime.Now - now).Seconds < 0.5) ;

            Image DrawArea;
            Graphics g;
            Pen myPen;

            int i, temp = -1;
            int j = num;

            for (i = 0; i < NumOfRows;)
            {
                if (matrix[i][j] == Value.EMPTY)
                {
                    temp = i;
                    i++;
                }
                else break;
            }

            if (temp == -1)
            {
                for (int k = 0; k < NumOfColumn; k++)
                    if (matrix[0][k] == Value.EMPTY) temp = k;
            }

            if (temp == -1)
            {
                MessageBox.Show("Invalid move!");
                bool found = false;
                for (int k = 0; k < NumOfColumn; k++)
                    if (matrix[0][k] == Value.EMPTY) { found = true; break; }
                if (found == true)
                {
                    MessageBox.Show("EndGame!");
                    initializeMatrix();
                    initializeColorOfGroupBox();
                    initializeColorOfGame();
                    if (this.isComputerEasy || this.isComputerMedium || this.isComputerHard) turn = false;
                }
            }
            else
            {
                if (turn == false)
                {
                    matrix[temp][j] = Value.PLAYER1;
                    brush = new SolidBrush(this.colorOfPlayer1);
                    turn = true;
                }
                else
                {
                    matrix[temp][j] = Value.PLAYER2;
                    brush = new SolidBrush(this.colorOfComputer);
                    turn = false;
                }
                foreach (Control control in this.game.Controls)
                {
                    if (control is PictureBox)
                    {
                        pictureBox = (PictureBox)control;
                        if (pictureBox.Name[10] == temp + '0' && pictureBox.Name[11] == j + '0')
                        {
                            DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
                            pictureBox.Image = DrawArea;
                            g = Graphics.FromImage(DrawArea);
                            myPen = new Pen(Brushes.Black, 2);
                            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
                            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
                        }
                    }
                }
                if (this.isWeHaveWinner() == true)
                {
                    if (turn == false)
                    {
                        player2Score++;
                        MessageBox.Show("Player2 is winner!\n");
                    }
                    else
                    {
                        player1Score++;
                        MessageBox.Show("Player1 is winner!\n");
                    }
                    initializeMatrix();
                    initializeColorOfGroupBox();
                    initializeColorOfGame();
                    if (this.isComputerEasy || this.isComputerMedium || this.isComputerHard) turn = false;
                }
            }
        }
        private void playerPlay(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
            pictureBox.Image = DrawArea;
            Graphics g = Graphics.FromImage(DrawArea);
            Pen myPen = new Pen(Brushes.Black, 2);
            g.DrawRectangle(myPen, 0, 0, pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
            SolidBrush brush = new SolidBrush(Color.Orange);
            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);

            int i, temp = -1;
            int j = pictureBox.Name[2] - '0';

            for (i = 0; i < NumOfRows;)
            {
                if (matrix[i][j] == Value.EMPTY)
                {
                    temp = i;
                    i++;
                }
                else break;
            }

            if (temp == -1)
            {
                MessageBox.Show("Invalid move!");
                bool found = false;
                for (int k = 0; k < NumOfColumn; k++)
                    if (matrix[0][k] == Value.EMPTY) { found = true; break; }
                if (found == true)
                {
                    MessageBox.Show("EndGame!");
                    initializeMatrix();
                    initializeColorOfGroupBox();
                    initializeColorOfGame();
                    if (this.isComputerEasy || this.isComputerMedium || this.isComputerHard) turn = false;
                }
            }
            else
            {
                if (turn == false)
                {
                    matrix[temp][j] = Value.PLAYER1;
                    brush = new SolidBrush(this.colorOfPlayer1);
                    turn = true;
                }
                else
                {
                    matrix[temp][j] = Value.PLAYER2;
                    brush = new SolidBrush(this.colorOfPlayer2);
                    turn = false;
                }
                foreach (Control control in this.game.Controls)
                {
                    if (control is PictureBox)
                    {
                        pictureBox = (PictureBox)control;
                        if (pictureBox.Name[10] == temp + '0' && pictureBox.Name[11] == j + '0')
                        {
                            DrawArea = new Bitmap(pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
                            pictureBox.Image = DrawArea;
                            g = Graphics.FromImage(DrawArea);
                            myPen = new Pen(Brushes.Black, 2);
                            g.DrawRectangle(myPen, 0, 0, pb0.Size.Width - 1, pb0.Size.Height - 1);
                            g.FillEllipse(brush, 0, 0, pictureBox.Size.Width - 2, pictureBox.Size.Height - 2);
                        }
                    }
                }
            }
        }
        private void pictureBoxClick(object sender, EventArgs e)
        {
            if (play == false) return;
            playerPlay(sender, e);
            if (this.isWeHaveWinner() == true)
            {
                if (turn == false)
                {
                    player2Score++;
                    MessageBox.Show("Player2 is winner!\n");
                }
                else
                {
                    player1Score++;
                    MessageBox.Show("Player1 is winner!\n");
                }
                initializeMatrix();
                initializeColorOfGroupBox();
                initializeColorOfGame();
                if (this.isComputerEasy || this.isComputerMedium || this.isComputerHard) turn = false;
            }
            else
            {
                if (this.isComputerEasy == true) easyComputer();
                if (this.isComputerMedium == true) medijumComputer();
                if (this.isComputerHard == true) hardComputer();
            }
        }
        private bool isWeHaveWinner()
        {
            for(int i = 0; i < NumOfRows; i++)
            {
                for(int j = 0; j < NumOfColumn; j++)
                {
                    if (matrix[i][j] == Value.EMPTY) continue;
                    if (j >= 3)
                    {
                        if (matrix[i][j] == matrix[i][j - 1] && matrix[i][j] == matrix[i][j - 2] && matrix[i][j] == matrix[i][j - 3]) return true;
                    }
                    if (j <= 4)
                    {
                        if (matrix[i][j] == matrix[i][j + 1] && matrix[i][j] == matrix[i][j + 2] && matrix[i][j] == matrix[i][j + 3]) return true;
                    }
                    if (i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j] && matrix[i][j] == matrix[i - 2][j] && matrix[i][j] == matrix[i - 3][j]) return true;
                    }
                    if (i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j] && matrix[i][j] == matrix[i + 2][j] && matrix[i][j] == matrix[i + 3][j]) return true;
                    }
                    if (j >= 3 && i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j - 1] && matrix[i][j] == matrix[i + 2][j - 2] && matrix[i][j] == matrix[i + 3][j - 3]) return true;
                    }
                    if (j <= 4 && i <= 3)
                    {
                        if (matrix[i][j] == matrix[i + 1][j + 1] && matrix[i][j] == matrix[i + 2][j + 2] && matrix[i][j] == matrix[i + 3][j + 3]) return true;
                    }
                    if (j >= 3 && i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j - 1] && matrix[i][j] == matrix[i - 2][j - 2] && matrix[i][j] == matrix[i - 3][j - 3]) return true;
                    }
                    if (j <= 4 && i >= 3)
                    {
                        if (matrix[i][j] == matrix[i - 1][j + 1] && matrix[i][j] == matrix[i - 2][j + 2] && matrix[i][j] == matrix[i - 3][j + 3]) return true;
                    }
                }
            }
            return false;
        }
        private void helpTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Winner is player who first connect four circle in the row, column or diagonal\n!", "Help");
        }
        private void aboutGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game is creat by the                ", "About Game");
        }
        private void viewScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Player1 " + this.player1Score + " : " + this.player2Score + " Player2 ", "Score");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfPlayer1 = Color.Red;
            this.initializeColorOfPlayer1();
        }
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfPlayer1 = Color.Blue;
            this.initializeColorOfPlayer1();
        }
        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfPlayer1 = Color.Yellow;
            this.initializeColorOfPlayer1();
        }
        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfPlayer2 = Color.Red;
            initializeColorOfPlayer2();
        }
        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfPlayer2 = Color.Blue;
            initializeColorOfPlayer2();
        }
        private void yellowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfPlayer2 = Color.Yellow;
            initializeColorOfPlayer2();
        }
        private void redToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfComputer = Color.Red;
        }
        private void blueToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfComputer = Color.Blue;
        }
        private void yellowToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            this.colorOfComputer = Color.Yellow;
        }
        private void playerVSPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            isComputerEasy = false;
            isComputerMedium = false;
            isComputerHard = false;
            this.player1Score = 0;
            this.player2Score = 0;
            initializeColorOfPlayer2();
        }
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            isComputerEasy = true;
            isComputerMedium = false;
            isComputerHard = false;
            this.player1Score = 0;
            this.player2Score = 0;
            initializeColorOfGame();
            initializeMatrix();
            initializeColorOfComputer();
        }
        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            isComputerEasy = false;
            isComputerMedium = true;
            isComputerHard = false;
            this.player1Score = 0;
            this.player2Score = 0;
            initializeColorOfGame();
            initializeMatrix();
            initializeColorOfComputer();
        }
        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (play == true) return;
            isComputerEasy = false;
            isComputerMedium = false;
            isComputerHard = true;
            this.player1Score = 0;
            this.player2Score = 0;
            initializeColorOfGame();
            initializeMatrix();
            initializeColorOfComputer();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.player1Score = 0;
            this.player2Score = 0;
            initializeColorOfGame();
            initializeMatrix();
            play = false;
        }
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            play = true;
        }
    }
}
