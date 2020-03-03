using MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyRepository.Base
{
    public abstract class SingletonBaseRepository<Repo,Model>: BaseRepository<Model> where Model : IBaseModel, new() where Repo: SingletonBaseRepository<Repo, Model>
    {
        private static readonly ThreadLocal<Repo> Lazy =
        new ThreadLocal<Repo>(() =>
            Activator.CreateInstance(typeof(Repo), true) as Repo);

        public static Repo Instance => Lazy.Value;
    }
}
