using System.Collections.Generic;
using UnityEngine;

public class SuspectManager : MonoBehaviour
{
    public static SuspectManager instance;

    public List<Suspect> suspects;
    public List<NailSO> nailSOs; // sarı siyah yeşil
    public List<FeatherSO> featherSOs;

    private void Awake()
    {
        instance = this;
    }

    public void RemoveSuspects(ItemData item)
    {

        if(item.id == 1) // sarı tırnak id'si
        {
            foreach(NailSO nailSO in nailSOs)
            {
                if (nailSO.nailType == NailType.yellow) continue;

                foreach(Suspect sus in suspects)
                {
                    if (nailSO.suspects.Contains(sus.getSuspectName()))
                    {
                        sus.EliminateSuspect();
                    }
                }
            }
        }
        else if(item.id == 2) // siyah tüy id'si
        {
            foreach (FeatherSO featherSO in featherSOs)
            {
                if (featherSO.featherType == FeatherType.black) continue;

                foreach (Suspect sus in suspects)
                {
                    if (featherSO.suspects.Contains(sus.getSuspectName()))
                    {
                        sus.EliminateSuspect();
                    }
                }
            }
        }


    }



    
}
