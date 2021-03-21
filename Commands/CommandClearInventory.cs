using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;

namespace Mroczny.ClearPlugin.Commands
{
    public class CommandClearInventory : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "clearinventory";

        public string Help => "clear inventory";

        public string Syntax => "<player>";

        public List<string> Aliases => new List<string>() { "ci" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length == 0)
            {
                ClearInventory(player);
                UnturnedChat.Say(caller, ClearPlugin.Instance.Translate("ClearInventorySuccess"), ClearPlugin.Instance.MessageColor);
                return;
            }

            var target = UnturnedPlayer.FromName(command[0]);

            if (target != null)
            {
                ClearInventory(UnturnedPlayer.FromName(command[0]));
                UnturnedChat.Say(caller, ClearPlugin.Instance.Translate("ClearInventoryPlayerSuccess", player.DisplayName), ClearPlugin.Instance.MessageColor);
            }
            else
            {
                UnturnedChat.Say(caller, ClearPlugin.Instance.Translate("PlayerNotFound"), UnityEngine.Color.red);
            }
        }

        private void ClearInventory(UnturnedPlayer player)
        {
            var playerInv = player.Inventory;

            player.Player.channel.send("tellSlot", ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER,
                (byte)0, (byte)0, EMPTY_BYTE_ARRAY);
            player.Player.channel.send("tellSlot", ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER,
                (byte)1, (byte)0, EMPTY_BYTE_ARRAY);


            for (byte page = 0; page < PlayerInventory.PAGES; page++)
            {
                if (page == PlayerInventory.AREA)
                    continue;

                var count = playerInv.getItemCount(page);

                for (byte index = 0; index < count; index++)
                {
                    playerInv.removeItem(page, 0);
                }
            }

            System.Action removeUnequipped = () =>
            {
                for (byte i = 0; i < playerInv.getItemCount(2); i++)
                {
                    playerInv.removeItem(2, 0);
                }
            };

            player.Player.clothing.askWearBackpack(0, 0, EMPTY_BYTE_ARRAY, true);
            removeUnequipped();

            player.Player.clothing.askWearGlasses(0, 0, EMPTY_BYTE_ARRAY, true);
            removeUnequipped();

            player.Player.clothing.askWearHat(0, 0, EMPTY_BYTE_ARRAY, true);
            removeUnequipped();

            player.Player.clothing.askWearPants(0, 0, EMPTY_BYTE_ARRAY, true);
            removeUnequipped();

            player.Player.clothing.askWearMask(0, 0, EMPTY_BYTE_ARRAY, true);
            removeUnequipped();

            player.Player.clothing.askWearShirt(0, 0, EMPTY_BYTE_ARRAY, true);
            removeUnequipped();

            player.Player.clothing.askWearVest(0, 0, EMPTY_BYTE_ARRAY, true);
            removeUnequipped();
        }

        public readonly byte[] EMPTY_BYTE_ARRAY = new byte[0];
    }
}
