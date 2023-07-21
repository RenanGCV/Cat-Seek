using UnityEngine;

public class GunFire : MonoBehaviour
{
    public float pullForce = 10f; // Força de puxão
    public float pullDistance = 5f; // Distância de puxão
    private bool isPulling = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPulling = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPulling = false;
        }
    }

    private void FixedUpdate()
    {
        if (isPulling)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pullDirection = mousePosition - (Vector2)transform.position;
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, pullDirection, pullDistance);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.CompareTag("inimigos"))
                {
                    Rigidbody2D rb = hit.collider.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        Vector2 pullVector = transform.position - hit.collider.transform.position;
                        rb.AddForce(pullVector.normalized * pullForce);
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pullDirection = mousePosition - (Vector2)transform.position;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)pullDirection.normalized * pullDistance);
    }
}
