namespace mis_221_pa_5_srjohnson16
{
    public class Trainer
    {
        //fields
        int trainerID;
        string name = "";
        string address = "";
        string email = "";
        static private int count = 0;

        //constructor
        public Trainer()
        {

        }
        public Trainer(int trainerID, string name, string address, string email)
        {
            this.trainerID = count++;
            this.name = name;
            this.address = address;
            this.email = email;
        }
        //methods
        public void SetID(int trainerID)
        {
            this.trainerID = trainerID;
        }
        public int GetID()
        {
            return trainerID;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetAddress()
        {
            return address;
        }
        public void SetAddress(string address)
        {
            this.address = address;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        static public void SetCount(int idCounter)
        {
            Trainer.count = idCounter;
        }
        static public void DecCount()
        {
            Trainer.count--;
        }
        static public void IncCount()
        {
            Trainer.count++;
        }
        static public int GetCount() {
            return Trainer.count;
        }

        public override string ToString()
        {
            return $"Trainer: {trainerID}\t Name: {name}\t Address: {address}\t Email: {email}";
        }
        public string ToTrainerFile()
        {
            return $"{trainerID}#{name}#{address}#{email}";
        }

    }
}