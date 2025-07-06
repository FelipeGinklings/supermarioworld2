using Godot;
using System;

public partial class ShellIdle : ShellState {

    public override void Enter() {
        GD.Print("ShellIdle: Enter");
        shell.LinearVelocity = Vector2.Zero;
        shell.animationShell.Play(shell.selectedColor + "-idle");
    }

    public void GoToLeft(Area2D area) {
        if (area.Name == FOOT) {
            GD.Print("ShellIdle: GoToLeft from Area2D");
            direction = WalkDirections.Left;
            EmitSignal(State.SignalName.Transitioned, this, SPIN);
        }
    }

    public void GoToRight(Area2D area) {
        if (area.Name == FOOT) {
            GD.Print("ShellIdle: GoToRight from Area2D");
            direction = WalkDirections.Right;
            EmitSignal(State.SignalName.Transitioned, this, SPIN);
        }
    }

    public override void Exit() {
        GD.Print("ShellIdle: Exit");
        shell.animationShell.Stop();
    }
}
