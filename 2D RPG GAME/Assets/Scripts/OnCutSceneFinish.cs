using UnityEngine;
using UnityEngine.Playables;

public class OnCutSceneFinish : MonoBehaviour
{
    [SerializeField] private NPCTrigger npcTrigger;
    
    private PlayableDirector playableDirector;

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
        playableDirector.stopped += PlayableDirectorOnstopped;
    }

    private void PlayableDirectorOnstopped(PlayableDirector obj)
    {
        npcTrigger.StartDialogue();
    }
}
