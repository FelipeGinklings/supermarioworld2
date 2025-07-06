using Godot;
using System;

public partial class GrubState : State {

    public const string CREATION = "creation";
    public const string WALK = "walk";
    public const string WAIT = "wait";
    public const string DEATH = "death";
    public const string MERGE = "merge";

    // Animation names
    public const string KICKED = "-kicked";

    // Directions for walking
    public enum WalkDirections { Left, Right }
    public const string LEFT = "left";
    public const string RIGHT = "right";

    protected Grub grub;

    public override void _Ready() {
        grub = Owner as Grub;
        System.Diagnostics.Debug.Assert(grub != null, "The KoopaState state type must be used only in the player scene. It needs the owner to be a Koopa node.");
    }
}