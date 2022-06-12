using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow.Launcher.Plugin.ShareX_Flow_Plugin
{
    class SharexCommand
    {
        public enum Cat {Upload, ScreenCapture, ScreenRecord, Tools, Other};

        public String Title
        { get; set; }

        public String SubTitle
        { get; set; }

        public String Command
        { get; set; }

        public Cat Category
        { get; set; }

        public String IcoPath
        { get; set; }
    }
}
