using Godot;
using System;

public partial class ShellState : State {
    public const string IDLE = "-idle";
    public const string SPIN = "-spin";

    protected Shell shell;

    public override void _Ready() {
        shell = Owner as Shell;
        System.Diagnostics.Debug.Assert(shell != null, "The ShellState state type must be used only in the player scene. It needs the owner to be a Shell node.");
    }

}
