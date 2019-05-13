using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var cinemas = ProcessCinema("cinema.csv");
            var movies = ProcessMovies("movies.csv");
           
            comboBox1.DataSource = movies.Select(x => x.movie_name).ToList();
            comboBox1.DisplayMember = "Name";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Movies movie = comboBox1.SelectedItem as Movies;
            var currentMovie = comboBox1.SelectedValue;
            var cinemas = ProcessCinema("cinema.csv");
            var movies = ProcessMovies("movies.csv");
            var orders1 = ProcessOrder("orders_1.csv");
            var orders2 = ProcessOrder("orders_2.csv");
            var orders = orders1.Concat(orders2);
            var ordersMovies = (from o in orders
                               join c in cinemas on o.seans equals c.seans
                               where o.movie_name == Convert.ToString(currentMovie)
                               select new {o.movie_name,o.quantity,c.ticket_price} ).ToList();

            var total = 0;
            foreach( var movi in ordersMovies)
            {
                total += movi.quantity * movi.ticket_price;
                 
            }
                           
          textBox1.Text = Convert.ToString(total);


        }


        private static List<Cinema> ProcessCinema(string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Cinema.ParseFromCsv)
                .ToList();

        }
        private static List<Movies> ProcessMovies(string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Movies.ParseFromCsv)
                .ToList();

        }

        private static List<Order> ProcessOrder(string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Order.ParseFromCsv)
                .ToList();

        }

    }
}
