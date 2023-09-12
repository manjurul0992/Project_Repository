using Project_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Repository.Models
{
    public class Player:IRole
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public DateTime PlayerDebut { get; set; }
        public int Age { get; set; }
        public Format Formates { get; set; }
        public int OdiRun { get; set; }
        public int T20Run { get; set; }
        public int TestRun { get; set; }
        public string OdiCentury { get; set; }
        public string T20Century { get; set; }
        public string TestCentury { get; set; }
        public decimal BatterStrikerRate { get; set; }
        public int Wicket { get; set; }
        public Experience LeagueExperience { get; set; }

        List<string> _roles = new List<string>();
        public void AddRole(string role)
        {
            _roles.Add(role);
        }
        public string RolePlays()
        {
            return string.Join(",", _roles.ToArray());
        }
    }
}
