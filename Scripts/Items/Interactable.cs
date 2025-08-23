using Godot;
using System;

public partial class Interactable : Item
{
    [Signal]
    public delegate void InteractionEventHandler();
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
            Player player = body as Player;
            player.Interact();
            if (canInteract)
            {
                interactionPrompt.Visible = true;
            }
        
            
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

    protected virtual void Interact()
    {
        GD.Print(itemName);
    }
}
