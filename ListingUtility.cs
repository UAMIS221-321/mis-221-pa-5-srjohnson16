namespace mis_221_pa_5_srjohnson16
{
    public class ListingUtility
    {

        private static int MAX_ARRAY_SIZE = 100;
        private static Listing[] listings = new Listing[MAX_ARRAY_SIZE];
        private static int count = 0;
        public static int GetCount()
        {
            return count;
        }
        public static void DecCount()
        {
            count--;
        }
        public static void IncCount()
        {
            count--;
        }
        public static void SetCount(int count)
        {
            ListingUtility.count = count;
        }
        //Iinitialization. Reads in data from file. must be called before any other method in this class
        public static void InitListing()
        {
            StreamReader inFile = new StreamReader("listing.txt");

            string line = inFile.ReadLine();
            //PROCESS
            while (line != null && line != "")
            {
                string[] temp = line.Split('#');
                listings[ListingUtility.GetCount()] = (new Listing(temp[0], temp[1], temp[2], temp[3], bool.Parse(temp[4])));
                count++;
                line = inFile.ReadLine();

            }
            //CLOSE
            inFile.Close();
        }
        // returns all listings 
        public static Listing[] GetListings()
        {
            return listings;
        }
        //methods
        public static void AddListing()
        {
            Listing newListing = new Listing();
            System.Console.WriteLine("Please enter the lsiting ID: ");
            newListing.SetListingID(int.Parse(Console.ReadLine()));

            System.Console.WriteLine("Please enter the trainer name: ");
            newListing.SetTrainerName(Console.ReadLine());

            System.Console.WriteLine("Please enter the session date: ");
            newListing.SetSessionDate(Console.ReadLine());

            System.Console.WriteLine("Please enter the session time: ");
            newListing.SetSessionTime(Console.ReadLine());

            System.Console.WriteLine("Please enter the session cost: ");
            newListing.SetSessionTime(Console.ReadLine());

            //it has to know what to look like in order to be a ox
            listings[ListingUtility.GetCount()] = newListing;
            System.Console.WriteLine("Listing successfully added.");

            ListingUtility.IncCount();

            Save();
        }
        public static void EditListing()
        {
            // public Listing(string listingID, string trainerName, string sessionDate, string sessionTime, string sessionCost, bool isTaken)
            System.Console.Write("Enter the listing to update: ");
            string searchVal = Console.ReadLine();
            int foundIndex = FindListing(searchVal);

            if (foundIndex != -1)
            {
                System.Console.WriteLine("Enter the listing ID");
                listings[foundIndex].SetListingID(int.Parse(Console.ReadLine()));

                System.Console.WriteLine("Enter the trainer name ");
                listings[foundIndex].SetTrainerName(Console.ReadLine());

                System.Console.WriteLine("Enter the session date: ");
                listings[foundIndex].SetSessionDate(Console.ReadLine());

                System.Console.WriteLine("Enter the session time");
                listings[foundIndex].SetSessionTime(Console.ReadLine());

                System.Console.WriteLine("Enter the session cost");
                listings[foundIndex].SetSessionCost(Console.ReadLine());
            }

            System.Console.WriteLine("Update successful.");
            Save();
        }
        public static void DeleteListing()
        {
            //find the listing to delete 
            System.Console.WriteLine("What is the ID of the listing you want to delete?");
            string searchVal = Console.ReadLine();

            int foundIndex = FindListing(searchVal); //returns the index of the trainer array that has that id

            if (foundIndex != -1) //if found 
            {
                for (int j = foundIndex; j < ListingUtility.GetCount() - 1; j++) //from position to n-1
                {
                    listings[j] = listings[j + 1];
                }
            }
            else System.Console.WriteLine("Trainer ID not found.");

            Trainer.DecCount();


            Save();
        }
        private static void Save()
        {
            StreamWriter outFile = new StreamWriter("listing.txt");

            for (int i = 0; i < ListingUtility.GetCount(); i++)
            {
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();

        }
        //returns the index of interest
        private static int FindListing(string searchVal)
        {
            //loops through array to see if elements match
            for (int i = 0; i < ListingUtility.GetCount(); i++)
            {
                if (listings[i].GetListingID() == int.Parse(searchVal))
                {
                    System.Console.WriteLine("Listing found..");                        //!Delete
                    return i;
                }
            }
            return -1;
        }
        //Searching. Search listing object array by listing ID
        public static Listing FindListingById(string listingId)
        {
            return listings[FindListing(listingId)];
        }

        //updates the status of the listing to "taken"
        public static void MarkListingAsTaken(string selectedListing)
        {
            //returns the object 
            FindListingById(selectedListing).SetIsTaken(true);

            Save();
        }

        public static void MarkListingAsCancelled(string selectedListing)
        {
            //returns the object 
            FindListingById(selectedListing).SetIsTaken(false);
            System.Console.WriteLine(" MarkListingAsCancelled() method");
            Save();
        }

        //Gets listings with the isTaken set to "false "
        public static Listing[] GetAvailableListings(ref int countAvail)
        {
            Listing[] availableListings = new Listing[MAX_ARRAY_SIZE];
            countAvail = 0;
            for (int i = 0; i < ListingUtility.GetCount(); i++)
            {
                if (listings[i].GetIsTaken() == false)
                {
                    availableListings[countAvail] = listings[i];
                    countAvail++;
                }
            }
            return availableListings;
        }


    }
}




///-------------

// Returns all listings with isTaken = false
// public Listing[] GetAvailableListings()
// {

//     Listing[] result;

//     for (int i = 0; i < Listing.GetCount(); i++)
//     {
//         if (listings[i].GetIsTaken() == false)
//         {
//             result[i] = listings[i];

//         }
//     }


//     return result;

// }