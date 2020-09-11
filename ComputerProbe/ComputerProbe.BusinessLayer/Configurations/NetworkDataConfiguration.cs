using ComputerProbe.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Configurations
{
    public class NetworkDataConfiguration : IEntityTypeConfiguration<NetworkData>
    {
        public void Configure(EntityTypeBuilder<NetworkData> builder)
        {
            builder.ToTable("NetworkData");
            builder.HasKey(x => x.Id);
        }
    }
}
