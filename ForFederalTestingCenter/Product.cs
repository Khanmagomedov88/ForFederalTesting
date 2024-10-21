using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ForFederalTestingCenter
{
    internal class Product
    {
        private string name { get; set; }
        private double weight { get; set; }
        private string packagingType { get; set; }

        public Product(string name, double weight, string packagingType)
        {
            this.name = name;
            this.weight = weight;
            this.packagingType = packagingType;
        }

        public string GetNameProduct() => name;
        public string GetPackingTypeProduct() => packagingType;


    }
}
