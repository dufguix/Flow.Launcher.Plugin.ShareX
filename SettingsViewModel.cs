namespace Flow.Launcher.Plugin.ShareX_Flow_Plugin
{
    public class SettingsViewModel(Settings settings) : BaseModel
    {
        private readonly Settings Settings = settings;

        public string SharexPath
        {
            get => Settings.SharexPath;
            set
            {
                if (Settings.SharexPath != value)
                {
                    Settings.SharexPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool AutoClose
        {
            get => Settings.AutoClose;
            set
            {
                if (Settings.AutoClose != value)
                {
                    Settings.AutoClose = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}