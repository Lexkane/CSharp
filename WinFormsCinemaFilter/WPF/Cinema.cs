using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
    class Cinema
    {
        public string seans { get; set; }
        public int ticket_price { get; set; }

        public Cinema(string _seans, int _ticket_price)
        {
            this.seans = _seans;
            this.ticket_price = _ticket_price;
        }

        internal static Cinema ParseFromCsv(string line)
        {
            string x0;
            int x1;
            var columns = line.Split(',');
            x0 = columns[0];
            int.TryParse(columns[1], out x1);

            return new Cinema (x0, x1);


        }

    }
}
