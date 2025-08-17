using Godot;
using System;
using System.Net.Http;

public partial class Player : MovableEntity
{
    [Signal]
    public delegate void UseEquipmentEventHandler();
    [Signal]
    public delegate void ChangeEquipmentEventHandler();
    [Signal]
    public delegate void ReloadEventHandler();
    [Export]
    private Movement movement;
    [Export]
    private Camera3D Camera;
    [Export]
    private WeaponHolder WeaponsEquipped;
    [Export]
    private Label healthUI;
    [Export]
    private PackedScene testweapon;
    [Export]
    private PackedScene testweapon2;

    public override void _Ready()
    {
        base._Ready();
        WeaponsEquipped.AddWeapon(testweapon);
        WeaponsEquipped.AddWeapon(testweapon2);
        UpdateUI();
    }


    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed)
            {
                EmitSignal(SignalName.UseEquipment);
            }
        }

    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            if (mouseEvent.ButtonIndex == MouseButton.WheelUp)
            {
                WeaponsEquipped.ChangeWeapon(); // +1 means "next"
                EmitSignal(SignalName.ChangeEquipment);
            }
        }
        if (Input.IsKeyPressed(Godot.Key.R))
        {
            WeaponsEquipped.EquippedWeapon().Reload();
            EmitSignal(SignalName.Reload);
        }
    }


    public override void _Process(double delta)
    {

    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        movement.Update(delta);
    }

    public override void Heal(float value)
    {
        HP.Heal(value);
        UpdateUI();
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
    public void UpdateUI()
    {
        healthUI.Text = HP.Value() + " / " + HP.maxValue();
    }



}
