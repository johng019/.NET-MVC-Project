using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GolfSrambleWeb.Models
{
    public class PlayerCtxt
    {
        public DbSet<Players>Players { get;set; }
    }
}