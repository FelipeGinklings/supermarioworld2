using Godot;
using System;

public partial class Playing : LevelState {
    public override void Enter() {
        gameLevel.GameTimer.Start();
    }
    public override void Update(double delta) {
        var (GameTimer, HitsRemaining, PlayerReachedEnd) = gameLevel.GetPlayingValues();

        if (PlayerReachedEnd) {
            EmitSignal(State.SignalName.Transitioned, this, VICTORY);
        } else if (HitsRemaining == 0 || (int)GameTimer.TimeLeft == 0) {
            EmitSignal(State.SignalName.Transitioned, this, GAME_OVER);
        }
    }
}
