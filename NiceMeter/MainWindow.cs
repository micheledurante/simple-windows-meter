using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace NiceMeter
{
    public partial class MainWindow : Form
    {
        private Computer Computer = new Computer
        {
            MainboardEnabled = true,
            CPUEnabled = true,
            RAMEnabled = true,
            GPUEnabled = true,
            FanControllerEnabled = true,
            HDDEnabled = true
        };

        private BindingSource BSource = new BindingSource();

        private Timer Timer = new Timer
        {
            Enabled = true,
            Interval = 500
        };

        /// <summary>
        /// Timed function that returns the current values of the sensors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            //// Clear previous text
            //TextArea.Clear();

            //// Gets a list of enabled hardware strings
            //var HardwareList = Computer.Hardware.Select(x => x.HardwareType).ToList();

            //foreach (var Hardware in Computer.Hardware)
            //{
            //    Hardware.Update();

            //    foreach (var Sensor in Hardware.Sensors)
            //    {
            //        if (Sensor.Value.HasValue)
            //            Console.WriteLine(String.Format("{0} - {1} - {2} = {3}", Hardware.HardwareType, Sensor.Name, Sensor.SensorType, Sensor.Value));
            //    }
            //}

            foreach (var Hardware in Computer.Hardware)
            {
                Hardware.Update();

                foreach (var Sensor in Hardware.Sensors)
                {
                    if (Sensor.Value.HasValue)
                        BSource.Add(String.Format("{0} - {1} - {2} = {3}", Hardware.HardwareType, Sensor.Name, Sensor.SensorType, Sensor.Value));
                }
            }
        }

        /// <summary>
        /// Required for the window to run correctly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextArea_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// On-Load event of the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Redirect the out Console stream
            //Console.SetOut(new StreamWriter(TextArea));

            // Initialize the DataGridView.
            GridView.AutoGenerateColumns = false;
            GridView.AutoSize = true;
            //dataGridView1.DataSource = BSource;

            BSource.Add("Bob");
            GridView.DataSource = BSource;

            // Initialize the form.
            AutoSize = true;
        }

        /// <summary>
        /// Executes code for the main window
        /// </summary>
        public MainWindow()
        {
            Computer.Open();

            InitializeComponent();

            //Timer.Tick += new EventHandler(TimerTick);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
