public partial class LevelState : State {
    public const string VICTORY = "victory";
    public const string PLAYING = "playing";
    public const string GAME_OVER = "gameOver";

    protected Level gameLevel;

    public override void _Ready() {
        gameLevel = Owner as Level;
        System.Diagnostics.Debug.Assert(gameLevel != null, "The LevelState state type must be used only in the level scene. It needs the owner to be a Level node.");
    }
}