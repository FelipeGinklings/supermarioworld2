using Godot;

public partial class PlayerCamera : Camera2D {
    [Export] public bool enableSmoothing = true;
    [Export] public float smoothSpeed = 5.0f;

    private const float paddingBottom = 50.0f; // Padding to keep the camera above the player

    [Export] private CharacterBody2D player;
    private float fixedY;

    public override void _Ready() {
        // Store the initial Y position of the camera
        fixedY = GlobalPosition.Y;

        // Enable camera smoothing if desired
        if (enableSmoothing) {
            Enabled = true;
        }
    }

    public override void _Process(double delta) {
        if (player != null) {
            Vector2 targetPosition = new Vector2(player.GlobalPosition.X - (GetViewportRect().Size.X / 2), fixedY + paddingBottom);

            if (enableSmoothing) {
                // Smooth camera movement only on X axis
                GlobalPosition = GlobalPosition.Lerp(targetPosition, smoothSpeed * (float)delta);
            } else {
                // Direct camera movement
                GlobalPosition = targetPosition;
            }
        }
    }
}
