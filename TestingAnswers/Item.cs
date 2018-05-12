using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAnswers
{
    public class Item
    {
        public virtual int ItemID { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual Store StoreID { get; set; }

        //public override bool Equals(object obj)
        //{
        //    return ItemID.Equals(((Item)obj).ItemID);
        //}
    }

    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Id(x => x.ItemID).Column("idItem").GeneratedBy.Assigned();
            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.Price).Column("Price").Default("0");
            Map(x => x.Quantity).Column("Quantity").Default("0");
            References(x => x.StoreID).Column("idStore");
        }
    }
}
