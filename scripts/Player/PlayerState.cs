public partial class PlayerState : State {
    public const string IDLE = "IDLE";
    public const string RUN = "RUN";
    public const string JUMP = "JUMP";
    public const string FALL = "FALL";
    public const string HOLD = "HOLD";
    public const string VICTORY = "VICTORY";
    public const string DEATH = "DEATH";
    public const string SPIN_JUMP = "SPIN_JUMP";
    public const string LOOK_UP = "LOOK_UP";
    public const string DUCK = "DUCK";
    public const string WALK = "WALK";
    public const string SKID = "SKID";
    public const string CLIMB = "CLIMB";
    public const string GROW_UP = "GROW_UP";
    public const string SHRINK_DOWN = "SHRINK_DOWN";

    protected Player player;

    public override void _Ready() {
        player = Owner as Player;
        System.Diagnostics.Debug.Assert(player != null, "The PlayerState state type must be used only in the player scene. It needs the owner to be a Player node.");
    }
}