//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewLauncher.DataContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProviderFile
    {
        public int ProviderFileId { get; set; }
        public Nullable<int> ProviderId { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public Nullable<long> FileSize { get; set; }
        public byte[] FileContent { get; set; }
    
        public virtual Provider Provider { get; set; }
    }
}
