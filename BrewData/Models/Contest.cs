using System;
using System.Collections.Generic;

namespace BrewData.Models {
  public class Contest {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<Vote> Votes { get; set; }
  }
}