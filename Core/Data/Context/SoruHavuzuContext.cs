using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Core.Data.Entity;

namespace Core.Data.Core;

public partial class SoruHavuzuContext : DbContext
{
    public SoruHavuzuContext()
    {
    }

    public SoruHavuzuContext(DbContextOptions<SoruHavuzuContext> options)
        : base(options)
    {
    }

    public static class DataSeeding
    {
        public static void Seed(DbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Count() == 0)
            {
                if (dbContext is SoruHavuzuContext)
                {
                    SoruHavuzuContext? context = dbContext as SoruHavuzuContext;

                    if (context != null)
                    {
                        if (context.Members.Count() == 0)
                        {
                            context.Members.AddRange(members);
                            context.SaveChanges();
                            context.MemberSecurities.AddRange(memberSecurities);
                            context.SaveChanges();
                        }

                        if (context.Libraries.Count() == 0)
                        {
                            context.Libraries.AddRange(libraries);
                            context.SaveChanges();
                        }

                        if (context.QuestionTypes.Count() == 0)
                        {
                            context.QuestionTypes.AddRange(questionType);
                            context.SaveChanges();
                        }

                        if (context.Questions.Count() == 0)
                        {
                            context.Questions.AddRange(questions);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        private static Member[] members = {
            new Member { Name = "Ahmet", Surname = "Yılmaz", Email = "ahmet.yilmaz@example.com", Gender = "Erkek", Birthday = new DateOnly(1990, 1, 15) },
            new Member { Name = "Ayşe", Surname = "Kara", Email = "ayse.kara@example.com", Gender = "Kadın", Birthday = new DateOnly(1985, 2, 20) },
            new Member { Name = "Mehmet", Surname = "Çelik", Email = "mehmet.celik@example.com", Gender = "Erkek", Birthday = new DateOnly(1992, 3, 10) },
            new Member { Name = "Fatma", Surname = "Demir", Email = "fatma.demir@example.com", Gender = "Kadın", Birthday = new DateOnly(1988, 4, 25) },
            new Member { Name = "Emre", Surname = "Şahin", Email = "emre.sahin@example.com", Gender = "Erkek", Birthday = new DateOnly(1995, 5, 30) },
            new Member { Name = "Zeynep", Surname = "Koç", Email = "zeynep.koc@example.com", Gender = "Kadın", Birthday = new DateOnly(1991, 6, 15) },
            new Member { Name = "Ali", Surname = "Öztürk", Email = "ali.ozturk@example.com", Gender = "Erkek", Birthday = new DateOnly(1993, 7, 20) },
            new Member { Name = "Hülya", Surname = "Yıldırım", Email = "hulya.yildirim@example.com", Gender = "Kadın", Birthday = new DateOnly(1987, 8, 5) },
            new Member { Name = "Mustafa", Surname = "Arslan", Email = "mustafa.arslan@example.com", Gender = "Erkek", Birthday = new DateOnly(1996, 9, 10) },
            new Member { Name = "Elif", Surname = "Güneş", Email = "elif.gunes@example.com", Gender = "Kadın", Birthday = new DateOnly(1989, 10, 25) },
            new Member { Name = "Kemal", Surname = "Bozkurt", Email = "kemal.bozkurt@example.com", Gender = "Erkek", Birthday = new DateOnly(1984, 11, 15) },
            new Member { Name = "Sibel", Surname = "Aydın", Email = "sibel.aydin@example.com", Gender = "Kadın", Birthday = new DateOnly(1997, 12, 20) },
            new Member { Name = "Burak", Surname = "Kılıç", Email = "burak.kilic@example.com", Gender = "Erkek", Birthday = new DateOnly(1991, 1, 10) },
            new Member { Name = "Nazan", Surname = "Aksoy", Email = "nazan.aksoy@example.com", Gender = "Kadın", Birthday = new DateOnly(1986, 2, 25) },
            new Member { Name = "Serkan", Surname = "Erdoğan", Email = "serkan.erdogan@example.com", Gender = "Erkek", Birthday = new DateOnly(1993, 3, 15) },
            new Member { Name = "Deniz", Surname = "Duman", Email = "deniz.duman@example.com", Gender = "Kadın", Birthday = new DateOnly(1992, 4, 20) },
            new Member { Name = "Eren", Surname = "Polat", Email = "eren.polat@example.com", Gender = "Erkek", Birthday = new DateOnly(1990, 5, 25) },
            new Member { Name = "Aylin", Surname = "Kaya", Email = "aylin.kaya@example.com", Gender = "Kadın", Birthday = new DateOnly(1988, 6, 30) },
            new Member { Name = "Cem", Surname = "Aktaş", Email = "cem.aktas@example.com", Gender = "Erkek", Birthday = new DateOnly(1994, 7, 25) },
            new Member { Name = "Büşra", Surname = "Çetin", Email = "busra.cetin@example.com", Gender = "Kadın", Birthday = new DateOnly(1995, 8, 15) }
        };

        private static MemberSecurity[] memberSecurities = {
            new MemberSecurity { MemberId = 1, Password = "password123" },
            new MemberSecurity { MemberId = 2, Password = "password456" },
            new MemberSecurity { MemberId = 3, Password = "password789" },
            new MemberSecurity { MemberId = 4, Password = "password321" },
            new MemberSecurity { MemberId = 5, Password = "password654" },
            new MemberSecurity { MemberId = 6, Password = "password987" },
            new MemberSecurity { MemberId = 7, Password = "password111" },
            new MemberSecurity { MemberId = 8, Password = "password222" },
            new MemberSecurity { MemberId = 9, Password = "password333" },
            new MemberSecurity { MemberId = 10, Password = "password444" },
            new MemberSecurity { MemberId = 11, Password = "password555" },
            new MemberSecurity { MemberId = 12, Password = "password666" },
            new MemberSecurity { MemberId = 13, Password = "password777" },
            new MemberSecurity { MemberId = 14, Password = "password888" },
            new MemberSecurity { MemberId = 15, Password = "password999" },
            new MemberSecurity { MemberId = 16, Password = "password000" },
            new MemberSecurity { MemberId = 17, Password = "password112" },
            new MemberSecurity { MemberId = 18, Password = "password223" },
            new MemberSecurity { MemberId = 19, Password = "password334" },
            new MemberSecurity { MemberId = 20, Password = "password445" }
        };

        private static Library[] libraries = {
            new Library { MemberId = 1, Name = "TYT Matematik Soruları", Description = "TYT (Temel Yeterlilik Testi) sınavı için matematik soruları.", Category = "Eğitim" },
            new Library { MemberId = 3, Name = "Veri Güvenliği Soruları", Description = "Bilgisayar güvenliği ve veri güvenliği alanında sorular.", Category = "Teknoloji" },
            new Library { MemberId = 5, Name = "İş Sağlığı ve Güvenliği Soruları", Description = "İş yerlerindeki sağlık ve güvenlikle ilgili sorular.", Category = "İş Sağlığı" },
            new Library { MemberId = 7, Name = "KPSS Türkçe Soruları", Description = "KPSS (Kamu Personeli Seçme Sınavı) sınavı için Türkçe soruları.", Category = "Eğitim" },
            new Library { MemberId = 9, Name = "Mühendislik Problemleri", Description = "Çeşitli mühendislik alanlarında karşılaşılan problemler.", Category = "Teknoloji" }
        };
        private static Question[] questions = {
            new Question { MemberId = 1, LibraryId = 1, QuestionType = 1, QuestionText = "2+2 kaç eder?", TrueAnswer = "4", FalseAnswer2 = "3", FalseAnswer3 = "5", FalseAnswer4 = "6", FalseAnswer5 = "7", QuestionImg = null },
            new Question { MemberId = 1, LibraryId = 1, QuestionType = 1, QuestionText = "3x3 kaç eder?", TrueAnswer = "9", FalseAnswer2 = "6", FalseAnswer3 = "8", FalseAnswer4 = "12", FalseAnswer5 = "10", QuestionImg = null },
            new Question { MemberId = 1, LibraryId = 1, QuestionType = 2, QuestionText = "5 çift sayıdır.", TrueAnswer = "Yanlış", FalseAnswer2 = "Doğru", QuestionImg = null },
            new Question { MemberId = 1, LibraryId = 1, QuestionType = 3, QuestionText = "7x7 kaç eder? ___", TrueAnswer = "49", QuestionImg = null },
            new Question { MemberId = 1, LibraryId = 1, QuestionType = 1, QuestionText = "12/4 kaç eder?", TrueAnswer = "3", FalseAnswer2 = "2", FalseAnswer3 = "4", FalseAnswer4 = "5", FalseAnswer5 = "6", QuestionImg = null },

            // Veri Güvenliği Soruları
            new Question { MemberId = 3, LibraryId = 2, QuestionType = 1, QuestionText = "Veri şifreleme nedir?", TrueAnswer = "Veriyi gizlemek", FalseAnswer2 = "Veriyi silmek", FalseAnswer3 = "Veriyi kopyalamak", FalseAnswer4 = "Veriyi taşımak", FalseAnswer5 = "Veriyi değiştirmek", QuestionImg = null },
            new Question { MemberId = 3, LibraryId = 2, QuestionType = 2, QuestionText = "Güçlü bir şifre en az 8 karakterden oluşmalıdır.", TrueAnswer = "Doğru", FalseAnswer2 = "Yanlış", QuestionImg = null },
            new Question { MemberId = 3, LibraryId = 2, QuestionType = 3, QuestionText = "Veri güvenliğinde en önemli unsur ______`dir.", TrueAnswer = "Gizlilik", QuestionImg = null },
            new Question { MemberId = 3, LibraryId = 2, QuestionType = 1, QuestionText = "Kötü amaçlı yazılım nedir?", TrueAnswer = "Zararlı yazılım", FalseAnswer2 = "Antivirüs", FalseAnswer3 = "Güvenlik duvarı", FalseAnswer4 = "Yedekleme", FalseAnswer5 = "Şifreleme", QuestionImg = null },
            new Question { MemberId = 3, LibraryId = 2, QuestionType = 1, QuestionText = "Veri ihlali nedir?", TrueAnswer = "Yetkisiz erişim", FalseAnswer2 = "Veri yedekleme", FalseAnswer3 = "Veri analizi", FalseAnswer4 = "Veri depolama", FalseAnswer5 = "Veri silme", QuestionImg = null },

            // İş Sağlığı ve Güvenliği Soruları
            new Question { MemberId = 5, LibraryId = 3, QuestionType = 1, QuestionText = "İş kazası nedir?", TrueAnswer = "İş sırasında meydana gelen kaza", FalseAnswer2 = "Evde meydana gelen kaza", FalseAnswer3 = "Trafik kazası", FalseAnswer4 = "Doğal afet", FalseAnswer5 = "Spor kazası", QuestionImg = null },
            new Question { MemberId = 5, LibraryId = 3, QuestionType = 2, QuestionText = "İş sağlığı ve güvenliği eğitimi zorunlu değildir.", TrueAnswer = "Yanlış", FalseAnswer2 = "Doğru", QuestionImg = null },
            new Question { MemberId = 5, LibraryId = 3, QuestionType = 3, QuestionText = "İş yerlerinde güvenlik ______ ile sağlanır.", TrueAnswer = "Tedbirler", QuestionImg = null },
            new Question { MemberId = 5, LibraryId = 3, QuestionType = 1, QuestionText = "Yangın söndürme cihazı nasıl kullanılır?", TrueAnswer = "Çek, nişan al, sık", FalseAnswer2 = "Çek, vur, koş", FalseAnswer3 = "Yak, kaç, bekle", FalseAnswer4 = "Sık, bırak, sakla", FalseAnswer5 = "Sık, yak, söndür", QuestionImg = null },
            new Question { MemberId = 5, LibraryId = 3, QuestionType = 1, QuestionText = "İş güvenliği şapkası ne amaçla kullanılır?", TrueAnswer = "Baş yaralanmalarını önlemek", FalseAnswer2 = "Ayak koruması", FalseAnswer3 = "Eldiven olarak", FalseAnswer4 = "Göz koruması", FalseAnswer5 = "Kulak koruması", QuestionImg = null },

            // KPSS Türkçe Soruları
            new Question { MemberId = 7, LibraryId = 4, QuestionType = 1, QuestionText = "Aşağıdaki cümledeki anlatım bozukluğunu bulun.", TrueAnswer = "Yanlış kelime kullanımı", FalseAnswer2 = "Eksik özne", FalseAnswer3 = "Yanlış zaman kullanımı", FalseAnswer4 = "Eksik yüklem", FalseAnswer5 = "Eksik nesne", QuestionImg = null },
            new Question { MemberId = 7, LibraryId = 4, QuestionType = 2, QuestionText = "Fiil kökünden türeyen sözcüklere fiilimsi denir.", TrueAnswer = "Doğru", FalseAnswer2 = "Yanlış", QuestionImg = null },
            new Question { MemberId = 7, LibraryId = 4, QuestionType = 3, QuestionText = "______ zamiri cümlede nesne görevi yapar.", TrueAnswer = "O", QuestionImg = null },
            new Question { MemberId = 7, LibraryId = 4, QuestionType = 1, QuestionText = "Eş anlamlısı en fazla olan kelime hangisidir?", TrueAnswer = "Güzel", FalseAnswer2 = "İyi", FalseAnswer3 = "Kötü", FalseAnswer4 = "Çirkin", FalseAnswer5 = "Büyük", QuestionImg = null },
            new Question { MemberId = 7, LibraryId = 4, QuestionType = 1, QuestionText = "Şiirde ahenk hangi unsurlarla sağlanır?", TrueAnswer = "Ölçü ve kafiye", FalseAnswer2 = "Renk ve çizgi", FalseAnswer3 = "Duygu ve düşünce", FalseAnswer4 = "Şekil ve yapı", FalseAnswer5 = "Ses ve anlam", QuestionImg = null },

            // Mühendislik Problemleri
            new Question { MemberId = 9, LibraryId = 5, QuestionType = 1, QuestionText = "Newtonun ikinci yasası nedir?", TrueAnswer = "F=ma", FalseAnswer2 = "E=mc^2", FalseAnswer3 = "a^2+b^2=c^2", FalseAnswer4 = "V=IR", FalseAnswer5 = "PV=nRT", QuestionImg = null },
            new Question { MemberId = 9, LibraryId = 5, QuestionType = 2, QuestionText = "Stres ve gerilme aynı anlama gelir.", TrueAnswer = "Yanlış", FalseAnswer2 = "Doğru", QuestionImg = null },
            new Question { MemberId = 9, LibraryId = 5, QuestionType = 3, QuestionText = "Direnç ______ birimiyle ölçülür.", TrueAnswer = "Ohm", QuestionImg = null },
            new Question { MemberId = 9, LibraryId = 5, QuestionType = 1, QuestionText = "Ohm Kanunu nedir?", TrueAnswer = "V=IR", FalseAnswer2 = "F=ma", FalseAnswer3 = "E=mc^2", FalseAnswer4 = "P=IV", FalseAnswer5 = "Q=mcΔT", QuestionImg = null },
            new Question { MemberId = 9, LibraryId = 5, QuestionType = 1, QuestionText = "Isı transferi hangi yollarla gerçekleşir?", TrueAnswer = "İletim, konveksiyon, radyasyon", FalseAnswer2 = "Elektrik, manyetik, kimyasal", FalseAnswer3 = "Difüzyon, ozmoz, filtrasyon", FalseAnswer4 = "Kondüksiyon, difüzyon, radyasyon", FalseAnswer5 = "İyonlaşma, rekombinasyon, buharlaşma", QuestionImg = null },
        };
        private static QuestionType[] questionType = {
            new QuestionType { Type = "Çoktan seçmeli" },
            new QuestionType { Type = "True/False" },
            new QuestionType { Type = "Boşluk doldurma" }
        };

    }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<LibraryMember> LibraryMembers { get; set; }

    public virtual DbSet<LibrarySetting> LibrarySettings { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberSecurity> MemberSecurities { get; set; }

    public virtual DbSet<MemberSetting> MemberSettings { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionSetting> QuestionSettings { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    public static readonly ILoggerFactory MyLoggerFactoryt = LoggerFactory.Create(builder => { builder.AddConsole(); });
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseLoggerFactory(MyLoggerFactoryt)
        .UseSqlServer("connectionString");

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         // DB Yolunu tanimladik.
    //         string db = Path.Combine(Directory.GetCurrentDirectory(), "..", "Core", "AppData", "QuestionPool.db");

    //         optionsBuilder
    //             .UseLoggerFactory(MyLoggerFactoryt)
    //             .UseSqlite($"Data Source={db}");
    //     }
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___Library__3214EC075A9DE112");

            entity.ToTable("_Library_", tb =>
                {
                    tb.HasTrigger("trg_ForLibraryMember_");
                    tb.HasTrigger("trg_ForLibrarySettings_");
                });

            entity.Property(e => e.Category).IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);

            entity.HasOne(d => d.Member).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK___Library___Membe__4316F928");
        });

        modelBuilder.Entity<LibraryMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___Library__3214EC07E9134980");

            entity.ToTable("_LibraryMembers_");

            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime");
            entity.Property(e => e.Role)
                .IsUnicode(false)
                .HasDefaultValue("Student");

            entity.HasOne(d => d.Library).WithMany(p => p.LibraryMembers)
                .HasForeignKey(d => d.LibraryId)
                .HasConstraintName("FK___LibraryM__Libra__4F7CD00D");

            entity.HasOne(d => d.Member).WithMany(p => p.LibraryMembers)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK___LibraryM__Membe__5070F446");
        });

        modelBuilder.Entity<LibrarySetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___Library__3214EC07E775123C");

            entity.ToTable("_LibrarySettings_", tb => tb.HasTrigger("trg_UpdateLibrarySettingsLastEditedDate"));

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime");
            entity.Property(e => e.LastEditedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Visibility).HasDefaultValue(true);

            entity.HasOne(d => d.Library).WithMany(p => p.LibrarySettings)
                .HasForeignKey(d => d.LibraryId)
                .HasConstraintName("FK___LibraryS__Libra__45F365D3");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___Member___3214EC07E72715B9");

            entity.ToTable("_Member_", tb => tb.HasTrigger("trg_ForMemberSettings_"));

            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Gender).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Surname).IsUnicode(false);
        });

        modelBuilder.Entity<MemberSecurity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___MemberS__3214EC07C9F16973");

            entity.ToTable("_MemberSecurity_");

            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.Member).WithMany(p => p.MemberSecurities)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK___MemberSe__Membe__398D8EEE");
        });

        modelBuilder.Entity<MemberSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___MemberS__3214EC072B548DCF");

            entity.ToTable("_MemberSettings_", tb => tb.HasTrigger("trg_UpdateMemberSettingsLastEditedDate"));

            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Language)
                .IsUnicode(false)
                .HasDefaultValue("tr");
            entity.Property(e => e.LastEditedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Role)
                .IsUnicode(false)
                .HasDefaultValue("student");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberSettings)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK___MemberSe__Membe__3C69FB99");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___Questio__3214EC0784C711DD");

            entity.ToTable("_Question_", tb => tb.HasTrigger("trg_QuestionSettings_"));

            entity.Property(e => e.FalseAnswer2).IsUnicode(false);
            entity.Property(e => e.FalseAnswer3).IsUnicode(false);
            entity.Property(e => e.FalseAnswer4).IsUnicode(false);
            entity.Property(e => e.FalseAnswer5).IsUnicode(false);
            entity.Property(e => e.QuestionText)
                .IsUnicode(false)
                .HasColumnName("Question");
            entity.Property(e => e.QuestionImg).IsUnicode(false);
            entity.Property(e => e.TrueAnswer).IsUnicode(false);

            entity.HasOne(d => d.Library).WithMany(p => p.Questions)
                .HasForeignKey(d => d.LibraryId)
                .HasConstraintName("FK___Question__Libra__5629CD9C");

            entity.HasOne(d => d.Member).WithMany(p => p.Questions)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK___Question__Membe__5535A963");

            entity.HasOne(d => d.QuestionTypeNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuestionType)
                .HasConstraintName("FK___Question__Quest__571DF1D5");
        });

        modelBuilder.Entity<QuestionSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___Questio__3214EC07EE5BF4AB");

            entity.ToTable("_QuestionSettings_", tb => tb.HasTrigger("trg_UpdateLastEditedDate"));

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime");
            entity.Property(e => e.LastEditedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionSettings)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK___Question__Quest__59FA5E80");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK___Questio__3214EC0743B8C0C0");

            entity.ToTable("_QuestionType_");

            entity.Property(e => e.Type).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
