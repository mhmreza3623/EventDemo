namespace DataModels.Core.Common
{
    public class AuditLogCollection
    {
        public AuditLogCollection()
        {
            CreateTime = DateTime.Now;
        }

        public DateTime CreateTime { get; set; }
        public string ResponseBody { get; set; }
        public string RequestBody { get; set; }
        public string StatusCode { get; set; }
    }
}
