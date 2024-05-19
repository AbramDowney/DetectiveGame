using UnityEngine;

public class secondPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player")){
            LoadNewScene();
        }
    }

    void LoadNewScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Parcour");
    }
}
