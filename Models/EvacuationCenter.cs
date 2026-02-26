namespace ProjectOne.Models
{
    public class EvacuationCenter
    {
        public int EvacuationCenterId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }

        public EvacuationCenter(int evacuationCenterId, string name, string address, int capacity)
        {
            EvacuationCenterId = evacuationCenterId;
            Name = name;
            Address = address;
            Capacity = capacity;
            CurrentOccupancy = 0;
        }

        public bool HasCapacity(int members)
        {
            return CurrentOccupancy + members <= Capacity;
        }

        public void AddOccupants(int members)
        {
            if (HasCapacity(members))
            {
                CurrentOccupancy += members;
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity in the evacuation center.");
            }
        }
    }
}