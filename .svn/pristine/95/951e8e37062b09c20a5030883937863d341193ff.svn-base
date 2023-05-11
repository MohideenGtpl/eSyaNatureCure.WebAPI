using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eSyaNatureCure.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";
        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtAddrin> GtAddrin { get; set; }
        public virtual DbSet<GtEapcms> GtEapcms { get; set; }
        public virtual DbSet<GtEcapcd> GtEcapcd { get; set; }
        public virtual DbSet<GtEcapct> GtEcapct { get; set; }
        public virtual DbSet<GtEcclco> GtEcclco { get; set; }
        public virtual DbSet<GtEccnpl> GtEccnpl { get; set; }
        public virtual DbSet<GtEcdcbn> GtEcdcbn { get; set; }
        public virtual DbSet<GtEcdcsn> GtEcdcsn { get; set; }
        public virtual DbSet<GtEcsmsc> GtEcsmsc { get; set; }
        public virtual DbSet<GtEfopa1> GtEfopa1 { get; set; }
        public virtual DbSet<GtEfoppr> GtEfoppr { get; set; }
        public virtual DbSet<GtEfpbdt> GtEfpbdt { get; set; }
        public virtual DbSet<GtEfpbhd> GtEfpbhd { get; set; }
        public virtual DbSet<GtEfpbps> GtEfpbps { get; set; }
        public virtual DbSet<GtEfpbsl> GtEfpbsl { get; set; }
        public virtual DbSet<GtEfprdt> GtEfprdt { get; set; }
        public virtual DbSet<GtEfprpm> GtEfprpm { get; set; }
        public virtual DbSet<GtEssrbl> GtEssrbl { get; set; }
        public virtual DbSet<GtEssrbr> GtEssrbr { get; set; }
        public virtual DbSet<GtEssrcg> GtEssrcg { get; set; }
        public virtual DbSet<GtEssrcl> GtEssrcl { get; set; }
        public virtual DbSet<GtEssrgr> GtEssrgr { get; set; }
        public virtual DbSet<GtEssrms> GtEssrms { get; set; }
        public virtual DbSet<GtEssrty> GtEssrty { get; set; }
        public virtual DbSet<GtEuusms> GtEuusms { get; set; }
        public virtual DbSet<GtGpacms> GtGpacms { get; set; }
        public virtual DbSet<GtGpdept> GtGpdept { get; set; }
        public virtual DbSet<GtGpdopl> GtGpdopl { get; set; }
        public virtual DbSet<GtGpdopy> GtGpdopy { get; set; }
        public virtual DbSet<GtGpdorl> GtGpdorl { get; set; }
        public virtual DbSet<GtGpdorn> GtGpdorn { get; set; }
        public virtual DbSet<GtGpdpms> GtGpdpms { get; set; }
        public virtual DbSet<GtGpdpus> GtGpdpus { get; set; }
        public virtual DbSet<GtGppkbl> GtGppkbl { get; set; }
        public virtual DbSet<GtGppkcv> GtGppkcv { get; set; }
        public virtual DbSet<GtGppkdc> GtGppkdc { get; set; }
        public virtual DbSet<GtGppkms> GtGppkms { get; set; }
        public virtual DbSet<GtGppkop> GtGppkop { get; set; }
        public virtual DbSet<GtGppkpr> GtGppkpr { get; set; }
        public virtual DbSet<GtGppkwk> GtGppkwk { get; set; }
        public virtual DbSet<GtGprmbm> GtGprmbm { get; set; }
        public virtual DbSet<GtGprmop> GtGprmop { get; set; }
        public virtual DbSet<GtGprmrv> GtGprmrv { get; set; }
        public virtual DbSet<GtGprmty> GtGprmty { get; set; }
        public virtual DbSet<GtGptbah> GtGptbah { get; set; }
        public virtual DbSet<GtGptbav> GtGptbav { get; set; }
        public virtual DbSet<GtGptbdc> GtGptbdc { get; set; }
        public virtual DbSet<GtGptbkd> GtGptbkd { get; set; }
        public virtual DbSet<GtGptbkg> GtGptbkg { get; set; }
        public virtual DbSet<GtGptbkh> GtGptbkh { get; set; }
        public virtual DbSet<GtGptbkp> GtGptbkp { get; set; }
        public virtual DbSet<GtGptbpi> GtGptbpi { get; set; }
        public virtual DbSet<GtGptbpl> GtGptbpl { get; set; }
        public virtual DbSet<GtGptbrc> GtGptbrc { get; set; }
        public virtual DbSet<GtGptbrs> GtGptbrs { get; set; }
        public virtual DbSet<GtGptbsv> GtGptbsv { get; set; }
        public virtual DbSet<GtGpterm> GtGpterm { get; set; }
        public virtual DbSet<GtGptrgc> GtGptrgc { get; set; }
        public virtual DbSet<GtGptrgd> GtGptrgd { get; set; }
        public virtual DbSet<GtGptrgh> GtGptrgh { get; set; }
        public virtual DbSet<GtGptrmc> GtGptrmc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GtAddrin>(entity =>
            {
                entity.HasKey(e => new { e.Isdcode, e.AreaCode });

                entity.ToTable("GT_ADDRIN");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Taluk).HasMaxLength(150);
            });

            modelBuilder.Entity<GtEapcms>(entity =>
            {
                entity.HasKey(e => new { e.PatientTypeId, e.PatientCategoryId });

                entity.ToTable("GT_EAPCMS");

                entity.Property(e => e.PatientTypeId).HasColumnName("PatientTypeID");

                entity.Property(e => e.PatientCategoryId).HasColumnName("PatientCategoryID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ServiceWiseRateType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TreatmentAllowedIp).HasColumnName("TreatmentAllowedIP");

                entity.Property(e => e.TreatmentAllowedOp).HasColumnName("TreatmentAllowedOP");
            });

            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(15);

                entity.HasOne(d => d.CodeTypeNavigation)
                    .WithMany(p => p.GtEcapcd)
                    .HasForeignKey(d => d.CodeType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECAPCD_GT_ECAPCT");
            });

            modelBuilder.Entity<GtEcapct>(entity =>
            {
                entity.HasKey(e => e.CodeType);

                entity.ToTable("GT_ECAPCT");

                entity.Property(e => e.CodeType).ValueGeneratedNever();

                entity.Property(e => e.CodeTyepDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodeTypeControl)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcclco>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear });

                entity.ToTable("GT_ECCLCO");

                entity.Property(e => e.FinancialYear).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TillDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEccnpl>(entity =>
            {
                entity.HasKey(e => new { e.Isdcode, e.PlaceId });

                entity.ToTable("GT_ECCNPL");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PlaceName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<GtEcdcbn>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear, e.DocumentId });

                entity.ToTable("GT_ECDCBN");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcdcsn>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.DocumentId });

                entity.ToTable("GT_ECDCSN");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcsmsc>(entity =>
            {
                entity.HasKey(e => new { e.ReminderType, e.Smsid, e.ReferenceKey });

                entity.ToTable("GT_ECSMSC");

                entity.Property(e => e.ReminderType)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Smsid)
                    .HasColumnName("SMSID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEfopa1>(entity =>
            {
                entity.HasKey(e => new { e.RUhid, e.AddressId });

                entity.ToTable("GT_EFOPA1");

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.RUh)
                    .WithMany(p => p.GtEfopa1)
                    .HasForeignKey(d => d.RUhid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EFOPA1_GT_EFOPPR");
            });

            modelBuilder.Entity<GtEfoppr>(entity =>
            {
                entity.HasKey(e => e.RUhid);

                entity.ToTable("GT_EFOPPR");

                entity.Property(e => e.RUhid)
                    .HasColumnName("R_UHID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgeDd).HasColumnName("AgeDD");

                entity.Property(e => e.AgeMm).HasColumnName("AgeMM");

                entity.Property(e => e.AgeYy).HasColumnName("AgeYY");

                entity.Property(e => e.BillStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup).HasMaxLength(6);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EMailId)
                    .HasColumnName("eMailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsDobapplicable).HasColumnName("IsDOBApplicable");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasMaxLength(15);

                entity.Property(e => e.PatientLastVisitDate).HasColumnType("datetime");

                entity.Property(e => e.PatientStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationChargesValidTill).HasColumnType("datetime");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.SUhid).HasColumnName("S_UHID");

                entity.Property(e => e.Title).HasMaxLength(4);
            });

            modelBuilder.Entity<GtEfpbdt>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BillDocumentKey, e.SerialNumber });

                entity.ToTable("GT_EFPBDT");

                entity.Property(e => e.ApprovalOn).HasColumnType("datetime");

                entity.Property(e => e.ConcessionAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PayableByInsurance).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PayableByPatient).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ServiceChargeAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ServiceDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ServiceNarration).HasMaxLength(250);

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<GtEfpbhd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear, e.DocumentId, e.DocumentNumber });

                entity.ToTable("GT_EFPBHD");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.BillStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BillType)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ConcessionOn)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountInsurance).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DiscountPatient).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DocumentDate).HasColumnType("datetime");

                entity.Property(e => e.ExchangeRate).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FinalizerOn).HasColumnType("datetime");

                entity.Property(e => e.FinancePostedDate).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LocalCurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(250);

                entity.Property(e => e.NetBillAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Opnumber).HasColumnName("OPNumber");

                entity.Property(e => e.PrintBillKey)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RUhid).HasColumnName("R_UHID");

                entity.Property(e => e.RefundStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RoundOff).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalBillAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalConcessionAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalDiscountAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TransCurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEfpbps>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BillDocumentKey });

                entity.ToTable("GT_EFPBPS");

                entity.Property(e => e.AdvanceAdjAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AdvanceAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CancellationAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CollectedAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DuesSettledAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PostSettlConcession).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SettlConcession).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<GtEfpbsl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BillDocumentKey, e.SerialNumber });

                entity.ToTable("GT_EFPBSL");

                entity.Property(e => e.AcknowledgeDate).HasColumnType("datetime");

                entity.Property(e => e.AdvanceAdjAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Crnamount)
                    .HasColumnName("CRNAmount")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Drnamount)
                    .HasColumnName("DRNAmount")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PayableAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PayerPercentage).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.PayerScheme)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SubledgerType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEfprdt>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear, e.BookTypeId, e.VoucherNumber });

                entity.ToTable("GT_EFPRDT");

                entity.Property(e => e.BookTypeId).HasColumnName("BookTypeID");

                entity.Property(e => e.AdvanceAdjAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.BillDocumentKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CancelledAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CollectedAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ConcessionAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .HasColumnName("FormID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IsApproved)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(250);

                entity.Property(e => e.PaidorCollectedBy).HasMaxLength(100);

                entity.Property(e => e.RefVoucherDate).HasColumnType("datetime");

                entity.Property(e => e.RefVoucherKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.RefundReason).HasMaxLength(250);

                entity.Property(e => e.TotalNetAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.VoucherAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.VoucherDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.VoucherType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEfprpm>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.VoucherKey });

                entity.ToTable("GT_EFPRPM");

                entity.Property(e => e.VoucherKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.ApprovalNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Badate)
                    .HasColumnName("BADate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BankTransferDate).HasColumnType("datetime");

                entity.Property(e => e.BankTransferNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BareferenceNumber)
                    .HasColumnName("BAReferenceNumber")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BatchNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardExpiryDate)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CardHolderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CardTerminal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ChequeDate).HasColumnType("datetime");

                entity.Property(e => e.ChequeNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepositedAtBranch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepostedAtCity)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DepostedOn).HasColumnType("datetime");

                entity.Property(e => e.DraweeBank)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.MpreferenceDate)
                    .HasColumnName("MPReferenceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MpreferenceNumber)
                    .HasColumnName("MPReferenceNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceCharge).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TransferAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TransferFromBank)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TransferToBank)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEssrbl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ServiceId });

                entity.ToTable("GT_ESSRBL");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayPercentage).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.InternalServiceCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.NightLinePercentage).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.ServiceCost).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEssrbr>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ServiceId, e.RateType, e.CurrencyCode, e.EffectiveDate });

                entity.ToTable("GT_ESSRBR");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CurrencyCode).HasMaxLength(4);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IpbaseRate)
                    .HasColumnName("IPBaseRate")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.IsIprateWardwise)
                    .IsRequired()
                    .HasColumnName("IsIPRateWardwise")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OpbaseRate)
                    .HasColumnName("OPBaseRate")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ServiceRule)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEssrcg>(entity =>
            {
                entity.HasKey(e => e.ServiceClassId);

                entity.ToTable("GT_ESSRCG");

                entity.Property(e => e.ServiceClassId)
                    .HasColumnName("ServiceClassID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntSccode).HasColumnName("IntSCCode");

                entity.Property(e => e.IntScpattern)
                    .IsRequired()
                    .HasColumnName("IntSCPattern")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEssrcl>(entity =>
            {
                entity.HasKey(e => e.ServiceClassId);

                entity.ToTable("GT_ESSRCL");

                entity.Property(e => e.ServiceClassId)
                    .HasColumnName("ServiceClassID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ServiceClassDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ServiceGroupId).HasColumnName("ServiceGroupID");

                entity.HasOne(d => d.ServiceGroup)
                    .WithMany(p => p.GtEssrcl)
                    .HasForeignKey(d => d.ServiceGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESSRCL_GT_ESSRGR");
            });

            modelBuilder.Entity<GtEssrgr>(entity =>
            {
                entity.HasKey(e => e.ServiceGroupId);

                entity.ToTable("GT_ESSRGR");

                entity.Property(e => e.ServiceGroupId)
                    .HasColumnName("ServiceGroupID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ServiceCriteria)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ServiceGroupDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.GtEssrgr)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESSRGR_GT_ESSRTY");
            });

            modelBuilder.Entity<GtEssrms>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("GT_ESSRMS");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("ServiceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.InternalServiceCode).HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ServiceClassId).HasColumnName("ServiceClassID");

                entity.Property(e => e.ServiceCost).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ServiceDesc)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.ServiceShortDesc)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.ServiceClass)
                    .WithMany(p => p.GtEssrms)
                    .HasForeignKey(d => d.ServiceClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESSRMS_GT_ESSRCL");
            });

            modelBuilder.Entity<GtEssrty>(entity =>
            {
                entity.HasKey(e => e.ServiceTypeId);

                entity.ToTable("GT_ESSRTY");

                entity.Property(e => e.ServiceTypeId)
                    .HasColumnName("ServiceTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ServiceTypeDesc)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GtEuusms>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("GT_EUUSMS");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeactivationReason).HasMaxLength(50);

                entity.Property(e => e.EMailId)
                    .IsRequired()
                    .HasColumnName("eMailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangeDate).HasColumnType("datetime");

                entity.Property(e => e.LoginAttemptDate).HasColumnType("datetime");

                entity.Property(e => e.LoginDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(20);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OtpgeneratedDate)
                    .HasColumnName("OTPGeneratedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Otpnumber)
                    .HasColumnName("OTPNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.PhotoUrl)
                    .HasColumnName("PhotoURL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredLanguage).HasMaxLength(10);

                entity.Property(e => e.UserAuthenticatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserDeactivatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtGpacms>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.ToTable("GT_GPACMS");

                entity.Property(e => e.ActivityId).ValueGeneratedNever();

                entity.Property(e => e.ActivityDesc)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ScheduleType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtGpdept>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("GT_GPDEPT");

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentDesc)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtGpdopl>(entity =>
            {
                entity.HasKey(e => new { e.DonorType, e.PackageId });

                entity.ToTable("GT_GPDOPL");

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGpdopy>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.DonorId });

                entity.ToTable("GT_GPDOPY");

                entity.Property(e => e.DonorId).HasColumnName("DonorID");

                entity.Property(e => e.Comments).HasMaxLength(250);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfDonation).HasColumnType("datetime");

                entity.Property(e => e.DonationAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.VoucherKeyReference)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<GtGpdorl>(entity =>
            {
                entity.HasKey(e => e.DonorType);

                entity.ToTable("GT_GPDORL");

                entity.Property(e => e.DonorType).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountPercentage).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.DonationRangeFrom).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DonationRangeTo).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DonorTypeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DonorValidityInYears).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGpdorn>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.DonorId });

                entity.ToTable("GT_GPDORN");

                entity.Property(e => e.DonorId).HasColumnName("DonorID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AgeYy).HasColumnName("AgeYY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfRegistration).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.DonatedSoFar).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.DonorFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DonorLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DonorMiddleName).HasMaxLength(50);

                entity.Property(e => e.DonorRegistrationNo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EmailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredMobileNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTill).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtGpdpms>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("GT_GPDPMS");

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentDesc)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGpdpus>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.UserId });

                entity.ToTable("GT_GPDPUS");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGppkbl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.PackageId, e.BlockedPackageDate });

                entity.ToTable("GT_GPPKBL");

                entity.Property(e => e.BlockedPackageDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(250);

                entity.Property(e => e.TillDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtGppkcv>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.DayId, e.ActivityId });

                entity.ToTable("GT_GPPKCV");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ToTime).HasColumnName("ToTIme");
            });

            modelBuilder.Entity<GtGppkdc>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.RoomTypeId, e.OccupancyType, e.EffectiveDate });

                entity.ToTable("GT_GPPKDC");

                entity.Property(e => e.OccupancyType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TillDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtGppkms>(entity =>
            {
                entity.HasKey(e => e.PackageId);

                entity.ToTable("GT_GPPKMS");

                entity.Property(e => e.PackageId).ValueGeneratedNever();

                entity.Property(e => e.BookingApplicableFor)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.CheckInWeekDays)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PackageDesc)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ServiceDesc).HasMaxLength(150);
            });

            modelBuilder.Entity<GtGppkop>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.OptionType, e.SerialNumber });

                entity.ToTable("GT_GPPKOP");

                entity.Property(e => e.OptionType)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OptionValues)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<GtGppkpr>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.RoomTypeId, e.OccupancyType });

                entity.ToTable("GT_GPPKPR");

                entity.Property(e => e.OccupancyType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<GtGppkwk>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.CheckInWeekDays });

                entity.ToTable("GT_GPPKWK");

                entity.Property(e => e.CheckInWeekDays)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGprmbm>(entity =>
            {
                entity.HasKey(e => new { e.RoomTypeId, e.RoomNumber, e.BedNumber });

                entity.ToTable("GT_GPRMBM");

                entity.Property(e => e.RoomNumber).HasMaxLength(15);

                entity.Property(e => e.BedNumber).HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGprmop>(entity =>
            {
                entity.HasKey(e => new { e.RoomTypeId, e.OptionType, e.SerialNumber });

                entity.ToTable("GT_GPRMOP");

                entity.Property(e => e.OptionType)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OptionDesc).HasMaxLength(4000);

                entity.Property(e => e.OptionValues)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<GtGprmrv>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RoomTypeId, e.RoomNumber, e.BedNumber, e.EffectiveDate });

                entity.ToTable("GT_GPRMRV");

                entity.Property(e => e.RoomNumber).HasMaxLength(15);

                entity.Property(e => e.BedNumber).HasMaxLength(15);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TillDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtGprmty>(entity =>
            {
                entity.HasKey(e => e.RoomTypeId);

                entity.ToTable("GT_GPRMTY");

                entity.Property(e => e.RoomTypeId).ValueGeneratedNever();

                entity.Property(e => e.BedType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RoomTypeDesc)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SqFeet).HasMaxLength(15);
            });

            modelBuilder.Entity<GtGptbah>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Ipnumber, e.SerialNumber });

                entity.ToTable("GT_GPTBAH");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.ActivityDate).HasColumnType("datetime");

                entity.Property(e => e.ActivityStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RatingComments).HasMaxLength(250);
            });

            modelBuilder.Entity<GtGptbav>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Ipnumber, e.SerialNumber, e.Cltype, e.ClcontrolId });

                entity.ToTable("GT_GPTBAV");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.Cltype)
                    .HasColumnName("CLType")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ClcontrolId)
                    .HasColumnName("CLControlID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Value).IsRequired();

                entity.Property(e => e.ValueType)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<GtGptbdc>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BookingKey, e.GuestId, e.DepartmentId });

                entity.ToTable("GT_GPTBDC");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGptbkd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BookingKey, e.GuestId, e.SerialNo });

                entity.ToTable("GT_GPTBKD");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DocumentUrl)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificationNumber)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGptbkg>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BookingKey, e.GuestId });

                entity.ToTable("GT_GPTBKG");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.ActualCheckedInDate).HasColumnType("datetime");

                entity.Property(e => e.ActualCheckedOutDate).HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.AgeYy).HasColumnName("AgeYY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Place).HasMaxLength(100);

                entity.Property(e => e.Uhid).HasColumnName("UHID");
            });

            modelBuilder.Entity<GtGptbkh>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear, e.DocumentId, e.DocumentNumber })
                    .HasName("PK_GT_GPTBKH_1");

                entity.ToTable("GT_GPTBKH");

                entity.HasIndex(e => new { e.BusinessKey, e.BookingKey })
                    .HasName("IX_GT_GPTBKH")
                    .IsUnique();

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.BookingStatus)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.CouponId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MemberDiscountAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.MemberDiscountPercentage).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.NetPackageAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PackageDiscountAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.ReasonforCancellation).HasMaxLength(100);

                entity.Property(e => e.TotalDiscountAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalPackageAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TotalTaxAmount).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtGptbkp>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BookingKey, e.GuestId });

                entity.ToTable("GT_GPTBKP");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.BasePrice).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.BedNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OccupancyType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PackagePrice).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TaxAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.TaxPercentage).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.GtGptbkp)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_GPTBKP_GT_GPRMTY");

                entity.HasOne(d => d.B)
                    .WithMany(p => p.GtGptbkp)
                    .HasPrincipalKey(p => new { p.BusinessKey, p.BookingKey })
                    .HasForeignKey(d => new { d.BusinessKey, d.BookingKey })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_GPTBKP_GT_GPTBKH");
            });

            modelBuilder.Entity<GtGptbpi>(entity =>
            {
                entity.HasKey(e => e.BookingKey);

                entity.ToTable("GT_GPTBPI");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IntegrationMode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentSignature).HasMaxLength(500);

                entity.Property(e => e.ResponseMessage).IsUnicode(false);

                entity.Property(e => e.TransactionAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<GtGptbpl>(entity =>
            {
                entity.HasKey(e => new { e.BookingKey, e.SerialNo });

                entity.ToTable("GT_GPTBPL");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.RequestType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtGptbrc>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BookingKey, e.GuestId, e.SerialNumber });

                entity.ToTable("GT_GPTBRC");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.BedNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DocumentDate).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PrevBedNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PrevRoomNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<GtGptbrs>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BookingKey, e.SerialNumber });

                entity.ToTable("GT_GPTBRS");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PrevCheckInDate).HasColumnType("datetime");

                entity.Property(e => e.PrevCheckOutDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtGptbsv>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.BookingKey, e.SerialNumber });

                entity.ToTable("GT_GPTBSV");

                entity.Property(e => e.BookingKey).HasColumnType("numeric(25, 0)");

                entity.Property(e => e.ConcessionAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ServiceChargeAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ServiceDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<GtGpterm>(entity =>
            {
                entity.HasKey(e => new { e.PolicyType, e.SerialNumber });

                entity.ToTable("GT_GPTERM");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PolicyStatement).IsRequired();
            });

            modelBuilder.Entity<GtGptrgc>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.MemberId, e.CouponId });

                entity.ToTable("GT_GPTRGC");

                entity.Property(e => e.CouponId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BookingDiscountPercentage).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTill).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtGptrgd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.MemberId, e.SerialNumber });

                entity.ToTable("GT_GPTRGD");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DonationAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DonationDate).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ReceiptVoucherReference).HasMaxLength(50);
            });

            modelBuilder.Entity<GtGptrgh>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.MemberId });

                entity.ToTable("GT_GPTRGH");

                entity.Property(e => e.AgeYy).HasColumnName("AgeYY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DonationAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RegisteredDate).HasColumnType("datetime");

                entity.Property(e => e.Uhid).HasColumnName("UHID");
            });

            modelBuilder.Entity<GtGptrmc>(entity =>
            {
                entity.HasKey(e => e.MembershipType);

                entity.ToTable("GT_GPTRMC");

                entity.Property(e => e.MembershipType).ValueGeneratedNever();

                entity.Property(e => e.BookingDiscountPercentage).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DonationRangeFrom).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DonationRangeTo).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });
        }
    }
}
