using UnityEngine;

public class EnemyFlee : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public float fleeDistance = 5f; // Dist�ncia de fuga
    public float fleeSpeed = 5f; // Velocidade de fuga

    private void Update()
    {
        // Calcula a dist�ncia entre o inimigo e o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Verifica se o jogador est� muito pr�ximo
        if (distanceToPlayer < fleeDistance)
        {
            // Calcula a dire��o oposta ao jogador
            Vector2 fleeDirection = transform.position - player.position;

            // Normaliza a dire��o e aplica a velocidade de fuga
            fleeDirection.Normalize();
            Vector2 fleeVelocity = fleeDirection * fleeSpeed;

            // Atualiza a posi��o do inimigo
            transform.position = (Vector2)transform.position + fleeVelocity * Time.deltaTime;
        }
    }
}
