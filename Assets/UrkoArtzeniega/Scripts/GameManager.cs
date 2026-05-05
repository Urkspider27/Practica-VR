using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public TextMeshProUGUI marcadorTexto;

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

    void OnEnable() { SceneManager.sceneLoaded += OnSceneLoaded; }
    void OnDisable() { SceneManager.sceneLoaded -= OnSceneLoaded; }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject objScore = GameObject.Find("Score");
        if (objScore != null)
        {
            marcadorTexto = objScore.GetComponent<TextMeshProUGUI>();
            ActualizarTexto();
        }
    }

    public void SumarPunto(int valor)
    {
        if (juegoTerminado) return;

        puntos += valor;
        if (puntos < 0) puntos = 0; // Evitar puntos negativos

        ActualizarTexto();

        if (puntos >= puntosObjetivo)
        {
            TerminarJuego();
        }
    }

    void ActualizarTexto()
    {
        if (marcadorTexto != null)
        {
            marcadorTexto.text = puntos + " / " + puntosObjetivo;
        }
    }

    void TerminarJuego()
    {
        juegoTerminado = true;
        if (marcadorTexto != null) marcadorTexto.text = "¡FIN DEL JUEGO!";
        Invoke("IrAlMenu", 3f);
    }

    void IrAlMenu()
    {
        // Reiniciamos los valores antes de volver al menú
        juegoTerminado = false;
        puntos = 0;
        SceneManager.LoadScene("MenuVR");
    }
}