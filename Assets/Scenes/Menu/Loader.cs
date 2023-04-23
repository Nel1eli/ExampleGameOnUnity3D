using System;
using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonoBehavior : MonoBehaviour { }
    public enum Scene
    {
        MenuScene,
        Loading,
        StartScene,
        StartLocation,
    }

    private static Action onLoaderCallBack;

    private static AsyncOperation loaderAsyncOperation;

    public static void Load(Scene scene)
    {
        onLoaderCallBack = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehavior>().StartCoroutine(LoadSceneAsync(scene));
            
        };
        SceneManager.LoadScene(Scene.Loading.ToString());

    }

    private static IEnumerator LoadSceneAsync (Scene scene)
    {
        yield return null;

        loaderAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!loaderAsyncOperation.isDone)
        {
            yield return null;
        }

    }

    public static float GetLoadingProgress()
    {
        if (loaderAsyncOperation != null)
        {
            return loaderAsyncOperation.progress;
        } else
        {
            return 1f;
        }
    }

    public static void LoaderCallBack ()
    {
        if (onLoaderCallBack != null)
        {
            onLoaderCallBack();
            onLoaderCallBack = null;
        }
    }
}
