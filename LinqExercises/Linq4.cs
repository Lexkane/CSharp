using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Product
    {
        public int id;
        public string name;
        public Product( int id,string _name)
            {
                id=id;    
                name=_name;
            }
    }

    class Company
    {
        public string name;
        public int productId;

        public Company (string _name,int _productId)
        {
            name = _name;
            productId = _productId;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            
            //Linq query join on id and output companyName and productName values
            List<Product> products = new List<Product>() { new Product(1, "Coca-cola"),new Product (2,"Windows"),new Product (3,"Iphone"),new Product(4,"Alexa") };
            List<Company> companies = new List<Company>() { new Company("Coca", 1), new Company("Microsoft",2),new Company("Apple",3),new Company ("Amazon",4) };

            var combo = from pr in products
                        from cmp in companies
                        where pr.id == cmp.productId
                        select  new Tuple<string, string>(pr.name,cmp.name);


            var query = from Pr in products
                        join Cmp in companies on Pr.id equals Cmp.productId
                        select new { companyName=Cmp.name,productName=Pr.name};

            foreach (var item in query)
            {
                Console.WriteLine("{0} - {1} ", item.companyName, item.productName);

            }

            }
    }
}


