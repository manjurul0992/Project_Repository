using Project_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Repository.Repositories
{
    public class PlayerRepository : IRepository
    {
        List<string> _roles = new List<string>();

        

        public void Delete(int playerId)
        {
            Player player = PlayerDB.PlayerList.FirstOrDefault(x => x.PlayerId == playerId);
            PlayerDB.PlayerList.Remove(player);
        }

        public IEnumerable<Player> GetAll()
        {
            return PlayerDB.PlayerList;
        }

        public Player GetById(int PlayerId)
        {
            Player player = PlayerDB.PlayerList.FirstOrDefault(x => x.PlayerId == PlayerId);
            return player;
        }

        public void Insert(Player player)
        {
            PlayerDB.PlayerList.Add(player);
        }

        

        public void Update(Player player)
        {

            Player moplayer = PlayerDB.PlayerList.FirstOrDefault(x => x.PlayerId == player.PlayerId);
            if (player.PlayerName != null)
            {
                moplayer.PlayerName = player.PlayerName;
            }
            if (player.Age != 0)
            {
                moplayer.Age = player.Age;
            }
        }
    }
}
