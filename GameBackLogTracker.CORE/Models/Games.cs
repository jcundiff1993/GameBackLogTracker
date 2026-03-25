using GameBackLogTracker.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.CORE.Models
{
    public class Games: IEntity
    {
        //Properties for the game details, including Name, Genre, Developer, Publisher, Description, Platform, ESRB Rating, Completed status, IsPlaying status, Playtime, and ReleaseDate.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public string ESRBRating { get; set; }
        public bool Completed { get; set; }
        public bool IsPlaying { get; set; }
        public double Playtime { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
