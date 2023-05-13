namespace mis_221_pa_5_srjohnson16
{
    public class Listing
    {
        //instance variables
        private int listingID;
        private int trainerID;
        private string trainerName;
        private string sessionDate;
        private string sessionTime;
        private decimal sessionCost;
        private bool isTaken = false;
        private bool isNotAvail = false;
        static private int count = 0;
        public Listing()
        {

        }
        public Listing(int listingID, string trainerName, string sessionDate, string sessionTime, decimal sessionCost, bool isTaken)
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.isTaken = isTaken;

        }
        public void SetListingID(int listingID)
        {
            this.listingID = count++;
        }
        public int GetListingID()
        {
            return listingID;
        }
        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }
        public int GetTrainerID()
        {
            return trainerID;
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
        public void SetSessionCost(decimal sessionCost)
        {
            this.sessionCost = sessionCost;
        }
        public decimal GetSessionCost()
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
        public void SetIsNotAvail(bool isNotAvail)
        {
            this.isNotAvail = isNotAvail;
        }
        public bool GetIsNotAvail()
        {
            return isTaken;
        }
        static public void SetCount(int count)
        {
            Listing.count = count;
        }
        static public void DecCount()
        {
            Listing.count--;
        }
        static public void IncCount()
        {
            Listing.count++;
        }
        static public int GetCount()
        {
            return Listing.count;
        }
        public string ToFile()
        {
            return $"{listingID}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{isTaken}";
        }
        public string ToListingString()
        {
            string stat = "";
            if (isTaken == true)
            {
                stat = "Not Availiable";
            }
            else if (isTaken == false)
            {
                stat = "Availiable";
            }
            return $"Listing ID: {listingID} \tTrainer name: {trainerName} \tSession Date: {sessionDate} \tSession Time: {sessionTime} \tCost of session ${sessionCost}\tStatus: {stat}";
        }
    }
}
