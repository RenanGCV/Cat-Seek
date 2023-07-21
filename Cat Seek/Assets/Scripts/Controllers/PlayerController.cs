using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float maxSpeed = 10f; // Velocidade m�xima do jogador
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

        // Limitar a velocidade m�xima do jogador
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

        currentSpeed = rb.velocity.magnitude; // Armazena a velocidade atual do jogador

        // Verificar se o jogador est� no ch�o para permitir pulos
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar se o jogador est� tocando no ch�o
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
