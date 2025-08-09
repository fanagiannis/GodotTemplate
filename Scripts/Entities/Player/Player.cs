using Godot;
using System;

public partial class Player : MovableEntity
{
    [Export]
    private Movement movement;
    [Export]
    private CameraController camera;

    public override void _Process(double delta)
    {
        movement.Update();
        camera.Update();
    }

}
