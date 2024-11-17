namespace Parking_Lot.ParkingLot
{
    public class ParkingLoot
    {
        private const string ParkingLotId = "PR1234";
        private List<ParkingFloor> Floors;

        public ParkingLoot(int floor, int numberOfSlots)
        {
            Floors = new List<ParkingFloor>();
            for (int i = 1; i <= floor; i++)
            {
                Floors.Add(new ParkingFloor(i, numberOfSlots));
            }
        }
        public string ParkVehicle(Vehicle vehicle)
        {
            foreach (var floor in Floors)
            {
                var slot = floor.FindAvailableSlot(vehicle.vehicleType);
                if (slot != null)
                {
                    slot.ParkVehicle(vehicle);
                    string ticketId = $"{ParkingLotId}_{floor.FloorNumber}_{slot.slotNumber}";
                    Console.WriteLine($"Vehicle parked. Ticket ID: {ticketId}");
                    return ticketId;
                }
            }
            Console.WriteLine("No available slots for this vehicle type.");
            return null;
        }

        public void UnparkVehicle(string ticketId)
        {
            string[] parts = ticketId.Split('_');
            if (parts.Length != 3 || parts[0] != ParkingLotId)
            {
                Console.WriteLine("Invalid ticket ID.");
                return;
            }

            if (int.TryParse(parts[1], out int floorNumber) && int.TryParse(parts[2], out int slotNumber))
            {
                var floor = Floors.Find(f => f.FloorNumber == floorNumber);
                if (floor != null)
                {
                    var slot = floor.FindAvailableSlot((VehicleType)slotNumber);
                    if (slot != null && slot.IsOcuppied)
                    {
                        slot.Unparkvehicle();
                        Console.WriteLine($"Vehicle unparked from ticket ID: {ticketId}");
                        return;
                    }
                }
            }
            Console.WriteLine("Invalid floor or slot number.");
        }

        public void DisplayFreeSlots(VehicleType type)
        {
            foreach (var floor in Floors)
            {
                Console.WriteLine($"Floor {floor.FloorNumber}:");
                floor.DisplayFreeSlots(type);
            }
        }

        public void DisplayOccupiedSlots(VehicleType type)
        {
            foreach (var floor in Floors)
            {
                Console.WriteLine($"Floor {floor.FloorNumber}:");
                floor.DisplayOccupiedSlots(type);
            }
        }

        public void DisplayFreeSlotCount(VehicleType type)
        {
            foreach (var floor in Floors)
            {
                int count = floor.CountFreeSlots(type);
                Console.WriteLine($"Floor {floor.FloorNumber} has {count} free slots for {type}.");
            }
        }
    }
}
