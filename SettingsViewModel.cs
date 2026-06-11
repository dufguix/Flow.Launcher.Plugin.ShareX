namespace Flow.Launcher.Plugin.ShareX_Flow_Plugin
{
    public class SettingsViewModel(Settings settings) : BaseModel
    {
        private readonly Settings _settings = settings;

        public string SharexPath
        {
            get => _settings.SharexPath;
            set
            {
                if (_settings.SharexPath != value)
                {
                    _settings.SharexPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool AutoClose
        {
            get => _settings.AutoClose;
            set
            {
                if (_settings.AutoClose != value)
                {
                    _settings.AutoClose = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}