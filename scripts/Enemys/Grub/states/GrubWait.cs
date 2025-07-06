using Godot;
using System;

public partial class GrubWait : GrubState {
    public override void Enter() {
        // Play the wait animation
        grub.animationGrub.Play(grub.selectedColor + KICKED);
    }

    public override void Exit() {
        // Stop the wait animation
        grub.animationGrub.Stop();
    }
}
