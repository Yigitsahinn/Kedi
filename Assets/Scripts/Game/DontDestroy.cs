using Unity.VisualScripting;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
