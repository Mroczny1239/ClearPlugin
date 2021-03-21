using Rocket.API;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System.Collections.Generic;

namespace Mroczny.ClearPlugin.Commands
{
    public class CommandClearVehicles : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "clearvehicles";

        public string Help => "clear all vehicles";

        public string Syntax => "";

        public List<string> Aliases => new List<string>() { "clearv" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            VehicleManager.askVehicleDestroyAll();
            UnturnedChat.Say(caller, ClearPlugin.Instance.Translate("ClearVehiclesSuccess"), ClearPlugin.Instance.MessageColor);
        }
    }
}
