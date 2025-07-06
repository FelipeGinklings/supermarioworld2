
public partial class KoopaState : State {
    public const string WALK = "walk";

    protected Koopa koopa;

    public override void _Ready() {
        koopa = Owner as Koopa;
        System.Diagnostics.Debug.Assert(koopa != null, "The KoopaState state type must be used only in the player scene. It needs the owner to be a Koopa node.");
    }
}