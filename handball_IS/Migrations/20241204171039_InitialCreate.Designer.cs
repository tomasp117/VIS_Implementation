﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using handball_IS.Utils;

#nullable disable

namespace handball_IS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241204171039_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("handball_IS.Objects.Actors.super.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Person", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("handball_IS.Objects.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TournamentInstanceId")
                        .HasColumnType("int");

                    b.Property<bool>("VoitingOpen")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("TournamentInstanceId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("handball_IS.Objects.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("handball_IS.Objects.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("handball_IS.Objects.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("handball_IS.Objects.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssistantRefereeId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("MainRefereeId")
                        .HasColumnType("int");

                    b.Property<string>("Playground")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TimePlayed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssistantRefereeId");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("GroupId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("MainRefereeId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("handball_IS.Objects.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GoalCount")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("RedCardCount")
                        .HasColumnType("int");

                    b.Property<int>("SevenMeterGoalCount")
                        .HasColumnType("int");

                    b.Property<int>("SevenMeterMissCount")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("TwoMinPenaltyCount")
                        .HasColumnType("int");

                    b.Property<int>("YellowCardCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("handball_IS.Objects.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TournamentInstanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("TournamentInstanceId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("handball_IS.Objects.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("handball_IS.Objects.TournamentInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EditionNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentInstances");
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Admin", b =>
                {
                    b.HasBaseType("handball_IS.Objects.Actors.super.Person");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Coach", b =>
                {
                    b.HasBaseType("handball_IS.Objects.Actors.super.Person");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("goalkeeperVoteId")
                        .HasColumnType("int");

                    b.Property<int?>("playerVoteId")
                        .HasColumnType("int");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TeamId");

                    b.HasIndex("goalkeeperVoteId");

                    b.HasIndex("playerVoteId");

                    b.ToTable("Coach", (string)null);
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Recorder", b =>
                {
                    b.HasBaseType("handball_IS.Objects.Actors.super.Person");

                    b.ToTable("Recorder", (string)null);
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Referee", b =>
                {
                    b.HasBaseType("handball_IS.Objects.Actors.super.Person");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.ToTable("Referee", (string)null);
                });

            modelBuilder.Entity("handball_IS.Objects.Category", b =>
                {
                    b.HasOne("handball_IS.Objects.TournamentInstance", "TournamentInstance")
                        .WithMany("Categories")
                        .HasForeignKey("TournamentInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TournamentInstance");
                });

            modelBuilder.Entity("handball_IS.Objects.Event", b =>
                {
                    b.HasOne("handball_IS.Objects.Match", "Match")
                        .WithMany("Events")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("handball_IS.Objects.Group", b =>
                {
                    b.HasOne("handball_IS.Objects.Category", "Category")
                        .WithMany("Groups")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("handball_IS.Objects.Match", b =>
                {
                    b.HasOne("handball_IS.Objects.Actors.sub.Referee", "AssistantReferee")
                        .WithMany("AssistantRefereeMatches")
                        .HasForeignKey("AssistantRefereeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("handball_IS.Objects.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("handball_IS.Objects.Group", "Group")
                        .WithMany("Matches")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("handball_IS.Objects.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("handball_IS.Objects.Actors.sub.Referee", "MainReferee")
                        .WithMany("MainRefereeMatches")
                        .HasForeignKey("MainRefereeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AssistantReferee");

                    b.Navigation("AwayTeam");

                    b.Navigation("Group");

                    b.Navigation("HomeTeam");

                    b.Navigation("MainReferee");
                });

            modelBuilder.Entity("handball_IS.Objects.Player", b =>
                {
                    b.HasOne("handball_IS.Objects.Category", "Category")
                        .WithMany("Stats")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("handball_IS.Objects.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("handball_IS.Objects.Team", b =>
                {
                    b.HasOne("handball_IS.Objects.Club", "Club")
                        .WithMany("Teams")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("handball_IS.Objects.TournamentInstance", "TournamentInstance")
                        .WithMany("Teams")
                        .HasForeignKey("TournamentInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("TournamentInstance");
                });

            modelBuilder.Entity("handball_IS.Objects.TournamentInstance", b =>
                {
                    b.HasOne("handball_IS.Objects.Tournament", "Tournament")
                        .WithMany("Editions")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Admin", b =>
                {
                    b.HasOne("handball_IS.Objects.Actors.super.Person", null)
                        .WithOne()
                        .HasForeignKey("handball_IS.Objects.Actors.sub.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Coach", b =>
                {
                    b.HasOne("handball_IS.Objects.Category", "Category")
                        .WithMany("Voting")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("handball_IS.Objects.Actors.super.Person", null)
                        .WithOne()
                        .HasForeignKey("handball_IS.Objects.Actors.sub.Coach", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("handball_IS.Objects.Team", "Team")
                        .WithMany("Coaches")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("handball_IS.Objects.Player", "goalkeeperVote")
                        .WithMany()
                        .HasForeignKey("goalkeeperVoteId");

                    b.HasOne("handball_IS.Objects.Player", "playerVote")
                        .WithMany()
                        .HasForeignKey("playerVoteId");

                    b.Navigation("Category");

                    b.Navigation("Team");

                    b.Navigation("goalkeeperVote");

                    b.Navigation("playerVote");
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Recorder", b =>
                {
                    b.HasOne("handball_IS.Objects.Actors.super.Person", null)
                        .WithOne()
                        .HasForeignKey("handball_IS.Objects.Actors.sub.Recorder", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Referee", b =>
                {
                    b.HasOne("handball_IS.Objects.Actors.super.Person", null)
                        .WithOne()
                        .HasForeignKey("handball_IS.Objects.Actors.sub.Referee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("handball_IS.Objects.Category", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Stats");

                    b.Navigation("Voting");
                });

            modelBuilder.Entity("handball_IS.Objects.Club", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("handball_IS.Objects.Group", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("handball_IS.Objects.Match", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("handball_IS.Objects.Team", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("Coaches");

                    b.Navigation("HomeMatches");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("handball_IS.Objects.Tournament", b =>
                {
                    b.Navigation("Editions");
                });

            modelBuilder.Entity("handball_IS.Objects.TournamentInstance", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("handball_IS.Objects.Actors.sub.Referee", b =>
                {
                    b.Navigation("AssistantRefereeMatches");

                    b.Navigation("MainRefereeMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
