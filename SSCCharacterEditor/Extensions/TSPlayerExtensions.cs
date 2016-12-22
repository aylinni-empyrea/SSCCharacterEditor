using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using TShockAPI;
using static TShockAPI.NetItem;

namespace SSCCharacterEditor.Extensions
{
	internal static class TSPlayerExtensions
	{
		/// <summary>
		/// Activates SSC for a <see cref="TSPlayer"/>.
		/// </summary>
		/// <param name="player"><see cref="TSPlayer"/> to activate SSC for.</param>
		internal static void EnterSSC(this TSPlayer player)
		{
			if (player == null || player.RealPlayer == false || Main.ServerSideCharacter)
				return;

			Main.ServerSideCharacter = true;
			NetMessage.SendData((int) PacketTypes.WorldInfo, player.Index);
		}

		/// <summary>
		/// Deactivates SSC for a <see cref="TSPlayer"/>.
		/// </summary>
		/// <param name="player"><see cref="TSPlayer"/> to deactivate SSC for.</param>
		internal static void ExitSSC(this TSPlayer player)
		{
			if (player == null || player.RealPlayer == false || !Main.ServerSideCharacter)
				return;

			Main.ServerSideCharacter = false;
			NetMessage.SendData((int) PacketTypes.WorldInfo, player.Index);
		}

		/// <summary>
		/// Applies given array of <see cref="Item"/> to <see cref="TSPlayer"/>.
		/// </summary>
		/// <param name="player"></param>
		/// <param name="items"></param>
		internal static void ApplyInventory(this TSPlayer player, Item[] items)
		{
			int index;
			for (int i = 0; i < MaxInventory; i++)
			{
				if (i < InventorySlots)
				{
					player.TPlayer.inventory[i].netDefaults(items[i].netID);

					if (player.TPlayer.inventory[i].netID != 0)
					{
						player.TPlayer.inventory[i].prefix = items[i].prefix;
						player.TPlayer.inventory[i].stack = items[i].stack;
					}

					NetMessage.SendData((int) PacketTypes.PlayerSlot, -1, -1, player.TPlayer.inventory[i].name, player.Index, i,
						player.TPlayer.inventory[i].prefix);
					NetMessage.SendData((int) PacketTypes.PlayerSlot, player.Index, -1, player.TPlayer.inventory[i].name, player.Index,
						i, player.TPlayer.inventory[i].prefix);
				}
				else if (i < InventorySlots + ArmorSlots)
				{
					index = i - InventorySlots;

					player.TPlayer.armor[index].netDefaults(items[i].netID);

					if (player.TPlayer.armor[index].netID != 0)
					{
						player.TPlayer.armor[index].prefix = items[i].prefix;
						player.TPlayer.armor[index].stack = items[i].stack;
					}

					NetMessage.SendData((int) PacketTypes.PlayerSlot, -1, -1, player.TPlayer.armor[index].name, player.Index, i,
						player.TPlayer.armor[index].prefix);
					NetMessage.SendData((int) PacketTypes.PlayerSlot, player.Index, -1, player.TPlayer.armor[index].name, player.Index,
						i, player.TPlayer.armor[index].prefix);
				}
				else if (i < InventorySlots + ArmorSlots + DyeSlots)
				{
					index = i - (InventorySlots + ArmorSlots);

					player.TPlayer.dye[index].netDefaults(items[i].netID);

					if (player.TPlayer.dye[index].netID != 0)
					{
						player.TPlayer.dye[index].prefix = items[i].prefix;
						player.TPlayer.dye[index].stack = items[i].stack;
					}

					NetMessage.SendData((int) PacketTypes.PlayerSlot, -1, -1, player.TPlayer.dye[index].name, player.Index, i,
						player.TPlayer.dye[index].prefix);
					NetMessage.SendData((int) PacketTypes.PlayerSlot, player.Index, -1, player.TPlayer.dye[index].name, player.Index,
						i, player.TPlayer.dye[index].prefix);
				}
				else if (i < InventorySlots + ArmorSlots + DyeSlots + MiscEquipSlots)
				{
					index = i - (InventorySlots + ArmorSlots + DyeSlots);

					player.TPlayer.miscEquips[index].netDefaults(items[i].netID);

					if (player.TPlayer.miscEquips[index].netID != 0)
					{
						player.TPlayer.miscEquips[index].prefix = items[i].prefix;
						player.TPlayer.miscEquips[index].stack = items[i].stack;
					}

					NetMessage.SendData((int) PacketTypes.PlayerSlot, -1, -1, player.TPlayer.miscEquips[index].name, player.Index, i,
						player.TPlayer.miscEquips[index].prefix);
					NetMessage.SendData((int) PacketTypes.PlayerSlot, player.Index, -1, player.TPlayer.miscEquips[index].name,
						player.Index,
						i, player.TPlayer.miscEquips[index].prefix);
				}
				else if (i < InventorySlots + ArmorSlots + DyeSlots + MiscEquipSlots + MiscDyeSlots)
				{
					index = i - (InventorySlots + ArmorSlots + DyeSlots + MiscEquipSlots);

					player.TPlayer.miscDyes[index].netDefaults(items[i].netID);

					if (player.TPlayer.miscDyes[index].netID != 0)
					{
						player.TPlayer.miscDyes[index].prefix = items[i].prefix;
						player.TPlayer.miscDyes[index].stack = items[i].stack;
					}

					NetMessage.SendData((int) PacketTypes.PlayerSlot, -1, -1, player.TPlayer.miscDyes[index].name, player.Index, i,
						player.TPlayer.miscDyes[index].prefix);
					NetMessage.SendData((int) PacketTypes.PlayerSlot, player.Index, -1, player.TPlayer.miscDyes[index].name,
						player.Index,
						i, player.TPlayer.miscDyes[index].prefix);
				}
			}
		}
	}
}