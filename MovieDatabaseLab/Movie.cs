using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseLab
{
    public class Movie
    {
        public string title;
        public string category;

        public Movie(string title, string category)
        {
            this.title = title;
            this.category = category;
        }

    }
}
