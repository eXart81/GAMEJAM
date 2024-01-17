using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{

    public SceneFader sceneFader;


    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

}