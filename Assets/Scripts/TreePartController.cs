using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreePartController : MonoBehaviour
{
    [SerializeField] private List<GameObject> treeParts;
    [SerializeField] private ParticleSystem growParticle;
    
    public void GrowTree()
    {
        growParticle.Play();
        StartCoroutine(GrowTreeCoroutine());
    }
    
    private IEnumerator GrowTreeCoroutine()
    {
        foreach (var treePart in treeParts)
        {
            treePart.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        
        GetComponentInParent<PlayerStateController>().FinishedGrowing();
    }

    public void CloseTree()
    {
        
        foreach (var treePart in treeParts)
        {
            treePart.SetActive(false);
        }
    }
}