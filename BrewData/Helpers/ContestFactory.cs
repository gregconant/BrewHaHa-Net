using BrewData.Models;

namespace BrewData.Helpers {
  public interface IContestFactory {
    Contest Create();
  }

  public class ContestFactory : IContestFactory {
    #region IContestFactory Members

    public Contest Create() {
      throw new System.NotImplementedException();
    }

    #endregion
  }
}
