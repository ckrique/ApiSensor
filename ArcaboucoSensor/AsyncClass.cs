using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ApiSensor.ArcaboucoSensor
{
    public class AsyncClass
    {
        OxygenSaturationSensor sensor = new OxygenSaturationSensor();

        public void StartThread()
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    sensor.changeSensorValue();
                    Thread.Sleep(5000);
                }
            });
            task.Start();
        }

        public double GetSensorValue()
        {
            return sensor.oxygenSaturationValue;
        }

        public void ChangeDirectionSensorValueToUp()
        {
            sensor.SetChangingValueDirection(OxygenSaturationSensor.BOTTOM_UP_DIRECTION);
        }

        public void ChangeDirectionSensorValueToDown()
        {
            sensor.SetChangingValueDirection(OxygenSaturationSensor.TOP_DOWN_DIRECTION);
        }


    }
}