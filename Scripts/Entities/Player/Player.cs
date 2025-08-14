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
    private Camera3D Camera;
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
        WeaponsEquipped.EquippedWeapon().Fire(Camera);
    }



}
