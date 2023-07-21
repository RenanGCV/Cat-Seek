using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // O objeto a ser seguido

    private void Update()
    {
        // Verificar se o objeto alvo está definido
        if (target != null)
        {
            // Atualizar a posição do objeto para a posição do objeto alvo
            transform.position = target.position;
        }
    }
}
