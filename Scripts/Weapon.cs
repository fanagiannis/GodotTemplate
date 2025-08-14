using Godot;
using System;

public partial class Weapon : MeshInstance3D
{
	[Export]
	private string weaponName;
	[Export]
	private string damage;
	[Export]
	private int currentAmmo, maxAmmo, magSize, currentMags;
	public virtual void Fire()
	{

	}
	public virtual void Reload()
	{
		if (currentAmmo <= 0 && maxAmmo >= magSize && currentMags > 0)
		{
			currentAmmo = magSize;
			currentMags--;
		}
			
	}
}
