using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimControlScript : MonoBehaviour
{
    //Robotのアニメーターコントローラー
    [SerializeField] private Animator robotAnimator;
    //マウスクリックのフラグ
    private bool mouseLeftButtonFlag;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        mouseLeftButtonFlag = false;   
    }

    // Update is called once per frame
    void Update()
    {
        robotAnimator.SetBool("runFlag", playerController.GetInputFlag());
        

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
