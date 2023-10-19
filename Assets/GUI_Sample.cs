using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_Sample : MonoBehaviour
{
    #region IMGUI 설명
    //Unity IMGUI(Immediate Mode GUI)
    //코드에 의해 구동되는 GUI 시스템
    //특징) 유니티에서 제공해주는 함수 OnGUI()를 통해
    //호출되고 구동
    //일반적은 유니티의 UI시스템(UGUI : 게임오브젝트 기반)
    //과 별개의 시스템으로 Start, Update 와 다른 별도의 영역에서
    //작업이 처리

    //해당 기능의 목적
    //인 게임 디버깅 디스플레이
    //스크립트 컴포넌트를 위한 인스펙터 제작
    //유니티 확장을 위한 에디터 윈도우 생성
    //쉽게 ui를 구현할 수 있어 입문용으로 활용
    #endregion

    private void OnGUI()
    {
        //box는 gui 배경 작업할때 사용
        GUI.Box(new Rect(10, 10, 1920, 1080), "MY MENU");
        //버튼
        //버튼을 눌렀을 경우를 작업할 때는 if문에 GUI를 생성합니다.
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
