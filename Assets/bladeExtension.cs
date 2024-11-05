using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeExtension : MonoBehaviour
{
    public GameObject blade;
    public GameObject light;

    double speed = 0.1;
    bool extended = true;
    double minVal = 0.0;
    double maxVal;
    float delta;
    double currentScale;

    double initX;
    double initZ;

    // Start is called before the first frame update
    void Start()
    {
        maxVal = transform.localScale.y;
        initX = transform.localScale.x;
        initZ = transform.localScale.z;
        currentScale = maxVal;
        delta = (float)(maxVal / speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            delta = extended ? -Mathf.Abs(delta) :
                      Mathf.Abs(delta);
        }

        currentScale += delta * Time.deltaTime;
        currentScale = Mathf.Clamp((float)currentScale,
                    (float)minVal,
                    (float)maxVal);

        transform.localScale = new Vector3((float)initX,
                          (float)currentScale,
                          (float)initZ);

        extended = currentScale > 0;

        if (extended && !blade.activeSelf)
        {
            blade.SetActive(true);
        }

        if (!extended && blade.activeSelf)
        {
            blade.SetActive(false);
        }

        if (extended)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
        }
    }
}
