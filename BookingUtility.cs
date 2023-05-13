

namespace mis_221_pa_5_srjohnson16
{
    public class BookingUtility
    {
        private Booking[] sessions;
        private Listing[] listings;

        private int MAX_SESSIONS;
        private ListingUtility listingUtility = new ListingUtility();


        public BookingUtility(Booking[] sessions, int MAX_SESSIONS, ListingUtility listingUtility, Listing[] listings)
        {
            this.listings = listings;
            this.sessions = sessions;
            this.MAX_SESSIONS = MAX_SESSIONS;
            this.listingUtility = listingUtility;
        }
        public BookingUtility() { }
        public BookingUtility(Listing[] listings)
        {
            this.listings = listings;
        }

        // public void InitSessions()
        // {
        //     //open
        //     StreamReader inFile = new StreamReader("transactions.txt");
        //     //process
        //     string line = inFile.ReadLine();
        //     Booking.SetCount(0);
        //     int count = 0;
        //     while (line != null)
        //     {
        //         System.Console.WriteLine("Line" + line);
        //         string[] temp = line.Split('#');
        //         sessions[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
        //         count++;
        //         line = inFile.ReadLine();
        //     }
        //     Booking.SetCount(count);
        //     //write sessions to file
        //     for (int i = 0; i < Booking.GetCount(); i++)
        //     {
        //         System.Console.WriteLine($"{sessions[i].ToSessionFile()}");
        //     }
        //     //close
        //     inFile.Close();
        // }
        //a booking object that accepts a listing array. Prints avaliable listing to screen
        public void PrintAvailableSessions(Listing[] listings)
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

        // public Listing GetSelectedListing(int listingID)
        // {
        //     StreamReader inFile = new StreamReader("listings.txt");
        //     string line = inFile.ReadLine();
        //     while (line != null)
        //     {
        //         string[] temp = line.Split('#');
        //         if (int.Parse(temp[0]) == listingID)
        //         {
        //             inFile.Close();
        //             return new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), bool.Parse(temp[5]));
        //         }
        //         line = inFile.ReadLine();
        //     }
        //     inFile.Close();
        //     return null;
        // }
        public Listing FindListingByID(string listingId)
        {
            // Listing[] foundListing = listings[FindListing(listingId)];
            return listings[FindListing(listingId)];
        }
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
        // public void MarkSessionAsTaken(string selectedListing)
        // {
        //     //returns the object 
        //     FindSessionById(selectedListing).SetIsTaken(true);

        //     SaveSession();
        // }



