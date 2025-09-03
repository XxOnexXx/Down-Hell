
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timer;
    
    void Start()
    {

    }


    void Update()
    {
        timer += Time.deltaTime;
        StartCoroutine(LoadNextScene());
        

    }

    void IncreaseLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    IEnumerator LoadNextScene()
    {
        
        yield return new WaitForSeconds(7);
        IncreaseLevel();
    }
}
