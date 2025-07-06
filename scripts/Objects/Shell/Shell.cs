using Godot;
using Godot.Collections;

public partial class Shell : RigidBody2D {
    [Export] public AnimatedSprite2D animationShell;
    [Export] public float speed = 100.0f;

    public enum ShellColor { Red, Green }
    [Export] public ShellColor Color;

    private static readonly Dictionary<ShellColor, string> colors = new() {
        { ShellColor.Red, "red" },
        { ShellColor.Green, "green" }
    };

    public string selectedColor => colors[Color];
}
