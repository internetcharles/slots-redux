using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateWheel : MonoBehaviour
{
    public GameObject prefab;
    public float radius;
    public float amount;
    public List<float> targets;

    private float SpinTarget()
    {
        for (float i = 1f; i < 18f; i++)
        {
            targets.Add(i * 60f + 360);
        }

        return targets[Mathf.RoundToInt(Random.Range(0f, 17f))];
    }

    // Start is called before the first frame update
    private void Start()
    {
        CreateReel();
        Spin();
    }

    // Creates reel
    private void CreateReel()
    {
        var angle = 0f;

        for (var i = 0; i <= amount; i++)
        {
            var y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            var z = -Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            var obj = Instantiate(prefab, transform);
            obj.transform.localPosition = new Vector3(0, y, z);
            obj.transform.localRotation = Quaternion.Euler(angle, 0, 0);

            angle += (360f / amount);
        }
    }

    private void Spin()
    {
        iTween.RotateAdd(gameObject, iTween.Hash(
                "rotation", new Vector3(0, 0, 0),
                        "amount", new Vector3(SpinTarget(), 0, 0),
                        "time", 5f,
                        "easetype", iTween.EaseType.easeOutSine,
                        "oncomplete", "StopSpinning"));
    }

    void StopSpinning()
    {
        Debug.Log("Stop spinning called");
        iTween.Stop();
        Debug.Log(SpinTarget());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Spin();
        }
    }
}
