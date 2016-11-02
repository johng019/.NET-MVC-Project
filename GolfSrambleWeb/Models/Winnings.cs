using System.Data.Entity;

namespace GolfSrambleWeb.Models
{
    public class Winnings
    {
        public DbSet<TotalWinnings>TotalWinnings { get; set;}
    }
}