using Godot;
using System;

public partial class EquipmentSlot : Node3D
{
	[Export]
	private Item equippedItem;

	public override void _Ready()
	{
		//var node = FindChild("test");
		//equippedItem = node as Item;
		//GD.Print(node.Name);
	}

	public override void _Process(double delta)
	{
	}
	public void SetEquippedItem(Item item)
	{
		equippedItem = item;
	}
}
