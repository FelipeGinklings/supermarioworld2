using Godot;

public partial class LevelVictory : LevelState {
    public override void Enter() {
        gameLevel.Reset();
    }
}
