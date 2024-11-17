namespace Parking_Lot.ParkingLot
{
    public class Main
    {
        static void DesignParking(string[] args)
        {
            // Create a parking lot with 3 floors and 10 slots per floor.
            ParkingLoot parkingLot = new ParkingLoot(3, 10);

            // Example operations.
            Vehicle car1 = new Vehicle(VehicleType.Car, "ABC123", "Red");
            parkingLot.ParkVehicle(car1);

            Vehicle bike1 = new Vehicle(VehicleType.Bike, "BIKE456", "Blue");
            parkingLot.ParkVehicle(bike1);

            parkingLot.DisplayFreeSlotCount(VehicleType.Car);
            parkingLot.DisplayFreeSlots(VehicleType.Bike);
            parkingLot.DisplayOccupiedSlots(VehicleType.Car);
        }
    }
}
