using Godot;
using System;

public partial class KoopaSeparate : KoopaState {

    public override void Enter() {
        GD.Print("KoopaSeparate: Entering state");
        // Use CallDeferred to avoid physics query flushing issues
        CallDeferred(nameof(PerformSeparation));
    }

    private void PerformSeparation() {
        GetTree().CreateTimer(0.15f).Timeout += () => {
            Node parent = koopa.GetParent();
            Vector2 koopaPosition = koopa.GlobalPosition;
            koopa.QueueFree();
            PackedScene grubScene = GD.Load<PackedScene>("res://scenes/grub.tscn");
            Node grubInstance = grubScene.Instantiate();
            ((Node2D)grubInstance).GlobalPosition = koopaPosition;
            parent.AddChild(grubInstance);
        };
    }

}
