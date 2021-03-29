using Rocket.API;

namespace Mroczny.ClearPlugin
{
    public class ClearPluginConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public bool AutoClearVehiclesEnabled { get; set; }
        public float AutoClearVehiclesIntervalSeconds { get; set; }

        public void LoadDefaults()
        {
            MessageColor = "magenta";
            AutoClearVehiclesEnabled = true;
            AutoClearVehiclesIntervalSeconds = 300f;
        }
    }
}
