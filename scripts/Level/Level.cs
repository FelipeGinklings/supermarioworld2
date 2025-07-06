using Godot;
public partial class Level : Node {
    [Export] public Timer GameTimer { get; set; }
    [Export] public int Coins { get; set; } = 0;
    [Export] public int Points { get; set; } = 0;
    [Export] public int YoshiCoins { get; set; } = 0;
    [Export] public int Lives { get; set; } = 5;
    [Export] public int HitsRemaining { get; set; } = 1;
    [Export] public int LevelPoints { get; set; } = 0;
    [Export] Player player;

    public (Timer GameTimer, int Coins, int Points, int YoshiCoins, int Lives, int LevelPoints) GetWinningValues() {
        return (GameTimer, Coins, Points, YoshiCoins, Lives, LevelPoints);
    }

    public (Timer GameTimer, int HitsRemaining) GetPlayingValues() {
        return (GameTimer, HitsRemaining);
    }

    public (Timer GameTimer, int Coins, int Points, int YoshiCoins, int Lives, int HitsRemaining, int LevelPoints) GetLosingValues() {
        return (GameTimer, Coins, Points, YoshiCoins, Lives, HitsRemaining, LevelPoints);
    }

    public override void _Ready() {
        AddToGroup("LevelManager");
    }

    public void Reset() {
        Coins = 0;
        Points = 0;
        YoshiCoins = 0;
        Lives = 5;
        HitsRemaining = 1;
        LevelPoints = 0;
    }
}
