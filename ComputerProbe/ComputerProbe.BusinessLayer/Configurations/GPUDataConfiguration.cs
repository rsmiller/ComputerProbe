using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class GPUDataConfiguration : IEntityTypeConfiguration<GPUData>
    {
        public void Configure(EntityTypeBuilder<GPUData> builder)
        {
            builder.ToTable("GPUData");
            builder.HasKey(x => x.Id);
        }
    }
}
