namespace mis_221_pa_5_srjohnson16
{
    public class Listing
    {
        //instance variables
        private int listingID;
        private string trainerName;
        private string customerName; 
        private string sessionDate;
        private string sessionTime;
        private string sessionCost;
        private bool isTaken = false;
        static private int idCounter = 0;

        public Listing()
        {

        }

        public Listing(string trainerName, string sessionDate, string sessionTime, string sessionCost, bool isTaken)
        {
            this.listingID = idCounter;
            idCounter += 1;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.isTaken = isTaken;
        }
        public void SetListingID(int listingID)
        {
            this.listingID = listingID;
        }
        public int GetListingID()
        {
            return listingID;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetSessionDate(string sessionDate)
        {
            this.sessionDate = sessionDate;
        }
        public string GetSessionDate()
        {
            return sessionDate;
        }
        public void SetSessionTime(string sessionTime)
        {
            this.sessionTime = sessionTime;
        }
        public string GetSessionTime()
        {
            return sessionTime;
        }
        public void SetSessionCost(string sessionCost)
        {
            this.sessionCost = sessionCost;
        }
        public string GetSessionCost()
        {
            return sessionCost;
        }
        public void SetIsTaken(bool isTaken)
        {
            this.isTaken = isTaken;
        }
        public bool GetIsTaken()
        {
            return isTaken;
        }
        static public void SetIDCount(int idCounter)
        {
            Listing.idCounter = idCounter;
        }
        static public void DecIDCount()
        {
            Listing.idCounter--;
        }
        static public void IncIDCount()
        {
            Listing.idCounter++;
        }
        static public int GetIDCount()
        {
            return Listing.idCounter;
        }

        public string ToFile()
        {
            return $"{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{isTaken}";
        }
        
        public string ToListingString()
        {
            return $"Listing ID: {listingID}\tTrainer name: {trainerName}\tSession Date: {sessionDate}\tSession Time: {sessionTime}\tCost of session ${sessionCost}";
        }

    }
}

//only display the avaliable movies