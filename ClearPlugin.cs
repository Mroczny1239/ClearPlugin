using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Mroczny.ClearPlugin
{
    public class ClearPlugin : RocketPlugin<ClearPluginConfiguration>
    {
        public static ClearPlugin Instance { get; private set; }
        const string Creator = "Mroczny";
        public Color MessageColor { get; set; }

        protected override void Load()
        {
            Instance = this;
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, Color.green);

            Logger.LogWarning($"Plugin made by {Creator}");
            Logger.LogWarning($"{Name} {Assembly.GetName().Version} has been loaded!");
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.LogWarning($"{Name} has been unloaded!");
        }

        public override TranslationList DefaultTranslations => new TranslationList(){
            {"ClearInventorySuccess","Inventory cleared!"},
            {"ClearInventoryPlayerSuccess","Player's {0} inventory has been cleared!"},
            {"PlayerNotFound","Player not found!"},
            {"ClearItemsSuccess","All items cleared!"},
            {"ClearVehiclesSuccess","All vehicles cleared!"}
        };
    }
}
