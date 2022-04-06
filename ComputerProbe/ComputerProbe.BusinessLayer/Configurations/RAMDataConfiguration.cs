using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class RAMDataConfiguration : IEntityTypeConfiguration<RAMData>
    {
        public void Configure(EntityTypeBuilder<RAMData> builder)
        {
            builder.ToTable("RAMData");
            builder.HasKey(x => x.Id);
        }
    }
}
