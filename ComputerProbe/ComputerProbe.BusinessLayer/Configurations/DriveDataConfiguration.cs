using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class DriveDataConfiguration : IEntityTypeConfiguration<DriveData>
    {
        public void Configure(EntityTypeBuilder<DriveData> builder)
        {
            builder.ToTable("DriveData");
            builder.HasKey(x => x.Id);
        }
    }
}
