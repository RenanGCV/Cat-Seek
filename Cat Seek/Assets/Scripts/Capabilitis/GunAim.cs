using UnityEngine;

public class GunAim : MonoBehaviour
{

    
    private void Update()
    {
        // Obter a posição do mouse em coordenadas de tela
        Vector3 mousePosition = Input.mousePosition;

        // Converter a posição do mouse de coordenadas de tela para coordenadas no mundo
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcular a direção do objeto em relação à posição do mouse
        Vector3 direction = worldMousePosition - transform.position;

        // Normalizar a direção para ter comprimento 1
        direction.Normalize();

        // Calcular o ângulo em radianos a partir da direção
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotacionar o objeto na direção do mouse
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
