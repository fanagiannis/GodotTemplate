using Godot;
using Godot.Collections;
using System;

public partial class WeaponHolder : Node3D
{
	[Export]
	private Array<Weapon> weapons = new Array<Weapon>();
	private Weapon currentWeapon;
	private int currentIndex;

	public void AddWeapon(PackedScene weapon)
	{
		if (weapon == null)
		{
			GD.Print("null");
			return;
		}


		Weapon newWpn = weapon.Instantiate<Weapon>();
		AddChild(newWpn);
		newWpn.Visible = true;
		weapons.Add(newWpn);
		GD.Print(newWpn + " equipped");

	}

	public void EquipWeapon(int index)
	{
		if (weapons.Count > 1)
		{
			weapons[currentIndex].Visible = false;
			currentIndex = index;
			currentWeapon = weapons[index];
			currentWeapon.Visible = true;
		}
		else
		{
			currentIndex = 0;
			currentWeapon = weapons[currentIndex];
			currentWeapon.Visible = true;
		}
		
	}

	public void RemoveWeapon(Weapon weapon)
	{
		foreach (Weapon wpn in weapons)
		{
			if (wpn == weapon)
			{
				weapons.Remove(wpn);
				return;
			}
		}
	}
	
}
