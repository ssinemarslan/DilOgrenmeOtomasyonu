//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ingilizcekonusmaogrenmeuygulamasi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Konular
    {
        public int KonuNo { get; set; }
        public string KonuAdi { get; set; }
        public int EgitmenNo { get; set; }
    
        public virtual Egitmenler Egitmenler { get; set; }
    }
}
