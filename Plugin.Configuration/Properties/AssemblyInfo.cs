using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: Guid("9160a0b6-1d31-4a8c-a256-eb1d933a29f4")]
[assembly: System.CLSCompliant(true)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://dkorablin.ru/project/Default.aspx?File=83")]
#else

[assembly: AssemblyTitle("Plugin.Configuration")]
[assembly: AssemblyDescription("UI for Plugins configuration")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Danila Korablin")]
[assembly: AssemblyProduct("Plugin.Configuration")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2012-2024")]

#endif