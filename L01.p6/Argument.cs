using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01.p6
{
    public class Argument
    {
        public Argument(string text, ConsoleColor color)
        {
            Text = text;
            Color = color;
        }

        public string Text { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
