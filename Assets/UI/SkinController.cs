using UnityEngine;

public class SkinController : MonoBehaviour
{
    public GameObject player;

    private CharacterControl controllerScript;

    // Start is called before the first frame update
    private void Start()
    {
        if (controllerScript == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            controllerScript = player.GetComponent<CharacterControl>();
        }
    }

    // Update is called once per frame
    public void ChangeSkin(int skinIndex)
    {
        controllerScript.SetSkin(skinIndex);
    }
}