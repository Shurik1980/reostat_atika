using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reostat
{
   public class SwitchRele
    {

        private int _RP1_ON_current;
        private int _RP1_OFF_current;
        private int _RP1_ON_voltage;
        private int _RP1_OFF_voltage;
        private int _RP2_ON_current;
        private int _RP2_OFF_current;
        private int _RP2_ON_voltage;
        private int _RP2_OFF_voltage;

        public SwitchRele()
        {  
        }
        ~SwitchRele()
        {
        }

        public int RP1_ON_current
        {
            get { return _RP1_ON_current; }
            set { _RP1_ON_current = value; }
        }

        public int RP1_OFF_current
        {
            get { return _RP1_OFF_current; }
            set { _RP1_OFF_current = value; }
        }

        public int RP1_ON_voltage
        {
            get { return _RP1_ON_voltage; }
            set { _RP1_ON_voltage = value; }
        }

        public int RP1_OFF_voltage
        {
            get { return _RP1_OFF_voltage; }
            set { _RP1_OFF_voltage = value; }
        }


        public int RP2_ON_current
        {
            get { return _RP2_ON_current; }
            set { _RP2_ON_current = value; }
        }

        public int RP2_OFF_current
        {
            get { return _RP2_OFF_current; }
            set { _RP2_OFF_current = value; }
        }

        public int RP2_ON_voltage
        {
            get { return _RP2_ON_voltage; }
            set { _RP2_ON_voltage = value; }
        }

        public int RP2_OFF_voltage
        {
            get { return _RP2_OFF_voltage; }
            set { _RP2_OFF_voltage = value; }
        }
    }
}
