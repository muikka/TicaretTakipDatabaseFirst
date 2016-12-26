//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicaretTakipDatabaseFirst.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbSatisHareketi
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public Nullable<int> UrunId { get; set; }
        public string UrunIsmi { get; set; }
        public Nullable<int> UrunAdet { get; set; }
        public Nullable<float> ToplamEtiketFiyati { get; set; }
        public Nullable<float> SatisBedeli { get; set; }
        public Nullable<float> YuzdeIskonto { get; set; }
        public Nullable<bool> PesinMi { get; set; }
        public Nullable<bool> VadeliMi { get; set; }
        public Nullable<System.DateTime> PesinTarihi { get; set; }
        public Nullable<System.DateTime> VadeTarihi { get; set; }
        public Nullable<System.DateTime> SatisTarihi { get; set; }
        public string MusteriIsmiSoyadi { get; set; }
    
        public virtual tbMusteri tbMusteri { get; set; }
        public virtual tbUrun tbUrun { get; set; }
    }
}