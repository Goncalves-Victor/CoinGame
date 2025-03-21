using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Demo");
            Cursor.visible = false;
        }
    }
}
