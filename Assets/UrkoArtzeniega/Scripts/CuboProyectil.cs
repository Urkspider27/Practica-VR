using UnityEngine;

public class CuboProyectil : MonoBehaviour
{
    public float velocidad = 5f;
    public bool esBomba = false; // Marcar esta casilla solo en el Prefab de la bomba
    private Vector3 direccion;

    void Start()
    {
        if (Camera.main != null)
        {
            // pequeño offset aleatorio al destino
            float offset = Random.Range(-1.0f, 1.0f);
            Vector3 destino = new Vector3(Camera.main.transform.position.x + offset, Camera.main.transform.position.y, Camera.main.transform.position.z);
            direccion = (destino - transform.position).normalized;
        }
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Arma"))
        {
            if (esBomba)
            {
                GameManager.instance.SumarPunto(-2); // La bomba resta
            }
            else
            {
                GameManager.instance.SumarPunto(1); // El cubo suma
            }
            Destroy(gameObject);
        }
    }
}