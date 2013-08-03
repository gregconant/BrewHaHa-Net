using System;

namespace BrewData.Models {
  public class Vote {
    public Guid Id { get; set; }
    public Beer Choice { get; set; }
  }
}
