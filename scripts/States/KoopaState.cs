using System.Collections.Generic;

public partial class KoopaState : State {
    public const string WALK = "walk";
    public const string GREEN = "green";
    public const string RED = "red";

    private static readonly Dictionary<int, string> colors = new Dictionary<int, string>
    {
        { 0, RED },
        { 1, GREEN }
    };

    protected Koopa koopa;

    public string selectedColor;

    public override void _Ready() {
        koopa = Owner as Koopa;
        System.Diagnostics.Debug.Assert(koopa != null, "The KoopaState state type must be used only in the player scene. It needs the owner to be a Koopa node.");
        selectedColor = colors[(int)koopa.Color];
    }
}