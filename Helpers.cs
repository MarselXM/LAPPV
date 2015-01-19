using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LV
{
    class Helpers
    {
        internal static void InvokeAppvApplication(AppvApplication appvApplication, string arguments)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = @"C:\ProgramData\App-V\" + appvApplication.PackageId + @"\" + appvApplication.VersionId + @"\" + appvApplication.Target.Replace("[{AppVPackageRoot}]", "Root");

                if (!string.IsNullOrEmpty(arguments))
                {
                    process.StartInfo.Arguments = arguments;
                }

                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
