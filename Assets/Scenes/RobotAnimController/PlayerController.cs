using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject cameraObj;
    private Vector3 forwardVec;
    private Vector3 rightVec;
    private bool inputFlag;
    // Start is called before the first frame update
    void Start()
    {
        var aimVec = transform.position - cameraObj.transform.position;
        aimVec.y = 0;
        forwardVec = aimVec.normalized;
        rightVec = Vector3.Cross(Vector3.up, aimVec).normalized;
        Debug.Log(forwardVec);
        Debug.Log(rightVec);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVec=new Vector3();
        if(Input.GetKey(KeyCode.W))
        {
            inputVec += forwardVec;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVec += rightVec ;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVec -= forwardVec ;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVec -= rightVec ;
        }
        Debug.Log(inputVec.magnitude);
        if(inputVec.magnitude<=0.1f)
        {
            inputFlag= false;
            return;

        }
        else
        {
            inputFlag = true;
        }
        inputVec*=0.01f;
        Debug.Log(inputVec);
        transform.position += inputVec;

       
        var _rotation = Quaternion.LookRotation(-inputVec);
        var rotation = Quaternion.Slerp(this.transform.rotation, _rotation, 0.1f);
        transform.rotation=rotation;

    }

    public bool GetInputFlag()
    {
        return inputFlag;
    }
}
