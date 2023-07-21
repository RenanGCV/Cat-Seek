using UnityEngine;

public class EnemyFlee : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float fleeDistance = 5f; // Distância de fuga
    public float fleeSpeed = 5f; // Velocidade de fuga

    private void Update()
    {
        // Calcula a distância entre o inimigo e o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Verifica se o jogador está muito próximo
        if (distanceToPlayer < fleeDistance)
        {
            // Calcula a direção oposta ao jogador
            Vector2 fleeDirection = transform.position - player.position;

            // Normaliza a direção e aplica a velocidade de fuga
            fleeDirection.Normalize();
            Vector2 fleeVelocity = fleeDirection * fleeSpeed;

            // Atualiza a posição do inimigo
            transform.position = (Vector2)transform.position + fleeVelocity * Time.deltaTime;
        }
    }
}
