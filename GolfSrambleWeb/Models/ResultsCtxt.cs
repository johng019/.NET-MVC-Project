using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GolfSrambleWeb.Models
{
    public class ResultsCtxt
    {
        public DbSet<Results>Results { get;set;}
    }
}