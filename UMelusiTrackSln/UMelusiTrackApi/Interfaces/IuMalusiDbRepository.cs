using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Interfaces
{
    public interface IuMalusiDbRepository
    {

        Livestock CreateNewLivestock(Livestock livestock);
        Farmer CreateNewFarmer(Farmer farmer);

        Order CreateNewOrder(Order order);
        bool DoesFarmerExistByUsername(string username);
        bool DoesFarmerExistById(int id);

        List<Farmer> GetAllFarmers(bool fullFetch = true);

        Livestock GetLivestockById(int livestockId);
        IList<Livestock> GetLivestocksByFarmerId(int livestockId);

        Farmer GetFarmerByUsername(string username, bool fullFetch = true);
        Farmer GetFarmerById(int id, bool fullFetch = true);

        LivestockPosition GetLivestockPositionById(int livestockPositionid);
        IList<LivestockPosition> GetLivestockPositionsByLivestockId(int livestockPositionId);
        IList<LivestockPosition> GetLivestockPositionsByLivestockIdAndDateTime(int livestockId, DateTime dateTime);

        LivestockPosition InsertLiveStockPosition(LivestockPosition livestockPosition);


        bool PerformAuthenticationCheck(string username, string password);
       // Order CreateNewOrder(Order order);

        //    Farmer GetFarmerByAuthenticationId(int farmerId, bool fullFetch = true);
        public Farmer GetAuthentication(string username, string password);

    }
}
