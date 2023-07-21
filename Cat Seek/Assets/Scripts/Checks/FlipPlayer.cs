using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        // Inverter a direção do sprite se necessário
        if ((moveX < 0 && isFacingRight) || (moveX > 0 && !isFacingRight))
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        // Inverter a escala do sprite no eixo X para inverter a direção
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
