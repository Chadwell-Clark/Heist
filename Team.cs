using System;
using System.Collections.Generic;

namespace Heist
{
    public class Team
    {

        public List<TeamMember> Members { get; set; }

        public Team()
        {
            Members = new List<TeamMember>();
        }

    }
}