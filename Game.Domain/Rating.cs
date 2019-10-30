using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Domain
{
    public class Rating : Entity
    {
        public User User { get; set; }
        public VideoGame VideoGame { get; set; }
        public int Mark { get; set; }
    }
}
