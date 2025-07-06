using Godot;

public partial class Grub : CharacterBody2D {
    [Export] public AnimatedSprite2D animationGrub;
    public float speed = 30.0f;
    public float driftingSpeed = 100.0f;
    public float jumpVelocity = -80.0f;
    public string selectedColor;

    // Construtor sem parâmetros necessário para o Godot
    public Grub() {
        speed = 30.0f;
        jumpVelocity = -80.0f;
        selectedColor = "red";
    }

    public Grub(string color) {
        speed = 30.0f;
        jumpVelocity = -80.0f;
        selectedColor = color;
    }

}
