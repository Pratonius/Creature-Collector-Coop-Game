using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private Slider slider;
    private GameObject fill;
    private GameObject healthInfo;
    public Creature creature;

    private int testMaxHealth = 319;

    public bool playerSide;

    void Start() {
        slider = gameObject.GetComponent<Slider>();
        slider.value = 100;
        fill = transform.Find("Fill").gameObject;
        healthInfo = transform.Find("HealthInfo").gameObject;
        healthInfo.SetActive(false);
        SetupSlider();
    }

    void Update() {}

    public void OnSliderValueChanged(float value) {
        ChecKSliderStatus();
        if (value > 50) {
            SetColor(Color.green);
        } if (value < 50 && value > 25) {
            SetColor(Color.yellow);
        } else if (value < 25) {
            SetColor(Color.red);
        }
    }

    void SetColor(Color color) {
        fill.GetComponent<Image>().color = color;
    }

    void ChecKSliderStatus() {
        if (slider.value == 0) {
            //fill.SetActive(false);
        } else {
            fill.SetActive(true);
        }
    }

    void SetupSlider() {
        if (playerSide) {
            slider.direction = Slider.Direction.LeftToRight;
        } else {
            slider.direction = Slider.Direction.RightToLeft;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        healthInfo.SetActive(true);
        //Set to take health info and put in here.
        //healthInfo.GetComponent<TextMeshProUGUI>().text = $"{slider.value} {creature.GetCurrentHealth}/{creature.GetMaxHealth}";
        healthInfo.GetComponent<TextMeshProUGUI>().text = $"{Math.Round(slider.value)}%  {Math.Round(testMaxHealth*slider.value/100)}/{testMaxHealth}";
    }

    public void OnPointerExit(PointerEventData eventData) {
        healthInfo.SetActive(false);
    }
}
