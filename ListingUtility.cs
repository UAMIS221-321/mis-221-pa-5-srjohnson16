namespace mis_221_pa_5_srjohnson16
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings)
        {
            this.listings = listings;
        }

        public ListingUtility()
        {
        }
        private static int count = 0;
        public static int GetCount()
        {
            return ListingUtility.count;
        }
        public static void DecCount()
        {
            ListingUtility.count--;
        }
        public static void IncCount()
        {
            ListingUtility.count--;
        }
        public static void SetCount(int count)

        {
            ListingUtility.count = count;
        }

        //Initialization. Reads in data from file. must be called before any other method in this class
        public void InitListing()
        {
            StreamReader inFile = new StreamReader("listing.txt");
            Listing.SetCount(0);
            int count = 0;
            string line = inFile.ReadLine();
            while (line != null && line != "")
            {
                string[] temp = line.Split('#');
                listings[count] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], decimal.Parse(temp[4]), bool.Parse(temp[5]));
                count++;
                line = inFile.ReadLine();
            }
            Listing.SetCount(count);
            //CLOSE
            inFile.Close();
        }

        public void AddListing()
        {
            Listing newListing = new Listing();
            System.Console.WriteLine("Please enter the listing ID as a whole number: ");
            newListing.SetListingID(Listing.GetCount() + 1);

            System.Console.WriteLine("Please enter the trainer name: ");
            newListing.SetTrainerName(Console.ReadLine());

            System.Console.WriteLine("Please enter the session date (mm/dd/yyyy): ");
            newListing.SetSessionDate(Console.ReadLine());

            System.Console.WriteLine("Please enter the session time (hh:mm): ");
            newListing.SetSessionTime(Console.ReadLine());

            System.Console.WriteLine("Please enter the session cost (as a decimal): ");
            newListing.SetSessionCost(decimal.Parse(Console.ReadLine()));

            System.Console.WriteLine("Listing is avaliable");
            newListing.SetIsTaken(false);

            //it has to know what to look like in order to be a ox
            listings[Listing.GetCount()] = newListing;
            System.Console.WriteLine("Listing successfully added.");

            Listing.IncCount();

            Save();
            System.Console.WriteLine($"Listing {newListing.GetListingID()} is avaliable.");
        }
        public void EditListing()//Listing[] listings)
        {
            System.Console.Write("Enter the listing to update: ");
            string searchVal = Console.ReadLine();
            int foundIndex = FindListing(searchVal);

            if (foundIndex != -1)
            {
                System.Console.WriteLine("Enter the trainer name for the listing ");
                listings[foundIndex].SetTrainerName(Console.ReadLine());

                System.Console.Write("Enter the session date (mm/dd/yy): ");
                listings[foundIndex].SetSessionDate(Console.ReadLine());

                System.Console.Write("Enter the session time (hh:mm): ");
                listings[foundIndex].SetSessionTime(Console.ReadLine());

                System.Console.WriteLine("Enter the session cost ($$$.$$)");
                listings[foundIndex].SetSessionCost(decimal.Parse(Console.ReadLine()));

                System.Console.WriteLine("Select 1 if the session has been taken or 2 if the session is avaliable");
                int choice = int.Parse(Console.ReadLine());
                while (choice != 1 && choice != 2)
                {
                    System.Console.WriteLine("Invalid choice. Please enter 1 or 2");
                    choice = int.Parse(Console.ReadLine());
                }
                if (choice == 1)
                {
                    listings[foundIndex].SetIsTaken(true);
                }
                else if (choice == 2)
                {
                    listings[foundIndex].SetIsTaken(false);
                }
            }
            System.Console.WriteLine($"You've successfully update listing {searchVal}");
            PauseAction();

            Save();
        }
        public void DeleteListing()
        {
            //find the listing to delete 
            System.Console.WriteLine("What is the ID of the listing you want to delete?");
            string searchVal = Console.ReadLine();
            int foundIndex = FindListing(searchVal); //returns the index of the trainer array that has that id

            if (foundIndex != -1) //if found 
            {
                System.Console.WriteLine($"Are you sure you want to delete listing {searchVal} (y/n)?");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    for (int j = foundIndex; j < Listing.GetCount() - 1; j++) //from position to n-1
                    {
                        listings[j] = listings[j + 1];
                    }

                    Listing.DecCount();
                }
                else if (choice == "n") { return; }

            }
            else System.Console.WriteLine("Trainer ID not found.");

            Save();
        }
        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listing.txt");

            for (int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();

        }
        //returns the index of interest
        private int FindListing(string searchVal)
        {
            for (int i = 0; i < Listing.GetCount(); i++)
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
        public Listing FindListingByID(string listingId)
        {
            return listings[FindListing(listingId)];
        }

        //updates the status of the listing to "taken"
        public void MarkListingAsTaken(string selectedListing)
        {
            //returns the object 
            FindListingByID(selectedListing).SetIsTaken(true);

            Save();
        }

        public void MarkListingAsCancelled(string selectedListing)
        {
            //returns the object 
            FindListingByID(selectedListing).SetIsTaken(false);
            System.Console.WriteLine(" MarkListingAsCancelled() method");
            Save();
        }

        public void GetAvailableListings(Listing[] listings)
        {
            System.Console.WriteLine("Available listings..");
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                if (listings[i].GetIsTaken() == false)
                {
                    System.Console.WriteLine(listings[i].ToListingString());
                }

            }
        }

        public void PauseAction()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

    }


}

