using UnityEngine;

public enum Direccion { Arriba, Abajo, Izquierda, Derecha }

public class CuboFlechas : MonoBehaviour
{
    public Direccion direccionRequerida;

    // El spawner asignará esto al crear el cubo
    public GameObject flechaVisual;

    public void SetDireccion(Direccion dir)
    {
        direccionRequerida = dir;

        // Usamos localRotation para que rote sobre el propio cubo y no se descoloque
        switch (dir)
        {
            case Direccion.Arriba:
                flechaVisual.transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direccion.Abajo:
                flechaVisual.transform.localRotation = Quaternion.Euler(0, 0, 180);
                break;
            case Direccion.Izquierda:
                flechaVisual.transform.localRotation = Quaternion.Euler(0, 0, 90);
                break;
            case Direccion.Derecha:
                flechaVisual.transform.localRotation = Quaternion.Euler(0, 0, -90);
                break;
        }
    }
}