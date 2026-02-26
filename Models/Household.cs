namespace ProjectOne.Models
{
    public class Household
    {
        public int HouseholdId { get; set; }
        public string HeadName { get; set; }
        public string Barangay { get; set; }
        public int MembersCount { get; set; }
        public bool IsEvacuated { get; set; }
        public string EvacuationCenterAssigned { get; set; }

        public Household(int householdId, string headName, string barangay, int membersCount)
        {
            HouseholdId = householdId;
            HeadName = headName;
            Barangay = barangay;
            MembersCount = membersCount;
            IsEvacuated = false;
            EvacuationCenterAssigned = "None";
        }
    }
}