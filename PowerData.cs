using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reostat
{
    public class PowerData
    {
        private int[] _powerData;
        private int _resPower;
        private int _countPower;

        public PowerData()
        {
            _powerData = new int[8];
            _resPower = 0;
            _countPower = 0;
        }
        ~PowerData()
        {
        }

        public int ResultPower()
        {
            int i;
            _resPower = 0;
            for (i = 0; i != 8; i++)
            {
                _resPower = _powerData[i] + _resPower;
            }
           return _resPower/8;
        }

        public bool pushData(int data)
        {
            _powerData[_countPower] = data;
            _countPower++;
            if (_countPower == 8)
            {
                _countPower = 0;
                return true;
            }
            else return false;
        }

    }
}
