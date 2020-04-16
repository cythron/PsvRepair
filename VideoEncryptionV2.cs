using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cytPSV
{
    namespace Pluralsight.Domain
    { 
        public class VideoEncryptionV2
        {
            public static string string1_v2 = "\0¿{U9\u0001®`ë\u0013Ñ[\u001BÏ";
            public static string string2_v2 = "\u0002\u008D\a\u0099\u0089\u009A%\u0084K°súÁ48äcz@\u009F,í>ö 2\vß\n@*í\vz\u008C\u0004½\u0093\0ÜeË\u0086\u001F\bÖ\u009E ADÓg&ì¶\u0017\u008DÀ\u0014{µìß\u0088Ø\u009FòÕÄ\u0081pªªtC\u008A@\u009C2:Åf\\\\­è\u009Eý\u0002g\u0003|ØBf\u0092 ";
            private static bool useV1 = true;
            public static string videoLocation;

            public static void XorBuffer(byte[] buff, int length, long position)
            {
                string text = "pluralsight";
                string text2 = "\u0006?zY¢²\u0085\u009fL¾î0Ö.ì\u0017#©>Å£Q\u0005¤°\u00018Þ^\u008eú\u0019Lqß'\u009d\u0003ßE\u009eM\u0080'x:\0~¹\u0001ÿ 4³õ\u0003Ã§Ê\u000eAË¼\u0090è\u009eî~\u008b\u009aâ\u001b¸UD<\u007fKç*\u001döæ7H\v\u0015Arý*v÷%Âþ¾ä;pü";
                for (int i = 0; i < length; i++)
                {
                    byte b = (byte)((long)(text[(int)((position + (long)i) % (long)text.Length)] ^ text2[(int)((position + (long)i) % (long)text2.Length)]) ^ (position + (long)i) % 251L);
                    int num = i;
                    int num2 = num;
                    buff[num2] ^= b;
                }
            }

            public static void XorBufferV2(byte[] buff, int length, long position)
            {
                for (int i = 0; i < length; i++)
                {
                    byte b = (byte)((long)(VideoEncryptionV2.string1_v2[(int)((position + (long)i) % (long)VideoEncryptionV2.string1_v2.Length)] ^ VideoEncryptionV2.string2_v2[(int)((position + (long)i) % (long)VideoEncryptionV2.string2_v2.Length)]) ^ (position + (long)i) % 251L);
                    int num10 = i;
                    int num11 = num10;
                    buff[num11] ^= b;
                }
            }

            public static void EncryptBuffer(byte[] buff, int length, long position)
            {
                VideoEncryptionV2.XorBufferV2(buff, length, position);
            }

            public static void DecryptBuffer(byte[] buff, int length, long position)
            {
                VideoEncryptionV2.XorBuffer(buff, length, position);
                if (buff[0] == 0 && buff[1] == 0 && buff[2] == 0)
                {
                    VideoEncryptionV2.useV1 = true;
                    return;
                }
                VideoEncryptionV2.XorBuffer(buff, length, position);
                if (position == 0L && length > 3)
                {
                    VideoEncryptionV2.XorBufferV2(buff, length, position);
                    if (buff[0] == 0 && buff[1] == 0)
                    {
                        byte b = buff[2];
                    }
                    VideoEncryptionV2.useV1 = false;
                    return;
                }
                if (VideoEncryptionV2.useV1)
                {
                    VideoEncryptionV2.XorBuffer(buff, length, position);
                    return;
                }
                VideoEncryptionV2.XorBufferV2(buff, length, position);
            }
        }
    }
}