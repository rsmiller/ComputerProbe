using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class PrinterDataConfiguration : IEntityTypeConfiguration<PrinterData>
    {
        public void Configure(EntityTypeBuilder<PrinterData> builder)
        {
            builder.ToTable("PrinterData");
            builder.HasKey(x => x.Id);
        }
    }
}
