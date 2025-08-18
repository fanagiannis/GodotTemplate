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
		Camera.Current = IsMultiplayerAuthority();
    }

    public override void _Input(InputEvent @event)
    {
		if (!IsMultiplayerAuthority())
			return;
        base._Input(@event);
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
}
