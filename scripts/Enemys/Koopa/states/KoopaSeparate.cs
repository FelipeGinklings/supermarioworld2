using Godot;
using System;

public partial class KoopaSeparate : KoopaState {

    public override void Enter() {
        // GD.Print("KoopaSeparate: Entering state");
        // Use CallDeferred to avoid physics query flushing issues
        CallDeferred(nameof(PerformSeparation));
    }

    private void PerformSeparation() {
        GetTree().CreateTimer(0.11f).Timeout += () => {
            Node parent = koopa.GetParent();
            Vector2 koopaPosition = koopa.GlobalPosition;
            koopa.QueueFree();
            PackedScene grubScene = GD.Load<PackedScene>("res://scenes/grub.tscn");
            PackedScene shellScene = GD.Load<PackedScene>("res://scenes/shell.tscn");
            Node grubInstance = grubScene.Instantiate();
            Node shellInstance = shellScene.Instantiate();
            ((Node2D)grubInstance).GlobalPosition = koopaPosition + Vector2.Right * 20;
            parent.AddChild(grubInstance);
            ((Node2D)shellInstance).GlobalPosition = koopaPosition + Vector2.Left * 20;
            parent.AddChild(shellInstance);
        };
    }

}
