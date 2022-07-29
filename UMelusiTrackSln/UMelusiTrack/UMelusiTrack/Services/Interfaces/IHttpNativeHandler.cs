using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UMelusiTrack.Services.Interfaces
{
    public interface IHttpNativeHandler
    {
        HttpClientHandler GetHttpClientHandler();
    }
}
