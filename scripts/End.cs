using Godot;

public partial class End : Area2D {
    private void OnBodyEntered(Node body) {
        if (body is Player) {
            GetTree().CallGroup("LevelManager", "OnPlayerReachedEnd");
        }
    }
}
