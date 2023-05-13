namespace mis_221_pa_5_srjohnson16
{
    public class Booking
    {
        private int sessionID;
        private int trainerID;
        private string trainerName;
        private string customerName;
        private string customerEmail;
        private DateTime bookedTrainingDate = DateTime.Now;
        private string sessionStatus = "";
        static private int count = 0;

        static public void SetCount(int count)
        {
            Booking.count = count;
        }
        static public int GetCount()
        {
            return count;
        }
        static public void IncCount()
        {
            Booking.count++;
        }
        public Booking()
        {

        }
        public Booking(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, string sessionStatus)
        {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.sessionStatus = sessionStatus;

        }
        public int GetSessionID()
        {
            return sessionID;
        }
        public void SetSessionID(int sessionID)
        {
            this.sessionID = sessionID;
        }
        public string GetCustomerName()
        {
            return customerName;
        }
        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerEmail()
        {
            return customerEmail;
        }
        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }
        static public void SetSessionCount(int count)
        {
            Booking.count = count;
        }
        static public void DecSessionCount()
        {
            Booking.count--;
        }
        static public void IncSessionCount()
        {
            Booking.count++;
        }
        static public int GetSessionCount()
        {
            return Booking.count;
        }

        public DateTime GetTrainingDate()
        {
            return trainingDate;
        }

        public void SetTrainingDate(string triainingDate)
        {
            this.trainingDate = trainingDate;
        }

        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }
        public int GetTrainingID()
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

        public void SetSessionStatus(string sessionStatus)
        {
            this.sessionStatus = sessionStatus;
        }

        public string GetSessionStatus()
        {
            return sessionStatus;
        }

        public string ToSessionFile()
        {
            return $"{sessionID}#{customerName}#{customerEmail}#{this.bookedTrainingDate}#{trainerID}#{trainerName}#{sessionStatus}";
        }


    }
}
