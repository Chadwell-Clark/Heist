using System;
using System.Threading;

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
            try
            {

                bankDifficulty = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Difficulty must be a number");
                Thread.Sleep(1500);
                Main();
            }

            UserInput();
            TrialRuns();

            Console.WriteLine();
            Console.WriteLine($"Successful Heist Runs: {successfulRun}");
            Console.WriteLine($"Failed Heist Runs: {failedRun}");


            Thread.Sleep(1000);

            if (failedRun > successfulRun)
            {
                Console.WriteLine("Looks like the law finally caught up to you!");
            }
            else
            {
                Console.WriteLine("You guys took your earnings, and managed to leave your life of crime behind. Good work!");
            }
            //Amount of runs.
            //For loop that keeps the user inputted data the same but changes heistLuck and checks the outcome each time.
            void UserInput()
            {
                Console.Write("Enter team member name > ");
                string addName = Console.ReadLine();
                int addSkillLevel = 0;
                bool skillLevelCheck;
                float addCourageFactor = 0;
                bool courageFactorCheck;
                if (addName != "")
                {
                    do
                    {
                        Console.Write("Enter team member's skill level between 1 and 10 > ");
                        skillLevelCheck = int.TryParse(Console.ReadLine(), out addSkillLevel);
                    }
                    while (!skillLevelCheck);

                    //do/while loops will make a specific action happen (this action can be declared inside the "do" portion) 
                    //the "while" is simply looking for a true boolean result. if the result is true, then it will continue onto the next line of code. if it is false, then it will 
                    //always run the "do" portion until it is true.
                    do
                    {
                        Console.Write("Enter team member courage factor (a number between 0.0 and 2.0 > ");
                        courageFactorCheck = float.TryParse(Console.ReadLine(), out addCourageFactor);
                        Console.WriteLine(courageFactorCheck);
                        Console.WriteLine(addCourageFactor);
                        //WHAT THE HELL IS HAPPENING?!?!?!?! dont panic baby, look at the comments above to get the over all gist. 
                        //seperate the while statemnt into 3 parts (these can be seen by seperating the parts with the "&&")

                        // WHILE courageFactorCheck is not true (inputted data is not a float) or
                        //     courageFactorCheck is true AND the number is not between 0.0 and 2.0 keep DOing the stuff in the brackets

                    } while (!(courageFactorCheck && addCourageFactor >= 0.0 && addCourageFactor <= 2.0));


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