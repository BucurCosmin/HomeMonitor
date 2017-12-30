using BMP180App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerRobot.Devices
{
    public class WeatherStation
    {
        private Bmp180Sensor _bmp180;
        private Timer _periodicTimer;

        public WeatherStation()
        {
            InitializeSensors();
            _periodicTimer = new Timer(this.onTimer, null, 0, 1000);
        }

        private async void InitializeSensors()
        {
            string calibrationData;

            // Initialize the BMP180 Sensor
            try
            {
                _bmp180 = new Bmp180Sensor();
                await _bmp180.InitializeAsync();
                calibrationData = _bmp180.CalibrationData.ToString();
            }
            catch (Exception ex)
            {
                calibrationData = "Device Error! " + ex.Message;
            }
        }
        private async void onTimer(object state)
        {
            string temperatureText, pressureText;
            try
            {
                var sensorData = await _bmp180.GetSensorDataAsync(Bmp180AccuracyMode.UltraHighResolution);
                temperatureText = sensorData.Temperature.ToString("F1");
                pressureText = sensorData.Pressure.ToString("F2");
                temperatureText += "C - hex:" + BitConverter.ToString(sensorData.UncompestatedTemperature);
                pressureText += "hPa - hex:" + BitConverter.ToString(sensorData.UncompestatedPressure);
            }
            catch (Exception ex)
            {
                temperatureText = "Sensor Error: " + ex.Message;
                pressureText = "Sensor Error: " + ex.Message;
            }
        }
    }
}
