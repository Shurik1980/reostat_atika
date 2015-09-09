using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reostat
{
    public class ExtData
    {
        private int[] _extVoltage;
        private int[] _extCurrent;

        public ExtData()
        {
            _extVoltage = new int[3];
            _extCurrent = new int[3];
            
        }
        ~ExtData()
        {
        }

        public int[] ExtVoltage
        {
            get { return _extVoltage; }
            set { _extVoltage = value; }
        }

        public int[] ExtCurrent
        {
            get { return _extCurrent; }
            set { _extCurrent = value; }
        }

    }
}
