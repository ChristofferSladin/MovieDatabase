using KrisInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Movies
{
    public class MoviesResponse
    {
        public int page { get; set; }
        public string next { get; set; }
        public int entries { get; set; }
        public List<Result> Results { get; set; }
    }
}
