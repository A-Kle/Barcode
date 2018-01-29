using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Barcode_Generator
{
    class Barcode
    {
        private int code;
        public static long[] encTable = new long[109];

        public Barcode(int code)
        {
            this.code = code;
        }

        public static Bitmap DrawBarcode(string barcode, code_options options)
        {
            encTable[0] = Convert.ToInt32("11011001100", 2);
            encTable[1] = Convert.ToInt32("11001101100", 2);
            encTable[2] = Convert.ToInt32("11001100110", 2);
            encTable[3] = Convert.ToInt32("10010011000", 2);
            encTable[4] = Convert.ToInt32("10010001100", 2);
            encTable[5] = Convert.ToInt32("10001001100", 2);
            encTable[6] = Convert.ToInt32("10011001000", 2);
            encTable[7] = Convert.ToInt32("10011000100", 2);
            encTable[8] = Convert.ToInt32("10001100100", 2);
            encTable[9] = Convert.ToInt32("11001001000", 2);
            encTable[10] = Convert.ToInt32("11001000100", 2);
            encTable[11] = Convert.ToInt32("11000100100", 2);
            encTable[12] = Convert.ToInt32("10110011100", 2);
            encTable[13] = Convert.ToInt32("10011011100", 2);
            encTable[14] = Convert.ToInt32("10011001110", 2);
            encTable[15] = Convert.ToInt32("10111001100", 2);
            encTable[16] = Convert.ToInt32("10011101100", 2);
            encTable[17] = Convert.ToInt32("10011100110", 2);
            encTable[18] = Convert.ToInt32("11001110010", 2);
            encTable[19] = Convert.ToInt32("11001011100", 2);
            encTable[20] = Convert.ToInt32("11001001110", 2);
            encTable[21] = Convert.ToInt32("11011100100", 2);
            encTable[22] = Convert.ToInt32("11001110100", 2);
            encTable[23] = Convert.ToInt32("11101101110", 2);
            encTable[24] = Convert.ToInt32("11101001100", 2);
            encTable[25] = Convert.ToInt32("11100101100", 2);
            encTable[26] = Convert.ToInt32("11100100110", 2);
            encTable[27] = Convert.ToInt32("11101100100", 2);
            encTable[28] = Convert.ToInt32("11100110100", 2);
            encTable[29] = Convert.ToInt32("11100110010", 2);
            encTable[30] = Convert.ToInt32("11011011000", 2);
            encTable[31] = Convert.ToInt32("11011000110", 2);
            encTable[32] = Convert.ToInt32("11000110110", 2);
            encTable[33] = Convert.ToInt32("10100011000", 2);
            encTable[34] = Convert.ToInt32("10001011000", 2);
            encTable[35] = Convert.ToInt32("10001000110", 2);
            encTable[36] = Convert.ToInt32("10110001000", 2);
            encTable[37] = Convert.ToInt32("10001101000", 2);
            encTable[38] = Convert.ToInt32("10001100010", 2);
            encTable[39] = Convert.ToInt32("11010001000", 2);
            encTable[40] = Convert.ToInt32("11000101000", 2);
            encTable[41] = Convert.ToInt32("11000100010", 2);
            encTable[42] = Convert.ToInt32("10110111000", 2);
            encTable[43] = Convert.ToInt32("10110001110", 2);
            encTable[44] = Convert.ToInt32("10001101110", 2);
            encTable[45] = Convert.ToInt32("10111011000", 2);
            encTable[46] = Convert.ToInt32("10111000110", 2);
            encTable[47] = Convert.ToInt32("10001110110", 2);
            encTable[48] = Convert.ToInt32("11101110110", 2);
            encTable[49] = Convert.ToInt32("11010001110", 2);
            encTable[50] = Convert.ToInt32("11000101110", 2);
            encTable[51] = Convert.ToInt32("11011101000", 2);
            encTable[52] = Convert.ToInt32("11011100010", 2);
            encTable[53] = Convert.ToInt32("11011101110", 2);
            encTable[54] = Convert.ToInt32("11101011000", 2);
            encTable[55] = Convert.ToInt32("11101000110", 2);
            encTable[56] = Convert.ToInt32("11100010110", 2);
            encTable[57] = Convert.ToInt32("11101101000", 2);
            encTable[58] = Convert.ToInt32("11101100010", 2);
            encTable[59] = Convert.ToInt32("11100011010", 2);
            encTable[60] = Convert.ToInt32("11101111010", 2);
            encTable[61] = Convert.ToInt32("11001000010", 2);
            encTable[62] = Convert.ToInt32("11110001010", 2);
            encTable[63] = Convert.ToInt32("10100110000", 2);
            encTable[64] = Convert.ToInt32("10100001100", 2);
            encTable[65] = Convert.ToInt32("10010110000", 2);
            encTable[66] = Convert.ToInt32("10010000110", 2);
            encTable[67] = Convert.ToInt32("10000101100", 2);
            encTable[68] = Convert.ToInt32("10000100110", 2);
            encTable[69] = Convert.ToInt32("10110010000", 2);
            encTable[70] = Convert.ToInt32("10110000100", 2);
            encTable[71] = Convert.ToInt32("10011010000", 2);
            encTable[72] = Convert.ToInt32("10011000010", 2);
            encTable[73] = Convert.ToInt32("10000110100", 2);
            encTable[74] = Convert.ToInt32("10000110010", 2);
            encTable[75] = Convert.ToInt32("11000010010", 2);
            encTable[76] = Convert.ToInt32("11001010000", 2);
            encTable[77] = Convert.ToInt32("11110111010", 2);
            encTable[78] = Convert.ToInt32("11000010100", 2);
            encTable[79] = Convert.ToInt32("10001111010", 2);
            encTable[80] = Convert.ToInt32("10100111100", 2);
            encTable[81] = Convert.ToInt32("10010111100", 2);
            encTable[82] = Convert.ToInt32("10010011110", 2);
            encTable[83] = Convert.ToInt32("10111100100", 2);
            encTable[84] = Convert.ToInt32("10011110100", 2);
            encTable[85] = Convert.ToInt32("10011110010", 2);
            encTable[86] = Convert.ToInt32("11110100100", 2);
            encTable[87] = Convert.ToInt32("11110010100", 2);
            encTable[88] = Convert.ToInt32("11110010010", 2);
            encTable[89] = Convert.ToInt32("11011011110", 2);
            encTable[90] = Convert.ToInt32("11011110110", 2);
            encTable[91] = Convert.ToInt32("11110110110", 2);
            encTable[92] = Convert.ToInt32("10101111000", 2);
            encTable[93] = Convert.ToInt32("10100011110", 2);
            encTable[94] = Convert.ToInt32("10001011110", 2);
            encTable[95] = Convert.ToInt32("10111101000", 2);
            encTable[96] = Convert.ToInt32("10111100010", 2);
            encTable[97] = Convert.ToInt32("11110101000", 2);
            encTable[98] = Convert.ToInt32("11110100010", 2);
            encTable[99] = Convert.ToInt32("10111011110", 2);
            encTable[100] = Convert.ToInt32("10111101110", 2);
            encTable[101] = Convert.ToInt32("11101011110", 2);
            encTable[102] = Convert.ToInt32("11110101110", 2);
            encTable[103] = Convert.ToInt32("11010000100", 2);
            encTable[104] = Convert.ToInt32("11010010000", 2);
            encTable[105] = Convert.ToInt32("11010011100", 2);
            encTable[106] = Convert.ToInt32("11000111010", 2);
            encTable[107] = Convert.ToInt32("11010111000", 2);
            encTable[108] = Convert.ToInt32("1100011101011", 2);



            byte[] code = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, Encoding.UTF8.GetBytes(" " + barcode + "  ")); // encoded chain of gived code for each char in that code
            string ascii = Encoding.ASCII.GetString(code);                                                                                                 //" " forces additional index for start/stop and check sum code
            for (int i = 1; i <= barcode.Length; i++)
            {
                if(code[i] >=32 && code[i] <=126)
                {
                    code[i] -= 32;
                }
                else if(code[i] <=31)
                {
                    code[i] += 64;
                }
                else
                {
                    code[i] = 31;
                }
            }
            code[0] = 104;
            code[barcode.Length + 2] = 108;
            code[barcode.Length + 1] = 104;
            for(int i = 1; i <= barcode.Length; i ++)
            {
                code[barcode.Length + 1] = Convert.ToByte((code[barcode.Length + 1] + code[i] * i) % 103); //check sum for code 128
            }
            Bitmap bitmap = new Bitmap(55 + 11 * barcode.Length, 75); //55 + 11 * lenght of given code
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.Clear(Color.White);
            int position = 10;
            for (int i = 0; i < code.Length; i++)
            {
                int code_length = (i == 0 || i == code.Length - 1) ? 60 : 50;  
                Int16 tmp = 1024;
                if(i == code.Length-1)
                {
                    tmp <<= 2;
                }
                while (tmp != 0)
                {
                    
                    if ((encTable[code[i]] & tmp) != 0)
                    {
                        Color color;
                        if((options & code_options.rainbow_colors) != code_options.none)
                        {
                        color = Color.FromArgb
                        (

                         Convert.ToInt32(255 * Math.Max(0, -2.0 * i / code.Length + 1)),
                         Convert.ToInt32(255 * (Math.Abs(2 * (1.0 * i / code.Length - 0.5)) *(-1) + 1)),
                         Convert.ToInt32(255 * Math.Max(0, (2.0 * i / code.Length) - 1))
                        );
                        }
                        else
                        {
                            color = Color.Black;
                        }

                        for (int z = 0; z < code_length; z++)
                        {
                            bitmap.SetPixel(position, z, color);
                        }      
                    }
                    position++;
                    tmp >>= 1;
                }
                StringFormat stringf = new StringFormat();
                stringf.Alignment = StringAlignment.Center;
                graphic.DrawString(ascii.Substring(i, 1), new Font("Fixedsys", 8), new SolidBrush(Color.Black), new RectangleF(position - 11, 53, 11, 15), stringf);
            }
            return bitmap;
        }
    }
}

