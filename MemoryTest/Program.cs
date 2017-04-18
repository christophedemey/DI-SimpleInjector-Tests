using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            woop();
            Console.ReadLine();
        }

        private async static void woop()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Performing memory test {i}");
                await GenerateAndRemoveObjects();
            }


            await Task.Delay(60000);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Finalized.");

        }

        private static async Task GenerateAndRemoveObjects()
        {
            List<StationController> stations = new List<StationController>();
            for (int i = 0; i < 1000000; i++)
            {
                //Resolve IStationController here...
                StationController station = new StationController(null);
                station.Execute($"Station {i}");
                stations.Add(station);
            }

            await Task.Delay(5000);
            stations.ForEach(row => row.Dispose());
            stations.Clear();

            await Task.Delay(5000);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Disposed.");
        }
    }
}
