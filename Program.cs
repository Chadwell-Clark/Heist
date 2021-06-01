using System;

namespace Heist
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Plan Your Heist");
            Team team = new Team();
            int bankDifficulty = 100;
            int teamSkill = 0;
            int numOfRuns = 1;
            int totalDifficulty = 0;
            UserInput();

            //Amount of runs.
            //For loop that keeps the user inputted data the same but changes heistLuck and checks the outcome each time.
            void UserInput()
            {
                Console.Write("Enter team member name > ");
                string addName = Console.ReadLine();
                if (addName != "")
                {
                    Console.Write("Enter team member's skill level > ");
                    int addSkillLevel = int.Parse(Console.ReadLine());
                    Console.Write("Enter team member courage factor (a number between 0.0 and 2.0 > ");
                    float addCourageFactor = float.Parse(Console.ReadLine());
                    Console.WriteLine(@"
                    ");
                    TeamMember newMember = new TeamMember(addName, addSkillLevel, addCourageFactor);
                    team.Members.Add(newMember);
                    UserInput();
                }
                else
                {
                    Console.WriteLine($"There are {team.Members.Count} members on this team");
                    foreach (TeamMember Member in team.Members)
                    {
                        Console.WriteLine(Member.GetDescription());
                        teamSkill += Member.SkillLevel;
                    }
                    Console.WriteLine($"Total team skill level: {teamSkill}");
                    Console.WriteLine($"Bank's difficulty level is {totalDifficulty}");
                    Console.Write("How many trial runs do you want? > ");
                    numOfRuns = int.Parse(Console.ReadLine());
                }
            }
            void TrialRuns()
            {
                int heistLuck = new Random().Next(-10, 10);
                totalDifficulty = bankDifficulty + heistLuck;

                for (int i = 0; i <= numOfRuns; i++)
                {
                    if (teamSkill >= bankDifficulty)
                    {
                        Console.WriteLine("Successful bank heist!");
                    }
                    else
                    {
                        Console.WriteLine("Failed.");
                    }
                }
            }
        }
    }
}