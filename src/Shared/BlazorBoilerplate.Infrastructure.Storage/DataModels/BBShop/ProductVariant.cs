using BlazorBoilerplate.Infrastructure.Storage.DataInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Infrastructure.Storage.DataModels
{
    public partial class ProductVariant : IAuditable, ISoftDelete
    {
        public long ProductId { get; set; }
      
        public long EditionId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }

        public Product Product { get; set; }

        public ProductEdition Edition { get; set; }
    }
}
