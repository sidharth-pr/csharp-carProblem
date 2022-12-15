namespace ConsoleApp1
{
    internal class Program
    {
        class Tire
        {
            private string tireName;
            protected int ecoFactor;
            public double tirePrice;
            public Tire(string tireName, int ecoFactor, double tirePrice)
            {
                this.tireName = tireName;
                this.ecoFactor = ecoFactor;
                this.tirePrice = tirePrice;
            }
        }

        class Car : Tire
        {
            protected double maxSpeed;
            protected string carName;
            Tire[] tires = new Tire[4];    
            protected double carPrice = 25000;

            public Car(string carName, Tire t1, Tire t2, Tire t3, Tire t4, Tire t5)
            {
                this.maxSpeed = 250;
                this.carName = carName;
                this.tires[0] = t1;
                this.tires[1] = t2;
                this.tires[2] = t3;
                this.tires[3] = t4;
                this.tires[4] = t5;
            }
            
            public virtual void Drive(double currentSpeed)
            {
                double percent = currentSpeed / maxSpeed * 100;
                Console.WriteLine("Driving a ", this.carName, " gasoline car with ", percent, " of maximal speed.");
                Console.WriteLine("Wheels:\r\n Front (L, R): ", tires[0], " ", tires[1], "\r\n Rear(L, R): ", tires[2], " ", tires[3], "\r\n Spare: ", tires[4]);
            }

            public void Refuel(string fuelType)
            {
                if (fuelType == "gas")
                    Console.WriteLine("Refueling with gas");
                else
                    Console.WriteLine("Refueling with ", fuelType, " not allowed!");
            }

            public void CalcPrice()
            {
                double total = carPrice + tires[0].tirePrice + tires[1].tirePrice + tires[2].tirePrice + tires[3].tirePrice + tires[4].tirePrice;
                Console.WriteLine("Total price is ", total);
            }

            public void CalcTravelTime(double distance)
            {
                double travelTime = this.maxSpeed / distance;
                Console.WriteLine("Minimum travel time for ", distance, " is ", travelTime);
            }
        }

        class SportCar : Car
        {
            public SportCar()
        }

        class ElectricCar : Car
        {

        }

        class HybridCar : Car
        {

        }
        static void Main(string[] args)
        {

        }
    }
}