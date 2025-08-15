using Godot;
using System;

public partial class Movement : CharacterBody3D
{
    [Export]
    private MovableEntity entity;
    [Export]
    private float jumpForce=100f;
    [Export]
    private float gravityScale = 9.14f;
    private bool isOnFloor = false;
    private bool isMoving = false;


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
            //GD.Print("Hit object: ", result["collider"]);
            //GD.Print("Hit position: ", result["position"]);
        }
        else
        {
            isOnFloor = false;
        }
    }

    private void Jump(double delta)
    {
        CheckFloorPosition();

        Vector3 jump = new Vector3(0, 0, 0);
        if (isOnFloor)
        {
            GD.Print("jump");
            jump = new Vector3(Velocity.X, jumpForce, Velocity.Z);
        }
        else
        {
            jump = new Vector3(Velocity.X, 0, Velocity.Z);
          
        }


        Velocity += jump * (float)delta;
    }

    private void Gravity(double delta)
    {
        CheckFloorPosition();

        Vector3 gravity = new Vector3(0, 0, 0);
        if (isOnFloor)
        {
            gravity = new Vector3(Velocity.X, 0, Velocity.Z);
        }
        else
        {

            gravity = new Vector3(Velocity.X, gravityScale, Velocity.Z);
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
        
        if (Velocity.Length() > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        Gravity(delta);
        if (Input.IsKeyPressed(Godot.Key.Space))
        {
           
            Jump(delta);
        }

        
        MoveAndSlide();
        //GD.Print(isMoving,isOnFloor);
    }

    public bool GetMovement()
    {
        return isMoving;
    }

    public bool CheckFloor()
    {
        return isOnFloor;
    }

}
