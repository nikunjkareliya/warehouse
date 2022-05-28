using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float rotateSpeed = 10;
    [SerializeField] CharacterController controller;
    [SerializeField] PlayerInput playerInput;
    
    private void Awake()
    {        
        InvokeRepeating("CheckForNearestBoxes", 1, 0.2f);
    }

    float xInput, zInput;    
    void Update()
    {
        //xInput = Input.GetAxis("Horizontal");
        //zInput = Input.GetAxis("Vertical");
        xInput = playerInput.GetHorizontalInput();
        zInput = playerInput.GetVerticalInput();
        Vector3 moveVector = new Vector3(xInput, 0, zInput);
        controller.Move(moveVector * Time.deltaTime * moveSpeed);
    }

    public Box nearestBox;
    public Box secondNearestBox;    
    [HideInInspector] public List<Box> tempList;
    void CheckForNearestBoxes() {
        
        foreach (Box box in ProtoManager.Instance.SpawnedBoxes) {
            if (!tempList.Contains(box)) {             
                tempList.Add(box);
            }
        }

        nearestBox = GetNearestBox(tempList);
        //Debug.Log("nearestBox: " + nearestBox.name);
        nearestBox.SetColorData(nearestBox.GetData().nearestColor);

        Box temp = nearestBox;
        tempList.Remove(temp);

        secondNearestBox = GetNearestBox(tempList);
        //Debug.Log("secondNearestBox: " + secondNearestBox.name);
        secondNearestBox.SetColorData(secondNearestBox.GetData().secondNearestColor);
        
        foreach (Box box in ProtoManager.Instance.SpawnedBoxes)
        {
            if (box != nearestBox && box != secondNearestBox)
            {
                box.SetColorData(secondNearestBox.GetData().defaultColor);
            }
        }
        tempList.Clear();       
    }
    
    Box GetNearestBox(List<Box> listBoxes) {

        Box nearestBox = listBoxes[0];
        float nearestDist = Vector3.Distance(transform.position, listBoxes[0].transform.position);
        for (int i = 1; i < listBoxes.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, listBoxes[i].transform.position);
            if (dist < nearestDist) {
                nearestDist = dist;
                nearestBox = listBoxes[i];
            }
        }
        return nearestBox;

    }
}
