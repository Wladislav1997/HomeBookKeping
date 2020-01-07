using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBookkeping.Models
{
    public class Operation
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // разово переодически
        public decimal? Sum { get; set; }
        public DateTime? Data { get; set; }
        public string NameAct { get; set; } // доход расход
        public string Coment { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
