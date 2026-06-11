using Flow.Launcher.Plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace Flow.Launcher.Plugin.ShareX_Flow_Plugin
{
    public class ShareX_Flow_Plugin : IPlugin, ISettingProvider
    {
        private PluginInitContext _context;
        private string _sharexExe;
        private Settings _settings;
        private SettingsViewModel _viewModel;
        private List<SharexCommand> _sharexCommands;

        public void Init(PluginInitContext context)
        {
            _context = context;
            _settings = context.API.LoadSettingJsonStorage<Settings>();
            _viewModel = new SettingsViewModel(_settings);
            _sharexExe = "ShareX.exe";
            _sharexCommands =
            [
                new() {Title = "FileUpload", SubTitle="Upload file", Command="-FileUpload", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "FolderUpload", SubTitle="Upload folder", Command="-FolderUpload", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "ClipboardUpload", SubTitle="Upload from clipboard", Command="-ClipboardUpload", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "ClipboardUploadWithContentViewer", SubTitle="Upload from clipboard with content viewer", Command="-ClipboardUploadWithContentViewer", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "UploadText", SubTitle="Upload text", Command="-UploadText", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "UploadURL", SubTitle="Upload from URL", Command="-UploadURL", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "DragDropUpload", SubTitle="Drag and drop upload", Command="-DragDropUpload", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "ShortenURL", SubTitle="Shorten URL", Command="-ShortenURL", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "StopUploads", SubTitle="Stop all active uploads", Command="-StopUploads", Category=SharexCommand.CategoryType.Upload, IcoPath=""},
                new() {Title = "PrintScreen", SubTitle="Capture entire screen", Command="-PrintScreen", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "ActiveWindow", SubTitle="Capture active window", Command="-ActiveWindow", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "CustomWindow", SubTitle="Capture custom window", Command="-CustomWindow", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "ActiveMonitor", SubTitle="Capture active monitor", Command="-ActiveMonitor", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "RectangleRegion", SubTitle="Capture region", Command="-RectangleRegion", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "RectangleLight", SubTitle="Capture region (Light)", Command="-RectangleLight", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "RectangleTransparent", SubTitle="Capture region (Transparent)", Command="-RectangleTransparent", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "CustomRegion", SubTitle="Capture pre configured region", Command="-CustomRegion", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "LastRegion", SubTitle="Capture last region", Command="-LastRegion", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "ScrollingCapture", SubTitle="Scrolling capture", Command="-ScrollingCapture", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "AutoCapture", SubTitle="Auto capture", Command="-AutoCapture", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "StartAutoCapture", SubTitle="Start auto capture using last region", Command="-StartAutoCapture", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "StopAutoCapture", SubTitle="Stop auto capture", Command="-StopAutoCapture", Category=SharexCommand.CategoryType.ScreenCapture, IcoPath=""},
                new() {Title = "ScreenRecorder", SubTitle="Start/Stop screen recording", Command="-ScreenRecorder", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "ScreenRecorderActiveWindow", SubTitle="Start/Stop screen recording using active window region", Command="-ScreenRecorderActiveWindow", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "ScreenRecorderCustomRegion", SubTitle="Start/Stop screen recording using pre configured region", Command="-ScreenRecorderCustomRegion", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "StartScreenRecorder", SubTitle="Start/Stop screen recording using last region", Command="-StartScreenRecorder", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "ScreenRecorderGIF", SubTitle="Start/Stop screen recording (GIF)", Command="-ScreenRecorderGIF", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "ScreenRecorderGIFActiveWindow", SubTitle="Start/Stop screen recording (GIF) using active window region", Command="-ScreenRecorderGIFActiveWindow", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "ScreenRecorderGIFCustomRegion", SubTitle="Start/Stop screen recording (GIF) using pre configured region", Command="-ScreenRecorderGIFCustomRegion", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "StartScreenRecorderGIF", SubTitle="Start/Stop screen recording (GIF) using last region", Command="-StartScreenRecorderGIF", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "StopScreenRecording", SubTitle="Stop screen recording", Command="-StopScreenRecording", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "PauseScreenRecording", SubTitle="Pause screen recording", Command="-PauseScreenRecording", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "AbortScreenRecording", SubTitle="Abort screen recording", Command="-AbortScreenRecording", Category=SharexCommand.CategoryType.ScreenRecord, IcoPath=""},
                new() {Title = "ColorPicker", SubTitle="Color picker", Command="-ColorPicker", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ScreenColorPicker", SubTitle="Screen color picker", Command="-ScreenColorPicker", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "Ruler", SubTitle="Ruler", Command="-Ruler", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "PinToScreen", SubTitle="Pin to screen", Command="-PinToScreen", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "PinToScreenFromScreen", SubTitle="Pin to screen from screen", Command="-PinToScreenFromScreen", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "PinToScreenFromClipboard", SubTitle="Pin to screen from clipboard", Command="-PinToScreenFromClipboard", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "PinToScreenFromFile", SubTitle="Pin to screen from file", Command="-PinToScreenFromFile", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "PinToScreenCloseAll", SubTitle="Pin to screen close all", Command="-PinToScreenCloseAll", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ImageEditor", SubTitle="Image editor", Command="-ImageEditor", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ImageBeautifier", SubTitle="Image beautifier", Command="-ImageBeautifier", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ImageEffects", SubTitle="Image effects", Command="-ImageEffects", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ImageViewer", SubTitle="", Command="-ImageViewer", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ImageCombiner", SubTitle="Image combiner", Command="-ImageCombiner", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ImageSplitter", SubTitle="Image splitter", Command="-ImageSplitter", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ImageThumbnailer", SubTitle="Image thumbnailer", Command="-ImageThumbnailer", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "VideoConverter", SubTitle="Video converter", Command="-VideoConverter", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "VideoThumbnailer", SubTitle="Video thumbnailer", Command="-VideoThumbnailer", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "AnalyzeImage", SubTitle="Analyze image", Command="-AnalyzeImage", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "OCR", SubTitle="Text capture (OCR)", Command="-OCR", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "QRCode", SubTitle="QR code", Command="-QRCode", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "QRCodeDecodeFromScreen", SubTitle="QR code (Decode from screen)", Command="-QRCodeDecodeFromScreen", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "QRCodeScanRegion", SubTitle="QR code scan region", Command="-QRCodeScanRegion", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "HashCheck", SubTitle="Hash check", Command="-HashCheck", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "Metadata", SubTitle="Metadata", Command="-Metadata", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "StripMetadata", SubTitle="Strip metadata", Command="-StripMetadata", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "IndexFolder", SubTitle="Index folder", Command="-IndexFolder", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ClipboardViewer", SubTitle="Clipboard viewer", Command="-ClipboardViewer", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "BorderlessWindow", SubTitle="", Command="-BorderlessWindow", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ActiveWindowBorderless", SubTitle="Active window borderless", Command="-ActiveWindowBorderless", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "ActiveWindowTopMost", SubTitle="Active window top most", Command="-ActiveWindowTopMost", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "InspectWindow", SubTitle="Inspect window", Command="-InspectWindow", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "MonitorTest", SubTitle="Monitor test", Command="-MonitorTest", Category=SharexCommand.CategoryType.Tools, IcoPath=""},
                new() {Title = "DisableHotkeys", SubTitle="Disable/Enable hotkeys", Command="-DisableHotkeys", Category=SharexCommand.CategoryType.Other, IcoPath=""},
                new() {Title = "OpenMainWindow", SubTitle="Open main window", Command="-OpenMainWindow", Category=SharexCommand.CategoryType.Other, IcoPath=""},
                new() {Title = "OpenScreenshotsFolder", SubTitle="Open screenshots folder", Command="-OpenScreenshotsFolder", Category=SharexCommand.CategoryType.Other, IcoPath=""},
                new() {Title = "OpenHistory", SubTitle="Open history window", Command="-OpenHistory", Category=SharexCommand.CategoryType.Other, IcoPath=""},
                new() {Title = "OpenImageHistory", SubTitle="Open image history window", Command="-OpenImageHistory", Category=SharexCommand.CategoryType.Other, IcoPath=""},
                new() {Title = "ToggleActionsToolbar", SubTitle="Toggle actions toolbar", Command="-ToggleActionsToolbar", Category=SharexCommand.CategoryType.Other, IcoPath=""},
                new() {Title = "ToggleTrayMenu", SubTitle="Toggle tray menu", Command="-ToggleTrayMenu", Category=SharexCommand.CategoryType.Other, IcoPath=""},
                new() {Title = "ExitShareX", SubTitle="Exit ShareX", Command="-ExitShareX", Category=SharexCommand.CategoryType.Other, IcoPath=""}
            ];
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

        public Control CreateSettingPanel()
        {
            return new SettingsView(_viewModel);
        }

        private bool RunCommand(ActionContext _, string cmd)
        {
            try
            {
                var extraArgs = " -silent";
                if (_settings.AutoClose)
                {
                    extraArgs += " -autoclose";
                }
                var startInfo = new ProcessStartInfo(_sharexExe, cmd + extraArgs)
                {
                    UseShellExecute = true,
                    WorkingDirectory = _settings.SharexPath
                };
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