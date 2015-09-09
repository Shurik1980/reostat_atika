using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace reostat
{
    class DefPoz
    {
        private byte _pozDGU;
        private bool _stateVSH1;
        private bool _stateVSH2;

        public DefPoz()
        {
        }
        ~DefPoz()
        {
        }

        public void DefinitionPoz(string poz, string typeDGU)
        {
            int pozint = Convert.ToInt32(poz);

            if((pozint&0x0040)!=0)
                _stateVSH1 = true;
            else
                _stateVSH1 = false;

            if ((pozint & 0x0080) != 0)
                _stateVSH2 = true;
            else
                _stateVSH2 = false;

            pozint = pozint & 0x00FF;

            if (typeDGU.IndexOf('7') > 0)
            {
                _pozDGU = 0;
            }

            if ((typeDGU.IndexOf('2') > 0) || (typeDGU.IndexOf('8') > 0))
            {
                switch (pozint)
                {
                    case 0x00:
                        _pozDGU = 0;
                        break;
                        //KB
                    case 0x01:
                        _pozDGU = 1;
                        break;
                        //KB, RU2
                    case 0x03:
                        _pozDGU = 2;
                        break;
                    //KB, RU2, BT1
                    case 0x07:
                        _pozDGU = 3;
                        break;
                    //KB, RU2, BT1, BT2
                    case 0x0F:
                        _pozDGU = 4;
                        break;
                    //KB, RU2, BT2, BT3
                    case 0x1B:
                        _pozDGU = 5;
                        break;
                    //KB, RU2, BT1, BT4
                    case 0x17:
                        _pozDGU = 6;
                        break;
                    //KB, RU2, BT3, BT4
                    case 0x33:
                        _pozDGU = 7;
                        break;
                    //KB, RU2, BT1, BT2, BT3, BT4
                    case 0x3F:
                        _pozDGU = 8;
                        break;
                }
            }

            if (typeDGU.IndexOf('3') > 0)
            {
                switch (pozint)
                {
                    case 0x00:
                        _pozDGU = 0;
                        break;
                    //KB
                    case 0x01:
                        _pozDGU = 1;
                        break;
                    //KB, RU1
                    case 0x05:
                        _pozDGU = 2;
                        break;
                    //KB, RU2
                    case 0x09:
                        _pozDGU = 3;
                        break;
                    //KB, RU1, RU2
                    case 0x0D:
                        _pozDGU = 4;
                        break;
                    //KB, RU3
                    case 0x11:
                        _pozDGU = 5;
                        break;
                    //KB, RU1, RU3
                    case 0x15:
                        _pozDGU = 6;
                        break;
                    //KB, RU2, RU3
                    case 0x19:
                        _pozDGU = 7;
                        break;
                    //KB, RU1, RU2,RU3
                    case 0x1D:
                        _pozDGU = 8;
                        break;
                }
            }
            
        }

        public byte PozDGU
        {
            get { return _pozDGU; }
            set { _pozDGU = value; }
        }

        public bool StateVSH1
        {
            get { return _stateVSH1; }
            set { _stateVSH1 = value; }
        }

        public bool StateVSH2
        {
            get { return _stateVSH2; }
            set { _stateVSH2 = value; }
        }

    }
}
