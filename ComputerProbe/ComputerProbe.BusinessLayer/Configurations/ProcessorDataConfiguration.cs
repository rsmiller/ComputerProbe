using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class ProcessorDataConfiguration : IEntityTypeConfiguration<ProcessorData>
    {
        public void Configure(EntityTypeBuilder<ProcessorData> builder)
        {
            builder.ToTable("ProcessorData");
            builder.HasKey(x => x.Id);
        }
    }
}
