namespace Parking_Lot.ParkingLot
{
    public class ParkingSlot
    {
        public int slotNumber { get; }
        public VehicleType vehicleType { get; }
        public bool IsOcuppied { get; private set; }
        public Vehicle parkedVehicle { get; private set; }
        public ParkingSlot(int slotNumber, VehicleType vehicleType)
        {
            this.slotNumber = slotNumber;
            this.vehicleType = vehicleType;
            this.IsOcuppied = false;
        }
        public bool ParkVehicle(Vehicle vehicle)
        {
            if(!this.IsOcuppied && this.vehicleType == vehicle.vehicleType) 
            {
                this.IsOcuppied=true;
                this.parkedVehicle = vehicle;
                return true;
            }
            return false;
        }
        public void Unparkvehicle()
        {
            this.parkedVehicle = null;
            this.IsOcuppied = false;
        }

    }
}
