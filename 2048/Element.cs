using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace _2048
{
    public class Element
    {
        public int Number { get; set; }
        public Color NumColor { get; set; }
        public Element(int number)
        {
            NumColor = Color.Yellow;
            Number = number;
        }
        public Element()
        {

        }

        public void GetColor()
        {
            switch (Number)
            {
                case 2: NumColor = Color.Yellow; break;
                case 4: NumColor = Color.Blue; break;
                case 8: NumColor = Color.Coral; break;
                case 16: NumColor = Color.Gold; break;
                case 32: NumColor = Color.Gray; break;
                case 64: NumColor = Color.HotPink; break;
                case 128: NumColor = Color.LightGreen; break;
                case 256: NumColor = Color.MediumPurple; break;
                case 512: NumColor = Color.SeaGreen; break;
                case 1024: NumColor = Color.White; break;
                case 2048: NumColor = Color.Silver; break;
                default:NumColor = Color.Yellow;break;
            }
        }


    }
}
