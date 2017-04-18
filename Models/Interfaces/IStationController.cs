using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IStationController
    {
        string StationName { get; set; }
        void Execute(string stationName);
        void Dispose();
    }
}