        public void AddBooking()
        {
            try
            {
            //1. View avaliable sessios
            BookingUtility bookingUtility = new BookingUtility(listings);

            Booking newSession = new Booking();
            Console.Write("Enter the listing ID of the session you would like to book: ");
            string selectedListingID = Console.ReadLine();

            Listing selectedListing = bookingUtility.FindListingByID(selectedListingID);
            //public Booking(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, string sessionStatus)

            newSession.SetSessionID(Booking.GetCount() + 1);  //assigns listing ID
            System.Console.Write("Please enter your name:");
            newSession.SetCustomerName(Console.ReadLine());

            System.Console.Write("Please enter your email address: ");
            newSession.SetCustomerEmail(Console.ReadLine());

          //  newSession.SetTrainingDate(listings[int.Parse(selectedListingID)].GetSessionDate());
            newSession.SetTrainerID(listings[int.Parse(selectedListingID)].GetTrainerID());
            newSession.SetTrainerName(listings[int.Parse(selectedListingID)].GetTrainerName());
            newSession.SetSessionStatus("Booked");

            sessions[Booking.GetCount()] = newSession;
            System.Console.WriteLine("Booking successfully added.");

            Booking.IncCount();
            SaveSession();
            Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        private void SaveSession()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for (int i = 0; i < Booking.GetSessionCount(); i++)
            {
                outFile.WriteLine(sessions[i].ToSessionFile());
            }
            outFile.Close();
        }


    }

}




// public static void AddBooking(Listing[] listings, Trainer[] trainers)
// {
//     //Listing listing = new Listing() {};
//     int countAvail = 0;

//     availableListings = GetAvailableListings(ref countAvail, listings);
//     PrintAvailableListingsForUser(availableListings, countAvail);
//     // Get selected listing ID from user
//     System.Console.Write("Please enter the ID of the listing you want to book: ");
//     string selectedListingID = Console.ReadLine();
//     // Find selected listing object
//     Listing selectedListing = ListingUtility.FindListingById(selectedListingID);
//     ListingUtility.MarkListingAsTaken(selectedListingID);

//     Booking newSession = new Booking() { };
//     newSession.SetSessionID(ListingUtility.GetCount());
//     System.Console.Write("Please enter your name:");
//     newSession.SetCustomerName(Console.ReadLine());

//     System.Console.Write("Please enter your email address: ");
//     newSession.SetCustomerEmail(Console.ReadLine());

//     //   newSession.SetTrainingDate(listings[int.Parse(selectedListingID)].GetSessionDate());
//     newSession.SetTrainerID(listings[int.Parse(selectedListingID)].GetTrainerID());
//     newSession.SetTrainerName(listings[int.Parse(selectedListingID)].GetTrainerName());
//     newSession.SetSessionStatus("Booked");

//     //it has to know what to look like in order to be a ox
//     sessions[Booking.GetSessionCount()] = newSession;
//     Booking.IncSessionCount();
//     Booking.IncCount();
//     // Mark listing as taken
//     System.Console.WriteLine($"You've successfully booked {selectedListingID}");

//     // Save booking to transaction file
//     BookingUtility.SaveSession();
// }


// private static void SaveSession()
// {
//     StreamWriter outFile = new StreamWriter("transactions.txt");
//     for (int i = 0; i < Booking.GetSessionCount(); i++)
//     {
//         outFile.WriteLine(sessions[i].ToSessionFile());
//     }
//     outFile.Close();
// }

// static public void PrintAvailableListingsForUser(Listing[] availableListings, int countAvail)
// {
//     for (int i = 0; i < countAvail; i++)
//     {
//         System.Console.WriteLine(availableListings[i].ToListingString());
//     }
// }


//     }
// }
/*
 bool isTaken = false;
            DateTime today = DateTime.Today;
            int sessionID = 20;
            Customer customer = new Customer();
            System.Console.Write("Please enter your name: ");
            customer.SetName(Console.ReadLine());
            System.Console.Write("Please enter your email address: ");
            customer.SetEmail(Console.ReadLine());

            System.Console.WriteLine($"Session ID: {sessionID} was booked by {customer.GetName()} email({customer.GetEmail()}) on {today}");


*/






// private static int MAX_ARRAY_SIZE = 100;
// private static Trainer[] trainers = new Trainer[MAX_ARRAY_SIZE];
// private static Listing[] listings = new Listing[MAX_ARRAY_SIZE];
// private static Booking[] sessions = new Booking[MAX_ARRAY_SIZE];        static int countAvail = 0; 
// public static void SetAvailCount(int countAvail)
// {
//     BookingUtility.countAvail = countAvail;
// }
// public static int GetAvailCount()
// {
//     return countAvail;
// }
// public static void AddBooking(Trainer[] trainers, Listing[] listings)
// {
//     Listing[] availableListings = ListingUtility.GetAvailableListings(ref countAvail);

//     PrintAvailableListingsForUser(availableListings, countAvail);

//     Booking newSession = new Booking();
//     System.Console.Write("Please enter your name:");
//     newSession.SetCustomerName(Console.ReadLine());

//     System.Console.Write("Please enter your email address: ");
//     newSession.SetCustomerEmail(Console.ReadLine());

//     System.Console.WriteLine("Enter the session id");
//     newSession.SetSessionID(int.Parse(Console.ReadLine()));

//     //it has to know what to look like in order to be a ox
//     sessions[Booking.GetSessionCount()] = newSession;
//     System.Console.WriteLine("Session successfully booked");

//     Booking newBooking = new Booking(trainers[0].GetName(), selectedListingI, newSession.GetCustomerName(), newSession.GetCustomerEmail());

//     Booking.IncSessionCount();

//     //save


//     // DateTime today = DateTime.Today;
//     // DateTime.Now.ToString("dd/MM/yyyy");



//     // todo: tell user to print id of listing that they want
//     System.Console.WriteLine("Enter the Id of the listing you want");

//     string selectedListingI = Console.ReadLine();

//     Listing selectedListing = ListingUtility.FindListingById(selectedListingI);
//     ListingUtility.MarkListingAsTaken(selectedListingI);



//     // maark listing as taken
//     System.Console.WriteLine($"You've successfully book {selectedListingI}");

//     BookingUtility.SaveSession();
// }
