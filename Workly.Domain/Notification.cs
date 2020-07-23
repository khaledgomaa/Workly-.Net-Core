using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workly.Domain
{
    public class Notification
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int orderId { get; set; }
        public Order Order { get; set; }

        public int AgentId { get; set; }

        public bool status { get; set; }
    }
}
