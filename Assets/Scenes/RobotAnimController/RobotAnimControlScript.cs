using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimControlScript : MonoBehaviour
{
    //Robot�̃A�j���[�^�[�R���g���[���[
    [SerializeField] private Animator robotAnimator;
    //�}�E�X�N���b�N�̃t���O
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
        

        //�\���Ă��邩�̃t���O���Z�b�g����
        robotAnimator.SetBool("shotStanceFlag", GetShotStance());

        //�\�����ˌ�
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
    /// �}�E�X�������ďe���\���Ă��邩
    /// </summary>
    /// <returns>�\���Ă���Ȃ�^�A���Ȃ��Ȃ�U</returns>
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
