using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    public void LoadStartScene()
    {
        Loader.Load(Loader.Scene.StartLocation);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
