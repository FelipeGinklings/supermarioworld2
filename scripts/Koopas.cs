using Godot;
using System;

public partial class Koopas : Node {
    [Export] Koopa koopa;
    [Export] private int _nKoopas = 1;

    public override void _Ready() {
        CreateKoopas();
    }

    private void CreateKoopas() {
        for (int i = 0; i < _nKoopas; i++) {
            Koopa newKoopa = koopa.Duplicate() as Koopa;
            // Get the width from the collision shape
            CollisionShape2D collisionShape = koopa.GetNode<CollisionShape2D>("Floor");
            float koopaWidth = 32.0f; // Default width

            if (collisionShape?.Shape is RectangleShape2D rect) {
                koopaWidth = rect.Size.X;
            }

            newKoopa.Position = new Vector2(koopa.Position.X - (i * koopaWidth + 10), koopa.Position.Y);
            AddChild(newKoopa);
        }
    }


}
