using Godot;
using System;

public partial class MovableEntity : Entity
{
    [Export]
    private float Speed;
    [Export]
    private float maxSpeed;

    public float GetSpeed()
    {
        return Speed;
    }
    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
}
