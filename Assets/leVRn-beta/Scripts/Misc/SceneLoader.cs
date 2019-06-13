﻿
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneLoader", menuName = "Misc/SceneLoader")]
public class SceneLoader : ScriptableObject
{
    public int mainScene;
    public int streetScene;
    public int kineticStreet;
    public int streetTest;
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

    public async void LoadKineticStreetScene(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(kineticStreet, LoadSceneMode.Single);
        await new WaitUntil((() => asyncLoad.isDone));
    }
    
    public async void LoadStreetTestScene(){
        Instantiate(loadingSphere, userLocation);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(streetTest, LoadSceneMode.Single);
        await new WaitUntil((() => asyncLoad.isDone));
    }
}
