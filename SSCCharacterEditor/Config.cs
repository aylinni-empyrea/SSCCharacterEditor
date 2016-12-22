using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using SSCCharacterEditor.Modifiers;
using Terraria.ID;
using TShockAPI;

namespace SSCCharacterEditor
{
	public static class Examples
	{
		#region Example Presets

		public static readonly List<Preset> ExamplePresets = new List<Preset>
		{
			new Preset("Warrior", "WarriorInv", 120, 0, Point.Zero),
			new Preset("Ranger", "RangerInv", 100, 0, Point.Zero),
			new Preset("Mage", "MageInv", 60, 60, Point.Zero)
		};

		#endregion

		#region Example Inventories

		public static readonly List<Inventory> ExampleInventories = new List<Inventory>
		{
			new Inventory("WarriorInv", new[]
			{
				new CEItem(ItemSlots.InvRow1Slot1, ItemID.CopperBroadsword, null, ItemPrefixes.Legendary),
				new CEItem(ItemSlots.InvRow1Slot2, ItemID.SilverPickaxe, null, ItemPrefixes.Slow),
				new CEItem(ItemSlots.InvRow1Slot3, ItemID.GoldAxe, null, ItemPrefixes.Annoying)
			}),
			new Inventory("RangerInv", new[]
			{
				new CEItem(ItemSlots.InvRow1Slot1, ItemID.LeadBow, null, ItemPrefixes.Unreal),
				new CEItem(ItemSlots.InvRow1Slot2, ItemID.TinPickaxe, null, ItemPrefixes.Nimble),
				new CEItem(ItemSlots.InvRow1Slot3, ItemID.PlatinumAxe, null, ItemPrefixes.Heavy)
			}),
			new Inventory("MageInv", new[]
			{
				new CEItem(ItemSlots.InvRow1Slot1, ItemID.WandofSparking, null, ItemPrefixes.Mythical),
				new CEItem(ItemSlots.InvRow1Slot2, ItemID.LeadPickaxe, null, ItemPrefixes.Light),
				new CEItem(ItemSlots.InvRow1Slot3, ItemID.TungstenAxe, null, ItemPrefixes.Pointy)
			})
		};

		#endregion
	}

	public class Config
	{
		public Config()
		{
			Presets = Examples.ExamplePresets;
			Inventories = Examples.ExampleInventories;
		}

		public List<Preset> Presets { get; set; }
		public List<Inventory> Inventories { get; set; }

		// Thanks clay

		public static Config Read()
		{
			string _path = Path.Combine(TShock.SavePath, "CharacterEditor.json");

			if (!File.Exists(_path))
			{
				TShock.Log.ConsoleInfo("CharacterEditor.json not found. Creating new one...");
				Config _config = new Config();
				File.WriteAllText(_path,
					JsonConvert.SerializeObject(_config, Formatting.Indented));
				return _config;
			}

			try
			{
				string raw = File.ReadAllText(_path);
				Config _config = JsonConvert.DeserializeObject<Config>(raw);
				return _config;
			}
			catch (Exception e)
			{
				TShock.Log.ConsoleError("CharacterEditor.json not valid. Creating new one...");
				Console.WriteLine(e.Message);
				Config _config = new Config();
				File.WriteAllText(_path,
					JsonConvert.SerializeObject(_config, Formatting.Indented));
				return _config;
			}
		}
	}
}