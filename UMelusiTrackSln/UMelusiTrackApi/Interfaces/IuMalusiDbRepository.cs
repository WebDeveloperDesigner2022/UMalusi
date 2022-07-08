using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Interfaces
{
    public interface IuMalusiDbRepository
    {

        Livestock CreateNewLivestock(Livestock livestock);
        Farmer CreateNewFarmer(Farmer farmer);

        bool DoesFarmerExistByUsername(string username);
        bool DoesFarmerExistById(int id);

        List<Farmer> GetAllFarmers(bool fullFetch = true);

        Livestock GetLivestockById(int livestockId);
        IList<Livestock> GetLivestocksByFarmerId(int livestockId);

        Farmer GetFarmerByUsername(string username, bool fullFetch = true);
        Farmer GetFarmerById(int id, bool fullFetch = true);

        bool PerformAuthenticationCheck(string username, string password);



    }
}
