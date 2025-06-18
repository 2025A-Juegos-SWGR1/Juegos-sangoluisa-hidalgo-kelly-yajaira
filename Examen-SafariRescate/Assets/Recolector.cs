using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Recolector : MonoBehaviour
{
    private GameObject objetoRecogido = null;
    private Vector3 posicionOriginalAnimal;

    [Tooltip("Tag de la zona de entrega. Ej: ZonaTigre o ZonaMono")]
    public string tagZonaEntrega = "ZonaTigre"; // Cambiar según nivel en el Inspector

    [Tooltip("Panel que aparece cuando entregas al animal")]
    public GameObject panelFelicidades; // Asignar en Inspector
    
    void Start()
    {
        // Guarda la posición original del mono al iniciar el juego
        GameObject animal = GameObject.FindGameObjectWithTag("Animal");
        if (animal != null)
        {
            posicionOriginalAnimal = animal.transform.position;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Chocó con la pared invisible
        if (collision.gameObject.CompareTag("ParedInvisible") && objetoRecogido != null)
        {
            objetoRecogido.transform.SetParent(null);
            objetoRecogido.transform.position = posicionOriginalAnimal;
            objetoRecogido = null;
            Debug.Log("¡Chocaste una pared! Regresa por el mono.");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // RECOGER animal
        if (other.CompareTag("Animal") && objetoRecogido == null)
        {
            objetoRecogido = other.gameObject;
            objetoRecogido.transform.SetParent(transform);
            objetoRecogido.transform.localPosition = new Vector3(0, 1, 0);
        }

        // ENTREGAR animal en la zona correcta
        else if (other.CompareTag(tagZonaEntrega) && objetoRecogido != null)
        {
            objetoRecogido.transform.SetParent(null);
            objetoRecogido.transform.position = other.transform.position;
            objetoRecogido = null;

            if (panelFelicidades != null)
                panelFelicidades.SetActive(true);
        }
    }

    // Botón para pasar al siguiente nivel
    public void IrAlSiguienteNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }
}