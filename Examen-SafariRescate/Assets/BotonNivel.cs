using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonNivel : MonoBehaviour
{
    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}