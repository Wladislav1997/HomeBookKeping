using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBookkeping.Models
{
    public class Operation
    {
        public int OperationId { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Type { get; set; }
        public string View { get; set; }
        public decimal Sum { get; set; }
        public DateTime Data { get; set; }
        public string Coment { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
