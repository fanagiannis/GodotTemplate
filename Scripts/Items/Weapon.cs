using Godot;
using System;

public partial class Weapon : MeshInstance3D
{
    [Export]
    protected string weaponName;
    [Export]
    public WeaponSound Sounds;
    [Export]
    protected float damage;
    [Export]
    protected float range;
    [Export]
    private int currentAmmo, maxAmmo, magSize, currentMags;
    public virtual void Fire(Camera3D Origin)
    {
        if (AmmoManipulation())
        {
            ShootRaycast(Origin);
        }
        
    }
    public virtual void Reload()
    {
        if (currentAmmo >= 0 && maxAmmo > 0 && currentAmmo!=magSize)
        {
            currentAmmo = magSize;
            maxAmmo -= magSize;
        }

    }

    public void ShootRaycast(Camera3D Origin)
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

    public bool AmmoManipulation()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            return true;
        }
        return false;
    }

    public void AddAmmo(int value)
    {
        maxAmmo += value;
    }

    public string WeaponName()
    {
        return weaponName;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public int GetMaxAmmo()
    {
        return maxAmmo;
    }
}
