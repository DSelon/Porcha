# Porcha

### 프로젝트 개요

유니티 게임 개발 프로젝트

___

### 개발 기간

2017.9. ~ 2017.11. (3개월)

___

### 역할 분담

|이름|역할|
|:--:|:--:|
|고성현|개발|
|고주용|아트|
|한창희|기획|

___

### 적용된 기술

**Unity** | **C#**

___

### 작동 영상

https://blog.naver.com/cgko321/223845545049

___

### 프로젝트 세팅 방법

1. **Unity 6000.0.41f1** 버전의 유니티를 설치한다.
2. 해당 프로젝트를 컴퓨터로 내려받는다.

___

### 프로젝트 구조

#### 폴더 구조
|경로|용도|
|:--|:--|
|Assets \ Category|작업이 이루어지는 폴더|
|Assets \ Items|에셋 리소스/프로젝트 설정 등의 폴더|
|Assets \ Resources|기타 리소스 폴더|

|경로|용도|
|:--|:--|
|Assets \ Category \ Images|이미지 폴더|
|Assets \ Category \ Plans|기획서 폴더|
|Assets \ Category \ Prefabs|프리팹 폴더|
|Assets \ Category \ Scenes|씬 폴더|
|Assets \ Category \ Scripts|스크립트 폴더|
|Assets \ Category \ Sounds|사운드 폴더|

#### 씬 구조
|이름|용도|
|:--|:--|
|Menu_Main|게임이 처음 실행되면 나타나는 메인 메뉴 화면|
|Menu_Developers|개발자 화면|
|Menu_Stage|스테이지 선택 화면|
|Room_StageMod_Area1_Map1_Level1|1지역 1맵 1레벨 플레이 화면|
|Room_StageMod_Area1_Map1_Level2|1지역 1맵 2레벨 플레이 화면|
|Room_StageMod_Area1_Map1_Level3|1지역 1맵 3레벨 플레이 화면|
|Room_StageMod_Area1_Map1_Level4|1지역 1맵 4레벨 플레이 화면|
|Room_ChallengeMod_Sky|1맵 무한 모드 플레이 화면|
|Room_ChallengeMod_Underwater|2맵 무한 모드 플레이 화면|
|Room_ChallengeMod_DeepUnderwater|3맵 무한 모드 플레이 화면|
|Win|승리 화면|
|Defeat|패배 화면|

#### 객체 구조
|클래스|용도|
|:--|:--|
|Background_Cloud|구름 클래스|
|Background_Display|배경 이미지 클래스|
|Enemy_Bird_Distance|원거리 공격 새 클래스|
|Enemy_Bird_Near|근접 공격 새 클래스|
|Enemy_Whale|고래 클래스|
|Etc_Button_Click|버큰 클릭 처리 클래스|
|Etc_Camera_Ratio|화면 비율 자동 조정 클래스|
|Etc_Cloud_Generator|구름 생성 클래스|
|Etc_Name_Changer|생성된 객체 이름 변경 클래스|
|Etc_Point_Area|목적지 도달 영역 클래스|
|Etc_Remove_Zone|객체 제거 영역 클래스|
|Etc_Score|점수 갱신 클래스|
|Etc_Sky_Enemy_Generator|하늘 적 생성 클래스|
|Etc_Stage|스테이지 클리어 여부 갱신 클래스|
|Etc_User_Interface|유저 인터페이스 갱신 클래스|
|Player_Collider|플레이어 클래스|
|Player_Control|플레이어 입력/이동 클래스|
|Projectile_Bomb|폭탄 클래스|
|Projectile_Bullet|총알 클래스|
|Projectile_Fireball|불덩어리 클래스|
|Projectile_Razer_Charging|레이저 차징 클래스|
|Projectile_Razer_Fire|레이저 발사 클래스|

___

### 핵심 기능

#### 크로스 플랫폼 지원 코드 작성

##### Player_Control.cs

```C#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Control : MonoBehaviour
{

    ...

    void Start() {

        ...

        if (SystemInfo.deviceType.ToString() == "Desktop") {

            ...

        }

        else if (SystemInfo.deviceType.ToString() == "Handheld") {

            GameObject.Find("Etc_Canvas_UserInterface").transform.Find("Android_Controller")
            .gameObject.SetActive(true);

            ...

        }

    }

    ...

}

```

Windows/Android 플랫폼을 지원하는 코드이다.\
SystemInfo.deviceType 객체로 기기 정보를 얻었다.\
기기가 모바일일 경우, 조이스틱 UI를 활성화시키는 방식으로 Android 플랫폼을 지원하였다.

#### 바라보는 방향의 회전 값 얻기

##### Enemy_Bird_Near.cs

```C#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird_Near : MonoBehaviour
{

    ...

    void OnTriggerEnter2D(Collider2D other) {

        if (other.name == "Virtual_Wall") {

            Rotation_X = GameObject.Find("Player").GetComponent<Transform>().position.x
            - this.GetComponent<Transform>().position.x;
            Rotation_Y = GameObject.Find("Player").GetComponent<Transform>().position.y
            - this.GetComponent<Transform>().position.y;
            Rotation = Mathf.Atan(Rotation_Y / Rotation_X) * (360 / (2 * Mathf.PI));
            this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Rotation);

            ...

        }

        ...

    }

    ...

}

```

