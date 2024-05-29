using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealthBarTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private Image image;
    private GameObject healthInfo;
    public GameObject healthBar;
    public Creature creature;

    private int testMaxHealth = 319;

    public bool playerSide = true;

    void Start() {
        Debug.Log(transform.childCount);
        image = healthBar.GetComponent<Image>();
        image.fillAmount = 1;
        healthInfo = transform.Find("HealthInfo").gameObject;
        healthInfo.SetActive(false);
        SetupSlider();
    }

    void LateUpdate() {
        OnValueChanged();
    }

    public void OnValueChanged() {
        if (image.fillAmount > 0.5) {
            SetColor(Color.green);
        } if (image.fillAmount < 0.5 && image.fillAmount > 0.25) {
            SetColor(Color.yellow);
        } else if (image.fillAmount < 0.25) {
            SetColor(Color.red);
        }
    }

    void SetColor(Color color) {
        image.color = color;
    }


    void SetupSlider() {
        //currently not working. jesper will fix at some point XD
        if (playerSide) {
            Debug.Log(image.fillOrigin);
            image.fillOrigin = (int)Image.OriginHorizontal.Left;
            Debug.Log(image.fillOrigin);
        } else {
            Debug.Log(image.fillOrigin);
            image.fillOrigin = (int)Image.OriginHorizontal.Right;
            Debug.Log(image.fillOrigin);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("TEST");
        healthInfo.SetActive(true);
        //Set to take health info and put in here.
        //healthInfo.GetComponent<TextMeshProUGUI>().text = $"{image.fillAmount} {creature.GetCurrentHealth}/{creature.GetMaxHealth}";
        healthInfo.GetComponent<TextMeshProUGUI>().text = $"{Math.Round(image.fillAmount)}%  {Math.Round(testMaxHealth*image.fillAmount/100)}/{testMaxHealth}";
    }

    public void OnPointerExit(PointerEventData eventData) {
        healthInfo.SetActive(false);
    }
}