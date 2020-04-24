using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cytPSV
{
    public class Terminal
    {
        public class Term
        {
            public static void Display(string text)
            {
                FrmHome.myConsole.Text = String.Concat(FrmHome.myConsole.Text, text);
            }

            public static void Reset()
            {
                FrmHome.myConsole.Text = "";
            }
        }
    }
}