근접 공격 새 객체(이하 '새')가 가상의 벽 영역을 지나고, 플레이어를 향해 돌진하는 코드이다.\
새가 플레이어를 바라보게 하기 위해서, 새의 rotation을 변경시켜줘야 한다.\
플레이어와 새의 position을 가져온 후, 삼각함수의 tan 개념을 활용하여 밑변과 높이로 rotation을 구했다.\
(Mathf.Atan()의 반환값은 radian이기 때문에 degree로 변환시키기 위하여 (360/(2*Mathf.PI)) 공식을 곱했습니다.)

___

### 부족한 점

#### 플레이어 이동 구현

플레이어를 이동할 때, Rigidbody.AddForce()를 사용하여 이동하게 될 경우,\
가속도를 받아 움직이기 때문에, 플레이어가 미끄러지듯이 움직이게 된다.\
이를 피하기 위해 transform.Translate()를 사용하여 이동을 구현하였다.\
하지만 이 메서드는 position을 변경시키는 방식이기에 Collider를 통해 이동 구역을 제한할 수 없다.\
이동 구역을 제한하기 위해서 코드를 아래와 같이 작성하였다.

##### Player_Control.cs

```C#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Control : MonoBehaviour
{

    ...

    IEnumerator Move_Ship()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Player_Direction_X = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Player_Direction_X = 1;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Player_Direction_Y = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Player_Direction_Y = -1;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Player_Direction_X = 0;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Player_Direction_X = 0;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Player_Direction_Y = 0;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Player_Direction_Y = 0;
            }
            Player_Direction = new Vector2(Player_Direction_X, Player_Direction_Y);
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
            }
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y <= -4.5)
            {
                if (Player_Direction_Y < 0)
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_Y > 0)
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y < -4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                if (Player_Direction_X > 0)
                {
                    this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y < -4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }

    ...

}

```

코드가 매우 길다.\
미끄러지지 않는 이동에는 Rigidbody.velocity를 사용하는 방식도 있는데,\
이것을 사용하는 것이 더 나았을 것 같다.

#### 팀 비교

플레이어와 적의 팀 비교를 할 수 있어야, 같은 팀 간의 공격을 방지할 수 있다.
팀 비교를 위하여 물체의 이름을 비교하는 방식을 사용하였다.
다만, 물체를 생성하게 될 경우, 물체의 이름 뒤에 '(Clone)'이 붙는다.
아래는 생성된 물체의 이름을 변경해주는 코드이다.

##### Etc_Name_Changer

```C#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etc_Name_Changer : MonoBehaviour
{

    void Start()
    {
        for (int k = 1; k < 500; k++)
        {
            if (GameObject.Find("Enemy_Bird_Distance (" + k + ")"))
            {
                if (GameObject.Find("Enemy_Bird_Distance (" + k + ")").name == "Enemy_Bird_Distance (" + k.ToString() + ")")
                {
                    GameObject.Find("Enemy_Bird_Distance (" + k + ")").name = "Enemy_Bird_Distance";
                }
            }
            if (GameObject.Find("Enemy_Bird_Near (" + k + ")"))
            {
                if (GameObject.Find("Enemy_Bird_Near (" + k + ")").name == "Enemy_Bird_Near (" + k.ToString() + ")")
                {
                    GameObject.Find("Enemy_Bird_Near (" + k + ")").name = "Enemy_Bird_Near";
                }
            }
        }
    }

    void Update()
    {
        if (GameObject.Find("Background_Cloud(Clone)"))
        {
            GameObject.Find("Background_Cloud(Clone)").name = "Background_Cloud";
        }
        if (GameObject.Find("Enemy_Bird_Distance(Clone)"))
        {
            GameObject.Find("Enemy_Bird_Distance(Clone)").name = "Enemy_Bird_Distance";
        }
        if (GameObject.Find("Enemy_Bird_Near(Clone)"))
        {
            GameObject.Find("Enemy_Bird_Near(Clone)").name = "Enemy_Bird_Near";
        }
        if (GameObject.Find("Enemy_Whale(Clone)"))
        {
            GameObject.Find("Enemy_Whale(Clone)").name = "Enemy_Whale";
        }
        if (GameObject.Find("Projectile_Bullet(Clone)"))
        {
            GameObject.Find("Projectile_Bullet(Clone)").name = "Projectile_Bullet";
        }
        if (GameObject.Find("Projectile_Fireball_Big(Clone)"))
        {
            GameObject.Find("Projectile_Fireball_Big(Clone)").name = "Projectile_Fireball_Big";
        }
        if (GameObject.Find("Projectile_Fireball_Normal(Clone)"))
        {
            GameObject.Find("Projectile_Fireball_Normal(Clone)").name = "Projectile_Fireball_Normal";
        }
        if (GameObject.Find("Projectile_Fireball_Small(Clone)"))
        {
            GameObject.Find("Projectile_Fireball_Small(Clone)").name = "Projectile_Fireball_Small";
        }
        if (GameObject.Find("Razer_Charging(Clone)"))
        {
            GameObject.Find("Razer_Charging(Clone)").name = "Razer_Charging";
        }
    }

}

```

해당 코드는 큰 문제가 있다.\
GameObject.Find()는 성능 손실을 유발할 수 있는데,\
이를 Update 안에서 잔뜩 사용했다는 것이다.\
이 뿐만 아니라 팀 비교를 위해서 이름을 비교한다는 것 자체가 비효율적인 것 같다.\
tag를 사용하여 팀 비교를 하는 것이 더 좋을 것 같다.