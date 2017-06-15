using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using tenorchem.Models;

namespace tenorchem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170614065945_User_mig")]
    partial class User_mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("tenorchem.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("isAdmin");

                    b.Property<string>("passWord");

                    b.Property<string>("userName");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
        }
    }
}
