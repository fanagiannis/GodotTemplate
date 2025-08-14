using Godot;
using System;

public partial class Weapon : MeshInstance3D
{
    [Export]
    private string weaponName;
    [Export]
    private float damage;
    [Export]
    private float range;

    [Export]
    private int currentAmmo, maxAmmo, magSize, currentMags;
    public virtual void Fire(Camera3D Origin)
    {
        Vector3 origin = Origin.GlobalPosition;
        var direction = -Origin.GlobalTransform.Basis.Z;
        var spaceState = GetWorld3D().DirectSpaceState;

        var query = new PhysicsRayQueryParameters3D
        {
            From = origin,
            To = origin + direction * range,
            CollideWithAreas = false,
            CollideWithBodies = true
        };

        var result = spaceState.IntersectRay(query);
        if (result.Count > 0)
        {
            var collider = result["collider"].AsGodotObject();
            var position = (Vector3)result["position"];
            Entity entity = collider as Entity;
            if (entity != null)
            {
                entity.TakeDamage(damage);
            }
        }
        else
        {
            GD.Print("Missed!");
        }
    }
    public virtual void Reload()
    {
        if (currentAmmo <= 0 && maxAmmo >= magSize && currentMags > 0)
        {
            currentAmmo = magSize;
            currentMags--;
        }

    }

    public string WeaponName()
    {
        return weaponName;
    }
}
