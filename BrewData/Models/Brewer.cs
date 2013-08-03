using System;

namespace BrewData.Models {
  public class Brewer {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateAdded { get; set; }
  }
}
