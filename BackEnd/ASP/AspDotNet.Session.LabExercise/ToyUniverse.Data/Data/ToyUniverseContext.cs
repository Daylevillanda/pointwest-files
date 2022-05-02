using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToyUniverse.Data.Models;

#nullable disable

namespace ToyUniverse.Data.Data
{
    public partial class ToyUniverseContext : DbContext
    {
        public ToyUniverseContext()
        {
        }

        public ToyUniverseContext(DbContextOptions<ToyUniverseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PickOfMonth> PickOfMonths { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShippingMode> ShippingModes { get; set; }
        public virtual DbSet<ShippingRate> ShippingRates { get; set; }
        public virtual DbSet<Shopper> Shoppers { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Toy> Toys { get; set; }
        public virtual DbSet<ToyBrand> ToyBrands { get; set; }
        public virtual DbSet<VwOrderWrapper> VwOrderWrappers { get; set; }
        public virtual DbSet<Wrapper> Wrappers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CCategoryId)
                    .HasName("ct_pk");

                entity.ToTable("Category");

                entity.Property(e => e.CCategoryId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCategoryId")
                    .IsFixedLength(true);

                entity.Property(e => e.CCategory)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCategory")
                    .IsFixedLength(true);

                entity.Property(e => e.VDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("vDescription");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CCountryId)
                    .HasName("c_pk");

                entity.ToTable("Country");

                entity.Property(e => e.CCountryId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCountryId")
                    .IsFixedLength(true);

                entity.Property(e => e.CCountry)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cCountry")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.COrderNo)
                    .HasName("CO_PK");

                entity.Property(e => e.COrderNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cOrderNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CCartId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cCartId")
                    .IsFixedLength(true);

                entity.Property(e => e.COrderProcessed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cOrderProcessed")
                    .IsFixedLength(true);

                entity.Property(e => e.CShippingModeId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("cShippingModeId")
                    .IsFixedLength(true);

                entity.Property(e => e.CShopperId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cShopperId")
                    .IsFixedLength(true);

                entity.Property(e => e.DExpDelDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dExpDelDate");

                entity.Property(e => e.DOrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dOrderDate");

                entity.Property(e => e.MGiftWrapCharges)
                    .HasColumnType("money")
                    .HasColumnName("mGiftWrapCharges");

                entity.Property(e => e.MShippingCharges)
                    .HasColumnType("money")
                    .HasColumnName("mShippingCharges");

                entity.Property(e => e.MTotalCost)
                    .HasColumnType("money")
                    .HasColumnName("mTotalCost");

                entity.HasOne(d => d.CShippingMode)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CShippingModeId)
                    .HasConstraintName("FK__Orders__cShippin__3D5E1FD2");

                entity.HasOne(d => d.CShopper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CShopperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__cShopper__3C69FB99");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.COrderNo, e.CToyId })
                    .HasName("z_key");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.COrderNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cOrderNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CToyId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cToyId")
                    .IsFixedLength(true);

                entity.Property(e => e.CGiftWrap)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cGiftWrap")
                    .IsFixedLength(true);

                entity.Property(e => e.CWrapperId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cWrapperId")
                    .IsFixedLength(true);

                entity.Property(e => e.MToyCost)
                    .HasColumnType("money")
                    .HasColumnName("mToyCost");

                entity.Property(e => e.SiQty).HasColumnName("siQty");

                entity.Property(e => e.VMessage)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("vMessage");

                entity.HasOne(d => d.COrderNoNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.COrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__cOrde__403A8C7D");

                entity.HasOne(d => d.CToy)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CToyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__cToyI__412EB0B6");

                entity.HasOne(d => d.CWrapper)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CWrapperId)
                    .HasConstraintName("FK__OrderDeta__cWrap__4222D4EF");
            });

            modelBuilder.Entity<PickOfMonth>(entity =>
            {
                entity.HasKey(e => new { e.CToyId, e.SiMonth, e.IYear })
                    .HasName("POM_PK");

                entity.ToTable("PickOfMonth");

                entity.Property(e => e.CToyId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cToyId")
                    .IsFixedLength(true);

                entity.Property(e => e.SiMonth).HasColumnName("siMonth");

                entity.Property(e => e.IYear).HasColumnName("iYear");

                entity.Property(e => e.ITotalSold).HasColumnName("iTotalSold");

                entity.HasOne(d => d.CToy)
                    .WithMany(p => p.PickOfMonths)
                    .HasForeignKey(d => d.CToyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PickOfMon__cToyI__4CA06362");
            });

            modelBuilder.Entity<Recipient>(entity =>
            {
                entity.HasKey(e => e.COrderNo)
                    .HasName("RCP_PK");

                entity.ToTable("Recipient");

                entity.Property(e => e.COrderNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cOrderNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cCity")
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCountryId")
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cState")
                    .IsFixedLength(true);

                entity.Property(e => e.CZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cZipCode")
                    .IsFixedLength(true);

                entity.Property(e => e.VAddress)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vAddress");

                entity.Property(e => e.VFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vFirstName");

                entity.Property(e => e.VLastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vLastName");

                entity.HasOne(d => d.CCountry)
                    .WithMany(p => p.Recipients)
                    .HasForeignKey(d => d.CCountryId)
                    .HasConstraintName("FK__Recipient__cCoun__48CFD27E");

                entity.HasOne(d => d.COrderNoNavigation)
                    .WithOne(p => p.Recipient)
                    .HasForeignKey<Recipient>(d => d.COrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipient__cOrde__47DBAE45");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasKey(e => e.COrderNo)
                    .HasName("SHP_PK");

                entity.ToTable("Shipment");

                entity.Property(e => e.COrderNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cOrderNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CDeliveryStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cDeliveryStatus")
                    .IsFixedLength(true);

                entity.Property(e => e.DActualDeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dActualDeliveryDate");

                entity.Property(e => e.DShipmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dShipmentDate");

                entity.HasOne(d => d.COrderNoNavigation)
                    .WithOne(p => p.Shipment)
                    .HasForeignKey<Shipment>(d => d.COrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shipment__cOrder__44FF419A");
            });

            modelBuilder.Entity<ShippingMode>(entity =>
            {
                entity.HasKey(e => e.CModeId)
                    .HasName("spm_pk");

                entity.ToTable("ShippingMode");

                entity.Property(e => e.CModeId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("cModeId")
                    .IsFixedLength(true);

                entity.Property(e => e.CMode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cMode")
                    .IsFixedLength(true);

                entity.Property(e => e.IMaxDelDays).HasColumnName("iMaxDelDays");
            });

            modelBuilder.Entity<ShippingRate>(entity =>
            {
                entity.HasKey(e => new { e.CCountryId, e.CModeId })
                    .HasName("SR_PRK");

                entity.ToTable("ShippingRate");

                entity.Property(e => e.CCountryId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCountryID")
                    .IsFixedLength(true);

                entity.Property(e => e.CModeId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("cModeId")
                    .IsFixedLength(true);

                entity.Property(e => e.MRatePerPound)
                    .HasColumnType("money")
                    .HasColumnName("mRatePerPound");

                entity.HasOne(d => d.CCountry)
                    .WithMany(p => p.ShippingRates)
                    .HasForeignKey(d => d.CCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShippingR__cCoun__2E1BDC42");

                entity.HasOne(d => d.CMode)
                    .WithMany(p => p.ShippingRates)
                    .HasForeignKey(d => d.CModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShippingR__cMode__2F10007B");
            });

            modelBuilder.Entity<Shopper>(entity =>
            {
                entity.HasKey(e => e.CShopperId)
                    .HasName("s_id");

                entity.ToTable("Shopper");

                entity.Property(e => e.CShopperId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cShopperId")
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cCity")
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCountryId")
                    .IsFixedLength(true);

                entity.Property(e => e.CCreditCardNo)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("cCreditCardNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CPassword)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cPassword")
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cState")
                    .IsFixedLength(true);

                entity.Property(e => e.CZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cZipCode")
                    .IsFixedLength(true);

                entity.Property(e => e.DExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dExpiryDate");

                entity.Property(e => e.VAddress)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("vAddress");

                entity.Property(e => e.VCreditCardType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("vCreditCardType");

                entity.Property(e => e.VEmailId)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("vEmailId");

                entity.Property(e => e.VFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vFirstName");

                entity.Property(e => e.VLastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vLastName");

                entity.HasOne(d => d.CCountry)
                    .WithMany(p => p.Shoppers)
                    .HasForeignKey(d => d.CCountryId)
                    .HasConstraintName("FK__Shopper__cCountr__31EC6D26");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => new { e.CCartId, e.CToyId })
                    .HasName("SCHP_PK");

                entity.ToTable("ShoppingCart");

                entity.Property(e => e.CCartId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cCartId")
                    .IsFixedLength(true);

                entity.Property(e => e.CToyId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cToyId")
                    .IsFixedLength(true);

                entity.Property(e => e.SiQty).HasColumnName("siQty");

                entity.HasOne(d => d.CToy)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.CToyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__cToyI__398D8EEE");
            });

            modelBuilder.Entity<Toy>(entity =>
            {
                entity.HasKey(e => e.CToyId)
                    .HasName("t_id");

                entity.Property(e => e.CToyId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cToyId")
                    .IsFixedLength(true);

                entity.Property(e => e.CBrandId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cBrandId")
                    .IsFixedLength(true);

                entity.Property(e => e.CCategoryId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCategoryId")
                    .IsFixedLength(true);

                entity.Property(e => e.ImPhoto)
                    .HasColumnType("image")
                    .HasColumnName("imPhoto");

                entity.Property(e => e.MToyRate)
                    .HasColumnType("money")
                    .HasColumnName("mToyRate");

                entity.Property(e => e.SiLowerAge).HasColumnName("siLowerAge");

                entity.Property(e => e.SiToyQoh).HasColumnName("siToyQoh");

                entity.Property(e => e.SiToyWeight).HasColumnName("siToyWeight");

                entity.Property(e => e.SiUpperAge).HasColumnName("siUpperAge");

                entity.Property(e => e.VToyDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("vToyDescription");

                entity.Property(e => e.VToyImgPath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vToyImgPath");

                entity.Property(e => e.VToyName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vToyName");

                entity.HasOne(d => d.CBrand)
                    .WithMany(p => p.Toys)
                    .HasForeignKey(d => d.CBrandId)
                    .HasConstraintName("FK__Toys__cBrandId__36B12243");

                entity.HasOne(d => d.CCategory)
                    .WithMany(p => p.Toys)
                    .HasForeignKey(d => d.CCategoryId)
                    .HasConstraintName("FK__Toys__cCategoryI__35BCFE0A");
            });

            modelBuilder.Entity<ToyBrand>(entity =>
            {
                entity.HasKey(e => e.CBrandId)
                    .HasName("TB_pk");

                entity.ToTable("ToyBrand");

                entity.Property(e => e.CBrandId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cBrandId")
                    .IsFixedLength(true);

                entity.Property(e => e.CBrandName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cBrandName")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VwOrderWrapper>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwOrderWrapper");

                entity.Property(e => e.COrderNo)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cOrderNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CToyId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cToyId")
                    .IsFixedLength(true);

                entity.Property(e => e.MWrapperRate)
                    .HasColumnType("money")
                    .HasColumnName("mWrapperRate");

                entity.Property(e => e.SiQty).HasColumnName("siQty");

                entity.Property(e => e.VDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vDescription");
            });

            modelBuilder.Entity<Wrapper>(entity =>
            {
                entity.HasKey(e => e.CWrapperId)
                    .HasName("w_id");

                entity.ToTable("Wrapper");

                entity.Property(e => e.CWrapperId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cWrapperId")
                    .IsFixedLength(true);

                entity.Property(e => e.ImPhoto)
                    .HasColumnType("image")
                    .HasColumnName("imPhoto");

                entity.Property(e => e.MWrapperRate)
                    .HasColumnType("money")
                    .HasColumnName("mWrapperRate");

                entity.Property(e => e.VDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vDescription");

                entity.Property(e => e.VWrapperImgPath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vWrapperImgPath");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
