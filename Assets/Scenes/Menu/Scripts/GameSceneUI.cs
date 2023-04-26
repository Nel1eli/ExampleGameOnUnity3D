using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    public void LoadStartScene()
    {
        Loader.Load(Loader.Scene.StartScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadSettingsScene()
    {
        Loader.Load(Loader.Scene.SettingsScene);
    }

    public void LoadMenuScene()
    {
        Loader.Load(Loader.Scene.MenuScene);
    }

    
}
