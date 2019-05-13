using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class Order
    {
        public string movie_name { get; set; }
        public string seans { get; set; }
        public int quantity { get; set; }


        public Order(string _movie_name,string _seans,int _quantity)
        {
            this.movie_name = _movie_name;
            this.seans = _seans;
            this.quantity =_quantity;
        }

        internal static Order ParseFromCsv(string line)
        {
            string x0, x1;
            int x2;


            var columns = line.Split(',');
            x0 = columns[0];
            x1 = columns[1];
            int.TryParse(columns[2], out x2);

            return new Order(x0, x1, x2);


        }




    }
}
