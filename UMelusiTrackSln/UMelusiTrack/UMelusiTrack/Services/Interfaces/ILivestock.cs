using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrackApi.Models;

namespace UMelusiTrack.Services.Interfaces
{
    public interface ILivestock
    {
        Task<Livestock> Livestock(string livestockName, string dob, string color, byte[] image, int farmerId, int trackerId, int livestockTypeId);
        Task SaveLivestockAsync(Livestock livestock);

        Task DeleteLivestockAsync(string id);
    }
}
