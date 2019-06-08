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
    public AudioClip previously;
    public AudioClip busExample;
    public AudioClip pedestrianExample;
    public AudioClip flagExample;
    
    private Animator anim;
    [NonSerialized]
    public AudioSource audioSource;

    private static readonly int On = Animator.StringToHash("PowerOn");
    private static readonly int Wave = Animator.StringToHash("Wave");
    private static readonly int ToScreen = Animator.StringToHash("GestureToScreen");
    private static readonly int Talking = Animator.StringToHash("Talking");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Hit = Animator.StringToHash("Hit");

    [NonSerialized]
    public bool changingLocation;

    // Start is called before the first frame update
    void Awake(){
        anim = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        holder.sceneLoader.userLocation = user;
        LookAtUser();
    }

    void Update(){
        
    }

    public void ChangeLocation(){
        changingLocation = true;
        anim.SetBool(Idle, false);
        anim.SetTrigger(Run);
        iTween.MoveTo(transform.parent.gameObject,
            iTween.Hash("position", holder.propController.guideLocation, "speed", 2, "looktarget",
                holder.propController.guideLocation, "oncomplete", "CompleteLocationChange", "oncompletetarget", gameObject, "easetype",
                iTween.EaseType.linear));

    }

    public void CompleteLocationChange(){
        anim.SetBool(Idle, true);
        LookAtUser();
        changingLocation = false;
    }

    void LookAtUser(){
        if (transform.parent != null){
            transform.parent.LookAt(mainCamera,Vector3.up);
        }
        else{
            transform.LookAt(mainCamera,Vector3.up);
        }
        
    }

    public void HitBall(){
        anim.SetTrigger(Hit);
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

    public void Previously(){
        PlayAudio(previously);
    }

    public void BusExample(){
        PlayAudio(busExample);
    }

    public void FlagExample(){
        PlayAudio(flagExample);
    }

    public void PedestrianExample(){
        PlayAudio(pedestrianExample);
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

    public void ChangeAudioGain(int volume){
        GetComponentInChildren<ResonanceAudioSource>().gainDb = volume;
    }
    public void TriggerHitEnded(){
        holder.animationTriggers.HitEnded = true;
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
