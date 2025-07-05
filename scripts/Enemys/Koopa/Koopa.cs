using System;
using Godot;

public partial class Koopa : CharacterBody2D {
    public enum KoopaColor { Red, Green }
    [Export] public KoopaColor Color;
    [Export] public AnimatedSprite2D animationKoopa;
    public float speed = 50.0f;
    public float jumpVelocity = -400.0f;
}
