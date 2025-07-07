using Godot;

public partial class PlayerCamera : Camera2D {
    [Export] public bool enableSmoothing = true;
    [Export] public float smoothSpeed = 5.0f;

    private const float paddingBottom = 60.0f; // Padding to keep the camera above the player

    [Export] private CharacterBody2D player;

    [Export] private float cameraAdjust = 40f; // Amount past 40 pixels to adjust camera position
    private float originalY;
    private float fixedY;

    public override void _Ready() {
        // Store the initial Y position of the camera
        fixedY = GlobalPosition.Y;
        originalY = GlobalPosition.Y;

        // Enable camera smoothing if desired
        if (enableSmoothing) {
            Enabled = true;
        }
    }

    float registeredDownPosition = 0;

    public override void _Process(double delta) {
        if (player != null) {
            Vector2 targetPosition = new Vector2(player.GlobalPosition.X - (GetViewportRect().Size.X / 2), fixedY + paddingBottom);
            var amountPast40 = (int)((registeredDownPosition - player.GlobalPosition.Y) / 30);
            if (player.GlobalPosition.Y <= 40 && registeredDownPosition == 0) {
                registeredDownPosition = player.GlobalPosition.Y;
                targetPosition.Y -= 40;
                GlobalPosition = GlobalPosition.Lerp(targetPosition, smoothSpeed * (float)delta);
                fixedY -= 40; // Adjust the camera Y position based on player position
            } else if (player.GlobalPosition.Y >= registeredDownPosition) {
                registeredDownPosition = 0;
                targetPosition.Y += 40;
                GlobalPosition = GlobalPosition.Lerp(targetPosition, smoothSpeed * (float)delta);
                fixedY = originalY; // Reset the camera Y position to its original value
            } else {
                targetPosition.Y -= amountPast40 * 40;
                GlobalPosition = GlobalPosition.Lerp(targetPosition, smoothSpeed * (float)delta);
            }
        }
    }
}
