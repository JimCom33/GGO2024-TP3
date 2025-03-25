using benjohnson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonManager : MonoBehaviour
{

    private Button soundButton;
    private Image buttonImage;
    public Sprite soundOnIcon, soundOffIcon;


    // Start is called before the first frame update
    void Start()
    {
        CreateSoundButton();
        UpdateButtonIcon();
    }

    void CreateSoundButton()
    {
        GameObject buttonObj = new GameObject("SoundButton");
        buttonObj.transform.SetParent(GameObject.Find("Canvas").transform);

        RectTransform rectTransform = buttonObj.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        rectTransform.anchoredPosition = new Vector2(50, -50);

        buttonImage = buttonObj.AddComponent<Image>();
        soundButton = buttonObj.AddComponent<Button>();
        soundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        SoundManager.instance.ToggleSound();
        UpdateButtonIcon();
    }

    void UpdateButtonIcon()
    {
        buttonImage.sprite = SoundManager.instance.IsMuted() ? soundOffIcon : soundOnIcon;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
