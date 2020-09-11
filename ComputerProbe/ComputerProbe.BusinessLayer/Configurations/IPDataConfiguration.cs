using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class IPDataConfiguration : IEntityTypeConfiguration<IPData>
    {
        public void Configure(EntityTypeBuilder<IPData> builder)
        {
            builder.ToTable("IPData");
            builder.HasKey(x => x.Id);
        }
    }
}
