using Godot;
using System;

public partial class Item : Node3D
{
	[Export]
	private PackedScene itemInstance;
	[Export]
	private string itemName;

	public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{

	}

	public virtual void Use()
	{
		GD.Print(itemName + " used!");
	}
}
