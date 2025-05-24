using UnityEngine;

public class ToggleInfo : MonoBehaviour
{
    public GameObject[] infoObjects;

    private bool[] estados;

    private void Start()
    {
        estados = new bool[infoObjects.Length];
        for (int i = 0; i < estados.Length; i++)
        {
            estados[i] = false; // por defecto invisibles
        }
    }

    public void ToggleObject(int index)
    {
        if (infoObjects[index] != null)
        {
            estados[index] = !estados[index];
            infoObjects[index].SetActive(estados[index]);
        }
    }
}
