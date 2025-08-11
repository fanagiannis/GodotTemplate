using Godot;
using System;

public partial class Movement : CharacterBody3D
{
    [Export]
    private MovableEntity entity;

    [Export]
    private float gravityScale = 9.14f;
    private bool isOnFloor = false;


    private void CheckFloorPosition()
    {
        Vector3 origin = Position;
        Vector3 target = origin + Vector3.Down * 1f;
        var spaceState = GetWorld3D().DirectSpaceState;

        var query = new PhysicsRayQueryParameters3D
        {
            From = origin,
            To = target,
            CollideWithAreas = true,
            CollideWithBodies = true
        };

        var result = spaceState.IntersectRay(query);
        if (result.Count > 0)
        {
            isOnFloor = true;
            GD.Print("Hit object: ", result["collider"]);
            GD.Print("Hit position: ", result["position"]);
        }
        else
        {
            isOnFloor = false;
        }
    }

    private void Gravity(double delta)
    {
        CheckFloorPosition();

        Vector3 gravity = new Vector3(0, 0, 0);
        if (isOnFloor)
        {
            gravity = new Vector3(0, 0, 0);
        }
        else
        {

            gravity = new Vector3(0, gravityScale, 0);
        }


        Velocity -= gravity * (float)delta;
    }

    public void Update(double delta)
    {
        Vector3 direction = new();
        Basis aim = GlobalTransform.Basis;
        if (Input.IsKeyPressed(Godot.Key.W))
        {
            direction -= aim.Z;
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
        Gravity(delta);
        MoveAndSlide();
    }

}
