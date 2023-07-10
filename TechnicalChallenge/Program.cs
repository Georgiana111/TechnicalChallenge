namespace TechnicalChallenge
{
    internal class Program
    {
        private const int Seconds = 130;

        static void Main(string[] args)
        {
            Console.WriteLine("User Id:");
            string userId = Console.ReadLine();
            Console.WriteLine("Date and time (MM/dd/yyyy hh:mm:ss tt):");
            string dateTime = Console.ReadLine();

            DateTime date;

            try
            {
                date = DateTime.Parse(dateTime);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date/time format. Please try again.");
                return;
            }

            string password = OTP.GeneratePassword(userId, date);
            Console.WriteLine("Generated Password: " + password);

            TimeSpan timeDifference = DateTime.Now - date;
            Console.WriteLine("Time Difference (seconds): " + timeDifference.TotalSeconds);

            if (timeDifference.TotalSeconds > Seconds)
            {
                Console.WriteLine("Password has expired. Generate a new password.");
                password = OTP.GeneratePassword(userId, DateTime.Now);
                Console.WriteLine("New Password: " + password);
            }
            else
            {
                Console.WriteLine("Password is still valid.");
            }
        }
    }
}
