using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd_Assignment2.Models
{
    public partial class AdventureWorks2017Context : DbContext
    {
        public AdventureWorks2017Context()
        {
        }

        public AdventureWorks2017Context(DbContextOptions<AdventureWorks2017Context> options)
            : base(options)
        {
        }

        public virtual DbSet<NikitaConnectionService> NikitaConnectionServices { get; set; }
        public virtual DbSet<NikitaOperationReturnTypeLookup> NikitaOperationReturnTypeLookups { get; set; }
        public virtual DbSet<NikitaOverrideLookup> NikitaOverrideLookups { get; set; }
        public virtual DbSet<NikitaParameterTypeLookup> NikitaParameterTypeLookups { get; set; }
        public virtual DbSet<NikitaProtocolTypeLookup> NikitaProtocolTypeLookups { get; set; }
        public virtual DbSet<NikitaVerbLookup> NikitaVerbLookups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.230;Initial Catalog=AdventureWorks2017;User ID=trainee2022;Password=trainee@2022");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NikitaConnectionService>(entity =>
            {
                entity.ToTable("nikita_Connection_Service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdvanceTracking).HasColumnName("advance_tracking");

                entity.Property(e => e.IsOperationReturnNullable).HasColumnName("is_operation_return_nullable");

                entity.Property(e => e.IsParameterTypeNullable).HasColumnName("is_parameter_type_nullable");

                entity.Property(e => e.OperationListType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("operation_list_type");

                entity.Property(e => e.OperationName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("operation_name");

                entity.Property(e => e.OperationReturnTypeId).HasColumnName("operation_return_type_id");

                entity.Property(e => e.OverrideId).HasColumnName("Override_id");

                entity.Property(e => e.ParameterListType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("parameter_list_type");

                entity.Property(e => e.ParameterName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("parameter_name");

                entity.Property(e => e.ParameterTypeId).HasColumnName("parameter_type_id");

                entity.Property(e => e.ProtocolTypeId).HasColumnName("protocol_type_id");

                entity.Property(e => e.ServiceDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("service_description");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("service_name");

                entity.Property(e => e.VerbId).HasColumnName("verb_id");

                entity.HasOne(d => d.OperationReturnType)
                    .WithMany(p => p.NikitaConnectionServiceOperationReturnTypes)
                    .HasForeignKey(d => d.OperationReturnTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nikita_Co__opera__5DA0D232");

                entity.HasOne(d => d.Override)
                    .WithMany(p => p.NikitaConnectionServiceOverrides)
                    .HasForeignKey(d => d.OverrideId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nikita_Co__Overr__5F891AA4");

                entity.HasOne(d => d.ParameterType)
                    .WithMany(p => p.NikitaConnectionServiceParameterTypes)
                    .HasForeignKey(d => d.ParameterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nikita_Co__param__607D3EDD");

                entity.HasOne(d => d.ProtocolType)
                    .WithMany(p => p.NikitaConnectionServices)
                    .HasForeignKey(d => d.ProtocolTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nikita_Co__proto__5CACADF9");

                entity.HasOne(d => d.Verb)
                    .WithMany(p => p.NikitaConnectionServiceVerbs)
                    .HasForeignKey(d => d.VerbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nikita_Co__verb___5E94F66B");
            });

            modelBuilder.Entity<NikitaOperationReturnTypeLookup>(entity =>
            {
                entity.ToTable("nikita_operation_return_type_lookup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OperationReturnType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("operation_return_type");
            });

            modelBuilder.Entity<NikitaOverrideLookup>(entity =>
            {
                entity.ToTable("nikita_Override_lookup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OperationReturnType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("operation_return_type");
            });

            modelBuilder.Entity<NikitaParameterTypeLookup>(entity =>
            {
                entity.ToTable("nikita_parameter_type_lookup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OperationReturnType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("operation_return_type");
            });

            modelBuilder.Entity<NikitaProtocolTypeLookup>(entity =>
            {
                entity.ToTable("nikita_protocol_type_lookup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ProtocolType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("protocol_type");
            });

            modelBuilder.Entity<NikitaVerbLookup>(entity =>
            {
                entity.ToTable("nikita_verb_lookup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OperationReturnType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("operation_return_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
