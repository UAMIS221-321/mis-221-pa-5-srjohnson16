namespace mis_221_pa_5_srjohnson16
{
    public class Trainer
    {
        //fields
        int trainerID;
        string name = "";
        string address = "";
        string email = "";
        static private int idCounter = 0;

        //constructor
        public Trainer()
        {

        }
        public Trainer(string name, string address, string email)
        {
            this.trainerID = idCounter;
            idCounter += 1;
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
            Trainer.idCounter = idCounter;
        }
        static public void DecCount()
        {
            Trainer.idCounter--;
        }
        static public void IncCount()
        {
            Trainer.idCounter++;
        }


        public override string ToString()
        {
            return $"Trainer: {idCounter}| Name: {name}| Address: {address}| Email: {email}";
        }
        public string ToFile()
        {
            return $"{name}#{address}#{email}";
        }

    }
}