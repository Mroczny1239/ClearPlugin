using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using UnityEngine;

namespace Mroczny.ClearPlugin.Commands
{
    public class ClearInventory : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public string Name => "clearinventory";
        public string Help => "Clear your inventory!";
        public string Syntax => "<player>";
        public List<string> Aliases => new List<string> { "ci" };
        public List<string> Permissions => new List<string>();
        
        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length == 0)
            {
                ClearPlayerInventory(player);
                UnturnedChat.Say(caller, ClearPlugin.Instance.Translate("ClearInventorySuccess"), ClearPlugin.Instance.MessageColor);
                return;
            }

            var target = UnturnedPlayer.FromName(command[0]);

            if (target != null)
            {
                ClearPlayerInventory(UnturnedPlayer.FromName(command[0]));
                UnturnedChat.Say(caller, ClearPlugin.Instance.Translate("ClearInventoryPlayerSuccess", player.DisplayName), ClearPlugin.Instance.MessageColor);
            }
            else
            {
                UnturnedChat.Say(caller, ClearPlugin.Instance.Translate("PlayerNotFound"), Color.red);
            }
        }

        private void ClearPlayerInventory(UnturnedPlayer player)
        {
            var playerInv = player.Inventory;

            player.Player.channel.send("tellSlot", ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER,
                (byte)0, (byte)0, EmptyByteArray);
            player.Player.channel.send("tellSlot", ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER,
                (byte)1, (byte)0, EmptyByteArray);


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

            void RemoveUnequipped()
            {
                for (byte i = 0; i < playerInv.getItemCount(2); i++)
                {
                    playerInv.removeItem(2, 0);
                }
            }

            player.Player.clothing.askWearBackpack(0, 0, EmptyByteArray, true);
            RemoveUnequipped();

            player.Player.clothing.askWearGlasses(0, 0, EmptyByteArray, true);
            RemoveUnequipped();

            player.Player.clothing.askWearHat(0, 0, EmptyByteArray, true);
            RemoveUnequipped();

            player.Player.clothing.askWearPants(0, 0, EmptyByteArray, true);
            RemoveUnequipped();

            player.Player.clothing.askWearMask(0, 0, EmptyByteArray, true);
            RemoveUnequipped();

            player.Player.clothing.askWearShirt(0, 0, EmptyByteArray, true);
            RemoveUnequipped();

            player.Player.clothing.askWearVest(0, 0, EmptyByteArray, true);
            RemoveUnequipped();
        }

        public readonly byte[] EmptyByteArray = new byte[0];
    }
}
