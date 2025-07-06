public partial class PlayerState : State {
    // Animation names
    public const string IDLE = "idle";
    public const string RUN = "run";
    public const string JUMP = "jump";
    public const string FALL = "fall";
    // public const string HOLD = "hold"; // Animação não existe no SpriteFrames
    public const string VICTORY = "victory";
    public const string DEATH = "death";
    public const string SPIN_JUMP = "spinJump";
    public const string WALK = "walk";
    public const string SKID = "skid";
    public const string CLIMB = "climb";
    // public const string GROW_UP = "grow_up"; // Animação não existe no SpriteFrames
    // public const string SHRINK_DOWN = "shrink_down"; // Animação não existe no SpriteFrames

    // Animations names only
    public const string LOOK_UP = "look_up";
    public const string DUCK = "duck";

    // Input action names
    public const string INPUT_LEFT = "ui_left";
    public const string INPUT_RIGHT = "ui_right";
    public const string INPUT_UP = "ui_up";
    public const string INPUT_DOWN = "ui_down";
    public const string INPUT_JUMP = "ui_accept";

    protected Player player;

    public override void _Ready() {
        player = Owner as Player;
        System.Diagnostics.Debug.Assert(player != null, "The PlayerState state type must be used only in the player scene. It needs the owner to be a Player node.");
    }
}