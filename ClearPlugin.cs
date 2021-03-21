using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace Mroczny.ClearPlugin
{
    public class ClearPlugin : RocketPlugin<ClearPluginConfiguration>
    {
        public static ClearPlugin Instance;
        string Version = "1.0.3";
        string Creator = "Mroczny";
        public Color MessageColor { get; set; }

        protected override void Load()
        {
            Instance = this;
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, Color.green);
            Logger.LogWarning($"Loading {Name} {Version}...");
            Logger.LogWarning($"Plugin Made By {Creator}");
            Logger.LogWarning($"{Name} has been loaded!");
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
