using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForFederalTestingCenter
{
    internal static class TruckManager
    {
        public static void TransportationProducts(Warehouse warehouse, List<Truck> trucks)
        {
            Console.WriteLine("Склад заполнен больше чем на 95%. Начинается транспортировка товара.");

            Dictionary<Product, int> products = warehouse.GetProductsInWarehouse();

            foreach (var product in products)
            {
                int loadTruck = 0;

                while (products[product.Key] != 0)
                {
                    foreach (var truck in trucks)
                    {
                        loadTruck = products[product.Key] > truck.GetTruckCapacity() ? truck.GetTruckCapacity() : products[product.Key];
                        truck.AddProduct(product.Key, loadTruck);
                        warehouse.RemovingProducts(loadTruck);
                        products[product.Key] -= loadTruck;
                        Console.WriteLine($"Грузовик №{truck.GetTruckNumber()} загрузил и увез {loadTruck} {product.Key.GetNameProduct()}");
                    }
                }

            }

            Thread.Sleep(2000); // Транспортировка раз в 2 секунды


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Транспортировка товара завершена: Склад пустой!");
            Console.ResetColor();

            foreach (var truck in trucks)
            {
                truck.PrintStatistics();
            }
        }
    }


}
