using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Launcher.Plugin.ShareX_Flow_Plugin
{
    public record SharexCommand
    {
        public enum CategoryType { Upload, ScreenCapture, ScreenRecord, Tools, Other };

        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string Command { get; init; }
        public CategoryType Category { get; init; }
        public string IcoPath { get; init; }
    }
}
