using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EventBus.Masstransit
{
    public class MassTransitConfiguration
    {
        public const string SectionName = "MassTransitConfiguration";
        public string RabbitMqHostName { get; set; }
        public string RabbitMqUsername { get; set; }
        public string RabbitMqPassword { get; set; }
        public string RabbitMqVirtualHost { get; set; }
    }
}
