using Godot;

public partial class End : Area2D {
    private void OnBodyEntered(Node body) {
        if (body is Player player) {
            // Notifica o gerenciador de nível
            GetTree().CallGroup("LevelManager", "OnPlayerReachedEnd");
            player.ReachedTheEnd = true;
        }
    }
}
