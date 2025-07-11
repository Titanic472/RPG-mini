using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class Tooltip : MonoBehaviour, IPointerExitHandler
{
    public GameObject tooltip, Title, Description;
    public Vector2 Offset;
    public bool FollowCursor = false;
    private RectTransform TooltipRectTransform;
    private RectTransform DescriptionRectTransform;
    private RectTransform TitleRectTransform;
    public Camera MainCamera;

    private void Awake(){
        DescriptionRectTransform = Description.GetComponent<RectTransform>();
        TitleRectTransform = Title.GetComponent<RectTransform>();
        TooltipRectTransform = tooltip.GetComponent<RectTransform>();
        tooltip.SetActive(false);
    }
    
    public void SetTextAndResize(string NewTitle, string NewDescription, int DirectionModifier){
        Title.GetComponent<Text>().text = NewTitle;
        Description.GetComponent<Text>().text = NewDescription;

        TitleRectTransform.sizeDelta = new Vector2(Math.Min(Title.GetComponent<Text>().preferredWidth, 250), Title.GetComponent<Text>().preferredHeight);
        DescriptionRectTransform.sizeDelta = new Vector2(Math.Min(Description.GetComponent<Text>().preferredWidth, 250), Description.GetComponent<Text>().preferredHeight);
        TooltipRectTransform.sizeDelta = new Vector2(Math.Max(DescriptionRectTransform.rect.size.x, TitleRectTransform.rect.size.x)+8, DescriptionRectTransform.rect.size.y + TitleRectTransform.rect.size.y+4);
        tooltip.SetActive(true);
        //Vector2 MousePos = MainCamera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x + TooltipRectTransform.rect.size.x*0.25f*DirectionModifier, Input.mousePosition.y - TooltipRectTransform.rect.height*0.25f));
        
        if (FollowCursor) {
            Vector2 mouseScreenPos = Input.mousePosition;
            Vector2 tooltipSize = TooltipRectTransform.sizeDelta;

            // Get the parent canvas
            Canvas canvas = tooltip.GetComponentInParent<Canvas>();
            Vector2 anchoredPos;
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();

            // Convert screen point to local point in canvas
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                mouseScreenPos,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : MainCamera,
                out anchoredPos
            );

            // Offset so the tooltip appears next to the cursor
            anchoredPos += new Vector2(tooltipSize.x * 0.5f * DirectionModifier, -tooltipSize.y * 0.5f);
            anchoredPos += Offset;

            TooltipRectTransform.anchoredPosition = anchoredPos;
        }
        /*LayoutRebuilder.ForceRebuildLayoutImmediate(DescriptionRectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(TitleRectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(TooltipRectTransform);*/
    }

    public void OnPointerExit(PointerEventData EventData){
        tooltip.SetActive(false);
    }
}