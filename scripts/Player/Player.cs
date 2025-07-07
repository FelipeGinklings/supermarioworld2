using Godot;

public partial class Player : CharacterBody2D {
    [Export] public float speed = 100.0f;
    [Export] public float maxJump = -375.0f;
    [Export] public AnimatedSprite2D animationPlayer;

    public bool ReachedTheEnd;
    public bool IsOnStairs = false;

    public void ExitedStairs() {
        GD.Print("Player: ExitedStairs");
        IsOnStairs = false;
    }


    private void FinishLine(Node _body) {
        ReachedTheEnd = true;
    }
}
