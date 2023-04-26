using UnityEngine;
using UnityEngine.Video;

public class StartSceneTrailer : MonoBehaviour
{
    [Header("Трейлер")]
    [SerializeField] VideoPlayer movie;

    private bool checkPlay;
    void Update()
    {
        if (movie.isPlaying)
            checkPlay = true;
        if (!movie.isPlaying && checkPlay)
        {
            Loader.Load(Loader.Scene.StartLocation);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) 
            movie.Stop();
    }
}
