using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Data
{
    public class DbInitializer
    {

        private readonly uMalusiContext _context;

        public DbInitializer(uMalusiContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (!_context.LivestockTypes.Any())
            {
                var llivestockType = new LivestockType();
                llivestockType.Description = "Cow";
                _context.LivestockTypes.Add(llivestockType);

                llivestockType = new LivestockType();
                llivestockType.Description = "Sheep";
                _context.LivestockTypes.Add(llivestockType);

                llivestockType = new LivestockType();
                llivestockType.Description = "Goat";
                _context.LivestockTypes.Add(llivestockType);

                _context.SaveChanges();
            }

            if (!_context.Farmers.Any())
            {

                var farmer = new Farmer();
                farmer.Names = "Sino";
                farmer.Surname = "Asiphe";
                farmer.Username = "Sino";
                farmer.Password = "pass123";

                var tracker = new Tracker();
                tracker.Description = "tk002";
                _context.Trackers.Add(tracker);

  




                var livestock = new Livestock();
                livestock.Name = "Cow1";
                livestock.DOB = "12/11/2019";
                livestock.LivestockTypeId = 1;
                livestock.Color = "Black&White";
                livestock.Tracker = tracker; 
                //livestock.Image = """";

                var userAccount = new Authentication();
                userAccount.Username = "Sino";
                userAccount.Password = "pass123";

                tracker = new Tracker();
                tracker.Description = "tk001";
                _context.Trackers.Add(tracker);

                farmer.Livestocks = new List<Livestock>();
                farmer.Livestocks.Add(livestock);

                farmer.Authentication = userAccount;


                _context.Farmers.Add(farmer);
                _context.Farmers.Add(farmer);
                _context.Authentications.Add(userAccount);
                _context.SaveChanges();
            }
        }
    }
}
