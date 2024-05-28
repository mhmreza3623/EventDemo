namespace SharedKernel.Logging.AuditLog
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
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
