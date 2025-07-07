using Godot;
using System;

public partial class GrupDeath : GrubState {
    public override void Enter() {
        // Play the death animation
        grub.animationGrub.Play(grub.selectedColor + "-" + DEATH);

        GetTree().CreateTimer(0.11f).Timeout += grub.QueueFree;
    }
}
