using UnityEngine;

public class ConfiguradorSables : MonoBehaviour
{
    public GameObject espadaIzquierda;

    void Start()
    {
        if (GameManager.instance != null)
        {
            espadaIzquierda.SetActive(GameManager.instance.dosSables);
        }
    }
}