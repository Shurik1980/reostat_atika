using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reostat
{
    class Parse
    {
        private double[] param;

        #region Constructor / Deconstructor
        public Parse()
        {
            param = new double[10];
        }
        ~Parse()
        {
        }
        #endregion


        public int ParseLine(string line)
        {
            /*if (line.IndexOf('>') > 0)
            {
                line = line.Remove(0, line.IndexOf('>'));
            }*/
            if (line.Length < 4)
                return 0;
            CRC crc = new CRC();
            string crcStr = line.Substring(line.Length-3,2);
            string calcCrc = line.Remove(line.Length - 3, 3);
            calcCrc = crc.GetCRC(calcCrc);
            calcCrc = calcCrc.Substring(calcCrc.Length-3,2);
            if (crcStr != calcCrc)
            {
                return 0;
            }
            int countParam=0;
            int ch1 = 0;
            int ch2 = 0;
            int countChar=0;
            bool flagCh = false;
            char[] charLine = new char[line.Length];
            line=line.Remove(line.Length-3,3);
            charLine = line.ToCharArray();
            while (countChar != line.Length)
            {               
                if ((charLine[countChar] == '+') || (charLine[countChar] == '-'))
                    {
                        if (flagCh == false)
                            {
                            ch1 = countChar;
                            flagCh = true;

                            ch2 = countChar;
                            if ((line.IndexOf('+', ch2 + 1) < 0) && (line.IndexOf('-', ch2 + 1) < 0))
                            {
                                string catStr;
                                catStr = line.Substring(ch2, line.Length - ch2);
                                catStr = catStr.Replace('.', ',');
                                //catStr = catStr.Remove(0, 1);
                                param[countParam] = Convert.ToDouble(catStr);
                                countParam++;
                            }
                            }
                        else
                            {
                                ch2 = countChar;
                                string catStr = line.Substring(ch1, ch2 - ch1);
                                catStr=catStr.Replace('.', ',');
                                param[countParam] = Convert.ToDouble(catStr);
                                flagCh = false;
                                countParam++;
                                countChar--;
                                if ((line.IndexOf('+', ch2+1) < 0) && (line.IndexOf('-', ch2+1) < 0))
                                {
                                    catStr = line.Substring(ch2, line.Length-ch2);
                                    catStr = catStr.Replace('.', ',');
                                    param[countParam] = Convert.ToDouble(catStr);
                                    countParam++;
                                }
                                ch1 = 0;
                                ch2 = 0;
                            }
                    }
                countChar++;
            }
            
            return countParam;
        }


        public int ParseRele(string line)
        {
            if (line.Length < 4)
                return 0;
            CRC crc = new CRC();
            string crcStr = line.Substring(line.Length - 3, 2);
            string calcCrc = line.Remove(line.Length - 3, 3);
            calcCrc = crc.GetCRC(calcCrc);
            calcCrc = calcCrc.Substring(calcCrc.Length - 3, 2);
            if (crcStr != calcCrc)
            {
                return 0;
            }
            int countParam = 0;

            return countParam;
        }

        public double GetParameter(int index)
        {
            if (param[index] > 1000)
                return 999;
            else
                return param[index];
        }
    }
}
