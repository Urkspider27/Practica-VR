using UnityEngine;

public class SableFlechas : MonoBehaviour
{
    private Vector3 posicionAnterior;
    private Vector3 velocidadSable;

    // Umbral mínimo de velocidad para que cuente como corte
    public float velocidadMinima = 1.5f;

    void Update()
    {
        velocidadSable = (transform.position - posicionAnterior) / Time.deltaTime;
        posicionAnterior = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        CuboFlechas cubo = other.GetComponent<CuboFlechas>();
        if (cubo == null) return;

        // Ignoramos golpes muy lentos
        if (velocidadSable.magnitude < velocidadMinima) return;

        Direccion direccionCorte = GetDireccionCorte();

        if (direccionCorte == cubo.direccionRequerida)
        {
            // Corte correcto
            GameManagerFlechas.instancia.SumarPunto();
        }

        Destroy(other.gameObject);
    }

    private Direccion GetDireccionCorte()
    {
        // Miramos en qué eje se mueve más el sable
        float x = velocidadSable.x;
        float y = velocidadSable.y;

        if (Mathf.Abs(y) > Mathf.Abs(x))
        {
            return y > 0 ? Direccion.Arriba : Direccion.Abajo;
        }
        else
        {
            return x > 0 ? Direccion.Derecha : Direccion.Izquierda;
        }
    }
}