using Godot;
using System;

public partial class Enemy : MovableEntity
{
    [Export]
    private string name;
    [Export]
    private Label3D nameDisplay;
    [Export]
    private Label3D HealthDisplay;

    public override void _Ready()
    {
        base._Ready();
        nameDisplay.Text=name;
        HealthDisplay.Text = HealthPoints().ToString();
    }
}
