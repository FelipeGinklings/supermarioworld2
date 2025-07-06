using Godot;

public partial class Victory : LevelState {
    public override void Enter() {
        gameLevel.Reset();
    }
}
