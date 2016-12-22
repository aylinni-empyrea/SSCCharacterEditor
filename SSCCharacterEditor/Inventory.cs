using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SSCCharacterEditor.Extensions;
using Terraria;
using TShockAPI;

namespace SSCCharacterEditor
{
	public class CEItem
	{
		public readonly int Slot;
		public readonly int ItemID;
		public readonly int Stack;
		public readonly byte Prefix;

		/// <summary>
		/// Creates a config friendly item class.
		/// </summary>
		/// <param name="slot"><see cref="ItemSlots"/> position of the item.</param>
		/// <param name="id">Item ID from <see cref="Terraria.ID.ItemID"/>.</param>
		/// <param name="stack">Number of items in the item stack. (Defaults to <see cref="Item.maxStack"/>)</param>
		/// <param name="prefix">Prefix/modifier of the item. (Defaults to <see cref="ItemPrefixes.None"/>)</param>
		[JsonConstructor]
		public CEItem(ItemSlots slot, int id, int? stack = null, ItemPrefixes prefix = ItemPrefixes.None)
		{
			Slot = (int) slot;
			ItemID = id;

			if (stack != null)
				Stack = (int) stack;
			else
				Stack = TShock.Utils.GetItemById(id).maxStack;

			Prefix = (byte) prefix;
		}
		/*
		/// <summary>
		/// Creates a config friendly item class.
		/// </summary>
		/// <param name="slot"><see cref="ItemSlots"/> position of the item.</param>
		/// <param name="name">Item name to be conveted to a <see cref="Terraria.ID.ItemID"/>.</param>
		/// <param name="stack">Number of items in the item stack. (Defaults to <see cref="Item.maxStack"/>)</param>
		/// <param name="prefix">Prefix/modifier of the item. (Defaults to <see cref="ItemPrefixes.None"/>)</param>
		public CEItem(ItemSlots slot, string name, int? stack = null, ItemPrefixes prefix = ItemPrefixes.None)
		{
			Slot = (int) slot;
			ItemID = TShock.Utils.GetItemByName(name).First().netID;

			if (stack != null)
				Stack = (int) stack;
			else
				Stack = TShock.Utils.GetItemById(ItemID).maxStack;

			Prefix = (byte) prefix;
		}
		*/
		public static explicit operator Item(CEItem item)
		{
			Item _item = TShock.Utils.GetItemById(item.ItemID);
			_item.prefix = item.Prefix;
			_item.stack = item.Stack;

			return _item;
		}
	}

	#region Helper data

	// Taken from https://tshock.readme.io/docs/slot-indexes#section-helpful-code-to-make-life-easier

	public enum ItemSlots
	{
		InvRow1Slot1,
		InvRow1Slot2,
		InvRow1Slot3,
		InvRow1Slot4,
		InvRow1Slot5,
		InvRow1Slot6,
		InvRow1Slot7,
		InvRow1Slot8,
		InvRow1Slot9,
		InvRow1Slot10,
		InvRow2Slot1,
		InvRow2Slot2,
		InvRow2Slot3,
		InvRow2Slot4,
		InvRow2Slot5,
		InvRow2Slot6,
		InvRow2Slot7,
		InvRow2Slot8,
		InvRow2Slot9,
		InvRow2Slot10,
		InvRow3Slot1,
		InvRow3Slot2,
		InvRow3Slot3,
		InvRow3Slot4,
		InvRow3Slot5,
		InvRow3Slot6,
		InvRow3Slot7,
		InvRow3Slot8,
		InvRow3Slot9,
		InvRow3Slot10,
		InvRow4Slot1,
		InvRow4Slot2,
		InvRow4Slot3,
		InvRow4Slot4,
		InvRow4Slot5,
		InvRow4Slot6,
		InvRow4Slot7,
		InvRow4Slot8,
		InvRow4Slot9,
		InvRow4Slot10,
		InvRow5Slot1,
		InvRow5Slot2,
		InvRow5Slot3,
		InvRow5Slot4,
		InvRow5Slot5,
		InvRow5Slot6,
		InvRow5Slot7,
		InvRow5Slot8,
		InvRow5Slot9,
		InvRow5Slot10,
		CoinSlot1,
		CoinSlot2,
		CoinSlot3,
		CoinSlot4,
		AmmoSlot1,
		AmmoSlot2,
		AmmoSlot3,
		AmmoSlot4,
		HandSlot,
		ArmorHeadSlot,
		ArmorBodySlot,
		ArmorLeggingsSlot,
		AccessorySlot1,
		AccessorySlot2,
		AccessorySlot3,
		AccessorySlot4,
		AccessorySlot5,
		AccessorySlot6,
		UnknownSlot1,
		VanityHeadSlot,
		VanityBodySlot,
		VanityLeggingsSlot,
		SocialAccessorySlot1,
		SocialAccessorySlot2,
		SocialAccessorySlot3,
		SocialAccessorySlot4,
		SocialAccessorySlot5,
		SocialAccessorySlot6,
		UnknownSlot2,
		DyeHeadSlot,
		DyeBodySlot,
		DyeLeggingsSlot,
		DyeAccessorySlot1,
		DyeAccessorySlot2,
		DyeAccessorySlot3,
		DyeAccessorySlot4,
		DyeAccessorySlot5,
		DyeAccessorySlot6,
		Unknown3,
		EquipmentSlot1,
		EquipmentSlot2,
		EquipmentSlot3,
		EquipmentSlot4,
		EquipmentSlot5,
		DyeEquipmentSlot1,
		DyeEquipmentSlot2,
		DyeEquipmentSlot3,
		DyeEquipmentSlot4,
		DyeEquipmentSlot5
	}

