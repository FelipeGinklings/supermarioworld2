using Godot;
using System;

public partial class GrupDeath : GrubState {
    public override void Enter() {
        // Play the death animation
        grub.animationGrub.Play(grub.selectedColor + "-" + DEATH);
        // Delete the node after a short delay
        grub.QueueFree();
    }
}
