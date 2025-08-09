using Godot;
using System;

public partial class Movement : CharacterBody3D
{

    [Export]
    private Node body;
    [Export]
    private MovableEntity entity;
    [Export]
    private CameraController camera;

    public void Update()
    {
        Vector3 direction = new();
        Basis aim = GlobalTransform.Basis;
        if (Input.IsKeyPressed(Godot.Key.W))
        {
            direction -= aim.Z;
        }

        if (Input.IsKeyPressed(Godot.Key.Q))
		{
			RotateY(0.01f);
		}

        if (Input.IsKeyPressed(Godot.Key.E))
		{
			RotateY(-0.01f);
		}

        if (Input.IsKeyPressed(Godot.Key.S))
        {
            direction += aim.Z;
        }

        if (Input.IsKeyPressed(Godot.Key.A))
        {
            direction -= aim.X;
        }

        if (Input.IsKeyPressed(Godot.Key.D))
        {
            direction += aim.X;
        }

        direction = direction.Normalized();

        Velocity = direction * entity.GetSpeed();
        MoveAndSlide();
    }

}
