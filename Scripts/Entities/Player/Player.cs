using Godot;
using System;

public partial class Player : MovableEntity
{
    [Signal]
    public delegate void UseEquipmentEventHandler();
    [Signal]
    public delegate void ChangeEquipmentEventHandler();
    [Export]
    private Movement movement;
    [Export]
    private Node3D Camera;
    [Export]
    private WeaponHolder WeaponsEquipped;
    [Export]
    private PackedScene testweapon;

    public override void _Ready()
    {
        base._Ready();
        WeaponsEquipped.AddWeapon(testweapon);
        
    }


    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed)
            {
                EmitSignal(SignalName.UseEquipment);
            }
            if (mouseEvent.ButtonIndex == MouseButton.WheelUp)
            {
                EmitSignal(SignalName.ChangeEquipment);
            }
        }
    }


    public override void _Process(double delta)
    {
        movement.Update(delta);
    }


    public void Use()
    {
        FireWeapon();
        //GD.Print("bang");
    }

    public void EquipmentChange()
    {
        GD.Print("equipment changed");
    }

    public void FireWeapon()
    {
        Vector3 origin = Camera.GlobalPosition;
        var direction = -Camera.GlobalTransform.Basis.Z;
        var spaceState = GetWorld3D().DirectSpaceState;

        var query = new PhysicsRayQueryParameters3D
        {
            From = origin,
            To = origin+direction*10f,
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
                entity.EmitSignal(SignalName.DamageTaken,10f);
            }
        }
        else
        {
            GD.Print("Missed!");
        }
    }



}
