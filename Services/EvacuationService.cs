using System;
using System.Collections.Generic;
using System.Linq;
using ProjectOne.Models;

namespace ProjectOne.Services
{
    public class EvacuationService
    {
        private List<Household> households = new List<Household>();
        private List<EvacuationCenter> evacuationCenters = new List<EvacuationCenter>();

        public EvacuationService()
        {
            SeedCenters();
        }

        private void SeedCenters()
        {
            evacuationCenters.Add(new EvacuationCenter(1, "Central Evacuation Center", "123 Main St", 100));
            evacuationCenters.Add(new EvacuationCenter(2, "North Evacuation Center", "456 North St", 50));
            evacuationCenters.Add(new EvacuationCenter(3, "South Evacuation Center", "789 South St", 75));
        }

        public void RegisterHousehold(string name, string barangay, int members)
        {
            int id = households.Count + 1;
            households.Add(new Household(id, name, barangay, members));
        }

        public List<EvacuationCenter> GetEvacuationCenters()
        {
            return evacuationCenters;
        }

        public List<Household> GetHouseholds()
        {
            return households;
        }

        public string Evacuate(int householdId, int centerId)
        {
            var household = households.FirstOrDefault(h => h.HouseholdId == householdId);
            var center = evacuationCenters.FirstOrDefault(c => c.EvacuationCenterId == centerId);

            if(household == null)
            {
                return "Household not found.";
            }

            if(center == null)
            {
                return "Evacuation center not found.";
            }
            if (!center.HasCapacity(household.MembersCount))
            {
                return "Not enough capacity in the evacuation center.";
            }

            center.AddOccupants(household.MembersCount);
            household.IsEvacuated = true;
            household.EvacuationCenterAssigned = center.Name;

            return "Household evacuated successfully.";
        }
    }
}