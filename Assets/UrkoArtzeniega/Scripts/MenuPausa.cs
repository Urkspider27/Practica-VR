using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;
    public InputActionReference botonMenu; // asignas el botón Menu del mando izquierdo

    private bool pausado = false;

    void OnEnable() => botonMenu.action.performed += TogglePausa;
    void OnDisable() => botonMenu.action.performed -= TogglePausa;

    void TogglePausa(InputAction.CallbackContext ctx)
    {
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
        SceneManager.LoadScene("MenuVR"); // el nombre de tu escena de menú
    }
}