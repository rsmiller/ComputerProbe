using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class ProbeDataConfiguration : IEntityTypeConfiguration<ProbeData>
    {
        public void Configure(EntityTypeBuilder<ProbeData> builder)
        {
            builder.ToTable("ProbeData");
            builder.HasKey(x => x.Id);
        }
    }
}
