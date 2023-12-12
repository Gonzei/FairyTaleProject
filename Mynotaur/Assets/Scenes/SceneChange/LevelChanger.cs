
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(string sceneName)
    {
        animator.SetTrigger("FadeOut");
        Invoke("FadeOut",.01f);
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeIn");
    }
}
