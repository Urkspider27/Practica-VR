using UnityEngine;

public class SpawnerFlechas : MonoBehaviour
{
    public GameObject cuboPrefab;
    public float intervalo = 2f;
    public float distanciaSpawn = 8f;
    public float destinationOffsetRange = 1.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= intervalo)
        {
            timer = 0;
            SpawnCubo();
        }
    }

    void SpawnCubo()
    {
        // Misma lógica de spawn que en fases anteriores
        Vector3 spawnPos = Camera.main.transform.position + Vector3.forward * distanciaSpawn;

        GameObject cubo = Instantiate(cuboPrefab, spawnPos, Quaternion.identity);

        // Asignar dirección aleatoria
        Direccion dirAleatoria = (Direccion)Random.Range(0, 4);
        cubo.GetComponent<CuboFlechas>().SetDireccion(dirAleatoria);

        // Mover hacia el jugador con offset
        float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);
        Vector3 destino = new Vector3(
            Camera.main.transform.position.x + offset,
            Camera.main.transform.position.y,
            Camera.main.transform.position.z
        );

        Vector3 direccion = (destino - spawnPos).normalized;
        cubo.GetComponent<Rigidbody>().linearVelocity = direccion * 4f;
    }
}