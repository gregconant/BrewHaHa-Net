using BrewData.Messages;
using BrewData.Models;

namespace BrewData.Repositories {
  public interface IContestRepository {
    OperationResult Create(Contest contest);
  }
  public class ContestRepository : IContestRepository {

    public ContestRepository() { }

    public OperationResult Create(Contest contest) {
      return new OperationResult { Message = "Contest Created (but not really)", Success = true };
    }

  }
}
