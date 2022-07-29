using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrackApi.Models;

namespace UMelusiTrack.Services.Interfaces
{
    public interface IOrder
    {
        Task<Order> Order(string name, string surname, int quantity, string referenceNo, string deliveryAddress, string contactNo, string emailAddress, int farmerId);
    }
}
