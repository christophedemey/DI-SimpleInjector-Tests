using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class StationController : IStationController
    {
        public string StationName { get; set; }
        private IBussinesLogicController bussinesLogicController = null;
        private ManualResetEvent waitHandle = null;

        public StationController(IBussinesLogicController bussinesLogicController)
        {
            this.bussinesLogicController = bussinesLogicController;
            waitHandle = new ManualResetEvent(false);
        }

        public void Execute(string stationName)
        {
            this.StationName = stationName;
            Task.Run(() => CheckStationThread());
        }

        private void CheckStationThread()
        {
            do
            {
                //Console.WriteLine($"Station {StationName} is up and running.");
                waitHandle.WaitOne(60000);
            } while (!waitHandle.WaitOne(0));
        }

        public void Dispose()
        {
            waitHandle.Set();
        }
    }
}
