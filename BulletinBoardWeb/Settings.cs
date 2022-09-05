//namespace BulletinBoardWeb
//{
//    static class Settings
//    {
//        static IConfiguration? configuration = null;

//        public static IConfiguration? Configuration {
//            get {
//                if (configuration is null)
//                    configuration = CreateConfiguration();
//                return configuration;
//            }
//        }

//        static IConfigurationRoot CreateConfiguration()
//            => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
//                                         .AddJsonFile("appsettings.json")
//                                         .Build();
//    }
//}
