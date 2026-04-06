using UnityEngine;

public class GeneradorCubos : MonoBehaviour
{
    public GameObject cuboPrefab;
    public float tiempoEntreCubos = 2.5f;
    private float tiempoTemporizador;

    public float rangoHorizontal = 2.0f;
    public float rangoVertical = 1.0f;

    void Update()
    {
        tiempoTemporizador += Time.deltaTime;

        if (tiempoTemporizador >= tiempoEntreCubos)
        {
            GenerarCuboAleatorio();
            tiempoTemporizador = 0f;
        }
    }

    void GenerarCuboAleatorio()
    {
        float xAleatorio = Random.Range(-rangoHorizontal, rangoHorizontal);
        float yAleatorio = Random.Range(-rangoVertical, rangoVertical);

        Vector3 posicionAleatoria = transform.position + new Vector3(xAleatorio, yAleatorio, 0);

        Instantiate(cuboPrefab, posicionAleatoria, transform.rotation);
    }
}