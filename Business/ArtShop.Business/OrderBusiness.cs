using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Entities.Model;

namespace ArtShop.Business
{
    public class OrderBusiness
    {
        public List<Order> GetAll()
        {
            return mockedList(15);
        }

        public Order GetById(int id)
        {
            return mockedList(1).First();
        }

        public Order Edit(Order order)
        {
            return new Order();
        }

        public Order Create(Order order)
        {
            return order;
        }

        public void Delete(int id)
        {
            
        }



        private List<Order> mockedList(int quantity)
        {
            var ret = new List<Order>();
            Random random = new Random();

            ArtistBusiness ab = new ArtistBusiness();
            ProductBusiness pb = new ProductBusiness();

            for (int i = 0; i < quantity; i++)
            {
                var order = new Order();

                order.UserName = RandomUser(random);
                order.ItemCount = RandomInt(random, 10);
                order.OrderDate = RandomDay(random);
                order.OrderNumber = RandomInt(random, 1000000);
                order.Id = RandomInt(random, 200+quantity);
                order.OrderDetail = getMockedDetail(random,ab,pb);
                order.TotalPrice = order.OrderDetail.First().Price * order.OrderDetail.First().Quantity;
                ret.Add(order);
            }

            return ret;
        }



        private List<OrderDetail> getMockedDetail(Random random , ArtistBusiness ab, ProductBusiness pb)
        {
            List<OrderDetail> ret = new List<OrderDetail>();
            var dtl = new OrderDetail();

            dtl.Product = pb.Get(RandomValidID(random));
            dtl.Product.Artist = ab.Get(dtl.Product.ArtistId);
            dtl.ProductId = dtl.Product.Id;
            dtl.Quantity = RandomInt(random, 20);
            dtl.Price = dtl.Product.Price;
            dtl.Id = RandomInt(random, 500);
            ret.Add(dtl);
            return ret;
        }


        static string RandomUser(Random gen)
        {
            string[] ids = new[] { "crossi","Test","msincovich","pruebaUsuario" };
            int usuarioSeleccionar = RandomInt(gen, ids.Length);
            return ids[usuarioSeleccionar];
        }

        static string RandomString(int length, Random gen)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[gen.Next(s.Length)]).ToArray());
        }

        static DateTime RandomDay(Random gen)
        {
            DateTime start = new DateTime(2015, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        static int RandomInt(Random gen, int max)
        {
            return gen.Next(max);
        }

        static int RandomInt(Random gen, int min,int max)
        {
            return gen.Next(min,max);
        }

        static int RandomValidID(Random gen)
        {
            int[] ids = new[] {3, 4, 5, 7, 15, 16, 17, 18, 20};
            int numeroASeleccionar = RandomInt(gen, 8);
            return ids[numeroASeleccionar];
        }

    }
}
