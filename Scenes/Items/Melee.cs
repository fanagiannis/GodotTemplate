using Godot;
using System;

public partial class Melee : Weapon
{
    public override void Fire(Camera3D Origin)
    {
		ShootRaycast(Origin);
    }

}
