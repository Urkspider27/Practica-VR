using UnityEngine;
using TMPro; // Necesario para controlar el texto

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI marcadorTexto;
    private int puntos = 0;
    private bool juegoTerminado = false;

    void Awake() { instance = this; }

    public void SumarPunto()
    {
        if (juegoTerminado) return;

        puntos++;
        marcadorTexto.text = puntos.ToString();

        if (puntos >= 20)
        {
            TerminarJuego();
        }
    }

    void TerminarJuego()
    {
        juegoTerminado = true;
        marcadorTexto.text = "¡FIN DEL JUEGO!";
        // Aquí podrías detener el Spawner si quieres
        Time.timeScale = 0; // Esto pausa el movimiento de los cubos
    }
}