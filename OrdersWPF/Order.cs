//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrdersWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public long ID_Order { get; set; }
        public string Name_product { get; set; }
        public Nullable<long> ID_Worker { get; set; }
        public string Tags { get; set; }
    
        public virtual Worker Worker { get; set; }
    }
}
