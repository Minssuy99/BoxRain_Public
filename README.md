# 🚀 C3_2F2T
프로젝트를 깃허브에 업로드했으나, 사용된 에셋 패키지들은

라이선스 규정에 따라 제외되었기 때문에 정상적인 실행이 불가능합니다.

<details>
 
<summary>WireFrame</summary>
 
![와이어프레임](https://github.com/Minssuy99/BoxRain_Public/assets/101568505/1e41bb48-73bc-45fa-99a1-65e0809cd3f7)

</details>

## 🖥️ 프로젝트 소개
Unity2D를 이용하여 만든 상자를 피하면서 생존하는 2D 게임입니다.

![image](https://github.com/Minssuy99/BoxRain_Public/assets/101568505/90d999c0-fc18-4eaf-a18f-091afd016401)


</br>

## 🎮 조작키
#### 이 게임은 키보드로 진행됩니다.
 
![조작키](https://github.com/Minssuy99/BoxRain_Public/assets/101568505/fad0d2a1-4e71-4f23-b9a3-0803d89445d2)



## 🕐 개발 기간
* ___24.05.16 ~ 24.05.22___

### 👨‍💻 팀 구성 및 역할
|역할|이름|담당업무|
|---|---|---|
|팀장|김민성|충돌처리, 게임 오버 애니메이션 효과, SFX, PPT 및 README 작성|
|팀원|김명수|움직이는 상자 구현, 점프 구현|
|팀원|서범진|바닥 충돌 처리, 애니메이션, 캐릭터 움직임, 난이도 시스템|
|팀원|하영빈|각종 UI들과 json을 이용한 데이터 저장을 구현|


### ⚙️ 개발 환경
- **언어** : `C#`
- **IDE** : `Visual Studio 2022`
- **엔진** : `Unity 2022.3.17f1`


</br>


## 📝 Files
### 🗂 BoxRain_Public

<details>
<summary> 📁 Animation</summary>
 
  * 🏃‍♀️ ___Box_Break.anim___
  * 🏃‍♀️ ___Player.controller___
  * 🏃‍♀️ ___Player_Idle.anim___
  * 🏃‍♀️ ___Player_Jump.anim___
  * 🏃‍♀️ ___Player_Run.anim___
  * 🏃‍♀️ ___RainBox.controller___
  * 🏃‍♀️ ___ShotBox.controller___
 </details>
 
<details>
<summary>📁 Input</summary>
 
  * 🕹 ___Top Down Controller2D.inputactions___
  </details>
  
<details>
<summary>📁 Scenes</summary>
 
  * ⚙️ ___Jin_MainScene.unity___
  * ⚙️ ___Jin_StartScene.unity___
  </details>
 
<details>
<summary>📁 Scripts</summary>

 </br>

 <details open>
  <summary>📂 Behaviors</summary>

* 📄 ___BigBox.cs___
* 📄 ___Rain.cs___
* 📄 ___ShotBox.cs___
* 📄 ___TopDownMovement.cs___
</details>

 <details open>
  <summary>📂 Controllers</summary>
  
* 📄 ___CAnimationHandler.cs___
* 📄 ___GameManager.cs___
* 📄 ___PlayerInputController.cs___
* 📄 ___SoundManager.cs___
* 📄 ___TopDownController.cs___
</details>

 <details open>
  <summary>📂 SaveData</summary>
  
* 📄 ___SaveData.cs___
* 📄 ___SaveSystem.cs___
</details>

 <details open>
  <summary>📂 UI</summary>
  
* 📄 ___PauseMenu.cs___
* 📄 ___PlayerScore.cs___
* 📄 ___StartButton.cs___
</details>

</details>




## ✔ 스크립트 바로가기
### 📦 Behaviors

<details>
<summary>💻 Scripts</summary>

</br>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Behaviors/BigBox.cs" target="_blank">BigBox.cs</a>
  
📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Behaviors/Rain.cs" target="_blank">Rain.cs</a>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Behaviors/ShotBox.cs" target="_blank">ShotBox.cs</a>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Behaviors/TopDownMovement.cs" target="_blank">TopDownMovement.cs</a>

 
</details>
</br>

### 📦 Controllers

<details>
<summary>💻 Scripts</summary>

</br>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Controllers/CAnimationHandler.cs" target="_blank">CAnimationHandler.cs</a>
  
📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Controllers/GameManager.cs" target="_blank">GameManager.cs</a>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Controllers/PlayerInputController.cs" target="_blank">PlayerInputController.cs</a>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Controllers/SoundManager.cs" target="_blank">SoundManager.cs</a>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/Controllers/TopDownController.cs" target="_blank">TopDownController.cs</a>

 
</details>
</br>

### 📦 SaveData

<details>
<summary>💻 Scripts</summary>

</br>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/SaveData/SaveData.cs" target="_blank">SaveData.cs</a>
  
📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/SaveData/SaveSystem.cs" target="_blank">SaveSystem.cs</a>


 
</details>
</br>

### 📦 UI

<details>
<summary>💻 Scripts</summary>

</br>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/UI/PauseMenu.cs" target="_blank">PauseMenu.cs</a>
  
📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/UI/PlayersScore.cs" target="_blank">PlayersScore.cs</a>

📑 <a href="https://github.com/Minssuy99/BoxRain_Public/blob/main/Assets/Scripts/UI/StartButton.cs" target="_blank">StartButton.cs</a>


</details>
</br>


