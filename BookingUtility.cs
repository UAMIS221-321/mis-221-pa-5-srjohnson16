namespace mis_221_pa_5_srjohnson16
{
    public class BookingUtility
    {
        private static int MAX_ARRAY_SIZE = 100;
        private Trainer[] trainers = new Trainer[MAX_ARRAY_SIZE];
        private Listing[] listings = new Listing[MAX_ARRAY_SIZE];
        private static Booking[] sessions = new Booking[MAX_ARRAY_SIZE];

        static int countAvail = 0;

        public static void SetAvailCount(int countAvail)
        {
            BookingUtility.countAvail = countAvail;
        }
        public static int GetAvailCount()
        {
            return countAvail;
        }

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

        //     Booking newBooking = new Booking(trainers[0].GetName(), selectedListingId, newSession.GetCustomerName(), newSession.GetCustomerEmail());

        //     Booking.IncSessionCount();

        //     //save


        //     // DateTime today = DateTime.Today;
        //     // DateTime.Now.ToString("dd/MM/yyyy");



        //     // todo: tell user to print id of listing that they want
        //     System.Console.WriteLine("Enter the Id of the listing you want");

        //     string selectedListingId = Console.ReadLine();

        //     Listing selectedListing = ListingUtility.FindListingById(selectedListingId);
        //     ListingUtility.MarkListingAsTaken(selectedListingId);



        //     // maark listing as taken
        //     System.Console.WriteLine($"You've successfully book {selectedListingId}");

        //     BookingUtility.SaveSession();
        // }

        public static void AddBooking(Trainer[] trainers, Listing[] listings)
        {
            Booking newSession = new Booking();
            System.Console.Write("Please enter your name:");
            newSession.SetCustomerName(Console.ReadLine());

            System.Console.Write("Please enter your email address: ");
            newSession.SetCustomerEmail(Console.ReadLine());

            System.Console.WriteLine("Enter the session id");
            newSession.SetSessionID(int.Parse(Console.ReadLine()));

            //it has to know what to look like in order to be a ox
            sessions[Booking.GetSessionCount()] = newSession;
            System.Console.WriteLine("Session successfully booked");

            Booking.IncSessionCount();

            //save

            // Get available listings
            Listing[] availableListings = ListingUtility.GetAvailableListings(ref countAvail);

            // Print available listings
            PrintAvailableListingsForUser(availableListings, countAvail);

            // Get selected listing ID from user
            System.Console.WriteLine("Enter the Id of the listing you want");
            string selectedListingId = Console.ReadLine();

            // Find selected listing object
            Listing selectedListing = ListingUtility.FindListingById(selectedListingId);
            ListingUtility.MarkListingAsTaken(selectedListingId);

            // Get trainer name for selected listing
            string trainerName = "";
            foreach (Trainer trainer in trainers)
            {
                if (trainer.GetTrainerID() == selectedListing.GetTrainerID())
                {
                    trainerName = trainer.GetName();
                    break;
                }
            }

            // Create new booking object
            Booking newBooking = new Booking(selectedListingId, newSession.GetCustomerName(), newSession.GetCustomerEmail(), trainerName);

            // Mark listing as taken
            System.Console.WriteLine($"You've successfully booked {selectedListingId}");

            // Save booking to transaction file
            BookingUtility.SaveSession();
        }




        private static void SaveSession()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for (int i = 0; i < Booking.GetSessionCount(); i++)
            {
                outFile.WriteLine(sessions[i].ToSessionFile());
            }
            outFile.Close();
        }

        static public void PrintAvailableListingsForUser(Listing[] availableListings, int countAvail)
        {
            for (int i = 0; i < countAvail; i++)
            {
                System.Console.WriteLine(availableListings[i].ToListingString());
            }
        }

        internal static void AddBooking()
        {
            throw new NotImplementedException();
        }
    }
}











//DUMP
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