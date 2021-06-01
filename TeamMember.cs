namespace Heist
{
    internal class TeamMember
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public float CourageFactor { get; set; }

        public TeamMember(string name, int skillLevel, float courageFactor)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courageFactor;
        }
    }
}