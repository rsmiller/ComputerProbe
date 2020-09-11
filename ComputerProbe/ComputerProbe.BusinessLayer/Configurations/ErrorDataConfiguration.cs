using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class ErrorDataConfiguration : IEntityTypeConfiguration<ErrorData>
    {
        public void Configure(EntityTypeBuilder<ErrorData> builder)
        {
            builder.ToTable("ErrorData");
            builder.HasKey(x => x.Id);
        }
    }
}
