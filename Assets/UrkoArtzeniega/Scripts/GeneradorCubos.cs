using UnityEngine;

public class GeneradorCubos : MonoBehaviour
{
    public GameObject cuboPrefab;
    public GameObject bombaPrefab;
    [Range(0, 1)] public float probabilidadBomba = 0.5f; // 60% bombas

    public float tiempoEntreCubos = 2.5f;
    private float tiempoTemporizador;

    public float rangoHorizontal = 2.0f;
    public float rangoVertical = 1.0f;

    void Update()
    {
        tiempoTemporizador += Time.deltaTime;

        if (tiempoTemporizador >= tiempoEntreCubos)
        {
            GenerarObjetoAleatorio();
            tiempoTemporizador = 0f;
        }
    }

    void GenerarObjetoAleatorio()
    {
        float xAleatorio = Random.Range(-rangoHorizontal, rangoHorizontal);
        float yAleatorio = Random.Range(-rangoVertical, rangoVertical);
        Vector3 posicionAleatoria = transform.position + new Vector3(xAleatorio, yAleatorio, 0);

        // Cubo o Bomba?
        GameObject objetoAInstanciar = cuboPrefab;
        if (Random.value < probabilidadBomba)
        {
            objetoAInstanciar = bombaPrefab;
        }

        Instantiate(objetoAInstanciar, posicionAleatoria, transform.rotation);
    }
}