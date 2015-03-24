using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DotoPing2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<PingResults> servers = new List<PingResults>
            {
                
                new PingResults(){ ServerName = "seasia1", PingAddress = "sgp-1.valve.net"},
                new PingResults(){ ServerName = "seasia2", PingAddress = "sgp-2.valve.net" },
                new PingResults(){ ServerName = "india", PingAddress = "180.149.41.100" },
                new PingResults(){ ServerName = "austrailia", PingAddress = "syd.valve.net" },
                new PingResults(){ ServerName = "russia1", PingAddress = "sto.valve.net" },
                new PingResults(){ ServerName = "russia2", PingAddress = "185.25.180.1" },
                new PingResults(){ ServerName = "eureast", PingAddress = "vie.valve.net" },
                new PingResults(){ ServerName = "eurwest", PingAddress = "lux.valve.net" },
                new PingResults(){ ServerName = "eurwest2", PingAddress = "146.66.158.1" },
                new PingResults(){ ServerName = "safrica1", PingAddress = "cpt-1.valve.net" },
                new PingResults(){ ServerName = "safrica2", PingAddress = "197.80.200.1" },
                new PingResults(){ ServerName = "safrica3", PingAddress = "196.38.180.1" },
                new PingResults(){ ServerName = "useast", PingAddress = "208.78.164.1" },
                new PingResults(){ ServerName = "uswest", PingAddress = "eat.valve.net" },
                new PingResults(){ ServerName = "sam1", PingAddress = "gru.valve.net" },
                new PingResults(){ ServerName = "sam2", PingAddress = "209.197.29.1" },
                new PingResults(){ ServerName = "sam3", PingAddress = "209.197.25.1" },
            };
        
        Label[] labelscur = new Label[18];
        Label[] labelsavg = new Label[18];
        Label[] labelsjit = new Label[18];

        public MainWindow()
        {
            InitializeComponent();
            // Create Timer To Control Label Updates
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += timer_Tick;
            timer.Start();
            // Declare Variables for Labels based on above array
            labelscur[0] = null;
            labelscur[1] = this.lblcur1;
            labelscur[2] = this.lblcur2;
            labelscur[3] = this.lblcur3;
            labelscur[4] = this.lblcur4;
            labelscur[5] = this.lblcur5;
            labelscur[6] = this.lblcur6;
            labelscur[7] = this.lblcur7;
            labelscur[8] = this.lblcur8;
            labelscur[9] = this.lblcur9;
            labelscur[10] = this.lblcur10;
            labelscur[11] = this.lblcur11;
            labelscur[12] = this.lblcur12;
            labelscur[13] = this.lblcur13;
            labelscur[14] = this.lblcur14;
            labelscur[15] = this.lblcur15;
            labelscur[16] = this.lblcur16;
            labelscur[17] = this.lblcur17;

            labelsavg[0] = null;
            labelsavg[1] = this.lblavg1;
            labelsavg[2] = this.lblavg2;
            labelsavg[3] = this.lblavg3;
            labelsavg[4] = this.lblavg4;
            labelsavg[5] = this.lblavg5;
            labelsavg[6] = this.lblavg6;
            labelsavg[7] = this.lblavg7;
            labelsavg[8] = this.lblavg8;
            labelsavg[9] = this.lblavg9;
            labelsavg[10] = this.lblavg10;
            labelsavg[11] = this.lblavg11;
            labelsavg[12] = this.lblavg12;
            labelsavg[13] = this.lblavg13;
            labelsavg[14] = this.lblavg14;
            labelsavg[15] = this.lblavg15;
            labelsavg[16] = this.lblavg16;
            labelsavg[17] = this.lblavg17;

            labelsjit[0] = null;
            labelsjit[1] = this.lbljit1;
            labelsjit[2] = this.lbljit2;
            labelsjit[3] = this.lbljit3;
            labelsjit[4] = this.lbljit4;
            labelsjit[5] = this.lbljit5;
            labelsjit[6] = this.lbljit6;
            labelsjit[7] = this.lbljit7;
            labelsjit[8] = this.lbljit8;
            labelsjit[9] = this.lbljit9;
            labelsjit[10] = this.lbljit10;
            labelsjit[11] = this.lbljit11;
            labelsjit[12] = this.lbljit12;
            labelsjit[13] = this.lbljit13;
            labelsjit[14] = this.lbljit14;
            labelsjit[15] = this.lbljit15;
            labelsjit[16] = this.lbljit16;
            labelsjit[17] = this.lbljit17;
            MouseDown += Window_MouseDown;  

            Task start = Task.Factory.StartNew(() => StartThreads());
              
        }
        void timer_Tick(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        // Borderless window click and drag
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        // Update labels with ping results, set color of text based on result
        void UpdateLabels()
        {
            lbltotal.Content = "Total Pings:     " + servers[1].TotalPings.ToString();
            for (int i = 1; i <= 17; i++)
            {
                labelscur[i].Content = servers[i - 1].LastPing + "ms";
                if (servers[i - 1].LastPing < 125)
                {
                    labelscur[i].Foreground = new SolidColorBrush(Colors.DarkGreen);
                }
                else if (servers[i - 1].LastPing < 250)
                {
                    labelscur[i].Foreground = new SolidColorBrush(Colors.Yellow);
                }
                else if (servers[i - 1].LastPing > 249)
                {
                    labelscur[i].Foreground = new SolidColorBrush(Colors.Red);
                }
                if (servers[i -1].LastPing == 10)
                {
                    labelscur[i].Content = "Err";
                    labelscur[i].Foreground = new SolidColorBrush(Colors.DarkRed);
                }
            }
            for (int i = 1; i <= 17; i++)
            {
                labelsavg[i].Content = servers[i - 1].AvgPing + "ms";
                if (servers[i - 1].AvgPing < 125)
                {
                    labelsavg[i].Foreground = new SolidColorBrush(Colors.DarkGreen);
                }
                else if (servers[i - 1].AvgPing < 250)
                {
                    labelsavg[i].Foreground = new SolidColorBrush(Colors.Yellow);
                }
                else if (servers[i - 1].AvgPing > 249)
                {
                    labelsavg[i].Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            for (int i = 1; i <= 17; i++)
            {
                labelsjit[i].Content = servers[i - 1].JitPing + "ms";
                if (servers[i - 1].JitPing < 125)
                {
                    labelsjit[i].Foreground = new SolidColorBrush(Colors.DarkGreen);
                }
                else if (servers[i - 1].JitPing < 250)
                {
                    labelsjit[i].Foreground = new SolidColorBrush(Colors.Yellow);
                }
                else if (servers[i - 1].JitPing > 249)
                {
                    labelsjit[i].Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }
        // Create concurrent objects and threads to allow GUI to remain responsive
        public void StartThreads()
        {
            for (int i = 0; i <= 16; i++)
            {
                Task.Delay(150).Wait();
                var aTask = Task.Factory.StartNew(() => servers[i - 1].DoPing());
            }            
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
