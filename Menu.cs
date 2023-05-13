namespace mis_221_pa_5_srjohnson16
{
    public class Menu
    {

        private static int MAX_ARRAY_SIZE = 100;
        static private Trainer[] trainers = new Trainer[MAX_ARRAY_SIZE];
        static private TrainerUtility tUtility = new TrainerUtility(trainers);

        static private Listing[] listings = new Listing[100];
        static private ListingUtility lUtility = new ListingUtility(listings);

        static private Booking[] sessions = new Booking[MAX_ARRAY_SIZE];
        static private BookingUtility bUtility = new BookingUtility(sessions, 100, lUtility, listings);

        // private Report[] reports = new Report[MAX_ARRAY_SIZE];

        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("\n\n\n\n\n");

                Console.Write(new string(' ', (Console.WindowWidth - "Welcome to Train Like A Champion. Please choose an option".Length) / 2));
                Console.WriteLine("Welcome to Train Like A Champion. Please choose an option");

                Console.Write(new string(' ', (Console.WindowWidth - "1. Manage trainer data".Length) / 2));
                Console.WriteLine("1. Manage trainer data");

                Console.Write(new string(' ', (Console.WindowWidth - "2. Manage listing data".Length) / 2));
                Console.WriteLine("2. Manage listing data");

                Console.Write(new string(' ', (Console.WindowWidth - "3. Manage customer booking data".Length) / 2));
                Console.WriteLine("3. Manage customer booking data");

                Console.Write(new string(' ', (Console.WindowWidth - "4. Run reports".Length) / 2));
                Console.WriteLine("4. Run reports");

                Console.Write(new string(' ', (Console.WindowWidth - "5. Exit the application".Length) / 2));
                Console.WriteLine("5. Exit the application");

                Console.Write(new string(' ', (Console.WindowWidth - "Enter your choice: ".Length) / 2));
                Console.Write("Enter your choice: ");
                string choiceStr = Console.ReadLine();
                if (int.TryParse(choiceStr, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            trainerMenu();
                            break;
                        case 2:
                            listingMenu();
                            break;
                        case 3:
                            bookingMenu();
                            break;
                        case 4:
                            reportMenu();
                            break;
                        case 5:
                            //exit
                            return;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                else
                {
                    // Console.Write(new string(' ', (Console.WindowWidth - "Invalid input!".Length) / 2));
                    Console.WriteLine("Invalid input!");
                }

            }
        }
        static void listingMenu()
        {
            //? Should populate the listings array
            lUtility.InitListing();
            //? Should only show avaliable listings 
            lUtility.GetAvailableListings(listings);


            Console.WriteLine("\n\n");
            Console.WriteLine("1. Add Listing");
            Console.WriteLine("2. Edit Lisitng");
            Console.WriteLine("3. Delete Listing");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            string choiceStr = Console.ReadLine();                    //TODO Undo comment
                                                                      //  string choiceStr = "1";
            if (int.TryParse(choiceStr, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        //add listing
                        lUtility.AddListing();
                        break;

                    case 2:
                        //edit listing 
                        lUtility.EditListing();
                        break;
                    case 3:
                        //delete listing
                        lUtility.DeleteListing();
                        break;
                    case 4:
                        //exit
                        return;
                    default:
                        // Console.Write(new string(' ', (Console.WindowWidth - "Invalid choice!".Length) / 2));
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            else
            {
                // Console.Write(new string(' ', (Console.WindowWidth - "Invalid input!".Length) / 2));
                Console.WriteLine("Invalid input!");
            }

        }

        static void trainerMenu()
        {
            Console.Clear();

            tUtility.InitTrainers();
            tUtility.GetTrainers();
            Console.WriteLine("\n\n");
            Console.WriteLine("1. Add trainer");
            Console.WriteLine("2. Edit trainer");
            Console.WriteLine("3. Delete trainer");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            string choiceStr = Console.ReadLine();                    //TODO Undo comment
                                                                      //  string choiceStr = "1";
            if (int.TryParse(choiceStr, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        //add trainer
                        tUtility.AddTrainer();

                        break;

                    case 2:
                        tUtility.EditTrainer();
                        break;
                    case 3:
                        //delete trainer
                        tUtility.DeleteTrainer();
                        break;
                    case 4:
                        //exit
                        return;

                    default:
                        Console.Write(new string(' ', (Console.WindowWidth - "Invalid choice!".Length) / 2));
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            else
            {
                // Console.Write(new string(' ', (Console.WindowWidth - "Invalid input!".Length) / 2));
                Console.WriteLine("Invalid input!");
            }
        }

        static void bookingMenu()
        {
            Console.Clear();
            //1. Show avaliable listings
            //? Should populate the listings array
            lUtility.InitListing();
            //? Should only show avaliable listings 
            lUtility.GetAvailableListings(listings);

            Console.WriteLine("\n\n");
            Console.WriteLine("1. Book Session");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");
            string choiceStr = Console.ReadLine();

            if (int.TryParse(choiceStr, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        bUtility.AddBooking();

                        break;
                    case 2:
                        //  bUtility.EditBooking();
                        break;
                    case 3:
                        //   bUtility.CancelBooking();

                        break;
                    case 4:
                        return;

                    default:
                        // Console.Write(new string(' ', (Console.WindowWidth - "Invalid choice!".Length) / 2));
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            else
            {
                // Console.Write(new string(' ', (Console.WindowWidth - "Invalid input!".Length) / 2));
                Console.WriteLine("Invalid input!");
            }

        }
        static void reportMenu()
        {

            //Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("1. View Customer Sessions");
            Console.WriteLine("2. View All Customer Sessions sorted by date");
            Console.WriteLine("3. View Montly Revenue Report");
            Console.WriteLine("4. View Yearly Revenue Report");
            Console.WriteLine("5. Back To Main Menu");
            Console.Write("Enter your choice: ");

            string choiceStr = Console.ReadLine();

            if (int.TryParse(choiceStr, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        //add trainer
                        //Report.CustomerSessions();
                        break;
                    case 2:
                        //Report.CustomerSessByDate();
                        break;
                    case 3:
                        //Report.MontlyRevenue();
                        //todo: Quarterly revenue
                        break;
                    case 4:
                        //Reprt.YearlyRevenue();
                        break;
                    case 5:
                        return;

                    default:
                        // Console.Write(new string(' ', (Console.WindowWidth - "Invalid choice!".Length) / 2));
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            else
            {
                // Console.Write(new string(' ', (Console.WindowWidth - "Invalid input!".Length) / 2));
                Console.WriteLine("Invalid input!");
            }
        }
    }
}












































