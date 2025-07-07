using Godot;
using System;

public partial class StairHead : Area2D {
    [Export] public AnimatedSprite2D animationHead;

    public string animationName = "idle";
}
