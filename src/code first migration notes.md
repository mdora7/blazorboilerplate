# Migrations notes

## Via the package manager console

### From scratch

 The following command execs same operation with dotnet CLI through the package manager console(VStudio) if want to.
It requires **Microsoft.EntityFrameworkCore.Tools** package if you haven't please install via NuGet Package Manager to **BlazorBoilerplate.Storage** project.
All commands needs to execute on **BlazorBoilerplate.Storage** project

```aspx-csharp
/* check if it's installed */
Get-Help about_EntityFrameworkCore


/* whatif shows db to drop but don't remove */
Drop-Database -context ApplicationDbContext -whatif

add-migration CreateLocalizationDb -context ApplicationDbContext -outputdir "Migrations/ApplicationDb"
add-migration CreateApplicationDb -context LocalizationDbContext -outputdir "Migrations/ApplicationDb"
add-migration CreateTenantStoreDb -context TenantStoreDbContext -outputdir "Migrations/ApplicationDb"
add-migration CreatePersistedGrantDb -context PersistedGrantDbContext -outputdir "Migrations/ApplicationDb"
add-migration CreateConfigurationDb -context ConfigurationDbContext -outputdir "Migrations/ApplicationDb"

update-database -Context ApplicationDbContext
update-database -Context LocalizationDbContext
update-database -Context TenantStoreDbContext
update-database -Context PersistedGrantDbContext
update-database -Context ConfigurationDbContext
```
