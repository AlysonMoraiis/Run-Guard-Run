using UnityEngine;

public class TempAutoDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 16);
    }
}
