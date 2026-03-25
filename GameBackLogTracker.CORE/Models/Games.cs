using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackLogTracker.CORE.Models
{
    public class Games
    {
        // Static field to keep track of the next available ID to assign to the game
        private static int nextId = 1;

        //Creates a private readonly field to store the unique ID of the game.
        private readonly int _id;


        public int Id { get { return _id; } }

        //Properties for the game details, including Name, Genre, Developer, Publisher, Description, Platform, ESRB Rating, Completed status, IsPlaying status, Playtime, and ReleaseDate.
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

        public Games()
        {
            _id = nextId++;
            Name = string.Empty;
            Genre = string.Empty;
            Developer = string.Empty;
            Publisher = string.Empty;
            Description = string.Empty;
            Platform = string.Empty;
            ESRBRating = string.Empty;
            Completed = false;
            IsPlaying = false;
            Playtime = 0.0;
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public Games(string name, string genre, string developer, string publisher, string description, string platform, string esrbRating, bool completed, bool isPlaying, double playTime, DateOnly releaseDate)
        {
            _id = nextId++;
            Name = name;
            Genre = genre;
            Developer = developer;
            Publisher = publisher;
            Description = description;
            Platform = platform;
            ESRBRating = esrbRating;
            Completed = completed;
            IsPlaying = isPlaying;
            Playtime = playTime;
            ReleaseDate = releaseDate;
        }
    }
}
