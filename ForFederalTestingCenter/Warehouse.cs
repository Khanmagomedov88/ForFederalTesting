using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForFederalTestingCenter
{
    internal class Warehouse
    {
        private static Warehouse instance;
        private static readonly object lockObject = new object();

        Dictionary<Product, int> products = new Dictionary<Product, int>();

        private WarehouseCapacity warehouseCapacity = WarehouseCapacity.Instance;


        public Dictionary<Product, int> GetProductsInWarehouse() => products;
        public int GetCurrentCapacity() => warehouseCapacity.currentCapacity;

        private Warehouse() { }

        /// <summary>
        /// Инициализирует переменную M 
        /// </summary>
        /// <param name="countM">Множитель объема склада</param>
        public void Initialize_M(double countM)
        {
            warehouseCapacity.M = countM;
        }

        /// <summary>
        /// Увеличивает объем склада на указанное значение * M
        /// </summary>
        /// <param name="count">Значение умноженное на M, на которое увеличится объем склада</param>
        public void IncreaseMaxCapacity(double count)
        {
            warehouseCapacity.maxCapacity += warehouseCapacity.M * count;
        }

        public void RemovingProducts(int remCount)
        {
            warehouseCapacity.currentCapacity -= remCount;
        }

        public static Warehouse Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Warehouse();
                        }
                    }
                }
                return instance;
            }
        }


        /// <summary>
        /// Добавляет продукт на склад. Если продукт уже существует, увеличивает его количество
        /// </summary>
        /// <param name="product">Продукт, который нужно добавить на склад</param>
        /// <param name="quantityProduct">Количество продукта</param>
        public bool AddProductToWarehouse(Product product, int quantityProduct)
        {
            if (warehouseCapacity.currentCapacity >= 0.95 * warehouseCapacity.maxCapacity)
            {
                return false;
            }

            if (products.TryGetValue(product, out int currentQuantity))
            {
                // Если продукт уже есть, увеличиваем его количество
                products[product] = currentQuantity + quantityProduct;

                UpdateCurrentCapacity();
                Console.WriteLine($"Склад разместил продукт {product.GetNameProduct()} на склад в размере {quantityProduct}");
                Console.WriteLine($"Заполненность склада: {warehouseCapacity.currentCapacity}/{warehouseCapacity.maxCapacity}");
                return true;
            }
            else
            {
                // Если продукта нет, добавляем его
                products.Add(product, quantityProduct);

                UpdateCurrentCapacity();
                Console.WriteLine($"Склад разместил продукт {product.GetNameProduct()} на склад в размере {quantityProduct}");
                Console.WriteLine($"Заполненность склада: {warehouseCapacity.currentCapacity}/{warehouseCapacity.maxCapacity}");
                return true;
            }
        }

        /// <summary>
        /// Обновляет текущую заполненность склада
        /// </summary>
        public void UpdateCurrentCapacity()
        {
            int currentCap = 0;

            foreach (var item in products)
            {
                currentCap += item.Value;
            }

            warehouseCapacity.currentCapacity = currentCap;
        }

        public void PrintInformation()
        {
            Console.WriteLine("На складе хранятся следующие товары и их количество:");

            foreach (var item in products)
            {
                Console.WriteLine($"Продукт: {item.Key} Количество продукта: {item.Key}");
            }
        }
    }
}
