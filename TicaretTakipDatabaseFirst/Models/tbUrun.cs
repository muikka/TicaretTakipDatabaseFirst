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
    
    public partial class tbUrun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbUrun()
        {
            this.tbSatisHareketi = new HashSet<tbSatisHareketi>();
        }
    
        public int Id { get; set; }
        public string UrunAciklamasi { get; set; }
        public Nullable<int> UrunGrubuId { get; set; }
        public string UrunGrubuIsmi { get; set; }
        public Nullable<float> AlisFiyat { get; set; }
        public Nullable<float> SatisFiyat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSatisHareketi> tbSatisHareketi { get; set; }
        public virtual tbUrunGrubu tbUrunGrubu { get; set; }
    }
}
