using System.Collections.Generic;

namespace PierreTreats.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinFlavor = new HashSet<FlavorTreat>();
    }

    public int TreatId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<FlavorTreat> JoinFlavor { get; set; }
  }
}