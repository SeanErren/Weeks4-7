using UnityEngine;

public class Toggle : MonoBehaviour
{
    public void toggleObject()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
