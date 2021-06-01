﻿using System;
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
                if (addName != "")
                {
                    do
                    {
                        Console.Write("Enter team member's skill level between 1 and 10 > ");
                        skillLevelCheck = int.TryParse(Console.ReadLine(), out addSkillLevel);
                    }
                    while (!skillLevelCheck);
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