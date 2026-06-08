using Unity.Mathematics;
using UnityEngine;

public class player : MonoBehaviour
{
    public float velocidad = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal");
        float movimientoX = velocidadX * velocidad * Time.deltaTime;

        Vector3 posicion = transform.position;

        transform.position = new Vector3(posicion.x + movimientoX, posicion.y);
    }
}
