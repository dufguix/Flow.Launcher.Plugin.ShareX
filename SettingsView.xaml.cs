using System.Windows.Controls;
using System.Windows;

namespace Flow.Launcher.Plugin.ShareX_Flow_Plugin
{
    public partial class SettingsView : UserControl
    {
        private readonly SettingsViewModel _viewModel;

        public SettingsView(SettingsViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void BrowseSharexPath(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFolderDialog
            {
                InitialDirectory = _viewModel.SharexPath,
                Title = "Select ShareX Installation Folder"
            };

            if (dialog.ShowDialog() == true)
            {
                _viewModel.SharexPath = dialog.FolderName;
            }
        }
    }
}