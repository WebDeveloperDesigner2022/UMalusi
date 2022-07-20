using Microsoft.EntityFrameworkCore;
using UMelusiTrackApi.Interfaces;
using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Data
{
    public class uMalusiDbRepository : IuMalusiDbRepository
    {
        private uMalusiContext _uMalusiContext;     

        public uMalusiDbRepository(uMalusiContext uMalusiContext)
        {
            _uMalusiContext = uMalusiContext;
        }

        #region Farmer

        public Farmer CreateNewFarmer(Farmer farmer)
        {
            _uMalusiContext.Farmers.Add(farmer);
            _uMalusiContext.SaveChanges();

            return farmer;
        }

        public bool DoesFarmerExistById(int id)
        {
            return _uMalusiContext.Farmers.Any(farm => farm.FarmerId == id);
        }

        public bool DoesFarmerExistByUsername(string username)
        {
            return _uMalusiContext.Farmers.Any(farm => farm.Username == username);
        }

        public List<Farmer> GetAllFarmers(bool fullFetch = true)
        {
            if (fullFetch)
            {
                var farmers = _uMalusiContext.Farmers.Include(f => f.Livestocks).ToList();
                return farmers;
            }
            else
            {
                var farmers = _uMalusiContext.Farmers.ToList();
                return farmers;
            }
        }

        public Farmer GetFarmerById(int id, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var farmer = _uMalusiContext.Farmers.Where(x => x.FarmerId == id).Include(c => c.Livestocks).FirstOrDefault();
                return farmer;
            }
            else
            {
                var farmer = _uMalusiContext.Farmers.Where(x => x.FarmerId == id).FirstOrDefault();
                return farmer;
            }
        }

        /*  public Farmer GetFarmerByLastName(string surname, bool fullFetch = true)
          {
              if (fullFetch)
              {
                  var farmer = _uMalusiContext.Farmers.Where(x => x.Surname.Contains(surname)).Include(x => x.Livestocks).FirstOrDefault();
                  return farmer;
              }
              else
              {
                  var farmer = _uMalusiContext.Farmers.Where(x => x.Surname.Contains(surname)).FirstOrDefault();
                  return farmer;

              }
          }
        */
        public Farmer GetFarmerByUsername(string usernane, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var farmer = _uMalusiContext.Farmers.Where(x => x.Username == usernane).Include(x => x.Livestocks).Include(x => x.Livestocks).FirstOrDefault();
                return farmer;
            }
            else
            {
                var farmer = _uMalusiContext.Farmers.Where(x => x.Username == usernane).FirstOrDefault();
                return farmer;

            }
        }

        #endregion

        #region Livestock

        public Livestock CreateLivestockAccount(Livestock livestock)
        {
            _uMalusiContext.Livestocks.Add(livestock);
            _uMalusiContext.SaveChanges();

            return livestock;
        }


        public IList<Livestock> GetLivestocksByFarmerId(int farmerId)
        {
            var alllivestocks = _uMalusiContext.Livestocks.Where(x => x.FarmerId == farmerId).ToList();
            return alllivestocks;

        }

        public Livestock GetLivestockById(int livestockId)
        {
            var alllivestocks = _uMalusiContext.Livestocks.Where(x => x.LivestockId == livestockId).FirstOrDefault();
            return alllivestocks;

        }

        #endregion

        #region Authentication

        public bool PerformAuthenticationCheck(string userName, string password)
        {
            var user = _uMalusiContext.Authentications.Where(u => u.Username == userName && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public Livestock CreateNewLivestock(Livestock livestock)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Tracker


        #endregion

        #region LivestockPosition
            
        public IList<LivestockPosition> GetLivestockPositionsByLivestockId(int livestockId)
        {
            var livestockPositions = _uMalusiContext.LivestockPositions.Where(x => x.LivestockId == livestockId).ToList();
            return livestockPositions;

        }

        public LivestockPosition GetLivestockPositionById(int livestockPositionId)
        {
            var livestockPosition = _uMalusiContext.LivestockPositions.Where(x => x.LivestockPositionId == livestockPositionId).FirstOrDefault();
            return livestockPosition;

        }

        public IList<LivestockPosition> GetLivestockPositionsByLivestockIdAndDateTime(int livestockId, DateTime dateTime)
        {
            var livestockPositions = _uMalusiContext.LivestockPositions.Where(x => (x.LivestockId == livestockId) && (x.DateTime >= dateTime)).ToList();
            return livestockPositions;

        }

        #endregion

    }


}