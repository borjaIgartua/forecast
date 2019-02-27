using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Code.Repo {
    public interface IRepository<T> {
        Task<IList<T>> FindEntitiesAsync(string key, string value);
    }
}
