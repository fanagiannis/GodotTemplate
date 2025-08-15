using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class WeaponHolder : Node3D
{
	[Export]
	private Label weaponStats;
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
		currentWeapon = newWpn;
		weapons.Add(newWpn);
		GD.Print(newWpn.WeaponName() + " equipped");
		SetWeaponDisplay();

	}

	public void EquipWeapon(int index)
	{
		if (index < 0 || index >= weapons.Count)
		{
			GD.PrintErr($"Invalid weapon index: {index}");
			return;
		}

		// Hide currently equipped weapon (if any)
		if (currentWeapon != null)
		{
			currentWeapon.Visible = false;
		}

		// Equip new weapon
		currentIndex = index;
		currentWeapon = weapons[index];
		currentWeapon.Visible = true;

		GD.Print($"Equipped weapon: {currentWeapon.WeaponName()}");
	}

	public void ChangeWeapon()
	{
		weapons[currentIndex].Visible = false;
		currentIndex++;
		if (currentIndex > weapons.Count - 1)
		{
			currentIndex = 0;
		}
		currentWeapon = weapons[currentIndex];
		weapons[currentIndex].Visible = true;
		GD.Print(currentIndex + " " + currentWeapon.WeaponName());
		SetWeaponDisplay();
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

	public Weapon EquippedWeapon()
	{
		//GD.Print(currentWeapon.WeaponName());
		return currentWeapon;
	}

	public void SetWeaponDisplay()
	{
		weaponStats.Text = currentWeapon.WeaponName() + "\n" + currentWeapon.GetCurrentAmmo() + "/" + currentWeapon.GetMaxAmmo();
	}

}
