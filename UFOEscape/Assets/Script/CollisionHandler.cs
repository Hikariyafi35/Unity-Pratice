using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour

{
    
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip SuccesSound;
    [SerializeField] AudioClip CrashSound;
    [SerializeField] ParticleSystem SuccesParticles;
    [SerializeField] ParticleSystem CrashParticles;

    AudioSource audioSource;
    
    bool isTransitioning = false;
    bool collisionDisabled = false;
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    void Update(){
        SkipLvl();
    }
    void OnCollisionEnter(Collision other) {
        if(isTransitioning || collisionDisabled){ return; }

            switch(other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("This thing is Friendly");
                    break;
                case "Finish":
                    Debug.Log("Congrats");
                    StartNextLvlSequence();
                    break;
                default:
                    Debug.Log("Sorry You Blew Up!");
                    StartCrashSequence(); 
                    break;
            }
    }
    void SkipLvl(){
        if(Input.GetKey(KeyCode.L)){
            StartnxtLvl();
        }else if(Input.GetKey(KeyCode.C)){
            collisionDisabled = !collisionDisabled;
        }
    }

    void StartCrashSequence(){
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(CrashSound);
        CrashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("restartLvl",delayTime); //Invoke give delay when objek get hit before going next scene
    }
    void StartNextLvlSequence(){
        isTransitioning = true;
        audioSource.Stop(); //stop all sound then start the sound effect
        SuccesParticles.Play();
        audioSource.PlayOneShot(SuccesSound);
        GetComponent<Movement>().enabled = false;
        Invoke("StartnxtLvl",delayTime);
    }
    void restartLvl(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void StartnxtLvl(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; //current lvl + 1 to go next lvl
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){ //next scene index equal to scene count on build setting
            nextSceneIndex = 0; // then go back to scene 0
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
