using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class Movies
    {

        public string movie_name { get; set; }
        public string director_name { get; set; }



        public Movies (string _movie_name, string  _director_name)
        {
            this.movie_name = _movie_name;
            this.director_name = _director_name;
        }

        internal static Movies ParseFromCsv(string line)
        {
            string x0, x1;
            
            
            var columns = line.Split(',');
            x0 = columns[0];
            x1 = columns[1];
            
            return new Movies (x0, x1);


        }

    }
}
