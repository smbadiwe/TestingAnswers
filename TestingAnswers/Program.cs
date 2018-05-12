using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAnswers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Store s = new Store
                {
                    Name = "Store 1",
                    StoreID = 1,
                    ItemID = new HashSet<Item>()
                };
                Item i1 = new Item
                {
                    Name = "Item 1",
                    ItemID = 1,
                    Price = 100,
                    Quantity = 1,
                    StoreID = s
                };
                Item i2 = new Item
                {
                    Name = "Item 2",
                    ItemID = 2,
                    Price = 100,
                    Quantity = 1,
                    StoreID = s
                };
                s.ItemID.Add(i1);
                s.ItemID.Add(i2);

                using (var session = NhConfig.GetSession())
                {
                    var trans = session.BeginTransaction();
                    try
                    {
                        session.SaveOrUpdateAsync(s);

                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }

                using (var session = NhConfig.GetSession())
                {
                    Store store = session.Query<Store>().Where(x => x.StoreID == 1).SingleOrDefault();
                    foreach (var item in store.ItemID)
                    {
                        Console.WriteLine($"Item - Id: {item.ItemID}. Name: {item.Name}. Store ID: {item.StoreID.StoreID}.");
                    }
                }
            }
            catch (Exception ex)
            {
                var curr = ex;
                while (curr != null)
                {
                    Console.WriteLine(curr.Message);
                    curr = curr.InnerException;
                }
            }

            Console.ReadKey();
        }
    }
}
