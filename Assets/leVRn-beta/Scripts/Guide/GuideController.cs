using System;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    
    public ScriptableObjectsHolder holder;
    public Transform mainCamera;
    public Transform user;

    public GameObject speechBubble;
    
    [Header("Voice Overs")] 
    public AudioClip introduction;
    public AudioClip energyDefinition;
    public AudioClip potentialEnergy;
    public AudioClip potentialContinue;
    public AudioClip potentialPosition;
    public AudioClip potentialBook;
    public AudioClip streetIntroduction;
    public AudioClip birdExample;
    public AudioClip signpostExample;
    public AudioClip fruitsExample;
    public AudioClip potentialConclusion;
    public AudioClip kineticIntroduction;
    public AudioClip kineticExample;
    public AudioClip kineticConclusion;
    
    private Animator anim;
    [NonSerialized]
    public AudioSource audioSource;

    private static readonly int On = Animator.StringToHash("PowerOn");
    private static readonly int Wave = Animator.StringToHash("Wave");
    private static readonly int ToScreen = Animator.StringToHash("GestureToScreen");
    private static readonly int Talking = Animator.StringToHash("Talking");
    private static readonly int Idle = Animator.StringToHash("Idle");

    // Start is called before the first frame update
    void Awake(){
        anim = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        holder.sceneLoader.userLocation = user;
    }

    void Update(){
        transform.LookAt(mainCamera,Vector3.up);
    }

    // Update is called once per frame
    public void PotentialEnergy(){
        PlayAudio(potentialEnergy);
    }

    public void PotentialContinue(){
        PlayAudio(potentialContinue);
    }

    public void PotentialPosition(){
        PlayAudio(potentialPosition);
    }

    public void PotentialBook(){
        PlayAudio(potentialBook);
    }
    
    public void Introduction(){
        PlayAudio(introduction);
    }

    public void DefineEnergy(){
        PlayAudio(energyDefinition);
    }

    public void StreetIntroduction(){
        PlayAudio(streetIntroduction);
    }

    public void FruitsExample(){
        PlayAudio(fruitsExample);
    }

    public void SignpostExample(){
        PlayAudio(signpostExample);
    }

    public void BirdExample(){
        PlayAudio(birdExample);
    }

    public void PotentialConclusion(){
        PlayAudio(potentialConclusion);
    }

    public void KineticIntroduction(){
        PlayAudio(kineticIntroduction);
    }

    public void KineticExample(){
        PlayAudio(kineticExample);
    }

    public void KineticConclusion(){
        PlayAudio(kineticConclusion);
    }

    private void PlayAudio(AudioClip clip){
        audioSource.PlayOneShot(clip);
        anim.SetBool(Talking,true);
        speechBubble.SetActive(true);
    }

    public void PowerOn(){
        anim.SetTrigger(On);
    }

    public void GestureToScreen(){
        anim.SetTrigger(ToScreen);
    }

    public void DoneTalking(){
        anim.SetBool(Talking, false);
        speechBubble.SetActive(false);
    }

    public void ForceIdle(){
        anim.SetBool(Idle, true);
    }

    public void TriggerWaveBegun(){
        holder.animationTriggers.WaveBegun = true;
    }

    public void TriggerWaveEnded(){
        holder.animationTriggers.WaveEnded = true;
    }

    public void TriggerPowerOnEnded(){
        holder.animationTriggers.PowerOnEnded = true;
    }
    
    
}
