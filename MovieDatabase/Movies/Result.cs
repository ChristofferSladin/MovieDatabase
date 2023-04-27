using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Movies
{
    public class Result
    {
        public string id { get; set; }
        public TitleText TitleText { get; set; }
        public ReleaseYear ReleaseYear { get; set; }
    }
}
