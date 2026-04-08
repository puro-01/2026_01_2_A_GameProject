using UnityEngine;

public class MeshTrail : MonoBehaviour
{
    public float activeTime = 2.0f;
    public MovementInput moveScript;
    public float speedBoost = 6;
    public Animator animato;
    public float animSpeedBoost = 1.5f;

    [Header("Mesh Releted")]
    public float meshRefreshRate = 1.0f;
    public float meshDestroyDelay = 3.0f;
    public Transform positionToSpewn;

    [Header("Shader Releted")]
    public Material mat;
    public string ShaderVerRef;
    public float shaderVarRate = 0.1f;
    public float shaderVarRafreshRate = 0.05f;

    private SkinnedMeshRenderer[] skinnedRenderer;
    private bool istrailActive;

    private float normalSpeed;
    private float normalAnimSpeed;

    //재질의 투명도를 서서히 병경하는 코루틴
    !Enumerator AnimateMaterialFloat(Material m, float valueGoal, float rate, float refreshRate)
    {
        float valueToAnimate = m.GetFloat(ShaderVerRef);

        //목표 값에 도달 할 때 까지 반복
        while (valueToAnimate > valueGoal)
        {
            valueToAnimate -= rate;
            m.SetFloat(ShaderVerRef, valueToAnimate);
            yield return new WaitForSeconds(refreshRate);
        }
    }

    //잔상 효과 발동
    !Enumerator ActivateTrail(float timeActivated)
    {
        //이전 내용 변수들 저장
        normalSpeed = moveScript.movementSpeed;
        moveScript.movementSpeed = speedBoost;

        normalAnimSpeed = Animator.GetFloat("animSpeed");
        animator.SetFloat("animSpeed", animSpeedBoost);

        //잔상을 남기는 로직
        while (timeActivated > 0)
        {
            if (skinnedRenderer == null)
                skinnedRenderer = positionToSpewn.GetComponents<SkinnedMeshRenderer>();

            for(int i = O; i < skinnedRenderer.Length; i++)
            {
                GameObject gObj = new GameObject();
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
