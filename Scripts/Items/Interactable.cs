using Godot;
using System;

public partial class Interactable : Item
{
    [Signal]
    public delegate void InteractSetEventHandler();
    [Export]
    protected Label3D interactionPrompt;
    [Export]
    protected bool canInteract { get; set; }
    public void SetInteract(bool set)
    {
        canInteract = set;
    }
    public void OnBodyEntered(Node3D body)
    {
        if (body.GetParent().IsInGroup("Player"))
        {
            interactionPrompt.Visible = true;
            SetInteract(true);
        }
    }
    
    public void OnBodyExitted(Node3D body)
	{
        if (body.GetParent().IsInGroup("Player"))
        {
            
            interactionPrompt.Visible = false;
            SetInteract(false);
		}
	}
}
