using Godot;
using System.Collections.Generic;

public partial class CreateStairs : Area2D {

    [Export] Area2D head2d, stair2d;
    [Export] public AnimatedSprite2D animationHead;
    [Export] public float stairSpacing = 16.0f; // Espaçamento entre escadas
    [Export] public float headSpeed = 50.0f; // Velocidade do movimento do cabeçalho
    private bool isBuilding = false;
    private float count = 0f;
    private Vector2 initialHeadPosition;
    public override void _Process(double delta) {
        if (isBuilding) {
            // Mover o cabeçalho para cima
            Vector2 currentPos = head2d.GlobalPosition;
            Vector2 newPos = new Vector2(currentPos.X, currentPos.Y - 1f);
            head2d.GlobalPosition = newPos;
            if (count >= 16) {
                count = 0; // Resetar o contador                    
                Area2D newStair = stair2d.Duplicate() as Area2D;
                var nextStairY = currentPos.Y; // Calcular a nova posição Y da escada
                newStair.Position = new Vector2(currentPos.X, nextStairY);
                head2d.GetParent().GetParent().AddChild(newStair); // Adicionar a nova escada ao avo
            } else {
                count += 1f;
            }
        }
    }

    public void StartStairs(Area2D _) {
        if (!isBuilding) {
            initialHeadPosition = head2d.GlobalPosition;
            initialHeadPosition = new Vector2(initialHeadPosition.X, 0); // Posição inicial do cabeçalho
            head2d.GlobalPosition = initialHeadPosition;
            count = 0f;

            // Iniciar animação do cabeçalho
            if (animationHead != null) {
                animationHead.Play("idle");
            }
            isBuilding = true;
            // Reiniciar animação do cabeçalho
            if (animationHead != null) {
                animationHead.Play("idle");
            }

            GD.Print("Iniciando construção das escadas!");
        }
    }

    public void EndStairs(Area2D _) {
        if (isBuilding) {
            isBuilding = false;
            if (animationHead != null) {
                animationHead.Stop();
            }
            head2d.QueueFree();
            GD.Print("Construção das escadas finalizada!");
        }
    }
}
