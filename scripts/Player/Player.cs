using Godot;

public partial class Player : CharacterBody2D {
    [Export] public float speed = 100.0f;
    [Export] public float maxJump = -375.0f;
    [Export] public AnimatedSprite2D animationPlayer;

    public bool ReachedTheEnd;

    private void FinishLine(Node _body) {
        ReachedTheEnd = true;
    }
}
