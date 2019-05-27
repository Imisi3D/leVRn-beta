
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneLoader")]
public class SceneLoader : ScriptableObject
{
    public int mainScene;
    public int streetScene;
    public GameObject loadingSphere;

    public async void LoadStreetScene(){
        Instantiate(loadingSphere);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(streetScene, LoadSceneMode.Single);
        await new WaitUntil((() => asyncLoad.isDone));
    }
}
