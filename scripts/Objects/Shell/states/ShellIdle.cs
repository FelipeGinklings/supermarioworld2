using Godot;
using System;

public partial class ShellIdle : ShellState {
    private bool isStomping = true;

    public override void Enter() {
        // GD.Print("ShellIdle: Enter");
        shell.LinearVelocity = Vector2.Zero;
        shell.animationShell.Play(shell.selectedColor + "-idle");
        isStomping = true;
    }

    public void GoToLeft(Area2D _) {
        // GD.Print("ShellIdle: GoToLeft from Area2D");
        direction = WalkDirections.Left;
        isStomping = false;
    }

    public void GoToRight(Area2D _) {
        // GD.Print("ShellIdle: GoToRight from Area2D");
        direction = WalkDirections.Right;
        isStomping = false;
    }

    public override void Update(double delta) {
        if (!isStomping) {
            EmitSignal(State.SignalName.Transitioned, this, SPIN);
        }
    }

    public override void Exit() {
        // GD.Print("ShellIdle: Exit");
        shell.animationShell.Stop();
    }
}
