namespace LV
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CommandLine;

    class Options
    {
        [Option('p', "packageid", Required = true)]
        public string PackageId { get; set; }

        [Option('e', "exe", Required = true)]
        public string ExeName { get; set; }

        [Option('a', "arguments")]
        public string Arguments { get; set; }
    }
}
