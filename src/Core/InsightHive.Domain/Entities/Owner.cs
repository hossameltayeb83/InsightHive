﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int UserId {  get; set; }
        public User User { get; set; }
        public Business Business { get; set; }
    }
}
