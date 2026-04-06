using UnityEngine;

public class CuboProyectil : MonoBehaviour
{
    public float velocidad = 5f; // Un poco más rápido para que sea divertido
    private Vector3 direccion;

    void Start()
    {
        if (Camera.main != null)
        {
            direccion = (Camera.main.transform.position - transform.position).normalized;
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
            GameManager.instance.SumarPunto();
            Destroy(gameObject);
        }
    }
}