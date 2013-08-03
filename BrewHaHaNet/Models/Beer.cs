using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewHaHaNet.Models {
  public class Beer {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public BeerType Type { get; set; }
    public Brewer BrewedBy { get; set; }
  }
}
