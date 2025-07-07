using Godot;
using System;

public partial class GrupMerge : GrubState {

    public override void Enter() {
        grub.animationGrub.Play(grub.selectedColor + "-" + MERGE);
        CallDeferred(nameof(PerformMerge));
    }

    private void PerformMerge() {
        GetTree().CreateTimer(0.5f).Timeout += () => {
            Node parent = grub.GetParent();
            Vector2 shellPosition = grub.GlobalPosition;
            grub.QueueFree();
            PackedScene koopaScene = GD.Load<PackedScene>("res://scenes/koopa.tscn");
            Node koopaInstance = koopaScene.Instantiate();
            ((Node2D)koopaInstance).GlobalPosition = shellPosition;
            parent.AddChild(koopaInstance);
        };
    }
}
