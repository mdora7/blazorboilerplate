using BlazorBoilerplate.Infrastructure.Storage.Permissions;
using BlazorBoilerplate.Infrastructure.Storage.DataInterfaces;
using System.ComponentModel.DataAnnotations;
using System;

namespace BlazorBoilerplate.Infrastructure.Storage.DataModels
{
    
    public partial class ProductStats : IAuditable, ISoftDelete
    {
        public int Id { get; set; }
        public int Visits { get; set; }
        public DateTime? LastVisit { get; set; }

    }
}