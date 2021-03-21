using Rocket.API;

namespace Mroczny.ClearPlugin
{
    public class ClearPluginConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor;

        public void LoadDefaults()
        {
            MessageColor = "magenta";
        }
    }
}
