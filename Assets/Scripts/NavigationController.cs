using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public AudioClip clickSound;
    public Animator anim;
    public KeyCode Next;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void GoToGameScene()
    {
        StartCoroutine(LoadScene(1, 1.4f));
        Application.LoadLevel(1);
    }

    public void GoToGameOverScene()
    {
        Application.LoadLevel(14);
    }
    
   
    public void soundInstruction()
    {
        FindObjectOfType<AudioManager>().PlaySingle(clickSound);
    }
    public void Exit()
    {
        FindObjectOfType<AudioManager>().PlaySingle(clickSound);
        Application.Quit();
    }
    public void GoToSpidersScene()
    {
        Application.LoadLevel(4);
    }
    public void GoToDarknessScene() 
    {
        Application.LoadLevel(6);
    }
    public void GoToClownScene()
    {
        Application.LoadLevel(8);
    }
    IEnumerator LoadScene(int scene, float wit)
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(wit);
        SceneManager.LoadScene(scene);
    }
    public void GoToIntroScene()
    {
        Application.LoadLevel(15);
    }
}
