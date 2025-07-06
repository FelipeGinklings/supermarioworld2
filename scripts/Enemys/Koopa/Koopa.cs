
using Godot;
using Godot.Collections;

public partial class Koopa : CharacterBody2D {
    public enum KoopaColor { Red, Green }
    [Export] public KoopaColor Color;
    [Export] public AnimatedSprite2D animationKoopa;
    public float speed = 30.0f;
    public float jumpVelocity = -400.0f;

    public const string GREEN = "green";
    public const string RED = "red";

    private static readonly Dictionary<KoopaColor, string> colors = new() {
        { KoopaColor.Red, RED },
        { KoopaColor.Green, GREEN }
    };

    public string selectedColor => colors[Color];

    public void GotHit() {
        GD.Print("Got Hit!");
    }
}
