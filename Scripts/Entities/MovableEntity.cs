using Godot;
using System;

public partial class MovableEntity : Entity
{
    [Export]
    private float Speed;
    [Export]
    private float maxSpeed;

    public override void _Ready()
    {
        base._Ready();
    }


    public float GetSpeed()
    {
        return Speed;
    }
    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
}
