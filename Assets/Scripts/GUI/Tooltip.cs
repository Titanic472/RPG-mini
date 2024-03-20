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
        Vector2 MousePos = MainCamera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x + TooltipRectTransform.rect.size.x*0.25f*DirectionModifier, Input.mousePosition.y - TooltipRectTransform.rect.height*0.25f));
        
        if (FollowCursor){
            //Description.transform.position = Title.transform.position - new Vector3(0, DescriptionRectTransform.rect.height*0.5f, 0);
            //Title.transform.position = new Vector3(MousePos.x + Offset.x,MousePos.y + Offset.y, 0);
            tooltip.transform.position = new Vector3(MousePos.x + Offset.x, MousePos.y + Offset.y, 0);
            //tooltip.transform.position = tooltip.transform.position - new Vector3(TooltipRectTransform.rect.size.x/2*DirectionModifier, TooltipRectTransform.rect.size.y/2, 0);
        }
        /*LayoutRebuilder.ForceRebuildLayoutImmediate(DescriptionRectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(TitleRectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(TooltipRectTransform);*/
    }

    public void OnPointerExit(PointerEventData EventData){
        tooltip.SetActive(false);
    }
}