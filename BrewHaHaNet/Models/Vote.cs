using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewHaHaNet.Models {
  public class Vote {
    public Guid Id { get; set; }
    public Beer Choice { get; set; }
  }
}
