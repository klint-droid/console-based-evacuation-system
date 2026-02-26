using System;
using ProjectOne.Services;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var service = new EvacuationService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       EVACUATION MANAGEMENT        ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Register Household");
                Console.WriteLine("2. View Evacuation Centers");
                Console.WriteLine("3. Evacuate Household");
                Console.WriteLine("4. View Households");
                Console.WriteLine("5. View Evacuated Households");
                Console.WriteLine("6. View Not Evacuated Households");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("HeadName: ");
                        string name = Console.ReadLine();

                        Console.Write("Barangay: ");
                        string barangay = Console.ReadLine();

                        Console.Write("Members Count: ");
                        if(!int.TryParse(Console.ReadLine(), out int members))
                        {
                            Console.WriteLine("Invalid number of members.");
                            Pause();
                            break;
                        }

                        service.RegisterHousehold(name, barangay, members);
                        Console.WriteLine("Household registered successfully!");
                        Pause();
                        break;
                    case "2":
                        var centers = service.GetEvacuationCenters();
                        Console.WriteLine("Evacuation Centers:");
                        if(centers.Count == 0)
                        {
                            Console.WriteLine("No evacuation centers found.");
                            Pause();
                            break;
                        }
                        foreach (var center in centers)
                        {
                            Console.WriteLine($"{center.EvacuationCenterId}. {center.Name} - {center.Address} (Capacity: {center.Capacity}, Occupied: {center.CurrentOccupancy})");
                        }
                        Pause();
                        break;
                    case "3":
                        var householdsList = service.GetHouseholds();
                        Console.WriteLine("Households List:");
                        if(householdsList.Count == 0)
                        {
                            Console.WriteLine("No households found.");
                            Pause();
                            break;
                        }
                        foreach (var household in householdsList)
                        {
                            Console.WriteLine($"{household.HouseholdId}. {household.HeadName} - {household.Barangay} (Members: {household.MembersCount}) - Evacuated: {household.IsEvacuated} - Center: {household.EvacuationCenterAssigned}");
                        }
                        Console.WriteLine("====================================");

                        Console.WriteLine("Evacuation Centers List:");
                        var centersList = service.GetEvacuationCenters();
                        if(centersList.Count == 0)
                        {
                            Console.WriteLine("No evacuation centers found.");
                            Pause();
                            break;
                        }
                        foreach (var center in centersList)
                        {
                            Console.WriteLine($"{center.EvacuationCenterId}. {center.Name} - {center.Address} (Capacity: {center.Capacity}, Occupied: {center.CurrentOccupancy})");
                        }
                        Console.Write("Household ID: ");
                        if(!int.TryParse(Console.ReadLine(), out int householdId))
                        {
                            Console.WriteLine("Invalid household ID.");
                            Pause();
                            break;
                        }

                        Console.Write("Evacuation Center ID: ");
                        if(!int.TryParse(Console.ReadLine(), out int centerId))
                        {
                            Console.WriteLine("Invalid evacuation center ID.");
                            Pause();
                            break;
                        }
                        
                        string result = service.Evacuate(householdId, centerId);
                        Console.WriteLine(result);
                        Pause();
                        break;
                    case "4":
                        var households = service.GetHouseholds();
                        Console.WriteLine("Households:");
                        if(households.Count == 0)
                        {
                            Console.WriteLine("No households found.");
                            Pause();
                            break;
                        }
                        foreach (var household in households)
                        {
                            Console.WriteLine($"{household.HouseholdId}. {household.HeadName} - {household.Barangay} (Members: {household.MembersCount}) - Evacuated: {household.IsEvacuated} - Center: {household.EvacuationCenterAssigned}");
                        }
                        Pause();
                        break;
                    case "5":
                        var evacuatedHouseholds = service.GetHouseholds().Where(h => h.IsEvacuated);
                        Console.WriteLine("Evacuated Households:");
                        if(evacuatedHouseholds.Count() == 0)
                        {
                            Console.WriteLine("No evacuated households found.");
                            Pause();
                            break;
                        }
                        foreach (var household in evacuatedHouseholds)
                        {
                            Console.WriteLine($"{household.HouseholdId}. {household.HeadName} - {household.Barangay} (Members: {household.MembersCount}) - Center: {household.EvacuationCenterAssigned}");
                        }
                        Pause();
                        break;
                    case "6":
                        var notEvacuatedHouseholds = service.GetHouseholds().Where(h => !h.IsEvacuated);
                        Console.WriteLine("Not Evacuated Households:");
                        if(notEvacuatedHouseholds.Count() == 0)
                        {
                            Console.WriteLine("No not evacuated households found.");
                            Pause();
                            break;
                        }
                        foreach (var household in notEvacuatedHouseholds)
                        {
                            Console.WriteLine($"{household.HouseholdId}. {household.HeadName} - {household.Barangay} (Members: {household.MembersCount})");
                        }
                        Pause();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}