using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_Sample : MonoBehaviour
{
    #region IMGUI ����
    //Unity IMGUI(Immediate Mode GUI)
    //�ڵ忡 ���� �����Ǵ� GUI �ý���
    //Ư¡) ����Ƽ���� �������ִ� �Լ� OnGUI()�� ����
    //ȣ��ǰ� ����
    //�Ϲ����� ����Ƽ�� UI�ý���(UGUI : ���ӿ�����Ʈ ���)
    //�� ������ �ý������� Start, Update �� �ٸ� ������ ��������
    //�۾��� ó��

    //�ش� ����� ����
    //�� ���� ����� ���÷���
    //��ũ��Ʈ ������Ʈ�� ���� �ν����� ����
    //����Ƽ Ȯ���� ���� ������ ������ ����
    //���� ui�� ������ �� �־� �Թ������� Ȱ��
    #endregion

    private void OnGUI()
    {
        //box�� gui ��� �۾��Ҷ� ���
        GUI.Box(new Rect(10, 10, 1920, 1080), "MY MENU");
        //��ư
        //��ư�� ������ ��츦 �۾��� ���� if���� GUI�� �����մϴ�.
        if(GUI.Button(new Rect(20, 40, 600, 300), "Scene 1"))
        {
            SceneManager.LoadScene(1);

        }
        if (GUI.Button(new Rect(10, 310, 600, 300), "Scene 1"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
