using Godot;
using System;

public partial class Item : Node3D
{
	[Export]
	protected PackedScene itemInstance;
	[Export]
	protected string itemName;

	public override void _Ready() { }
	public override void _Process(double delta) { }

	public virtual void Use()
	{
		GD.Print(itemName + " used!");
	}
}
