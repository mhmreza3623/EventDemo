namespace SharedKernel.Common.MongoDb
{
    public class MongodbConfig
    {
        public const string SectionName = "MongoDBConfig";

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
