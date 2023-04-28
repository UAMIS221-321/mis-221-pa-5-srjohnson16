namespace mis_221_pa_5_srjohnson16
{
    public class Report
    {
        private static Trainer[] trainer;

        private static Listing[] listing;


        //reports
        public static void DisplayAllTrainers()
        {
            Trainer[] trainer = TrainerUtility.GetTrainers();

            for (int i = 0; i < TrainerUtility.GetCount(); i++)
            {
                System.Console.WriteLine(trainer[i].ToString());
            }
        }

        public static void DisplayAllListings()
        {
            Listing[] listings = ListingUtility.GetListings();

            for (int i = 0; i < ListingUtility.GetCount(); i++)
            {
                System.Console.WriteLine(listings[i].ToListingString());
            }

        }

        // public static void IndividualCustomerReport()
        // {
        //     Session[] session = Booking.

        //     Console.WriteLine("Enter email to view customer report");
        //     string searchEmail = Console.ReadLine();

        //     for
        // }

    }
}