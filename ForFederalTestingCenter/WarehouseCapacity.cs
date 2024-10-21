using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForFederalTestingCenter
{
    internal class WarehouseCapacity
    {
        private static WarehouseCapacity instance;
        private static readonly object lockObject = new object();
        public double M;
        public double maxCapacity = 0; // Максимальная вместимость склада
        public int currentCapacity = 0; // Текущая заполненность склада

        private WarehouseCapacity() { }

        public static WarehouseCapacity Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new WarehouseCapacity();
                        }
                    }
                }
                return instance;
            }
        }

    }
}
