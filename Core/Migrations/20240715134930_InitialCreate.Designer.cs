﻿// <auto-generated />
using System;
using Core.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(SoruHavuzuContext))]
    [Migration("20240715134930_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Data.Entity.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK___Library__3214EC075A9DE112");

                    b.HasIndex("MemberId");

                    b.ToTable("_Library_", null, t =>
                        {
                            t.HasTrigger("trg_ForLibraryMember_");

                            t.HasTrigger("trg_ForLibrarySettings_");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("Core.Data.Entity.LibraryMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasDefaultValue("Student");

                    b.HasKey("Id")
                        .HasName("PK___Library__3214EC07E9134980");

                    b.HasIndex("LibraryId");

                    b.HasIndex("MemberId");

                    b.ToTable("_LibraryMembers_", (string)null);
                });

            modelBuilder.Entity("Core.Data.Entity.LibrarySetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<DateTime?>("LastEditedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.Property<bool?>("Visibility")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id")
                        .HasName("PK___Library__3214EC07E775123C");

                    b.HasIndex("LibraryId");

                    b.ToTable("_LibrarySettings_", null, t =>
                        {
                            t.HasTrigger("trg_UpdateLibrarySettingsLastEditedDate");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("Core.Data.Entity.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Gender")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Surname")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK___Member___3214EC07E72715B9");

                    b.ToTable("_Member_", null, t =>
                        {
                            t.HasTrigger("trg_ForMemberSettings_");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("Core.Data.Entity.MemberSecurity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id")
                        .HasName("PK___MemberS__3214EC07C9F16973");

                    b.HasIndex("MemberId");

                    b.ToTable("_MemberSecurity_", (string)null);
                });

            modelBuilder.Entity("Core.Data.Entity.MemberSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Language")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasDefaultValue("tr");

                    b.Property<DateTime?>("LastEditedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasDefaultValue("student");

                    b.HasKey("Id")
                        .HasName("PK___MemberS__3214EC072B548DCF");

                    b.HasIndex("MemberId");

                    b.ToTable("_MemberSettings_", null, t =>
                        {
                            t.HasTrigger("trg_UpdateMemberSettingsLastEditedDate");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("Core.Data.Entity.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FalseAnswer2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FalseAnswer3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FalseAnswer4")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FalseAnswer5")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionImg")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("QuestionText")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Question");

                    b.Property<int?>("QuestionType")
                        .HasColumnType("int");

                    b.Property<string>("TrueAnswer")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK___Questio__3214EC0784C711DD");

                    b.HasIndex("LibraryId");

                    b.HasIndex("MemberId");

                    b.HasIndex("QuestionType");

                    b.ToTable("_Question_", null, t =>
                        {
                            t.HasTrigger("trg_QuestionSettings_");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("Core.Data.Entity.QuestionSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DeletedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(NULL)");

                    b.Property<DateTime?>("LastEditedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK___Questio__3214EC07EE5BF4AB");

                    b.HasIndex("QuestionId");

                    b.ToTable("_QuestionSettings_", null, t =>
                        {
                            t.HasTrigger("trg_UpdateLastEditedDate");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("Core.Data.Entity.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK___Questio__3214EC0743B8C0C0");

                    b.ToTable("_QuestionType_", (string)null);
                });

            modelBuilder.Entity("Core.Data.Entity.Library", b =>
                {
                    b.HasOne("Core.Data.Entity.Member", "Member")
                        .WithMany("Libraries")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK___Library___Membe__4316F928");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.Data.Entity.LibraryMember", b =>
                {
                    b.HasOne("Core.Data.Entity.Library", "Library")
                        .WithMany("LibraryMembers")
                        .HasForeignKey("LibraryId")
                        .HasConstraintName("FK___LibraryM__Libra__4F7CD00D");

                    b.HasOne("Core.Data.Entity.Member", "Member")
                        .WithMany("LibraryMembers")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK___LibraryM__Membe__5070F446");

                    b.Navigation("Library");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.Data.Entity.LibrarySetting", b =>
                {
                    b.HasOne("Core.Data.Entity.Library", "Library")
                        .WithMany("LibrarySettings")
                        .HasForeignKey("LibraryId")
                        .HasConstraintName("FK___LibraryS__Libra__45F365D3");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("Core.Data.Entity.MemberSecurity", b =>
                {
                    b.HasOne("Core.Data.Entity.Member", "Member")
                        .WithMany("MemberSecurities")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK___MemberSe__Membe__398D8EEE");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.Data.Entity.MemberSetting", b =>
                {
                    b.HasOne("Core.Data.Entity.Member", "Member")
                        .WithMany("MemberSettings")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK___MemberSe__Membe__3C69FB99");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Core.Data.Entity.Question", b =>
                {
                    b.HasOne("Core.Data.Entity.Library", "Library")
                        .WithMany("Questions")
                        .HasForeignKey("LibraryId")
                        .HasConstraintName("FK___Question__Libra__5629CD9C");

                    b.HasOne("Core.Data.Entity.Member", "Member")
                        .WithMany("Questions")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK___Question__Membe__5535A963");

                    b.HasOne("Core.Data.Entity.QuestionType", "QuestionTypeNavigation")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionType")
                        .HasConstraintName("FK___Question__Quest__571DF1D5");

                    b.Navigation("Library");

                    b.Navigation("Member");

                    b.Navigation("QuestionTypeNavigation");
                });

            modelBuilder.Entity("Core.Data.Entity.QuestionSetting", b =>
                {
                    b.HasOne("Core.Data.Entity.Question", "Question")
                        .WithMany("QuestionSettings")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK___Question__Quest__59FA5E80");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Core.Data.Entity.Library", b =>
                {
                    b.Navigation("LibraryMembers");

                    b.Navigation("LibrarySettings");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Core.Data.Entity.Member", b =>
                {
                    b.Navigation("Libraries");

                    b.Navigation("LibraryMembers");

                    b.Navigation("MemberSecurities");

                    b.Navigation("MemberSettings");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Core.Data.Entity.Question", b =>
                {
                    b.Navigation("QuestionSettings");
                });

            modelBuilder.Entity("Core.Data.Entity.QuestionType", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
