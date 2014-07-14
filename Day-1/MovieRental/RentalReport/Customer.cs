using System.Collections.Generic;

namespace RentalReport
{
    public class Customer
    {
        string _name;
        IList<Rental> _rentals = new List<Rental>();
        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Name
        {
            get { return _name; }
        }

        public string Statement()
        {
            var result = "Rental Record for " + Name + "\n";
            foreach(var rental in _rentals)
            {
                result += "\t" + rental.Movie.Title + "\t" + rental.GetAmount() + "\n";
            }
            result += "Amount owed is " + GetTotalAmount() + "\n";
            result += "You earned " + GetTotalFrequentRentalPoints() + " frequent renter points";

            return result;
        }
        public double GetTotalAmount() {
            double totalAmount = 0;
            foreach (var rental in _rentals)
            {
                totalAmount += rental.GetAmount();
            }
            return totalAmount;
        }
        public int GetTotalFrequentRentalPoints()
        {
            int frequentRentalPoints = 0;
            foreach (var rental in _rentals)
            {
                frequentRentalPoints += rental.GetFrequentPoints();
            }
            return frequentRentalPoints;
        }
    }
}