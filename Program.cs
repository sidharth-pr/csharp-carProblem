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

        class Car // Standard car class
        {
            protected double maxSpeed = 250, tankDist = 1200, tankStop = 5, carPrice = 25000; // Maximum Speed, Distance before fueling tank, Time to fuel tank, Cost of the car
            public string carName, carType = "gasoline"; // Name of the car
            protected Tire[] tires = new Tire[5]; // 5 Tire objects

            public Car(string carName, Tire t1, Tire t2, Tire t3, Tire t4, Tire t5) // Constructor
            {
                this.carName = carName;
                this.tires[0] = t1;
                this.tires[1] = t2;
                this.tires[2] = t3;
                this.tires[3] = t4;
                this.tires[4] = t5;
            }
            
            public virtual void drive(double currentSpeed) // Prints several details about the car
            {
                double percent = currentSpeed / maxSpeed * 100;
                Console.WriteLine("Driving a " + this.carName + " " + this.carType + " car with " + percent + " of maximal speed.");
                Console.WriteLine("Wheels:\r\n Front (L, R): " + tires[0] + " " + tires[1] + "\r\n Rear(L, R): " + tires[2] + " " + tires[3] + "\r\n Spare: " + tires[4]);
            }

            public virtual void refuel(string fuelType) // Prints refueling details
            {
                if (fuelType == this.carType)
                    Console.WriteLine("Refueling with " + fuelType);
                else
                    Console.WriteLine("Refueling with " + fuelType + " is not allowed!");
            }

            public virtual void calcPrice() // Calculates total price of car including cost of the tires being used
            {
                double total = carPrice + tires[0].tirePrice + tires[1].tirePrice + tires[2].tirePrice + tires[3].tirePrice + tires[4].tirePrice;
                Console.WriteLine("Total price is " + total);
            }

            protected double actualDistance(double tankDist) // Calculates travel distance based on tire eco factors
            {
                double ef = tires[0].ecoFactor + tires[1].ecoFactor + tires[2].ecoFactor + tires[3].ecoFactor + tires[4].ecoFactor;
                double newTankDist = tankDist * (1 + ef);
                return newTankDist;
            }
   
            protected double calcTankStops(double distance, double newTankDist) // Calculates the number of tank stops
            {
                double noOfStops = (distance - (distance % newTankDist)) / newTankDist;
                return noOfStops;
            }

            protected double calcTotalStopTime(double noOfStops, double tankStop) // Calculates time spent in tank stops
            {
                double totalStop = (noOfStops * tankStop) / 60;
                return totalStop;
            }

            protected void printTravelTime(double travelTime, double noOfStops, double distance) // To print the calculations of travel time methods
            {
                string i;
                double hours = (travelTime - (60 * travelTime % 60) / 60);
                double minutes = ((travelTime - hours * 60));
                if (noOfStops == 1)
                    i = "stop";
                else
                    i = "stops";
                Console.WriteLine("Minimum travel time for {0}km is {1,2:f0}h {2,2:f0}min ({3} tank {4}).", distance, hours, minutes, noOfStops, i);
            }
            public virtual void calcTravelTime(double distance) // Calculates minimum travel time by considering maximum travel speed, refueling requirements, and eco factor of the tires
            {
                double newTankDist = actualDistance(tankDist); // Function Call
                double travelTime = distance / maxSpeed;
                double noOfStops = calcTankStops(distance, newTankDist);
                double totalStopTime = calcTotalStopTime(noOfStops, this.tankStop);
                travelTime += totalStopTime;
                printTravelTime(travelTime, noOfStops, distance);
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
                this.carType = "gasoline";
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
                this.carType = "electricity";
            }
        }

        class HybridCar : Car // Hybrid car class
        {
            private double extraTankDist = 2000;
            private double extraTankStop = 30;
            private string extraCarType = "gasoline";
            public HybridCar(string carName, Tire t1, Tire t2, Tire t3, Tire t4, Tire t5) : base(carName, t1, t2, t3, t4, t5) // Constructor with parent constructor call
            {
                this.maxSpeed = 230;
                this.tankStop = 30;
                this.tankDist = 2000;
                this.carPrice = 40000;
                this.carType = "electricity";
            }

            public override void refuel(string fuelType)
            {
                if (fuelType == carType || fuelType == extraCarType)
                    Console.WriteLine("Refueling with " + fuelType);
                else
                    Console.WriteLine("Refueling with " + fuelType + " is not allowed!");
            }

            public override void calcTravelTime(double distance)
            {
                double newTankDist = actualDistance(tankDist); // Function Call
                double newExtraTankDist = actualDistance(extraTankDist);
                double travelTime = distance / maxSpeed;
                double noOfStops = calcTankStops(distance, newTankDist);
                double noOfStops1 = calcTankStops(distance, newExtraTankDist);
                double totalStopTime = calcTotalStopTime(noOfStops, this.tankStop);
                double totalStopTime1 = calcTotalStopTime(noOfStops, this.extraTankStop);
                travelTime += totalStopTime + totalStopTime1;
                printTravelTime(travelTime, noOfStops + noOfStops1, distance);
            }
        }

        public static void Main(string[] args) // Main method
        {
            Tire normal = new Tire("Vredestein Sportrac 5", 40, 0); 
            Tire eco = new Tire("Michelin Energy Saver", 110, 0.06);
            Tire snow = new Tire("Pirelli Cinturato Winter", 60, -0.04); // Declaration of Tire objects

            Car[] cars = new Car[4]; 
            cars[0] = new Car("BMW G30", normal, normal, normal, normal, normal);
            cars[1] = new SportCar("Ferrari 288", eco, eco, normal, normal, normal);
            cars[2] = new ElectricCar("Tesla S", snow, snow, snow, snow, snow);
            cars[3] = new HybridCar("Lexus IS 300h", eco, eco, eco, eco, eco); // Declaration of Car objects

            foreach (Car car in cars)
            {
                car.drive(230);
                car.refuel("gasoline");
                car.refuel("electricity");
                car.calcPrice();
                car.calcTravelTime(2000);
                Console.ReadLine();
            }
        }
    }
}