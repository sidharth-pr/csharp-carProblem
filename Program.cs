namespace ConsoleApp1
{
    internal class Program
    {
        class Tire // Tire class
        {
            private string tireName; // Name of the tire
            public int ecoFactor; // Eco Factor of the tire
            public double tirePrice; // Price of the tire
            public Tire(string tireName, int ecoFactor, double tirePrice) // Constuctor
            {
                this.tireName = tireName;
                this.ecoFactor = ecoFactor;
                this.tirePrice = tirePrice;
            }
        }

        class Car // Gasoline car class
        {
            protected double maxSpeed, tankDist, tankStop; // Maximum Speed, Distance before fueling tank, Time to fuel tank
            public string carName, carType; // Name of the car
            protected Tire[] tires = new Tire[5]; // 5 Tire objects
            protected double carPrice; // Cost of the car

            public Car(string carName, Tire t1, Tire t2, Tire t3, Tire t4, Tire t5) // Constructor
            {
                this.maxSpeed = 250;
                this.tankStop = 5;
                this.tankDist = 1200;
                this.carPrice = 25000;
                this.carType = "gasoline";
                this.carName = carName;
                this.tires[0] = t1;
                this.tires[1] = t2;
                this.tires[2] = t3;
                this.tires[3] = t4;
                this.tires[4] = t5;
            }
            
            public virtual void Drive(double currentSpeed) // Prints several details about the car
            {
                double percent = currentSpeed / maxSpeed * 100;
                Console.WriteLine("Driving a " + this.carName + " " + this.carType + " car with " + percent + " of maximal speed.");
                Console.WriteLine("Wheels:\r\n Front (L, R): " + tires[0] + " " + tires[1] + "\r\n Rear(L, R): " + tires[2] + " " + tires[3] + "\r\n Spare: " + tires[4]);
            }

            public virtual void Refuel(string fuelType) // Prints refueling details
            {
                if (fuelType == "gas")
                    Console.WriteLine("Refueling with " + fuelType);
                else
                    Console.WriteLine("Refueling with " + fuelType + " is not allowed!");
            }

            public virtual void CalcPrice() // Calculates total price of car including cost of the tires being used
            {
                double total = carPrice + tires[0].tirePrice + tires[1].tirePrice + tires[2].tirePrice + tires[3].tirePrice + tires[4].tirePrice;
                Console.WriteLine("Total price is " + total);
            }

            private void actualDistance() // Calculates travel distance based on tire eco factors
            {
                double ef = tires[0].ecoFactor + tires[1].ecoFactor + tires[2].ecoFactor + tires[3].ecoFactor + tires[4].ecoFactor;
                tankDist += ef * tankDist;
            }

            private double travelTime(double distance) // Private method used by CalcTravelTime to do some calculations
            {
                actualDistance(); // Function Call
                double travelTime = this.maxSpeed / distance;
                int noOfStops = Convert.ToInt32(distance / tankDist);
                travelTime += (noOfStops * tankStop);
                return travelTime;
            }
            public virtual void CalcTravelTime(double distance) // Calculates minimum travel time by considering maximum travel speed, refueling requirements, and eco factor of the tires
            {
                Console.WriteLine("Minimum travel time for " + distance + " is " + travelTime(distance));
            }
        }

        class SportCar : Car // Sports car class
        {
            public SportCar(string carName, Tire t1, Tire t2, Tire t3, Tire t4, Tire t5) : base(carName, t1, t2, t3, t4, t5) // Constructor with parent constructor call
            {
                this.maxSpeed = 300;
                this.tankStop = 5;
                this.tankDist = 1000;
                this.carPrice = 80000;
                this.carType = "sports";
            }

            public override void Drive(double currentSpeed) // Overridden method
            {
                base.Drive(currentSpeed);
            }

            public override void Refuel(string fuelType)
            {
                if (fuelType == "gas")
                    Console.WriteLine("Refueling with " + fuelType);
                else
                    Console.WriteLine("Refueling with " + fuelType + " is not allowed!");
            }

            public override void CalcPrice()
            {
                base.CalcPrice();
            }

            public override void CalcTravelTime(double distance)
            {
                base.CalcTravelTime(distance);
            }
        }

        class ElectricCar : Car // Electric car class
        {
            public ElectricCar(string carName, Tire t1, Tire t2, Tire t3, Tire t4, Tire t5) : base(carName, t1, t2, t3, t4, t5) // Constructor with parent constructor call
            {
                this.maxSpeed = 240;
                this.tankStop = 80;
                this.tankDist = 600;
                this.carPrice = 70000;
                this.carType = "electric";
            }

            public override void Drive(double currentSpeed) // Overridden method
            {
                base.Drive(currentSpeed);
            }

            public override void Refuel(string fuelType)
            {
                if (fuelType == "electricity")
                    Console.WriteLine("Refueling with " + fuelType);
                else
                    Console.WriteLine("Refueling with " + fuelType + " is not allowed!");
            }

            public override void CalcPrice()
            {
                base.CalcPrice();
            }

            public override void CalcTravelTime(double distance)
            {
                base.CalcTravelTime(distance);
            }
        }

        class HybridCar : Car // Hybrid car class
        {
            public HybridCar(string carName, Tire t1, Tire t2, Tire t3, Tire t4, Tire t5) : base(carName, t1, t2, t3, t4, t5) // Constructor with parent constructor call
            {
                this.maxSpeed = 230;
                this.tankStop = 30;
                this.tankDist = 2000;
                this.carPrice = 40000;
                this.carType = "hybrid";
            }

            public override void Drive(double currentSpeed) // Overridden method
            {
                base.Drive(currentSpeed);
            }

            public override void Refuel(string fuelType)
            {
                if (fuelType == "electricity" || fuelType == "gas")
                    Console.WriteLine("Refueling with " + fuelType);
                else
                    Console.WriteLine("Refueling with " + fuelType + " is not allowed!");
            }

            public override void CalcPrice()
            {
                base.CalcPrice();
            }

            public override void CalcTravelTime(double distance)
            {
                base.CalcTravelTime(distance);
            }
        }

        public static void Main(string[] args) // Main method
        {
            Tire normal = new Tire("Vredestein Sportrac 5", 40, 0); 
            Tire eco = new Tire("Michelin Energy Saver", 110, 0.06);
            Tire snow = new Tire("Pirelli Cinturato Winter", 60, -0.04); // Declaration of Tire objects

            Car[] cars = new Car[4]; 
            cars[0] = new Car("BMW_G30", normal, normal, normal, normal, normal);
            cars[1] = new SportCar("Ferrari_288", eco, eco, normal, normal, normal);
            cars[2] = new ElectricCar("Tesla_S", snow, snow, snow, snow, snow);
            cars[3] = new HybridCar("Lexus_IS_300h", eco, eco, eco, eco, eco); // Declaration of Car objects

            foreach (Car car in cars)
            {
                car.Drive(230);
                car.Refuel("gasoline");
                car.Refuel("electricity");
            }
        }
    }
}