using Godot;
using Godot.Collections;
using System;

public partial class Inventory : Node3D
{
	[Export]
	private Array<Item> items = new Array<Item>();
	[Export]
	private int equippedItem=0;
	private int maxItems;

	public override void _Ready()
	{
		maxItems = items.Count;
	}

	public override void _Process(double delta)
	{
	}

	public void AddItem(Item item)
	{
		items.Add(item);
		GD.Print(item + " added");
		maxItems = items.Count;
	}

	public Item SelectItem(Item item)
	{
		foreach (Item value in items)
		{
			if (value == item)
			{
				return item;
			}
		}
		return null;
	}

	public void ClearInventory()
	{
		items.Clear();
	}
	public void SetEquippedItem(Item item)
	{
		//equippedItem = item;
	}
}
