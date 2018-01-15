using System;
using System.Collections.Generic;
using System.Text;

namespace CarDemoApp.Model
{
    class CarBrand
    {
        public string BrandName { get; set; }
        public string BrandLogo  { get; set; }

        public CarBrand()
        {

        }
        public CarBrand(string name, string image)
        {
            BrandName = name;
            BrandLogo = image;
        }
    }
}
