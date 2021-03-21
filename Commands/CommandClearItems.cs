using Rocket.API;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System.Collections.Generic;

namespace Mroczny.ClearPlugin.Commands
{
    public class CommandClearItems : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "clearitems";

        public string Help => "clear all items on ground";

        public string Syntax => "";

        public List<string> Aliases => new List<string>() { "cleari" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            ItemManager.askClearAllItems();
            UnturnedChat.Say(caller, ClearPlugin.Instance.Translate("ClearItemsSuccess"), ClearPlugin.Instance.MessageColor);
        }
    }
}
