namespace mis_221_pa_5_srjohnson16
{
    public class TrainerUtility
    {
        private static int MAX_TRAINER_SIZE = 100;
        private static Trainer[] trainers = new Trainer[MAX_TRAINER_SIZE];
        //Methods
        private static int count = 0;

        public static int GetCount()
        {
            return count;
        }
        public static int IncCount()
        {
            return count++;
        }
        public static void SetCount(int count)
        {
            TrainerUtility.count = count;
        }

        public static void GetAllTrainers()
        {
            System.Console.WriteLine("Getting trainers from file...");

            StreamReader inFile = new StreamReader("trainer.txt");
            string line = inFile.ReadLine();
            TrainerUtility.SetCount(0);
            while (line != null && line != "")
            {
                string[] temp = line.Split('#'); //[0,1,2,3]

                trainers[TrainerUtility.GetCount()] = new Trainer(temp[0], temp[1], temp[2]);
                //count++;

                line = inFile.ReadLine();

                TrainerUtility.IncCount();
            }

            inFile.Close();
        }
        public static void AddTrainer()
        {
            Trainer newTrainer = new Trainer();
            System.Console.WriteLine("Please enter the trainer ID");
            newTrainer.SetID(int.Parse(Console.ReadLine()));

            System.Console.WriteLine("Please enter the trainer name");
            newTrainer.SetName(Console.ReadLine());

            System.Console.WriteLine("Please enter the trainer address");
            newTrainer.SetAddress(Console.ReadLine());

            System.Console.WriteLine("Please enter the trainer email");
            newTrainer.SetEmail(Console.ReadLine());

            trainers[count] = newTrainer;
            System.Console.WriteLine("Trainer successfully added.");

            Trainer.IncCount();

            Save();

        }
        public static void EditTrainer()
        {
            System.Console.WriteLine("What is the ID of the trainer you want to update");
            string searchVal = Console.ReadLine();
            int foundIndex = FindTrainer(searchVal);

            //todo display trainer infomation?
            //todo what would you like to update?
            //todo update that specific element

            if (foundIndex != -1)
            {
                System.Console.WriteLine("Enter the trainer's ID");
                trainers[foundIndex].SetID(int.Parse(Console.ReadLine()));

                System.Console.WriteLine("Enter the trainer name ");
                trainers[foundIndex].SetName(Console.ReadLine());

                System.Console.WriteLine("Enter the trainer's address");
                trainers[foundIndex].SetAddress(Console.ReadLine());

                System.Console.WriteLine("Enter the trainer's email");
                trainers[foundIndex].SetEmail(Console.ReadLine());
            }

            System.Console.WriteLine("Update successful.");
            Save();
        }
        public static void DeleteTrainer()
        {
            //find the trainer to delete based on trainer id,name,email,address
            System.Console.WriteLine("What is the ID of the trainer you want to delete?");
            string searchVal = Console.ReadLine();

            int foundIndex = FindTrainer(searchVal); //returns the index of the trainer array that has that id

            if (foundIndex != -1) //if found 
            {
                for (int j = foundIndex; j < count - 1; j++) //from position to n-1
                {
                    trainers[j] = trainers[j + 1];
                }
            }
            else System.Console.WriteLine("Trainer ID not found.");

            Trainer.DecCount();


            Save();
        }
        private static int FindTrainer(string searchVal)
        {
            //loops through array to see if elements match
            for (int i = 0; i < count; i++)
            {
                if (trainers[i].GetID() == int.Parse(searchVal))
                {
                    System.Console.WriteLine("Trainer found..");                        //!Delete
                    return i;
                }
            }
            return -1;
        }
        private static void Save()
        {
            System.Console.WriteLine("Saving to file...");
            //open
            StreamWriter outFile = new StreamWriter("trainer.txt");

            //process
            for (int i = 0; i < count; i++)
            {
                outFile.WriteLine(trainers[i].ToFile());
            }

            //close 
            outFile.Close();
        }

        public static Trainer[] GetTrainers()
        {
            return trainers;
        }
    }
}

//display list of avaliable trainers
//Ask user which trainer would they like to book 
//enter trainer id to book
//