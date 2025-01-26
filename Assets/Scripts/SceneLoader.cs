using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void MainMenuLoader()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void AirLoader()
    {
        SceneManager.LoadScene("AirScene");
    }

    public void EarthLoader()
    {
        SceneManager.LoadScene("EarthScene");
    }

    public void DarknessLoader()
    {
        SceneManager.LoadScene("DarknessScene");
    }

    public void LightLoader()
    {
        SceneManager.LoadScene("LightScene");
    }

    public void WaterLoader()
    {
        SceneManager.LoadScene("WaterScene");
    }

    public void FireLoader()
    {
        SceneManager.LoadScene("FireScene");
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        // Stop playing the scene in the Unity Editor
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}