
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneLoader")]
public class SceneLoader : ScriptableObject
{
    public int mainScene;
    public int streetScene;
    public GameObject loadingSphere;

    [NonSerialized] public Transform userLocation;

    public async void LoadStreetScene(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(streetScene, LoadSceneMode.Single);
        await new WaitUntil((() => asyncLoad.isDone));
    }
    
    public async void LoadSimulationScene(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainScene, LoadSceneMode.Single);
        await new WaitUntil((() => asyncLoad.isDone));
    }
}
