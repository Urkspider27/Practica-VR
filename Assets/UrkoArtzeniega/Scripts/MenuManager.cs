using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TMP_Dropdown comboCubos;
    public Toggle checkSables;

    public void EmpezarNivelFacil()
    {
        GuardarConfiguracion();
        SceneManager.LoadScene("NivelFacil");
    }

    public void EmpezarNivelComplicado()
    {
        GuardarConfiguracion();
        SceneManager.LoadScene("NivelDificil");
    }

    public void EmpezarNivelFlechitas()
    {
        GuardarConfiguracion();
        SceneManager.LoadScene("NivelFlechitas");
    }

    private void GuardarConfiguracion()
    {
        if (GameManager.instance != null)
        {
            // Leemos el número del Dropdown
            int cantidad = int.Parse(comboCubos.options[comboCubos.value].text);
            GameManager.instance.puntosObjetivo = cantidad;

            // Leemos el Checkbox
            GameManager.instance.dosSables = checkSables.isOn;
        }
    }
}