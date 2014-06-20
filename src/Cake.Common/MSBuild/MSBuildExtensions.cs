﻿using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Common.MSBuild
{
    public static class MSBuildExtensions
    {
        [CakeScriptMethod]
        public static void MSBuild(this ICakeContext context, FilePath solution)
        {
            MSBuild(context, solution, settings => { });
        }

        [CakeScriptMethod]
        public static void MSBuild(this ICakeContext context, FilePath solution, Action<MSBuildSettings> configurator)
        {
            var settings = new MSBuildSettings(solution);
            configurator(settings);

            var runner = new MSBuildRunner(context.FileSystem, context.Environment);
            runner.Run(settings);
        }
    }
}
