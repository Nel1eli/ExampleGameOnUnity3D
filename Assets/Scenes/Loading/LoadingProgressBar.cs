using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = transform.GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = Loader.GetLoadingProgress();
    }
}
