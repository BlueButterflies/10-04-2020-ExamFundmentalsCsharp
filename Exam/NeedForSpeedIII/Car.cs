namespace NeedForSpeedIII
{
    public class Car
    {
        public Car(int distance, int fuel)
        {
            this.Mileage = distance;
            this.Fuel = fuel;
        }

        public int Mileage { get; set; }
        public int Fuel { get; set; }

        
    }
}
