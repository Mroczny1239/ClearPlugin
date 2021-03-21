using Rocket.API;

namespace Mroczny.ClearPlugin
{
    public class ClearPluginConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }

        public void LoadDefaults()
        {
            MessageColor = "magenta";
        }
    }
}
