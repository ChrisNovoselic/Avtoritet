﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AvtoritetEntities : DbContext
    {
        public AvtoritetEntities()
            : base("name=AvtoritetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Links> Links { get; set; }
        public virtual DbSet<NewsLog> NewsLog { get; set; }
        public virtual DbSet<VersionLog> VersionLog { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<ButtonStyle> ButtonStyle { get; set; }
        public virtual DbSet<CommandFile> CommandFile { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupBox> GroupBox { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProviderAccount> ProviderAccount { get; set; }
        public virtual DbSet<ProviderFile> ProviderFile { get; set; }
        public virtual DbSet<SettingUpdate> SettingUpdate { get; set; }
    }
}
