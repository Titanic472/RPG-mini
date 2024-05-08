using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderObjectMover : MonoBehaviour
{
    public GameObject ObjectToMove;
    public float minValue = 0f;
    public float maxValue = 10f;

    public void OnSliderValueChanged(float value){
        float MappedValue = Mathf.Lerp(minValue, maxValue, value);
            Vector3 NewPosition = ObjectToMove.transform.position;
            NewPosition.x = MappedValue;
            ObjectToMove.transform.position = NewPosition;
    }

    public void ChangeObjectToMove(GameObject NewObjectToMove){
        ObjectToMove = NewObjectToMove;
    }
}
