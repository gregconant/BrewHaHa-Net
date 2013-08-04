using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrewData.Helpers {
  public interface IGuidFactory {
    Guid NewGuid();
  }
  public class GuidFactory : IGuidFactory {

    public Guid NewGuid() {
      return Guid.NewGuid();
    }

  }
}
