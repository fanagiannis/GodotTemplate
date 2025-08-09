using Godot;
using System;

public partial class CameraController : Camera3D
{
	[Export]
    private float mouseSensitivity = 0.002f;
	[Export]
    private float pitch = 0f;
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public void Update()
	{
		var direction = Vector3.Zero;
		if (Input.IsKeyPressed(Godot.Key.Q))
		{
			RotateY(mouseSensitivity);
		}

		direction = direction.Normalized();

        
		
	}

	public override void _Process(double delta)
	{
	}
}
