using BMP180App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ControllerApp.devices;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ControllerApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Bmp180Sensor _bmp180;
        private Timer _periodicTimer;
        public MainPage()
        {
            this.InitializeComponent();
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

            var task = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                calibrationDataTextBlock.Text = calibrationData;
            });
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

                WeatherData data = new WeatherData
                {
                    Temperature = sensorData.Temperature,
                    Pressure = sensorData.Pressure
                };
                var client = new HttpClient();
                //client.BaseAddress = new Uri("http://192.168.0.105/WebMonitor");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string weather = JsonConvert.SerializeObject(data);
                HttpResponseMessage response = await client.PostAsync("http://192.168.0.105:5001/Home/AddWeatherData", new StringContent(weather));
                Console.WriteLine(response.StatusCode.ToString());

            }
            catch (Exception ex)
            {
                temperatureText = "Sensor Error: " + ex.Message;
                pressureText = "Sensor Error: " + ex.Message;
            }
        }
    }
}