	public enum ItemPrefixes : byte
	{
		None,
		Large,
		Massive,
		Dangerous,
		Savage,
		Sharp,
		Pointy,
		Tiny,
		Terrible,
		Small,
		Dull,
		Unhappy,
		Bulky,
		Shameful,
		Heavy,
		Light,
		Sighted,
		Rapid,
		Hasty,
		Intimidating,
		Deadly,
		Staunch,
		Awful,
		Lethargic,
		Arkward,
		Powerful,
		Mystic,
		Adept,
		Masterful,
		Inept,
		Ignorant,
		Deranged,
		Intense,
		Taboo,
		Celestial,
		Furious,
		Keen,
		Superior,
		Forceful,
		Broken,
		Damaged,
		Shoddy,
		Quick,
		Deadly2,
		Agile,
		Nimble,
		Murderous,
		Slow,
		Sluggish,
		Lazy,
		Annoying,
		Nasty,
		Manic,
		Hurtful,
		Strong,
		Unpleasant,
		Weak,
		Ruthless,
		Frenzying,
		Godly,
		Demonic,
		Zealous,
		Hard,
		Guarding,
		Armored,
		Warding,
		Arcane,
		Precise,
		Lucky,
		Jagged,
		Spiked,
		Angry,
		Menacing,
		Brisk,
		Fleeting,
		Hasty2,
		Quick2,
		Wild,
		Rash,
		Intrepid,
		Violent,
		Legendary,
		Unreal,
		Mythical
	}

	#endregion

	public class Inventory
	{
		public string Name { get; }

		[JsonIgnore]
		public Item[] Items { get; set; }

		public List<CEItem> CEItems { get; set; }

		/*
				public Inventory(string _name, Item[] _items)
				{
					Name = _name;
					Items = _items;
				}
				*/
		public Inventory(string _name, IEnumerable<CEItem> _items)
		{
			Name = _name;
			CEItems = _items.ToList();
			Items = Parse(CEItems);
		}

		public static Item[] Parse(IEnumerable<CEItem> item)
		{
			if (item == null) throw new ArgumentNullException(nameof(item));

			var _items = new Item[NetItem.MaxInventory];

			foreach (var i in item)
				_items[i.Slot] = (Item) i;

			return _items;
		}

		public void Apply(TSPlayer player)
		{
#if DEBUG
			Console.WriteLine($"Applying {Name} to {player.Name}");
#endif
			player.EnterSSC();

			try
			{
				player.ApplyInventory(Items);
			}
			catch (Exception e)
			{
				player.SendErrorMessage("An error occurred while applying the preset inventory to your character." + "\n" +
				                        "Please contact your server's administrator.");
				TShock.Log.Error(e.ToString());
			}
		}
	}
}