using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewHaHaNet.Models {
  public class Brewer {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateAdded { get; set; }
  }
}
