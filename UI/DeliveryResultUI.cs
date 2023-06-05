using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{

    private const string POPUP = "PopUp";

    [SerializeField] private Image backgorundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color succesColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite succesSprite;
    [SerializeField] private Sprite failedSprite;


    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {

        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;

        gameObject.SetActive(false);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e) {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgorundImage.color = failedColor;
        iconImage.sprite = failedSprite;
        messageText.text = "DELIVERY\nFAILED";
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e) {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgorundImage.color = succesColor;
        iconImage.sprite = succesSprite;
        messageText.text = "DELIVERY\nSUCCESS"; ;
    }
}
