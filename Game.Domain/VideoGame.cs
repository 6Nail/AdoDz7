using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Domain
{
    public class VideoGame : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double AvgRating { get; set; }
    }
}
