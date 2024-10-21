using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForFederalTestingCenter
{
    internal class Truck
    {
        private static int lastTruckNumber = 0; // Статическая переменная для хранения последнего номера
        private int truckNumber;
        private int truckCapacity;

        private Dictionary<Product, int> products;

        public Truck(int truckCapacity)
        {
            this.truckCapacity = truckCapacity;
            this.truckNumber = ++lastTruckNumber;
            this.products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int loadTruck)
        {
            if (products.ContainsKey(product))
            {
                products[product] += loadTruck;
            }
            else
            {
                products[product] = loadTruck;
            }
        }


        public void PrintStatistics()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nСтатистика грузовика №{truckNumber}:");
            Console.ResetColor();

            foreach (var product in products)
            {
                Console.WriteLine($"Перевез {product.Value} продуктов {product.Key.GetNameProduct()} с типом упаковки: {product.Key.GetPackingTypeProduct()}");
            }
        }

        public int GetTruckCapacity() => truckCapacity;

        public int GetTruckNumber() => truckNumber;
    }
}
