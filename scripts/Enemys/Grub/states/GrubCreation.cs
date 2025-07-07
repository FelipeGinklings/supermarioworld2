using Godot;
using System;

public partial class GrubCreation : GrubState {
    private float moveTime = 1f; // Tempo para mover para a direita (em segundos)
    private float currentMoveTime = 0.0f;
    private bool hasFinishedMoving = false;
    public override void Enter() {
        grub.animationGrub.Play(grub.selectedColor + KICKED);
        grub.animationGrub.FlipH = true;

        // Reseta os valores para o movimento
        currentMoveTime = 0.0f;
        hasFinishedMoving = false;
    }

    public override void Exit() {
        grub.animationGrub.FlipH = false;
    }

    public override void PhysicsUpdate(double delta) {
        // Se ainda não terminou de se mover para a direita
        if (currentMoveTime < moveTime && !hasFinishedMoving) {
            // Move o grub para a direita
            grub.Velocity = new Vector2(grub.driftingSpeed * (moveTime - currentMoveTime), grub.Velocity.Y + grub.GetGravity().Y * (float)delta);

            // Vira o sprite para a direita
            grub.animationGrub.FlipH = true;

            grub.MoveAndSlide();
            currentMoveTime += (float)delta;
        }
        // Após terminar o movimento, para o grub
        else if (!hasFinishedMoving) {
            // Para o movimento horizontal
            grub.Velocity = new Vector2(0.0f, grub.Velocity.Y + grub.GetGravity().Y * (float)delta);
            grub.MoveAndSlide();
            hasFinishedMoving = true;
            EmitSignal(State.SignalName.Transitioned, this, WALK);
            return;
        }
        // Continua aplicando gravidade se já terminou de se mover
        else {
            grub.Velocity = new Vector2(0.0f, grub.Velocity.Y + grub.GetGravity().Y * (float)delta);
            grub.MoveAndSlide();
        }
    }
}
