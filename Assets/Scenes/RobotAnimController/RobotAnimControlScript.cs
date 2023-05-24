using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimControlScript : MonoBehaviour
{
    //Robotのアニメーターコントローラー
    private Animator robotAnimator;
    //マウスクリックのフラグ
    private bool mouseLeftButtonFlag;
    [SerializeField] private GameObject laserSight ;
    private LineRenderer lineRenderer;
    private Vector3 lineEndPos;
    // Start is called before the first frame update
    void Start()
    {
        lineEndPos = transform.forward;

        robotAnimator = GetComponent<Animator>();
        mouseLeftButtonFlag = false;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.SetPosition(0, laserSight.transform.position);
        lineRenderer.SetPosition(1, lineEndPos*5);
    }

    // Update is called once per frame
    void Update()
    {
        //構えているかのフラグをセットする
        robotAnimator.SetBool("shotStanceFlag", GetShotStance());

        //構え中射撃
        if (robotAnimator.GetBool("shotStanceFlag")&&Input.GetMouseButton(0))
        {
            robotAnimator.SetBool("autoShotFlag", true);
        }
        else
        {
            robotAnimator.SetBool("autoShotFlag", false);
        }
    }

    /// <summary>
    /// マウスを押して銃を構えているか
    /// </summary>
    /// <returns>構えているなら真、いないなら偽</returns>
    private bool GetShotStance()
    {
        if (Input.GetMouseButtonDown(1))
        {

            mouseLeftButtonFlag = true;

        }
        else if (mouseLeftButtonFlag && Input.GetMouseButtonUp(1))
        {
            mouseLeftButtonFlag = false;
        }
        return mouseLeftButtonFlag;
    }


}
