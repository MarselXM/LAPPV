using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LV
{
    class AppvApplication
    {
        internal string Id { get; set; }
        internal Guid PackageId { get; set; }
        internal Guid VersionId { get; set; }
        internal string Name { get; set; }
        internal string Target { get; set; }
    }
}
