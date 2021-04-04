using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;
using SDG.Unturned;

namespace Mroczny.ClearPlugin
{
    public class ClearPlugin : RocketPlugin<ClearPluginConfiguration>
    {
        public static ClearPlugin Instance { get; private set; }
        const string Version = "1.0.7";
        const string Creator = "Mroczny";
        public Color MessageColor { get; set; }

        protected override void Load()
        {
            Instance = this;
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, Color.green);
            Logger.LogWarning($"{Name} {Version} has been loaded!");
            Logger.LogWarning($"Plugin Made By {Creator}");
            if (Configuration.Instance.AutoClearVehiclesEnabled)
            {
                InvokeRepeating("ClearVehicles", Configuration.Instance.AutoClearVehiclesDuration, Configuration.Instance.AutoClearVehiclesDuration);
            }
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.LogWarning($"{Name} has been unloaded!");
            CancelInvoke("ClearVehicles");
        }

        public override TranslationList DefaultTranslations => new TranslationList(){
            {"ClearInventorySuccess","Inventory cleared!"},
            {"ClearInventoryPlayerSuccess","Player's {0} inventory has been cleared!"},
            {"PlayerNotFound","Player not found!"},
            {"ClearItemsSuccess","All items cleared!"},
            {"ClearVehiclesSuccess","All vehicles cleared!"}
        };

        public void ClearVehicles()
        {
            VehicleManager.askVehicleDestroyAll();
            Logger.LogWarning("All vehicles cleared!");
        }
    }
}
