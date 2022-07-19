using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarController : MonoBehaviour
{
    private Image barImage;

    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private TextMeshProUGUI barTMP;

    private float currentValue;
    private float currentFill;
    public float MyMaxValue { get; set; }

    public float MyCurrentValue {
        get { return currentValue; }
        set {
            if (value > MyMaxValue) currentValue = MyMaxValue;
            else if (value < 0) currentValue = 0;
            else currentValue = value;

            currentFill = currentValue / MyMaxValue;
            barTMP.text = currentValue + " / " + MyMaxValue;
        }
    }

    private void Start() {
        barImage = GetComponent<Image>();
    }

    private void Update() {
        // HP, MP의 값이 변경되는 경우
        if(currentFill != barImage.fillAmount)
        {
            // bar 게이지가 차는걸 Lerp 메서드로 부드럽게 채워지도록 변경
            barImage.fillAmount = Mathf.Lerp(barImage.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    // bar 현재값과 최대값을 세팅
    public void Initialize(float currentValue, float maxValue) {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
