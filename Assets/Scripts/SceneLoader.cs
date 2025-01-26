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
}