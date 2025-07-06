using Godot;

public partial class PlayerVictory : PlayerState {
    private float victoryWalkTime = 2.5f; // Tempo para caminhar para a direita
    private float currentWalkTime = 0.0f;
    private bool hasPlayedVictoryAnimation = false;
    private bool gameEnded = false;

    public override void Enter() {
        // Para qualquer input do jogador
        player.SetPhysicsProcess(false);

        // Reseta os valores para o estado de vitória
        currentWalkTime = 0.0f;
        hasPlayedVictoryAnimation = false;
        gameEnded = false;
    }

    public override void PhysicsUpdate(double delta) {
        // Se ainda não terminou de caminhar para a direita
        if (currentWalkTime < victoryWalkTime) {
            // Move o jogador para a direita
            player.Velocity = new Vector2(player.speed * 0.5f, player.Velocity.Y + player.GetGravity().Y * (float)delta);

            // Vira o sprite para a direita
            player.animationPlayer.FlipH = true;

            // Reproduz animação de caminhada
            if (player.animationPlayer.Animation != WALK) {
                player.animationPlayer.Play(WALK);
            }

            player.MoveAndSlide();
            currentWalkTime += (float)delta;
        }
        // Após caminhar, reproduz animação de vitória
        else if (!hasPlayedVictoryAnimation) {
            // Para o movimento
            player.Velocity = new Vector2(0.0f, player.Velocity.Y + player.GetGravity().Y * (float)delta);
            player.MoveAndSlide();

            // Reproduz animação de vitória
            player.animationPlayer.Play(VICTORY);
            hasPlayedVictoryAnimation = true;
            // Aguarda a animação de vitória terminar e então caminha mais um pouco
            GetTree().CreateTimer(1.5f).Timeout += () => {
                // Aguarda um pouco e então termina o jogo
                currentWalkTime = 0.0f; // Reset para usar novamente
                victoryWalkTime = 3.0f; // Tempo menor para caminhar após vitória
            };

        } else if ((currentWalkTime >= victoryWalkTime) && hasPlayedVictoryAnimation) {
            GetTree().CreateTimer(4.5f).Timeout += EndGame;
        } else if (!gameEnded) {
            player.Velocity = new Vector2(0.0f, player.Velocity.Y + player.GetGravity().Y * (float)delta);
            player.MoveAndSlide();
        }
    }

    private void EndGame() {
        if (!gameEnded) {
            gameEnded = true;
            // Pausa o jogo
            GetTree().Paused = true;
            // Aqui você pode adicionar mais lógica, como:
            // - Mostrar tela de vitória
            // - Salvar pontuação
            // - Ir para próximo nível
            // - Voltar ao menu principal
            EmitSignal(State.SignalName.Transitioned, this, IDLE);
        }
    }

    public override void Exit() {
        // Reativa o processamento de física do jogador quando sair do estado
        player.SetPhysicsProcess(true);
    }
}
