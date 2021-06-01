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
            int teamSkill;
            UserInput();

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
                    }
                }
            }
        }
    }
}