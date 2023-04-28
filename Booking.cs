namespace mis_221_pa_5_srjohnson16
{
    public class Booking
    {
        private int sessionID;
        private string trainerID;
        private string listingID;
        private string customerName;
        private string customerEmail;
        private DateTime trainingDate;
        private string status;

        static int count = 0;

        public Booking()
        {

        }
        public Booking(string trainerID, string listingID, string customerEmail, string customerName)
        {
            this.sessionID = count;
            count += 1;
            DateTime today = DateTime.Now;
            this.trainingDate = today;
            this.trainerID = trainerID;
            this.listingID = listingID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
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
        public string ToSessionFile()
        {
            return $"{sessionID}#{GetCustomerName()}#{GetCustomerEmail()}#{trainingDate.ToString("yyyy-MM-dd HH:mm:ss")}";
        }
    }
}
