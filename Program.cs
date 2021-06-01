using System;

namespace Heist
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Plan Your Heist");
            Team team = new Team();
            int bankDifficulty = 0;
            int teamSkill = 0;
            int numOfRuns = 1;
            int totalDifficulty = 0;
            int successfulRun = 0;
            int failedRun = 0;

            Console.Write("Enter the bank difficulty number > ");
            bankDifficulty = int.Parse(Console.ReadLine());

            UserInput();
            TrialRuns();

            Console.WriteLine();
            Console.WriteLine($"Successful Heist Runs: {successfulRun}");
            Console.WriteLine($"Failed Heist Runs: {failedRun}");

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
                    Console.Write("How many trial runs do you want? > ");
                    numOfRuns = int.Parse(Console.ReadLine());
                }
            }
            void TrialRuns()
            {

                for (int i = 1; i <= numOfRuns; i++)
                {
                    int heistLuck = new Random().Next(-10, 10);
                    totalDifficulty = bankDifficulty + heistLuck;
                    Console.WriteLine($"Total team skill level: {teamSkill}");
                    Console.WriteLine($"Bank's difficulty level is {totalDifficulty}");
                    if (teamSkill >= totalDifficulty)
                    {
                        Console.WriteLine("Successful bank heist!");
                        successfulRun++;
                    }
                    else
                    {
                        Console.WriteLine("Failed.");
                        failedRun++;
                    }
                }
            }
        }
    }
}