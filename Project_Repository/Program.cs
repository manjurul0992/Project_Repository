using Project_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Repository.Models;

namespace Project_Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int temp = 0;
                while (temp == 0)
                {
                    Console.Write("Which Information Do You Want: \n[Hints]\n1. Batsman\n2. Bowler\nEnter sl No\t:");
                    Format Formates = (Format)int.Parse(Console.ReadLine());
                    if (Formates == (Format)1 || Formates == (Format)2)
                    {
                        if (Formates == (Format)1)
                        {
                            BatterInfo();
                        }
                        else
                        {
                            BowlerInfo();
                        }
                        temp = 1;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter correct No!!");
                        temp = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
            Console.ReadLine();
            
            Console.ReadKey();
            
            

        }
        private static void BatterInfo() 
        {
            DisplayDetail();

        }
        private static void BowlerInfo()
        {
            DisplayDetail();
            
        }
        public static void DisplayDetail()
        {
            Console.WriteLine("1. Show All Player");
            Console.WriteLine("2. Insert Player");
            Console.WriteLine("3. Update Player");
            Console.WriteLine("4. Delete Player");

            var index = int.Parse(Console.ReadLine());
            Reveal(index);
            

        }
        public static void Reveal(int index)
        {
            PlayerRepository playerRepository= new PlayerRepository();
            if (index == 1)
            {
                var playerList = playerRepository.GetAll();
                if (playerList.Count() == 0)
                {
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("NO DATA CAST");
                    Console.WriteLine("******************************************");
                    DisplayDetail();
                }
                else
                {
                    foreach (var i in playerRepository.GetAll())
                    {
                        Console.WriteLine($"Player Id: {i.PlayerId}, \nPlayer Name: {i.PlayerName}, \nAge: {i.Age},\nPlayer Debut Date: {i.PlayerDebut},\nTotal ODI Run : {i.OdiRun}, \nTotal T20 Run : {i.T20Run}, \nTotal Test Run : {i.TestRun},\nODI Match Century : {i.OdiCentury},\nT20 Match Century : {i.T20Century},\nTest Match Century : {i.TestCentury},\nBatsman Striker Rate : {i.BatterStrikerRate},\nTotal Wicket Bowler : {i.Wicket},\nLeague Experience : {i.LeagueExperience},");
                    }
                    Console.WriteLine("******************************************");
                    DisplayDetail();
                }
            }
            else if (index == 2)
            {
                Console.WriteLine("******************************************");
                Console.Write("Name :");
                string name = Console.ReadLine();

                Console.Write("Age :");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Player Debut Date :");
                DateTime pdebut = DateTime.Parse(Console.ReadLine());

                Console.Write("ODI Total Run :");
                int odirun = Convert.ToInt32(Console.ReadLine());

                Console.Write("T20 Total Run :");
                int t20run = Convert.ToInt32(Console.ReadLine());

                Console.Write("Test Total Run :");
                int testrun = Convert.ToInt32(Console.ReadLine());

                Console.Write("ODI Century :");
                string odicen = Console.ReadLine();

                Console.Write("T20 Century :");
                string t20cen = Console.ReadLine();

                Console.Write("Test Century :");
                string testcen = Console.ReadLine();

                Console.Write("Batsman Striker Rate :");
                decimal batStRate = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Total Wicket Bowler:");
                int bowWic = Convert.ToInt32(Console.ReadLine());

                Console.Write("League Experience :[Ipl-1,Bbl-2,Bpl-3,Vitality-4] ");
                Experience legExpri = (Experience)int.Parse(Console.ReadLine());

                


                int maxId = playerRepository.GetAll().Any() ? playerRepository.GetAll().Max(x => x.PlayerId) : 0;

                Player player = new Player
                {
                    PlayerId = maxId + 1,
                    PlayerName = name,
                    PlayerDebut=pdebut,
                    Age = age,
                    OdiRun=odirun,
                    T20Run=t20run,
                    TestRun=testrun,
                    TestCentury=testcen,
                    OdiCentury=odicen,
                    T20Century=t20cen,
                    BatterStrikerRate = batStRate,
                    Wicket = bowWic,
                    LeagueExperience = legExpri



                };

                string role = "";
                while (role.ToLower() != "0")
                {
                    Console.WriteLine("Role : [type 0 to stop]");
                    role = Console.ReadLine();
                    player.AddRole(role);
                    
                }

                playerRepository.Insert(player);
                Console.WriteLine("Data Inserted successfully!.");
                Console.WriteLine("******************************************");
                DisplayDetail();
            }
            else if (index == 3)
            {
                Console.WriteLine("******************************************");
                Console.Write("Enter Player Id To Update: ");
                int id = int.Parse(Console.ReadLine());
                var moplayer = playerRepository.GetById(id);

                if (moplayer == null)
                {
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Player Id Is Invalid!");
                    Console.WriteLine("******************************************");
                    DisplayDetail();
                }
                else
                {
                    Console.WriteLine($"Update Info For PLayer Id : {id}");
                    Console.WriteLine("******************************************");
                    Console.Write("Name :");
                    string name = Console.ReadLine();

                    Console.Write("Age :");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Player Debut Date :");
                    DateTime pdebut = DateTime.Parse(Console.ReadLine());

                    Console.Write("ODI Total Run :");
                    int odirun = Convert.ToInt32(Console.ReadLine());

                    Console.Write("T20 Total Run :");
                    int t20run = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Test Total Run :");
                    int testrun = Convert.ToInt32(Console.ReadLine());

                    Console.Write("ODI Century : ");
                    string odicen = Console.ReadLine();

                    Console.Write("T20 Century : ");
                    string t20cen = Console.ReadLine();

                    Console.Write("Test Century : ");
                    string testcen = Console.ReadLine();

                    Console.Write("Batsman Striker Rate :");
                    decimal batStRate = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Total Wicket Bowler : ");
                    int bowWic = Convert.ToInt32(Console.ReadLine());

                    Console.Write("League Experience :[Ipl-1,Bbl-2,Bpl-3,Vitality-4]  ");
                    Experience legExpri = (Experience)int.Parse(Console.ReadLine());


                    Player player = new Player
                    {
                        PlayerId = id,
                        PlayerName = name,
                        PlayerDebut= pdebut,
                        Age = age,
                        OdiRun = odirun,
                        T20Run = t20run,
                        TestRun = testrun,
                        TestCentury = testcen,
                        OdiCentury = odicen,
                        T20Century = t20cen,
                        BatterStrikerRate=batStRate,
                        Wicket=bowWic,
                        LeagueExperience=legExpri
                    };

                    string role = "";
                    while (role.ToLower() != "0")
                    {
                        Console.WriteLine("Role : [type 0 to stop]");
                        role = Console.ReadLine();
                        player.AddRole(role);

                    }

                    playerRepository.Update(player);
                    Console.WriteLine("Data Updated Successfully!");
                    Console.WriteLine("******************************************");
                    DisplayDetail();
                }
            }
            else if (index == 4)
            {
                Console.WriteLine("******************************************");
                Console.Write("Enter Player Id to Delete: ");
                int id = int.Parse(Console.ReadLine());
                var moplayer = playerRepository.GetById(id);

                if (moplayer == null)
                {
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Player Id is invalid!");
                    Console.WriteLine("******************************************");
                    DisplayDetail();
                }
                else
                {
                    playerRepository.Delete(id);
                    Console.WriteLine("Data Deleted Successfully!");
                    Console.WriteLine("******************************************");
                    DisplayDetail();
                }
            }

        }
    }
}
