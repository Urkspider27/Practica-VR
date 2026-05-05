using UnityEngine;
using TMPro;

public class GameManagerFlechas : MonoBehaviour
{
    public static GameManagerFlechas instancia;

    public TextMeshProUGUI textoPuntos;
    public int puntosObjetivo = 20;
    public GameObject panelVictoria; // un canvas que muestras al ganar

    private int puntos = 0;

    void Awake()
    {
        instancia = this;
    }

    public void SumarPunto()
    {
        puntos++;
        textoPuntos.text = puntos.ToString();

        if (puntos >= puntosObjetivo)
        {
            panelVictoria.SetActive(true);
            // Pausar spawner
            FindFirstObjectByType<SpawnerFlechas>().enabled = false;
        }
    }
}