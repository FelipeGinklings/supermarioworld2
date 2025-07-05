using Godot;

public partial class Player : CharacterBody2D {
    [Export] public float speed = 100.0f;
    [Export] public float jumpHeight = -250.0f;
    [Export] public AnimatedSprite2D animationPlayer;
}
