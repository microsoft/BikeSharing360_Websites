using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BikeSharing.Web.Data;

namespace BikeSharing.Web.Data.Migrations
{
    [DbContext(typeof(BikeSharingContext))]
    [Migration("20170208155615_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BikeSharing.Web.Data.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Initial");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });
        }
    }
}
