using static System.Reflection.Metadata.BlobBuilder;

namespace Parking_Lot.ParkingLot
{
    public class ParkingFloor
    {
        public int FloorNumber { get; }
        List<ParkingSlot> Slots;

        public ParkingFloor(int floorNumber, int numSlots)
        {
            FloorNumber = floorNumber;
            Slots = new List<ParkingSlot>();
            InitializeSlots(numSlots);
        }
        private void InitializeSlots(int numSlots)
        {
            if (numSlots < 3)
            {
                throw new ArgumentException("Each floor must have at least 3 slots.");
            }
            Slots.Add(new ParkingSlot(1, VehicleType.Truck)); // First slot for a truck.
            Slots.Add(new ParkingSlot(2, VehicleType.Bike)); // Second slot for a bike.
            Slots.Add(new ParkingSlot(3, VehicleType.Bike)); // Third slot for a bike.
            for (int i = 4; i <= numSlots; i++)
            {
                Slots.Add(new ParkingSlot(i, VehicleType.Car)); // Remaining slots for cars.
            }
        }
        public ParkingSlot FindAvailableSlot(VehicleType type)
        {
            foreach (var slot in Slots)
            {
                if (!slot.IsOcuppied && slot.vehicleType == type)
                {
                    return slot;
                }
            }
            return null;
        }

        public void DisplayFreeSlots(VehicleType type)
        {
            foreach (var slot in Slots)
            {
                if (!slot.IsOcuppied && slot.vehicleType == type)
                {
                    Console.WriteLine($"Slot {slot.slotNumber} is free.");
                }
            }
        }

        public void DisplayOccupiedSlots(VehicleType type)
        {
            foreach (var slot in Slots)
            {
                if (slot.IsOcuppied && slot.vehicleType == type)
                {
                    Console.WriteLine($"Slot {slot.slotNumber} is occupied by {slot.parkedVehicle.registrationNumber}.");
                }
            }
        }

        public int CountFreeSlots(VehicleType type)
        {
            int count = 0;
            foreach (var slot in Slots)
            {
                if (!slot.IsOccupied && slot.SlotType == type)
                {
                    count++;
                }
            }
            return count;
        }
    }

}
