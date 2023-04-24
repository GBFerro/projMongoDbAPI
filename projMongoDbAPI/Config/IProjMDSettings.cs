namespace projMongoDbAPI.Config
{
    public interface IProjMDSettings
    {
        public string ClientCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
