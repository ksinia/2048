using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2048
{
    class Board
    {
        public Element[,] Elements { get; set; }
        public Board()
        {
            Elements = new Element[4, 4];
        }
        public static int[,] RandomGenerate()
        {
            Random rnd = new Random();
            int[,] numbers = new int[4, 4];

            numbers[rnd.Next(0, 3), rnd.Next(0, 3)] = rnd.Next(1, 100);
            numbers[rnd.Next(0, 3), rnd.Next(0, 3)] = rnd.Next(1, 100);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (numbers[i, j] < 90 & numbers[i, j] > 0) numbers[i, j] = 2;
                    else if (numbers[i, j] >= 90) numbers[i, j] = 4;

                }
            }

            return numbers;
        }

        public void Random()
        {
            ArrayList coords = new ArrayList();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Elements[i, j].Number == 0)
                    {
                        coords.Add(i.ToString() + ":" + j.ToString());
                    }
                }
            }

            Random rnd = new Random();
            int temporaryIndex = rnd.Next(0, coords.Count);
            int temporaryValue = rnd.Next(1, 100);
            if (temporaryValue > 90) temporaryValue = 4;
            else temporaryValue = 2;
            string[] indexes = Convert.ToString(coords[temporaryIndex]).Split(':');
            Elements[Convert.ToInt32(indexes[0]), Convert.ToInt32(indexes[1])].Number = temporaryValue;
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "up": Up(); break;
                case "down": Down(); break;
                case "left": Left(); break;
                case "right": Right(); break;
            }
        }
        public void Left()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Elements[i, j].Number != 0)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (Elements[i, k].Number == Elements[i, k + 1].Number)
                            {
                                Elements[i, k].Number *= 2;
                                Elements[i, k + 1].Number = 0;
                            }
                            if (Elements[i, k].Number == 0)
                            {
                                Elements[i, k].Number = Elements[i, k + 1].Number;
                                Elements[i, k + 1].Number = 0;
                            }
                        }
                    }
                }
            }
        }

        public void Right()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (Elements[i, j].Number != 0)
                    {
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (Elements[i, k].Number == Elements[i, k - 1].Number)
                            {
                                Elements[i, k].Number *= 2;
                                Elements[i, k - 1].Number = 0;
                            }
                            if (Elements[i, k].Number == 0)
                            {
                                Elements[i, k].Number = Elements[i, k - 1].Number;
                                Elements[i, k - 1].Number = 0;
                            }
                        }
                    }
                }
            }
        }

        public void Up()
        {
            for (int i = 0; 4 > i; i++)
            {
                for (int j = 0; 4 > j; j++)
                {
                    if (Elements[i, j].Number != 0)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {

                            if (Elements[k, j].Number == Elements[k + 1, j].Number)
                            {
                                Elements[k, j].Number *= 2;
                                Elements[k + 1, j].Number = 0;
                            }
                            if (Elements[k, j].Number == 0)
                            {
                                Elements[k, j].Number = Elements[k + 1, j].Number;
                                Elements[k + 1, j].Number = 0;
                            }

                        }
                    }
                }
            }
        }

        public void Down()
        {
            for (int i = 0; 4 > i; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (Elements[i, j].Number != 0)
                    {
                        for (int k = i + 1; k < 4; k++)
                        {

                            if (Elements[k, j].Number == Elements[k - 1, j].Number)
                            {
                                Elements[k, j].Number *= 2;
                                Elements[k - 1, j].Number = 0;
                            }
                            if (Elements[k, j].Number == 0)
                            {
                                Elements[k, j].Number = Elements[k - 1, j].Number;
                                Elements[k - 1, j].Number = 0;
                            }

                        }
                    }
                }
            }
        }
    }
}
