﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBookkeping.Models
{
    public class User
    {
       public string Email { get; set; }
       public string Password { get; set; }
       public int Id { get; set; }

       public List<Operation> Operations { get; set; }
       
    }
}
