using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reostat
{
    class CRC
    {
        #region Constructor / Deconstructor
        public CRC()
        {
            
        }
        ~CRC()
        {
        }
        #endregion

        public string GetCRC(string line)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int countChar = 0;
            int sum = 0;
            char[] charLine = new char[line.Length];
            charLine = line.ToCharArray();

            while (countChar != line.Length)
            {
                sum = charLine[countChar] + sum;
                countChar++;
            }
            string retLine = line;
            byte ch;
            ch = (byte)sum;
            retLine = line;
            retLine += binarToAscii(ch);
            retLine += "\r";
            return retLine;
        }

        private string binarToAscii(byte inByte)
	    {
	        int handByte;
            int outAscii1;
            int outAscii2;
            string ret="";
	
	        handByte = (inByte & 0xF0)>>4;
	        if(handByte < 0x0A)
		        {
		        outAscii1 = (handByte + '0');
		        }
	        else
		        {
		        outAscii1 = ('A' + handByte - 10);
		        }
	
	        handByte = inByte & 0x0F;
	        if(handByte < 0x0A)
		        {
		        outAscii2 =  (handByte + 0x30);
		        }
	        else
		        {
		        outAscii2 = ( 'A' + handByte - 10);
		        }

            char c1 = (char)outAscii1;
            char c2 = (char)outAscii2;
            ret = c1.ToString();
            ret = ret + c2;
            return ret;
	}

    }
}
