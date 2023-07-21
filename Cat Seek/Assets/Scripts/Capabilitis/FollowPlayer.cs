using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // O objeto a ser seguido

    private void Update()
    {
        // Verificar se o objeto alvo est� definido
        if (target != null)
        {
            // Atualizar a posi��o do objeto para a posi��o do objeto alvo
            transform.position = target.position;
        }
    }
}
