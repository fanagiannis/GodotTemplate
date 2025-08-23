using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Interaction : Node
{
    private Interactable itemToInteract { get; set; }
    public void CheckInteraction(Camera3D Origin,PhysicsDirectSpaceState3D space)
    {
        // GetWorld3D().DirectSpaceState
         Vector3 origin = Origin.GlobalPosition;
        var direction = -Origin.GlobalTransform.Basis.Z;
        var spaceState = space;

        var query = new PhysicsRayQueryParameters3D
        {
            From = origin,
            To = origin + direction * 10f,
            CollideWithAreas = false,
            CollideWithBodies = true
        };

        var result = spaceState.IntersectRay(query);
        if (result.Count > 0)
        {
            var collider = result["collider"].AsGodotObject();
            var position = (Vector3)result["position"];
            Interactable item = collider as Interactable;
            if (item != null)
            {
                itemToInteract = item;
                itemToInteract.SetInteract(true);
            }
            itemToInteract = null;
        }
    }
}
