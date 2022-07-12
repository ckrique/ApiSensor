using FIWARE.OrionClient.IoTAgent;
using FIWARE.OrionClient.REST;
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
        OxygenSaturationSensor simulatedSensor = new OxygenSaturationSensor();

        public void StartThread()
        {
            Task task = new Task(async () =>
            {
                while (true)
                {
                    simulatedSensor.changeSensorValue();

                    RESTClient<string> restClient = new RESTClient<string>();
                    Task<string> returnedTask = restClient.SendMeasurementFromSensorToBroker(simulatedSensor.oxygenSaturationValue);

                    Thread.Sleep(2000);
                }
            });
            task.Start();
        }

        public double GetSensorValue()
        {
            return simulatedSensor.oxygenSaturationValue;
        }

        public void ChangeDirectionSensorValueToUp()
        {
            simulatedSensor.SetChangingValueDirection(OxygenSaturationSensor.BOTTOM_UP_DIRECTION);
        }

        public void ChangeDirectionSensorValueToDown()
        {
            simulatedSensor.SetChangingValueDirection(OxygenSaturationSensor.TOP_DOWN_DIRECTION);
        }


    }
}