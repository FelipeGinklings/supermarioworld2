using Godot;
using System;

public partial class Victory : LevelState {
    public override void Enter() {
        GD.Print("VICTORY! Level completed!");
    }
}
