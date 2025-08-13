using Godot;
using System;

public partial class Player : MovableEntity
{
    [Signal]
    public delegate void UseEquipmentEventHandler();
    [Export]
    private Movement movement;

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


    public override void _Process(double delta)
    {
        movement.Update(delta);
    }


    public void Use()
    {
        GD.Print("bang");
    }

}
