using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopText : MonoBehaviour{
    [SerializeField] private GameObject PopTextPrefab;
    [SerializeField] private Vector3 Scale;
    public void Pop(int oldQuantity, int newQuantity){
        if (oldQuantity != newQuantity)
        {
            GameObject popText = Instantiate(PopTextPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
            PopLocal(popText, new Vector3(0,0,-0.5f), new Vector3(0.75f * Scale.x, 0.75f  * Scale.y, 0 * Scale.z));
            popText.GetComponent<PopUpController>()
                .SetText(
                    oldQuantity < newQuantity ? $"+{newQuantity - oldQuantity}" : $"{newQuantity - oldQuantity}",   //Check for number sign
                    oldQuantity < newQuantity ? Color.green : Color.red                                             //Check for TextColor
                );
            popText.transform.localScale = Scale;
        }
    }
    public void Pop(string text, Color color){
        GameObject popText = Instantiate(PopTextPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
        PopLocal(popText, new Vector3(0, 0, -1), new Vector3(1, 1, 0));
        popText.GetComponent<PopUpController>().SetText(text,color);
    }
    public void Pop(Vector3 popLocalPosition, Vector3 popRandRange, Color color, string text)
    {
        GameObject popText = Instantiate(PopTextPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
        PopLocal(popText, popLocalPosition, popRandRange);
        popText.GetComponent<PopUpController>().SetText(text, color);
    }

    private void PopLocal(GameObject popText, Vector3 popLocalPosition, Vector3 popRandRange){
        popText.transform.localPosition = new Vector3(
                popLocalPosition.x + Random.Range(-popRandRange.x, popRandRange.x),
                popLocalPosition.y + Random.Range(-popRandRange.y, popRandRange.y),
                popLocalPosition.z + Random.Range(-popRandRange.z, popRandRange.z)
            ); //SetRandPos
        popText.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
