using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.Domain
{
    public class VideoEncryption
    {
        public static void XorBuffer(byte[] buff, int length, long position)
        {
            string text = "pluralsight";
            string text2 = "\u0006?zY¢²\u0085\u009fL¾î0Ö.ì\u0017#©>Å£Q\u0005¤°\u00018Þ^\u008eú\u0019Lqß'\u009d\u0003ßE\u009eM\u0080'x:\0~¹\u0001ÿ 4³õ\u0003Ã§Ê\u000eAË¼\u0090è\u009eî~\u008b\u009aâ\u001b¸UD<\u007fKç*\u001döæ7H\v\u0015Arý*v÷%Âþ¾ä;pü";
            for (int i = 0; i < length; i++)
            {
                byte b = (byte)((long)(text[(int)((position + (long)i) % (long)text.Length)] ^ text2[(int)((position + (long)i) % (long)text2.Length)]) ^ (position + (long)i) % 251L);
                buff[i] ^= b;
            }
        }
    }
}