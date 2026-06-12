using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [Header("Movimiento y Salto")]
    public float velocidad = 8f;
    public float fuerzaSalto = 12f;

    [Header("Mecanica de Pared")]
    public LayerMask capaPared;
    public float distanciaRayo = 1.2f;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
  
      }

        bool paredDerecha = Physics2D.Raycast(transform.position, Vector2.right, distanciaRayo, capaPared);
        bool paredIzquierda = Physics2D.Raycast(transform.position, Vector2.left, distanciaRayo, capaPared);

        if ((paredDerecha && movimientoX > 0) || (paredIzquierda && movimientoX < 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
        void OnDrawGizmo()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * distanciaRayo);
            Gizmos.DrawLine(transform.position, transform.position + Vector3.left * distanciaRayo);
        }
    }
}
