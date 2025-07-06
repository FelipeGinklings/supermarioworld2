using Godot;
public partial class Level : Node {
    [Export] public Timer GameTimer { get; set; }
    [Export] public int Coins { get; set; } = 0;
    [Export] public int Points { get; set; } = 0;
    [Export] public int YoshiCoins { get; set; } = 0;
    [Export] public int Lives { get; set; } = 5;
    [Export] public int HitsRemaining { get; set; } = 1;
    [Export] public int LevelPoints { get; set; } = 0;

    public bool PlayerReachedEnd { get; private set; } = false;

    public (Timer GameTimer, int Coins, int Points, int YoshiCoins, int Lives, int HitsRemaining, int LevelPoints, bool PlayerReachedEnd) GetValues() {
        return (GameTimer, Coins, Points, YoshiCoins, Lives, HitsRemaining, LevelPoints, PlayerReachedEnd);
    }

    public override void _Ready() {
        AddToGroup("LevelManager");
    }

    public void OnPlayerReachedEnd() {
        PlayerReachedEnd = true;
        GD.Print("Player reached the end! Victory condition set.");
    }
}
