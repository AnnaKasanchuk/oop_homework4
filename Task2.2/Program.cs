using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerTeamApp
{
    public abstract class Worker
    {
        public string Name { get; protected set; } = string.Empty;
        
        public string Position { get; protected set; } = string.Empty;
        
        public string WorkDay { get; protected set; } = string.Empty;

        public Worker(string name)
        {
            Name = name;
        }

        public virtual void Call()
        {
            WorkDay += "[Call] ";
        }

        public virtual void WriteCode()
        {
            WorkDay += "[WriteCode] ";
        }

        public virtual void Relax()
        {
            WorkDay += "[Relax] ";
        }

        public abstract void FillWorkDay();
    }

    public class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            Position = "Developer";
        }

        public override void FillWorkDay()
        {
            WorkDay = string.Empty;
            
            WriteCode();
            
            Call();
            
            Relax();
            
            WriteCode();
        }
    }

    public class Manager : Worker
    {
        private readonly Random _random = new Random(); 

        public Manager(string name) : base(name)
        {
            Position = "Manager";
        }

        public override void FillWorkDay()
        {
            WorkDay = string.Empty;

            int firstCallSequence = _random.Next(1, 11);
            
            for (int i = 0; i < firstCallSequence; i++)
            {
                Call();
            }

            Relax();

            int secondCallSequence = _random.Next(1, 6);
            
            for (int i = 0; i < secondCallSequence; i++)
            {
                Call();
            }
        }
    }

    public class Team
    {
        public string Name { get; private set; } = string.Empty;

        private readonly List<Worker> _workers = new List<Worker>(); 

        public Team(string name)
        {
            Name = name;
        }

        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
        }

        public void ShowTeamInfo()
        {
            Console.WriteLine($"Team: {Name}");
            Console.WriteLine("Employees:");

            foreach (Worker worker in _workers)
            {
                Console.WriteLine(worker.Name);
            }
        }

        public void ShowDetailedInfo()
        {
            Console.WriteLine($"Team: {Name}");
            Console.WriteLine("Detailed information:");

            foreach (Worker worker in _workers)
            {
                Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay.Trim()}");
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Enter the team name: ");
            string teamName = Console.ReadLine() ?? string.Empty;
            Team team = new Team(teamName);

            bool isRunning = true; 

            while (isRunning)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1. Enter the developer");
                Console.WriteLine("2. Enter the manager");
                Console.WriteLine("3. Display information about the team");
                Console.WriteLine("4. Display detailed information about the team");
                Console.WriteLine("0. Exit");
                Console.Write("Select an item: ");

                string choice = Console.ReadLine() ?? string.Empty;
                Console.WriteLine();

                bool isAddDev = choice == "1"; 
                bool isAddMgr = choice == "2"; 
                bool isShowInfo = choice == "3"; 
                bool isShowDetailed = choice == "4"; 
                bool isExit = choice == "0"; 

                if (isAddDev)
                {
                    Console.Write("Enter the developer's name: ");
                    string devName = Console.ReadLine() ?? string.Empty;
                    Developer dev = new Developer(devName);
                    
                    dev.FillWorkDay();
                    
                    team.AddWorker(dev);
                    
                    Console.WriteLine($"Developer {devName} has been added!");
                }
                else if (isAddMgr)
                {
                    Console.Write("Enter the manager's name: ");
                    string mgrName = Console.ReadLine() ?? string.Empty;
                    Manager mgr = new Manager(mgrName);
                    
                    mgr.FillWorkDay();
                    
                    team.AddWorker(mgr);
                    
                    Console.WriteLine($"Manager {mgrName} has been added!");
                }
                else if (isShowInfo)
                {
                    team.ShowTeamInfo();
                }
                else if (isShowDetailed)
                {
                    team.ShowDetailedInfo();
                }
                else if (isExit)
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
        }
    }
}