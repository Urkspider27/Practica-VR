using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI marcadorTexto;

    // Variables configurables desde el Menú
    [HideInInspector] public int puntosObjetivo = 20;
    [HideInInspector] public bool dosSables = false;

    private int puntos = 0;
    private bool juegoTerminado = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Para que no se borre al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPunto(int valor)
    {
        if (juegoTerminado) return;

        puntos += valor;
        // Evitamos puntos negativos
        if (puntos < 0) puntos = 0;

        marcadorTexto.text = "Puntos: " + puntos + " / " + puntosObjetivo;

        if (puntos >= puntosObjetivo)
        {
            TerminarJuego();
        }
    }

    void TerminarJuego()
    {
        juegoTerminado = true;
        marcadorTexto.text = "¡FIN DEL JUEGO!";
        // Opcional: Invoke para volver al menú en 3 segundos
        Invoke("IrAlMenu", 3f);
    }

    void IrAlMenu()
    {
        SceneManager.LoadScene("MenuVR");
    }
}