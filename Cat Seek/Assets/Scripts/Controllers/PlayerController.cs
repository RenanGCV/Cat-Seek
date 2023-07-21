using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float maxSpeed = 10f; // Velocidade máxima do jogador
    private bool isJumping = false;
    private Rigidbody2D rb;
    [SerializeField] float currentSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        // Movimento horizontal
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Limitar a velocidade máxima do jogador
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

        currentSpeed = rb.velocity.magnitude; // Armazena a velocidade atual do jogador

        // Verificar se o jogador está no chão para permitir pulos
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar se o jogador está tocando no chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
