namespace Parking_Lot.ParkingLot
{
    public class Vehicle
    {
        public VehicleType vehicleType { get; }
        public string registrationNumber { get; }

        public string color { get; }

        public Vehicle(VehicleType vehicleType, string registrationNumber, string color)
        {
            this.vehicleType = vehicleType;
            this.registrationNumber = registrationNumber;
            this.color = color;
        }

    }
    public enum VehicleType
    {
        Car,
        Bike,
        Truck
    }
}
