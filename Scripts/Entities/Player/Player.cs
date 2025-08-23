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
    protected Movement movement;
    [Export]
    protected Camera3D Camera;
    [Export]
    protected WeaponHolder WeaponsEquipped;
    [Export]
    protected Interaction playerInteraction;
    [Export]
    protected Label healthUI;
    [Export]
    protected PackedScene baseWeapon;

    public override void _Ready()
    {
        base._Ready();

        WeaponsEquipped.AddWeapon(baseWeapon);
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


    public override void _PhysicsProcess(double delta)
    {
        //if (!IsMultiplayerAuthority())
        // return;
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

    public void Interact()
    {
        playerInteraction.CheckInteraction(Camera, GetWorld3D().DirectSpaceState);
    }

    public WeaponHolder GetWeaponHolder()
    {
        return WeaponsEquipped;
    }

    public void FireWeapon()
    {
        if (WeaponsEquipped.GetWeaponsListLength() > 0)
            WeaponsEquipped.EquippedWeapon().Fire(Camera);
        else
            GD.Print("punch");
    }
    public void UpdateUI()
    {
        healthUI.Text = HP.Value() + " / " + HP.maxValue();
    }

    public Interaction Interaction()
    {
        return playerInteraction;
    }

    public Camera3D GetCamera()
    {
        return Camera;
    }

}
