using Godot;
using System;

public partial class NetworkPlayer : Player
{
	[Export]
	private int id { get; set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		SetMultiplayerAuthority(int.Parse(Name));
	}


	public override void _Ready()
	{
		base._Ready();
		AddToGroup("Player");
		Camera.Current = IsMultiplayerAuthority();
		if (Multiplayer.GetUniqueId() != GetMultiplayerAuthority())
		{
			// Hide the CanvasLayer so only the local player sees their own UI
			CanvasLayer canvas = GetNode<CanvasLayer>("CharacterBody3D/FollowCamera/CanvasLayer");
			if (canvas != null)
				canvas.Visible = false;
		}
		UpdateHealthUI();
	}

	public override void _Input(InputEvent @event)
	{
		if (!IsMultiplayerAuthority())
			return;
		base._Input(@event);

		if (Input.IsKeyPressed(Godot.Key.L))
		{
			TakeDamage(10);
			UpdateHealthUI();
		}
	}


	public override void _UnhandledInput(InputEvent @event)
	{
		if (!IsMultiplayerAuthority())
			return;
		base._UnhandledInput(@event);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (!IsMultiplayerAuthority())
			return;

		base._PhysicsProcess(delta);
		movement.Update(delta);
	}


	public void SetID(int value)
	{
		id = value;
	}

	public void UpdateHealthUI()
	{
		Label3D healthDisplay = GetNode<Label3D>("CharacterBody3D/FollowCamera/Health");
		healthDisplay.Text = HP.Value().ToString();
	}

	
}
