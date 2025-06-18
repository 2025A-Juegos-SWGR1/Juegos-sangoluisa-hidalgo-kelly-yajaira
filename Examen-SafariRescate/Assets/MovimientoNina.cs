using UnityEngine;

public class MovimientoNina : MonoBehaviour
{
    public float velocidad = 5f;

    public float minX = -7f;
    public float maxX = 7f;
    public float minY = -4f;
    public float maxY = 8f; 

    void Update()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = new Vector3(movX, movY, 0f).normalized * (velocidad * Time.deltaTime);
        transform.position += movimiento;

        // Limitar movimiento dentro del mapa
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );
    }
}