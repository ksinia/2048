using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {

        Board GameBoard;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            GameBoard = new Board();
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 4;
            for (int i = 0; i < 4; i++)
                dataGridView1.Columns[i].Width = 49;


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1[i, j].Style.BackColor = Color.Yellow;
                }
            }
            int[,] array = Board.RandomGenerate();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (array[i, j] != 0)
                    {
                        GameBoard.Elements[i, j] = new Element(array[i, j]);
                        dataGridView1.Rows[i].Cells[j].Value = array[i, j];
                    }
                    else GameBoard.Elements[i, j] = new Element(0);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameBoard.Move("left");
            GameBoard.Random();
            ChangeColors();
            Draw();

        }
        private void Draw()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 4;
            for (int i = 0; i < 4; i++)
                dataGridView1.Columns[i].Width = 49;


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                   
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = GameBoard.Elements[i,j].NumColor;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GameBoard.Elements[i, j].Number != 0)
                    {

                        dataGridView1.Rows[i].Cells[j].Value = GameBoard.Elements[i, j].Number;
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameBoard.Move("right");
            GameBoard.Random();
            ChangeColors();
            Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameBoard.Move("up");
            GameBoard.Random();
            ChangeColors();
            Draw();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GameBoard.Move("down");
            GameBoard.Random();
            ChangeColors();
            Draw();
        }
         
        private void ChangeColors()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GameBoard.Elements[i, j].GetColor();
                }
            }
        }

        
    }
}
