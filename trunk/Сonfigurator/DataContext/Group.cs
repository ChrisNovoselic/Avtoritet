//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Сonfigurator.DataContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            this.GroupBox = new HashSet<GroupBox>();
        }
    
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Height { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupBox> GroupBox { get; set; }
    }
}
