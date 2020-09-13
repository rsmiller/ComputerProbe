using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class SoftwareDataConfiguration : IEntityTypeConfiguration<SoftwareData>
    {
        public void Configure(EntityTypeBuilder<SoftwareData> builder)
        {
            builder.ToTable("SoftwareData");
            builder.HasKey(x => x.Id);
        }
    }
}
