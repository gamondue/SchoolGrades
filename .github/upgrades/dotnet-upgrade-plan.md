# .NET 10 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade SchoolGrades\SchoolGrades.csproj
4. Upgrade TreeMpttBlazor\TreeMpttBlazor.shproj
5. Upgrade NUnitTests\NUnitDbTests.csproj
6. Upgrade TreeMpttManagement\TreeMpttManagement.shproj
7. Upgrade TreeMpttWinForms\TreeMpttWinForms.shproj
8. Upgrade TreeMpttWpf\TreeMpttWpf.shproj
9. Upgrade SharedWpf\SharedWpf.shproj
10. Upgrade SchoolGrades_WPF\SchoolGrades_WPF.csproj
11. Upgrade BusinessObjects\BusinessObjects.shproj
12. Upgrade SharedWinForms\SharedWinForms.shproj
13. Upgrade BusinessLayer\BusinessLayer.shproj
14. Upgrade DataLayer\DataLayer.shproj
15. Upgrade SharedItems\SharedItems.shproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

Table below contains projects that do belong to the dependency graph for selected projects and should not be included in the upgrade.

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|


### Aggregate NuGet packages modifications across all projects

No NuGet package modifications were reported by the analysis.

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### SchoolGrades modifications

Project properties changes:
  - Target framework should be changed from `net9.0-windows10.0.17763.0` to `net10.0-windows`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Resolve any API or SDK breaks after changing target framework.

#### TreeMpttBlazor modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Migrate any old project-style references to SDK-style if needed and address obsolete APIs.

#### NUnitDbTests modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Update test frameworks or test adapters if required for .NET 10.

#### TreeMpttManagement modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Ensure project references are valid and update package references as necessary.

#### TreeMpttWinForms modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Update Windows Forms usages if any breaking API changes appear.

#### TreeMpttWpf modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Update WPF references and ensure XAML builds correctly under .NET 10.

#### SharedWpf modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Verify shared WPF components build and run under .NET 10.

#### SchoolGrades_WPF modifications

Project properties changes:
  - Target framework should be changed from `net9.0-windows10.0.17763.0` to `net10.0-windows`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Address WPF-specific API updates and platform target changes.

#### BusinessObjects modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Verify business object serialization and compatibility.

#### SharedWinForms modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Validate WinForms components and update any deprecated APIs.

#### BusinessLayer modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Ensure business logic compiles and dependencies are updated.

#### DataLayer modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Update data access packages and verify EF/ADO behavior if applicable.

#### SharedItems modifications

Project properties changes:
  - Target framework should be changed from `.NETCore,Version=v4.5.1` to `net10.0`

NuGet packages changes:
  - None reported by analysis

Other changes:
  - Update any shared items and ensure compilation under net10.0.
