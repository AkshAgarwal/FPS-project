using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TargetManager : MonoBehaviour
{
    public static TargetManager tm=null;
    [SerializeField] int targetcount;
    [SerializeField] TextMeshProUGUI score;
    // Start is called before the first frame update

    private void Start()
    {
        if (tm == null)
        {
            tm = this;
        }    
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Targets");
        targetcount = targets.Length;
        score.SetText("TARGETS LEFT: " + targetcount.ToString());
    }
    // Update is called once per frame

    private void Update()
    {
        WinScene();
    }

    public void destroy()
    {
        targetcount--;
        score.SetText("TARGETSLEFT: " + targetcount.ToString());
    }
    public void WinScene()
    {
      if(targetcount==0)
        {
            MenuManager.mm.WinScene();
        }
    }
}
