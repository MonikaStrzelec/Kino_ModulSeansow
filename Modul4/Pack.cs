//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modul4
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class Pack
    {
        public int IDPack { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } = .00M;


        public int add(String name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            using (var context = new projektkinoEntities1())
            {
                context.Pack.Add(this);
                context.SaveChanges();
                return this.IDPack;
            }
        }

        public static void Delete(int index)
        {
            using (var context = new projektkinoEntities1())
            {
                Pack pack = context.Pack.Find(index);
                context.Entry(pack).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public override string ToString()
        {
            return this.Name + ": " + this.Price + "PLN";
        }
    }
}
