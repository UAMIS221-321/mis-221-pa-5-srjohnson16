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
        private static Report reports = new Report(sessions);

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

            string choiceStr = Console.ReadLine();
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

            //? Should only show avaliable listings 
            //  lUtility.GetAvailableListings(listings);
            lUtility.InitListing();
            bUtility.InitSessions();


            Console.WriteLine("\n\n");
            Console.WriteLine("1. View Avaliable Bookings");
            Console.WriteLine("2. Book a Session");
            Console.WriteLine("3. Cancel Session");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");
            string choiceStr = Console.ReadLine();

            if (int.TryParse(choiceStr, out int choice))
            {
                switch (choice)
                {
                    case 1:

                        bUtility.PrintAvailableSessions(listings);
                        System.Console.WriteLine("Enter any key to continue.");
                        Console.ReadKey();

                        break;
                    case 2:
                        lUtility.GetAvailableListings(listings);
                        bUtility.AddBooking();
                        return;
                    case 3:
                        bUtility.CancelBooking();
                        System.Console.WriteLine("Enter any key to continue.");
                        Console.ReadKey();


                        break;
                    case 4:
                        return;

                    default:
                        Console.Write(new string(' ', (Console.WindowWidth - "Invalid choice!".Length) / 2));
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            else
            {
                Console.Write(new string(' ', (Console.WindowWidth - "Invalid input!".Length) / 2));
                Console.WriteLine("Invalid input!");
            }

        }
        static void reportMenu()
        {

            Console.Clear();
            bUtility.InitSessions();
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
                        System.Console.WriteLine("No function");
                        System.Console.WriteLine("Enter any key to continue.");
                        Console.ReadKey();

                        break;
                    case 2:

                        bUtility.InitSessions();
                        reports.HistoricalCustomerSessions();
                        System.Console.WriteLine("Enter any key to continue.");
                        Console.ReadKey();
                        break;
                    case 3:
                        System.Console.WriteLine("No function");

                        System.Console.WriteLine("Enter any key to continue.");
                        Console.ReadKey();


                        break;
                    case 4:
                        System.Console.WriteLine("No function");

                        System.Console.WriteLine("Enter any key to continue.");
                        Console.ReadKey();

                        break;
                    case 5:
                        return;

                    default:
                        Console.Write(new string(' ', (Console.WindowWidth - "Invalid choice!".Length) / 2));
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            else
            {
                Console.Write(new string(' ', (Console.WindowWidth - "Invalid input!".Length) / 2));
                Console.WriteLine("Invalid input!");
            }
        }
    }
}












































