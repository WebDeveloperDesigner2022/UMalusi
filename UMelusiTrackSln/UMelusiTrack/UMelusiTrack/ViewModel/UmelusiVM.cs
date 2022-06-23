using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Models;
using UMelusiTrack.Models.Services;
using UMelusiTrack.Services;

namespace UMelusiTrack.ViewModel
{
    public class UmelusiVM
    {
        
        public Task APIAsync()
        {
            return Task.CompletedTask;
        }
    }    
}