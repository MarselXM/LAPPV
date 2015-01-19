using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;

namespace LV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // TODO : check if App-V is installed
            // keeping it really simple for POC purposes
            // reluctant to use Microsoft.Management.Infrastructure to avoid Win-RM dependency

            List<AppvApplication> appvApplications = new List<AppvApplication>();

            ManagementPath managementPath = new ManagementPath();
            managementPath.NamespacePath = @"\\.\ROOT\Appv";
            managementPath.ClassName = "AppvClientApplication";
            ManagementClass managementClass = new ManagementClass(managementPath);

            foreach (ManagementObject appvApplicationEntry in managementClass.GetInstances())
            {
                AppvApplication appvApp = new AppvApplication();
                appvApp.Id = appvApplicationEntry["ApplicationId"].ToString();
                appvApp.Name = appvApplicationEntry["Name"].ToString();
                appvApp.Target = appvApplicationEntry["TargetPath"].ToString();

                Guid packageId = new Guid();
                Guid versionId = new Guid();

                Guid.TryParse(appvApplicationEntry["PackageId"].ToString(), out packageId);
                Guid.TryParse(appvApplicationEntry["PackageVersionId"].ToString(), out versionId);

                appvApp.PackageId = packageId;
                appvApp.VersionId = versionId;

                appvApplications.Add(appvApp);
            }

            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Guid packageId = new Guid();
                Guid.TryParse(options.PackageId, out packageId);

                foreach (AppvApplication appvApp in appvApplications)
                {
                    if (appvApp.PackageId == packageId)
                    {
                        if (appvApp.Id.ToLower().Contains(options.ExeName.ToLower()))
                        {
                            Helpers.InvokeAppvApplication(appvApp, options.Arguments);
                        }
                    }
                }
            }
        }
    }
}
