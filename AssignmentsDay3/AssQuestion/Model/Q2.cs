using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssQuestion.Model
{
    internal class Q2 //carClass
    {
        
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model {  get; set; }
        public int Year {  get; set; }
        public double Price {  get; set; }

        public Q2(int Id, string brand, string model, int year, double price)
        {
            CarId= Id;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Car Id: {CarId}\nBrand: {Brand}\nModel: {Model}\nYear: {Year}\nPrice: {Price}");
        }

    }
}
