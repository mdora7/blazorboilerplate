using BlazorBoilerplate.Infrastructure.Storage.Permissions;
using BlazorBoilerplate.Infrastructure.Storage.DataInterfaces;
using System.ComponentModel.DataAnnotations;
using System;

namespace BlazorBoilerplate.Infrastructure.Storage.DataModels
{
    
    public partial class ProductStats : IAuditable, ISoftDelete
    {
        public long Id { get; set; }
        public long Visits { get; set; }
        public DateTime? LastVisit { get; set; }

    }
}