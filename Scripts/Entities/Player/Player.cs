using Godot;
using System;

public partial class Player : MovableEntity
{
    [Export]
    private Movement movement;

    public override void _Process(double delta)
    {
        movement.Update();
    }

}
