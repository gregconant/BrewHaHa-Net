using System;

namespace BrewData.Models {
  public class Beer {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public BeerType Type { get; set; }
    public Brewer BrewedBy { get; set; }
  }
}
