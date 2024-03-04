namespace Drivers.Api.Configurations;

    public class DatabaseSettings: IDatabaseSettings
    {
        public string ConnectionString {get; set;} = string.Empty;
        public string DatabaseName {get; set;} = string.Empty;
        public required Dictionary<string, string> Collections { get; set; }
    }
    public class IDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        Dictionary<string, string> Collections { get; set; }
    }   
