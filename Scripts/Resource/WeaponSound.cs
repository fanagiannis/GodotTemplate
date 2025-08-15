using Godot;
using System;


[GlobalClass]
public partial class WeaponSound : Resource
{
	[Export] public AudioStream fireSound { get; set; }
	[Export] public AudioStream reloadSound { get; set; }
	[Export] public AudioStream noAmmosSound { get; set; }
}
