using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewMRTKScene : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Name of the scene to be loaded when the button is selected.")]
    private string SceneToBeLoaded = "";

    [SerializeField]
    [Tooltip("Timeout in seconds before new scene is loaded.")]
    private float waitTimeInSecBeforeLoading = 0.25f;

    public DetermineDevice deviceTypeScript;

    public void LoadScene()
    {
        if (deviceTypeScript.isHololens)
        {
            LoadScene("Hololens");
        }

        else
        {
            LoadScene("WMR");
        }
    }

    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
        {
            StartCoroutine(LoadNewScene(sceneName));
        }
        else
        {
            Debug.Log($"Unsupported scene name: {sceneName}");
        }
    }

    public static string lastSceneLoaded = "";
    private IEnumerator LoadNewScene(string sceneName)
    {
        Debug.Log($"New scene name: {SceneToBeLoaded}");
        lastSceneLoaded = SceneToBeLoaded;
        yield return new WaitForSeconds(waitTimeInSecBeforeLoading);
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
