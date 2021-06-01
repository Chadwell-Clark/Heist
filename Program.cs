using System;

namespace Heist
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Plan Your Heist");

            static void UserInput()
            {
                Console.Write("Enter team member name > ");
                string addName = Console.ReadLine();
                Console.Write("Enter team member's skill level > ");
                int addSkillLevel = int.Parse(Console.ReadLine());
                Console.Write("Enter team member courage factor (a number between 0.0 and 2.0 > ");
                float addCourageFactor = float.Parse(Console.ReadLine());
                TeamMember newMember = new TeamMember(addName, addSkillLevel, addCourageFactor);
            }


            Console.WriteLine(newMember.GetDescription());


        }
    }
}