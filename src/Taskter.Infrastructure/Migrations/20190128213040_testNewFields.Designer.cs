﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Migrations
{
    [DbContext(typeof(TaskterDbContext))]
    [Migration("20190128213040_testNewFields")]
    partial class testNewFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Taskter.Core.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tacta"
                        });
                });

            modelBuilder.Entity("Taskter.Core.Entities.Dummy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Dummies");
                });

            modelBuilder.Entity("Taskter.Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("Code")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Code = "OU742",
                            Name = "Tracker"
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 1,
                            Code = "MOL001",
                            Name = "Moleraj"
                        });
                });

            modelBuilder.Entity("Taskter.Core.Entities.ProjectTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Billable");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Billable = true,
                            Name = "Development",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            Billable = true,
                            Name = "Review",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 3,
                            Billable = false,
                            Name = "Marketing",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 4,
                            Billable = true,
                            Name = "Marketing",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 5,
                            Billable = true,
                            Name = "UI",
                            ProjectId = 2
                        },
                        new
                        {
                            Id = 6,
                            Billable = true,
                            Name = "Backend",
                            ProjectId = 2
                        },
                        new
                        {
                            Id = 7,
                            Billable = true,
                            Name = "Deployment",
                            ProjectId = 2
                        },
                        new
                        {
                            Id = 8,
                            Billable = false,
                            Name = "Audit",
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("Taskter.Core.Entities.ProjectTaskEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("DurationInMin");

                    b.Property<string>("Note");

                    b.Property<int>("ProjectTaskId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectTaskId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectTaskEntres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2019, 1, 28, 22, 30, 40, 265, DateTimeKind.Local).AddTicks(8704),
                            DurationInMin = 30,
                            Note = " Lorem ipsum dolor sit amet",
                            ProjectTaskId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2019, 1, 28, 22, 30, 40, 270, DateTimeKind.Local).AddTicks(5565),
                            DurationInMin = 90,
                            Note = " Lorem ipsum dolor sit amet",
                            ProjectTaskId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2019, 1, 28, 22, 30, 40, 270, DateTimeKind.Local).AddTicks(5613),
                            DurationInMin = 60,
                            Note = " Lorem ipsum dolor sit amet",
                            ProjectTaskId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2019, 1, 28, 22, 30, 40, 270, DateTimeKind.Local).AddTicks(5620),
                            DurationInMin = 90,
                            Note = " Lorem ipsum dolor sit amet",
                            ProjectTaskId = 4,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Taskter.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarURL")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Role")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarURL = "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg",
                            FirstName = "Nermin",
                            LastName = "Milisic",
                            Role = "Domar",
                            UserName = "nermin.milisic"
                        },
                        new
                        {
                            Id = 2,
                            AvatarURL = "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg",
                            FirstName = "Selim",
                            LastName = "Huskic",
                            Role = "Kotlovnicar",
                            UserName = "selim.huskic"
                        });
                });

            modelBuilder.Entity("Taskter.Core.Entities.UserProject", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ProjectId");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("UsersProjects");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ProjectId = 1
                        },
                        new
                        {
                            UserId = 2,
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("Taskter.Core.Entities.Project", b =>
                {
                    b.HasOne("Taskter.Core.Entities.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taskter.Core.Entities.ProjectTask", b =>
                {
                    b.HasOne("Taskter.Core.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taskter.Core.Entities.ProjectTaskEntry", b =>
                {
                    b.HasOne("Taskter.Core.Entities.ProjectTask", "ProjectTask")
                        .WithMany("ProjectsTaskEntries")
                        .HasForeignKey("ProjectTaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Taskter.Core.Entities.User", "User")
                        .WithMany("UsersProjectsTaskEntries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taskter.Core.Entities.UserProject", b =>
                {
                    b.HasOne("Taskter.Core.Entities.Project", "Project")
                        .WithMany("UsersProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Taskter.Core.Entities.User", "User")
                        .WithMany("UsersProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
