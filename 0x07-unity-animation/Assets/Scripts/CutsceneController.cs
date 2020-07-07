using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject timerCanvas;
    public PlayerController playerController;
    public GameObject mainCamera;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).length < animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            timerCanvas.SetActive(true);
            playerController.enabled = true;
            mainCamera.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("Has Finsihed");
        }
    }
}
