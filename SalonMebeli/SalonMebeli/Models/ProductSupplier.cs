//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalonMebeli.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSupplier
    {
        public int ProductSupplierID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductSupplierName { get; set; }
    
        public virtual Product Product { get; set; }
    }
}