using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;

    // Usamos la estructura del profe: privado pero visible en el Inspector
    [SerializeField] private InputActionReference botonMenu;

    private bool pausado = false;

    private void OnEnable()
    {
        // Suscribirse al evento 'performed' (cuando se pulsa el botón)
        botonMenu.action.performed += TogglePausa;
    }

    private void OnDisable()
    {
        // Desuscribirse para evitar errores de memoria
        botonMenu.action.performed -= TogglePausa;
    }

    private void TogglePausa(InputAction.CallbackContext context)
    {
        Debug.Log("¡Botón Menú pulsado!"); // Añadimos el aviso en consola del profe

        pausado = !pausado;
        panelPausa.SetActive(pausado);

        // Colocar el panel delante del jugador
        if (pausado)
        {
            panelPausa.transform.position = Camera.main.transform.position
                                          + Camera.main.transform.forward * 1.5f;
            panelPausa.transform.rotation = Quaternion.LookRotation(
                panelPausa.transform.position - Camera.main.transform.position
            );
        }

        Time.timeScale = pausado ? 0f : 1f;
    }

    public void Reanudar()
    {
        pausado = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuVR"); // Asegúrate de que tu escena de inicio se llama exactamente "MenuVR"
    }
}