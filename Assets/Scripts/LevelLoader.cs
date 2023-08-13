using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
           LoadGlassWorld(SceneManager.GetActiveScene());
        }
    }

    private void LoadGlassWorld(Scene scene)
    {
        StartCoroutine(scene.name.Equals("RealWorld") ? LoadLevel("GlassWorld") : LoadLevel("RealWorld"));
    }

    IEnumerator LoadLevel(string levelName)
    {
      transition.SetTrigger("Start");

      yield return new WaitForSeconds(transitionTime);
      
      SceneManager.LoadScene(levelName);

    }
}
