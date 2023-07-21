using UnityEngine;

public class GunAim : MonoBehaviour
{

    
    private void Update()
    {
        // Obter a posi��o do mouse em coordenadas de tela
        Vector3 mousePosition = Input.mousePosition;

        // Converter a posi��o do mouse de coordenadas de tela para coordenadas no mundo
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcular a dire��o do objeto em rela��o � posi��o do mouse
        Vector3 direction = worldMousePosition - transform.position;

        // Normalizar a dire��o para ter comprimento 1
        direction.Normalize();

        // Calcular o �ngulo em radianos a partir da dire��o
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotacionar o objeto na dire��o do mouse
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
