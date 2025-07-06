using Godot;
using System;

public partial class LevelPlaying : LevelState {

    private bool reachedTheEnd;
    public override void Enter() {
        gameLevel.GameTimer.Start();
    }

    private void FinishLine(Node _body) {
        reachedTheEnd = true;
    }

    public override void Update(double delta) {
        var (GameTimer, HitsRemaining) = gameLevel.GetPlayingValues();

        if (reachedTheEnd) {
            EmitSignal(State.SignalName.Transitioned, this, VICTORY);
        } else if (HitsRemaining == 0 || (int)GameTimer.TimeLeft == 0) {
            EmitSignal(State.SignalName.Transitioned, this, GAME_OVER);
        }
    }
}
