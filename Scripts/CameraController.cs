using Godot;
using System;

public partial class CameraController : Camera3D
{
	[Export]
	private CharacterBody3D character;
	[Export]
	private Node3D cameraPivot;
	[Export]
    private float mouseSensitivity = 0.002f;
	[Export]
    private float pitch = 0f;
	private float minPitch = -1.5f;
	private float maxPitch = 1.5f;
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

    public override void _Input(InputEvent @event)
    {
		if (@event is InputEventMouseMotion mouseMotion)
		{
			character.RotateY(-mouseMotion.Relative.X * mouseSensitivity);
			pitch -= mouseMotion.Relative.Y * mouseSensitivity;
			pitch = Mathf.Clamp(pitch,minPitch,maxPitch);
			cameraPivot.Rotation = new Vector3(pitch, 0, 0);
		}
    }

	
	public void Update(CharacterBody3D character)
	{

		var direction = Vector3.Zero;
		if (Input.IsKeyPressed(Godot.Key.Q))
		{
			character.RotateY(0.01f);
		}

		if (Input.IsKeyPressed(Godot.Key.E))
		{
			character.RotateY(-0.01f);
		}

		direction = direction.Normalized();



	}

	public override void _Process(double delta)
	{
		Update(character);
	}
}
