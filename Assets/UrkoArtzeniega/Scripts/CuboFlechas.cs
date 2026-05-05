using UnityEngine;

public enum Direccion { Arriba, Abajo, Izquierda, Derecha }

public class CuboFlechas : MonoBehaviour
{
    public Direccion direccionRequerida;

    // El spawner asignará esto al crear el cubo
    public GameObject flechaVisual; // arrastra el hijo en el Inspector

    public void SetDireccion(Direccion dir)
    {
        direccionRequerida = dir;

        switch (dir)
        {
            case Direccion.Arriba:
                flechaVisual.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direccion.Abajo:
                flechaVisual.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case Direccion.Izquierda:
                flechaVisual.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case Direccion.Derecha:
                flechaVisual.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
        }
    }
}