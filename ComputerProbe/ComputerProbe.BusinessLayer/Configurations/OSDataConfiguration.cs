using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class OSDataConfiguration : IEntityTypeConfiguration<OSData>
    {
        public void Configure(EntityTypeBuilder<OSData> builder)
        {
            builder.ToTable("OSData");
            builder.HasKey(x => x.Id);
        }
    }
}
