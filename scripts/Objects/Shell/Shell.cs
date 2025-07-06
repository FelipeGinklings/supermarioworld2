using Godot;
using Godot.Collections;

public partial class Shell : RigidBody2D {
    [Export] public AnimatedSprite2D animationShell;
    [Export] public float speed = 300.0f;

    public enum ShellColor { Red, Green }
    [Export] public ShellColor Color;

    private static readonly Dictionary<ShellColor, string> colors = new() {
        { ShellColor.Red, "red" },
        { ShellColor.Green, "green" }
    };
    public string selectedColor => colors[Color];
    public override void _Ready() {
        GravityScale = 1.0f; // Keep gravity for falling
        LockRotation = true; // Prevent rotation
    }
}
