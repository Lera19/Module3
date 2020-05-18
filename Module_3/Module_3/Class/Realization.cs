using Module_3.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module_3.Class
{
    public class Realization
    {
        public IList<Products> products;

        public Realization()
        {
            products = new List<Products>()
            {
                new Products(ClothingType.jacket, 1000, 20),
                new Products(ClothingType.jeans, 350, 10),
                new Products(ClothingType.T_shirt, 100, 5),


            };
        }

        public void Run()
        {
            var tasks = new List<Task>();

            foreach (var prod in products)
            {

                tasks.Add(new Task(() => Processing(prod)));
            }
            foreach (var t in tasks)
            {
                t.Start();
            }

        }
        private void Processing(Products prod)
        {
            prod.ProductsSt += PrintNotification;

            prod.Move();
            AddProducts();
            DeleteProducts();

        }


        private void PrintNotification(object sender, string message)
        {
            Console.WriteLine(message);
        }


        private void AddProducts()
        {
            Random rnd = new Random();

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    products.Add(new Products(ClothingType.jacket, rnd.Next(800, 1500), 20));
                    products.Add(new Products(ClothingType.jeans, rnd.Next(250, 600), 10));
                    products.Add(new Products(ClothingType.T_shirt, rnd.Next(50, 400), 5));


                    foreach (var prod in products)
                    {
                        Console.WriteLine($"Add : {prod}");
                    }

                }


            });


        }

        private void DeleteProducts()
        {
            IList<Products> listEx = new List<Products>();
            Random rnd = new Random();

            Task.Factory.StartNew(() =>
            {
                try
                {
                    for (int i = 0; i <= 5; i++)
                    {


                        products.Remove(new Products(ClothingType.jacket, rnd.Next(800, 1500), 30));
                        products.Remove(new Products(ClothingType.jeans, rnd.Next(250, 600), 23));
                        products.Remove(new Products(ClothingType.T_shirt, rnd.Next(50, 400), 15));


                        foreach (var prod in products)
                        {
                            Console.WriteLine($"Delete {prod}");

                        }
                    }
                }
                finally
                {
                    foreach (var prod in products)
                    {
                     listEx.Add(prod);
                    }
                }
            });
        }

        public void Menu()
        {

            Console.WriteLine("Menu: jacket 1, jeans 2, T_shirt 3");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    var jacket = from j in products
                                 where j.ClothingType == ClothingType.jacket
                                 select j;
                    Console.WriteLine(jacket);
                    break;
                case 2:
                    var jeans = from jen in products
                                where jen.ClothingType == ClothingType.jeans
                                select jen;
                    Console.WriteLine(jeans);
                    break;

                case 3:
                    var t_shirt = from t in products
                                  where t.ClothingType == ClothingType.T_shirt
                                  select t;
                    Console.WriteLine(t_shirt);
                    break;
                default:
                    Console.WriteLine("Not correct input");
                    break;
            }
            Console.Write("Input anything");

        }
    }
}
