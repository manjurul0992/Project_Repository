using Project_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Repository.Repositories
{
    public interface IRepository
    {
        IEnumerable<Player> GetAll();
        Player GetById(int PlayerId);
        void Insert(Player player);
        void Update(Player player);
        void Delete(int playerId);
    }
    public interface IRole
    {
        void AddRole(string role);
        string RolePlays();
    }

}
