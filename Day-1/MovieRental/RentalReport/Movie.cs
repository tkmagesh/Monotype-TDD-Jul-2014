namespace RentalReport
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        IMoviePricingStrategy _pricingStrategy;

        string _title;
        int _priceCode;

        public Movie(string title,IMoviePricingStrategy pricingStrategy)
        {
            _title = title;
            //_priceCode = priceCode;
            _pricingStrategy = pricingStrategy;
        }

        public int PriceCode
        {
            get { return _priceCode; }
            set { _priceCode = value;}
        }

        public string Title
        {
            get { return _title; }
        }
        public double GetAmount(int daysRented) {
            return _pricingStrategy.GetAmount(daysRented);
        }

        public int GetFrequentPoints(int DaysRented)
        {
            if ((PriceCode == Movie.NEW_RELEASE) && DaysRented > 1)
                return 2;
            return 1;

        }
    }

    public class NewReleaseMoviePricingStrategy : IMoviePricingStrategy
    {

        public double GetAmount(int daysRented)
        {
            return daysRented * 3;
        }
    }

    public class ChildrenMoviePricingStrategy : IMoviePricingStrategy
    {
        public double GetAmount(int daysRented)
        {
            double thisAmount = 1.5;
            if (daysRented > 3)
                thisAmount += (daysRented - 3) * 1.5;
            return thisAmount;
        }
    }

    public class RegularMoviePricingStrategy : IMoviePricingStrategy
    {
        public double GetAmount(int daysRented)
        {
            double thisAmount = 2;
            if (daysRented > 2)
                thisAmount += (daysRented - 2) * 1.5;
            return thisAmount;
        }
    }



    public interface IMoviePricingStrategy
    {
        double GetAmount(int daysRented);
    }
}