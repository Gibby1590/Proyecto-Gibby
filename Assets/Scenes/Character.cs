using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float vel;
    protected Vector2 inputMove;
    [SerializeField] protected float m_vida;
    protected float m_vidaActual;

    protected Rigidbody2D rb; // Rigidbody2D para físicas en 2D
    [SerializeField] protected float fuerzaSalto;
    [SerializeField] protected Transform laserTag;

    private void Start()
    {
        m_vidaActual = m_vida;
        rb = GetComponent<Rigidbody2D>(); // Inicializa Rigidbody2D
    }

    protected bool EstaEnSuelo()
    {
        if (laserTag == null) return false;

        // Raycast en 2D hacia abajo
        RaycastHit2D hit = Physics2D.Raycast(laserTag.position, Vector2.down, 0.2f);
        if (hit.collider != null)
        {
            return hit.collider.CompareTag("Suelo"); // True si toca suelo
        }
        return false;
    }

    public void TakeDamage(float damage)
    {
        m_vidaActual -= damage;
        Debug.Log("Vida actual: " + m_vidaActual);
    }

    public void DamagePlayer(float damage)
    {
        TakeDamage(damage);
    }

    public void Die()
    {
        if (m_vidaActual <= 0)
        {
            gameObject.SetActive(false); // o Destroy(gameObject);
        }
    }

    public void Mover()
    {
        // Movimiento horizontal en 2D
        Vector2 direction = new Vector2(inputMove.x, 0);
        rb.MovePosition(rb.position + direction * vel * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        if (laserTag == null) return;

        Gizmos.color = Color.yellow;
        // Línea de raycast en 2D
        Gizmos.DrawLine(laserTag.position, laserTag.position + (Vector3)Vector2.down * 0.2f);
    }
}