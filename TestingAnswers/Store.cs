using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAnswers
{
    public class Store
    {
        public virtual int StoreID { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Item> ItemID { get; set; }

        //public override bool Equals(object obj)
        //{
        //    return StoreID.Equals(((Store)obj).StoreID);
        //}
    }

    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(x => x.StoreID).Column("idStore").GeneratedBy.Assigned();
            Map(x => x.Name).Column("Name").Not.Nullable();

            HasMany(x => x.ItemID).KeyColumn("idStore").Inverse().AsSet().Cascade.SaveUpdate();
            //HasMany(x => x.ItemID).KeyColumn("idItem").Inverse().Table("Item").AsSet().Cascade.SaveUpdate();
            //HasMany(x => x.ItemID).KeyColumn("idItem").Inverse().AsSet().Cascade.All();
        }
    }
}
