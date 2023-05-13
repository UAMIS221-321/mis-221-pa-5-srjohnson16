namespace mis_221_pa_5_srjohnson16
{
    public class TrainerUtility
    {
        private Trainer[] trainers;
        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }
        public TrainerUtility()
        { }


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

        public Trainer[] InitTrainers()
        {
            System.Console.WriteLine("Getting trainers from file...");
            StreamReader inFile = new StreamReader("trainer.txt");
            string line = inFile.ReadLine();
            Trainer.SetCount(0);
            int count = 0;
            while (line != null && line != "")
            {
                string[] temp = line.Split('#'); //[0,1,2,3]
                trainers[count] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                count++;
                line = inFile.ReadLine();
            }
            Trainer.SetCount(count);
            //close
            inFile.Close();

            return trainers;
        }
        public void AddTrainer()
        {
            Trainer newTrainer = new Trainer();
         //   System.Console.WriteLine("Please enter the trainer ID");
            newTrainer.SetID(Trainer.GetCount() + 1);

            //!! SET TRAINER ID

            System.Console.WriteLine("Please enter the trainer name");
            newTrainer.SetName(Console.ReadLine());

            System.Console.WriteLine("Please enter the trainer address");
            newTrainer.SetAddress(Console.ReadLine());

            System.Console.WriteLine("Please enter the trainer email");
            newTrainer.SetEmail(Console.ReadLine());

            trainers[Trainer.GetCount()] = newTrainer;
            System.Console.WriteLine("Trainer successfully added.");
            Trainer.IncCount();
            Save();

        }
        public void EditTrainer()
        {
            System.Console.WriteLine("What is the ID of the trainer you want to update");
            string searchVal = Console.ReadLine();
            int foundIndex = FindTrainer(searchVal);

            //todo display trainer infomation?
            //todo what would you like to update?
            //todo update that specific element

            if (foundIndex != -1)
            {
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
        public void DeleteTrainer()
        {
            //find the trainer to delete based on trainer id,name,email,address
            System.Console.WriteLine("What is the ID of the trainer you want to delete?");
            string searchVal = Console.ReadLine();

            int foundIndex = FindTrainer(searchVal); //returns the index of the trainer array that has that id

            if (foundIndex != -1) //if found 
            {
                for (int j = foundIndex; j < Trainer.GetCount()- 1; j++) //from position to n-1
                {
                    trainers[j] = trainers[j + 1];
                }
            }
            else System.Console.WriteLine("Trainer ID not found.");

            Trainer.DecCount();
            Save();
        }
        private int FindTrainer(string searchVal)
        {
            //loops through array to see if elements match
            for (int i = 0; i < Trainer.GetCount(); i++)
            {
                if (trainers[i].GetID() == int.Parse(searchVal))
                {
                    System.Console.WriteLine("Trainer found..");                        //!Delete
                    return i;
                }
            }
            return -1;
        }
        private void Save()
        {
            System.Console.WriteLine("Saving to file...");
            //open
            StreamWriter outFile = new StreamWriter("trainer.txt");

            //process
            for (int i = 0; i <Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].ToTrainerFile());
            }

            //close 
            outFile.Close();
        }
        public void GetTrainers()
        {
            Thread.Sleep(1000);
            System.Console.WriteLine("Available Trainers..");

            for (int i = 0; i < Trainer.GetCount(); i++)
            {

                System.Console.WriteLine(trainers[i].ToString());
            }
        }

        public Trainer FindTrainerById(string trainerID)
        {
            return trainers[FindTrainer(trainerID)];
        }


    }
}
