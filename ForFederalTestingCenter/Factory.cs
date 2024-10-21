using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ForFederalTestingCenter
{
    internal class Factory
    {
        private int productsPerHour { get; set; }
        private string nameFactory = string.Empty;

        private Product product;

        Warehouse warehouse = Warehouse.Instance;

        public Factory(Product product, int productsPerHour)
        {
            this.product = product;
            this.productsPerHour = productsPerHour;
            this.nameFactory = $"Завод по производству {product.GetNameProduct()}";

            Warehouse.Instance.IncreaseMaxCapacity(productsPerHour); // Увеличиваем объем склада. По условию: M * (сумму продукции всех фабрик в час).
        }


        /// <summary>
        /// Производит продукты и добавляет их на склад
        /// </summary>
        public void MakeProduct()
        {
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine($"Фабрика {nameFactory} произвела {productsPerHour} продукта {product.GetNameProduct()}");

                isRun = warehouse.AddProductToWarehouse(product, productsPerHour);

                Thread.Sleep(2000); // Производство раз в 2 секунды

            }
        }

    }
}
