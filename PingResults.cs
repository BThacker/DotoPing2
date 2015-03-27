using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace DotoPing2
{
    class PingResults
    {
        public string PingAddress;
        public string ServerName;

        List<int> lPingResults = new List<int>();

        private int avgPing;
        private int jitPing;
        private int totalPings;
        private long lastPing;
        
        // Encapsulate return
        
        public long LastPing { get { return lastPing; } }
        public int AvgPing { get { return avgPing; } }
        public int JitPing { get { return jitPing; } }
        public int TotalPings { get { return totalPings; } } 

        // Calculate Standard Deviation
        public void StandardDeviation()
        {
            avgPing = (int) lPingResults.Average();
            jitPing = (int) Math.Sqrt(lPingResults.Average(v => Math.Pow(v - AvgPing, 2)));
        }

        // Perform Ping, duh. Timer set to stagger ping return  
        public void DoPing()
        {
            totalPings = 0;
            Ping newPing = new Ping();
            for (int i = 1; i < 5000; i++)
            {
                PingReply reply = newPing.Send(PingAddress);
                if (reply.Status == IPStatus.Success)
                {                  
                    Task.Delay(2800).Wait();
                    lastPing = (int) reply.RoundtripTime;
                    lPingResults.Add((int) LastPing);
                    StandardDeviation();
                    totalPings++;
                }
                else
                {
                    lastPing = 999;
                }     
            }

        }
    }
}
