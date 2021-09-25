using SourceGenerators;
using System;

namespace BlazorBoilerplate.Shared.Models
{
    public partial class ProductFilter : QueryParameters
    {
        [AutoNotify]
        private int? _id;
    }
}
