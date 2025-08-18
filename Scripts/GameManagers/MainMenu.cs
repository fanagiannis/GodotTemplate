using Godot;
using System;

public partial class MainMenu : Node3D
{
    [Export]
    private PackedScene shootingRangeScene, multiplayerScene;
    public void LoadShootingRange()
    {
        GetTree().ChangeSceneToPacked(shootingRangeScene);
    }
    public void LoadMultiplayer()
    {
        GetTree().ChangeSceneToPacked(multiplayerScene);
    }
    public void Exit()
    {
        GetTree().Quit();
    }
}
