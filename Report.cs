namespace mis_221_pa_5_srjohnson16
{
    public class Report
    {

        private Booking[] sessions;
        private Listing[] listings;
        private BookingUtility bookingUtility;

        public Report(BookingUtility bookingUtility)
        {
            this.bookingUtility = bookingUtility;
        }
        public Report(Booking[] sessions, Listing[] listings)
        {
            this.listings = listings;
            this.sessions = sessions;
        }
       public Report(Booking[] sessions)
        {
            this.listings = listings;
            this.sessions = sessions;
        }
        public void SortByEmailAndDate()
        {
            for (int i = 0; i < Booking.GetSessionCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Booking.GetSessionCount(); j++)
                {
                    int emailCompare = this.sessions[j].GetCustomerEmail().CompareTo(this.sessions[min].GetCustomerEmail());
                    if (emailCompare < 0 || (emailCompare == 0 && DateTime.Parse(this.sessions[j].GetTrainingDate()) < DateTime.Parse(this.sessions[min].GetTrainingDate())))
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i);
                }
            }
        }
        public void SortByEmail()
        {
            for (int i = 0; i < Booking.GetSessionCount() - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Booking.GetSessionCount(); j++)
                {
                    int emailCompare = this.sessions[j].GetCustomerEmail().CompareTo(this.sessions[min].GetCustomerEmail());
                    if (emailCompare < 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(min, i);
                }
            }
        }


        public void HistoricalCustomerSessions()
        {
            SortByEmailAndDate();
            System.Console.WriteLine($"Total booked sessions: {Booking.GetSessionCount()}");
            if (sessions == null || sessions.Length == 0)
            {
                System.Console.WriteLine("no sessions found.");
                return;
            }
            string currEmail = sessions[0].GetCustomerEmail();
            int count = 1;
            for (int i = 1; i < Booking.GetSessionCount(); i++)
            {

                if (sessions[i].GetCustomerEmail() == currEmail)
                {
                    count++;
                }
                else
                {
                    Thread.Sleep(1000);
                    ProcessBreak(ref currEmail, ref count, sessions, ref i);
                }
            }
            ProcessBreak(currEmail, count);
        }

        public void ProcessBreak(ref string currEmail, ref int count, Booking[] sessions, ref int index)
        {
            System.Console.WriteLine($"{currEmail} has {count} session(s)");
            currEmail = sessions[index].GetCustomerEmail();
            count = 1;
            Thread.Sleep(1000);

        }
        private void ProcessBreak(string currEmail, int count)
        {
            System.Console.WriteLine($"{currEmail} has {count} session(s)");

        }
        public void Swap(int x, int y)
        {
            Booking temp = sessions[x];
            sessions[x] = sessions[y];
            sessions[y] = temp;
        }

        public void IndividualCustomerSessions()
        {
            SortByEmail();
            System.Console.WriteLine("Please enter the email of the customer to view previous training sessions");

        }
        // private void SaveReport()
        // {
        //     StreamWriter outFile = new StreamWriter("historical.txt");
        //     for (int i = 0; i < Booking.GetSessionCount(); i++)
        //     {
        //         outFile.WriteLine(sessions[i].ToSessionFile());
        //     }
        //     outFile.Close();
        // }

        // public void RevenueByYear()
        // {
        //     string currYear = sessions[0].GetTrainingDate();
        //     decimal yearRevTotal = listings[0].GetSessionCost();

        //     System.Console.WriteLine();
        //     System.Console.WriteLine(currYear);

        //     for (int i = 1; i < Booking.GetCount(); i++)
        //     {
        //         if (currYear == sessions[i].GetTrainingDate() && sessions[i].GetSessionStatus() == "Booked")
        //         {
        //             revYearTotal += listings[i].GetSessionCost();
        //         }
        //         else ProcessYearBreak(ref revYearTotal, sessions[i], ref currYear);

        //     }
        //     ProcessYearBreak(currYear, revYearTotal);
        // }

        // public void ProcessYearBreak(ref int revYearTotal, Booking newBooking, Listing newList, ref int currYear)
        // {
        //     System.Console.WriteLine($"Yearly Revenue: ${revYearTotal}\n");
        //     yearRevTotal = newList.GetSessionCost();
        //     currYear = newBooking.GetTrainingDate();
        //     System.Console.WriteLine(currYear);
        // }

        // public void ProcessYearBreak(int currYear, int revYearTotal)
        // {
        //     System.Console.WriteLine($"Year {currYear} Revenue: ${revYearTotal}\n");
        // }


    }
}



