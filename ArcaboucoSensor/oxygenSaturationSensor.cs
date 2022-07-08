using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiSensor.ArcaboucoSensor
{
    public class OxygenSaturationSensor
    {
        public const string TOP_DOWN_DIRECTION = "TOP_DOWN_DIRECTION";
        public const string BOTTOM_UP_DIRECTION = "BOTTOM_UP_DIRECTION";
        public const int LOWER_LIMIT  = 19;
        public const int UPPER_LIMIT = 30; 


        public string changingValueDirection { get; set; }

        public string name { get; set; }

        public double oxygenSaturationValue { get; set; }

        public OxygenSaturationSensor()
        {
            oxygenSaturationValue = 22.2;
            changingValueDirection = BOTTOM_UP_DIRECTION;
        }

        public void SetChangingValueDirection(string direction)
        {
            changingValueDirection = direction;
        }

        public void changeSensorValue()
        {
            if (changingValueDirection.Equals(BOTTOM_UP_DIRECTION))
                increaseSensorValue();
            else if (changingValueDirection.Equals(TOP_DOWN_DIRECTION))
                decreaseSensorValue();
        }

        private void increaseSensorValue()
        {
            if(oxygenSaturationValue <= UPPER_LIMIT)
                oxygenSaturationValue += 0.1;
        }

        private void decreaseSensorValue()
        {
            if (oxygenSaturationValue >= LOWER_LIMIT)                
                oxygenSaturationValue -= 0.1;
        }
    }
}