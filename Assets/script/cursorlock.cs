using UnityEngine;

public class cursorlock : MonoBehaviour
{
    void Start()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
    }
}