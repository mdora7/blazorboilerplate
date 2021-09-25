using BlazorBoilerplate.Infrastructure.Storage.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Infrastructure.Storage.DataModels
{
    public partial class ProductEdition : IAuditable, ISoftDelete
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
