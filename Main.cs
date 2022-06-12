using Flow.Launcher.Plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Flow.Launcher.Plugin.ShareX_Flow_Plugin
{
    public class ShareX_Flow_Plugin : IPlugin
    {
        private PluginInitContext _context;
        private String _sharexExe;
        private String _sharexPath;
        private List<SharexCommand> _sharexCommands;

        public void Init(PluginInitContext context)
        {
            _context = context;
            _sharexExe = "ShareX.exe";
            _sharexPath = "C:\\Program Files\\ShareX\\";
            _sharexCommands = new List<SharexCommand>
            {
                new SharexCommand {Title = "FileUpload", SubTitle="Upload file", Command="-FileUpload", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "FolderUpload", SubTitle="Upload folder", Command="-FolderUpload", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "ClipboardUpload", SubTitle="Upload from clipboard", Command="-ClipboardUpload", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "ClipboardUploadWithContentViewer", SubTitle="Upload from clipboard with content viewer", Command="-ClipboardUploadWithContentViewer", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "UploadText", SubTitle="Upload text", Command="-UploadText", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "UploadURL", SubTitle="Upload from URL", Command="-UploadURL", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "DragDropUpload", SubTitle="Drag and drop upload", Command="-DragDropUpload", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "ShortenURL", SubTitle="Shorten URL", Command="-ShortenURL", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "TweetMessage", SubTitle="Tweet message", Command="-TweetMessage", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "StopUploads", SubTitle="Stop all active uploads", Command="-StopUploads", Category=SharexCommand.Cat.Upload, IcoPath=""},
                new SharexCommand {Title = "PrintScreen", SubTitle="Capture entire screen", Command="-PrintScreen", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "ActiveWindow", SubTitle="Capture active window", Command="-ActiveWindow", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "ActiveMonitor", SubTitle="Capture active monitor", Command="-ActiveMonitor", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "RectangleRegion", SubTitle="Capture region", Command="-RectangleRegion", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "RectangleLight", SubTitle="Capture region (Light)", Command="-RectangleLight", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "RectangleTransparent", SubTitle="Capture region (Transparent)", Command="-RectangleTransparent", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "CustomRegion", SubTitle="Capture pre configured region", Command="-CustomRegion", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "LastRegion", SubTitle="Capture last region", Command="-LastRegion", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "ScrollingCapture", SubTitle="Scrolling capture", Command="-ScrollingCapture", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "AutoCapture", SubTitle="Auto capture", Command="-AutoCapture", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "StartAutoCapture", SubTitle="Start auto capture using last region", Command="-StartAutoCapture", Category=SharexCommand.Cat.ScreenCapture, IcoPath=""},
                new SharexCommand {Title = "ScreenRecorder", SubTitle="Start/Stop screen recording", Command="-ScreenRecorder", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "ScreenRecorderActiveWindow", SubTitle="Start/Stop screen recording using active window region", Command="-ScreenRecorderActiveWindow", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "ScreenRecorderCustomRegion", SubTitle="Start/Stop screen recording using pre configured region", Command="-ScreenRecorderCustomRegion", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "StartScreenRecorder", SubTitle="Start/Stop screen recording using last region", Command="-StartScreenRecorder", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "ScreenRecorderGIF", SubTitle="Start/Stop screen recording (GIF)", Command="-ScreenRecorderGIF", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "ScreenRecorderGIFActiveWindow", SubTitle="Start/Stop screen recording (GIF) using active window region", Command="-ScreenRecorderGIFActiveWindow", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "ScreenRecorderGIFCustomRegion", SubTitle="Start/Stop screen recording (GIF) using pre configured region", Command="-ScreenRecorderGIFCustomRegion", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "StartScreenRecorderGIF", SubTitle="Start/Stop screen recording (GIF) using last region", Command="-StartScreenRecorderGIF", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "StopScreenRecording", SubTitle="Stop screen recording", Command="-StopScreenRecording", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "AbortScreenRecording", SubTitle="Abort screen recording", Command="-AbortScreenRecording", Category=SharexCommand.Cat.ScreenRecord, IcoPath=""},
                new SharexCommand {Title = "ColorPicker", SubTitle="Color picker", Command="-ColorPicker", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "ScreenColorPicker", SubTitle="Screen color picker", Command="-ScreenColorPicker", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "Ruler", SubTitle="Ruler", Command="-Ruler", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "ImageEditor", SubTitle="Image editor", Command="-ImageEditor", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "ImageEffects", SubTitle="Image effects", Command="-ImageEffects", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "ImageViewer", SubTitle="", Command="-ImageViewer", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "ImageCombiner", SubTitle="Image combiner", Command="-ImageCombiner", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "ImageSplitter", SubTitle="Image splitter", Command="-ImageSplitter", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "ImageThumbnailer", SubTitle="Image thumbnailer", Command="-ImageThumbnailer", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "VideoConverter", SubTitle="Video converter", Command="-VideoConverter", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "VideoThumbnailer", SubTitle="Video thumbnailer", Command="-VideoThumbnailer", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "OCR", SubTitle="Text capture (OCR)", Command="-OCR", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "QRCode", SubTitle="QR code", Command="-QRCode", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "QRCodeDecodeFromScreen", SubTitle="QR code (Decode from screen)", Command="-QRCodeDecodeFromScreen", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "HashCheck", SubTitle="Hash check", Command="-HashCheck", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "IndexFolder", SubTitle="Index folder", Command="-IndexFolder", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "ClipboardViewer", SubTitle="Clipboard viewer", Command="-ClipboardViewer", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "BorderlessWindow", SubTitle="", Command="-BorderlessWindow", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "InspectWindow", SubTitle="Inspect window", Command="-InspectWindow", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "MonitorTest", SubTitle="Monitor test", Command="-MonitorTest", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "DNSChanger", SubTitle="DNS changer", Command="-DNSChanger", Category=SharexCommand.Cat.Tools, IcoPath=""},
                new SharexCommand {Title = "DisableHotkeys", SubTitle="Disable/Enable hotkeys", Command="-DisableHotkeys", Category=SharexCommand.Cat.Other, IcoPath=""},
                new SharexCommand {Title = "OpenMainWindow", SubTitle="Open main window", Command="-OpenMainWindow", Category=SharexCommand.Cat.Other, IcoPath=""},
                new SharexCommand {Title = "OpenScreenshotsFolder", SubTitle="Open screenshots folder", Command="-OpenScreenshotsFolder", Category=SharexCommand.Cat.Other, IcoPath=""},
                new SharexCommand {Title = "OpenHistory", SubTitle="Open history window", Command="-OpenHistory", Category=SharexCommand.Cat.Other, IcoPath=""},
                new SharexCommand {Title = "OpenImageHistory", SubTitle="Open image history window", Command="-OpenImageHistory", Category=SharexCommand.Cat.Other, IcoPath=""},
                new SharexCommand {Title = "ToggleActionsToolbar", SubTitle="Toggle actions toolbar", Command="-ToggleActionsToolbar", Category=SharexCommand.Cat.Other, IcoPath=""},
                new SharexCommand {Title = "ToggleTrayMenu", SubTitle="Toggle tray menu", Command="-ToggleTrayMenu", Category=SharexCommand.Cat.Other, IcoPath=""},
                new SharexCommand {Title = "ExitShareX", SubTitle="Exit ShareX", Command="-ExitShareX", Category=SharexCommand.Cat.Other, IcoPath=""}
            };

        }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();
            foreach (var command in _sharexCommands.FindAll(shxCmd => shxCmd.Title.Contains(query.Search, StringComparison.OrdinalIgnoreCase)))
            {
                var result = new Result
                {
                    Title = command.Title,
                    SubTitle = command.SubTitle + " | " + command.Category.ToString() + " category",
                    IcoPath = String.IsNullOrEmpty(command.IcoPath) ? "icon.png" : command.IcoPath,
                    Action = e => RunCommand(e, command.Command)
                };
                results.Add(result);
            }
            return results;
        }

        private bool RunCommand(ActionContext e, String cmd)
        {
            //_context.API.ShowMsg("Start ShareX : " + cmd);
            try
            {
                var startInfo = new ProcessStartInfo(_sharexExe, cmd);
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = _sharexPath;
                Process.Start(startInfo);
            }
            catch (Win32Exception w32Ex)
            {
                // If a command needs elevation and the user hits "No" on the UAC dialog an exception is thrown
                // with this message. We want to ignore this exception but throw any others.
                if (w32Ex.Message != "The operation was canceled by the user")
                    throw;
            }
            catch (FormatException)
            {
                _context.API.ShowMsg("There was a problem. Please check the arguments format for the command.");
            }
            return true;
        }

    }
}