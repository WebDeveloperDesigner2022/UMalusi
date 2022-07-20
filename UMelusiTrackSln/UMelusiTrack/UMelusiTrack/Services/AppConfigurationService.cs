namespace UMelusiTrack.Services
{
    public class AppConfigurationService
    {
        static AppConfigurationService _instance;

        public static AppConfigurationService Instance =>
            _instance ?? (_instance = new AppConfigurationService());

        public string uMalusiServerUrl { get; set; }

        public AppConfigurationService()
        {
#if LOCALSERVER
            uMalusiServerUrl = "https://10.0.2.2:5001/";
#else
            uMalusiServerUrl = "https://localhost:7052";
#endif



        }
    }
}
