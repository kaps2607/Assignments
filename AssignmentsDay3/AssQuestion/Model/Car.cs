

namespace AssQuestion.Model
{
    public class Car
    {
        int CarId { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        double Price { get; set;}

        //public Car(int CarId, string Brand, string Model, int Year, double Price)
        //{
        //    Console.WriteLine("Receiving Car Information");
        //    CarId = CarId;
        //    Brand = Brand;
        //    Model = Model;
        //    Year = Year;
        //    Price = Price;
        //}


        public void getDetails()
        {
           
            Console.Write("Enter Car id: ");
            CarId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Brand: ");
            Brand = Console.ReadLine();
            Console.Write("Which Model is it? ");
            Model = Console.ReadLine();
            Console.Write("In which year did you purchase it?");
            Year = Convert.ToInt32(Console.ReadLine());
            Console.Write("How much did it cost to you?");
            Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Receiving Car Information");
        }
        public void showDetails()
        {
            Console.WriteLine("Presenting Car Information");
            // Console.WriteLine($"Car id is: {CarId}\nBrand: {Brand}\nModel: {Model}\nYear: {Year}\nPrice: {Price}");
            Console.WriteLine($"car is{CarId}");
            Console.WriteLine($"car brand is {Brand}");
            Console.WriteLine($"car model is {Model}");
            Console.WriteLine($"car manufacturing year is {Year}");
            Console.WriteLine($"car price is {Price}");
        }   
    }
}