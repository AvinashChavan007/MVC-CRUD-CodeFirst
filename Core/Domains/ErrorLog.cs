using System;

namespace Core.Domains
{
    public class ErrorLog : BaseEntity
    {
        public string AppName { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public DateTime LogDate { get; set; }

    }
}
