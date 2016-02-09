using UnityEngine;
using System.Collections;

/// <summary>
/// Gameobject picks a random frame from all images available as part of a frame-based animation!.
/// Allows for multiple images to be assigned  to SINGLE prefab. At setup script  assigns to a Gameobject RANDOM annimation frame from its Sprite-based animations.Then animation speed is set to 0.
/// </summary>
/// <requires>
/// Gaameobjects must have Animator object and at least one animation
/// The Animator  needs to have following custom float properties created:
/// 1) AnimSpeedMultiplayer
/// 2) AnimOffset
/// Those PROPERTIES need to be linked to AnimationState that uses animation we are interested in.
/// </requires>
public class SetRandomAnimationFrame : MonoBehaviour {

    static Random rnd = new Random();


    [SerializeField] private int no_frames=5 ;//This is suppoused to be equal to the number of frames you choose from
    private float interval;
    /// <summary>
    /// Calculates how long single frame is displayes during animation.
    /// Picks random frame from animation frames and gets the time delay that is needed to display the frame.
    /// Actually displays the frame by strating animation at THIS time point.
    /// Sets animation speed to 0 so the frame stays unchanged.
    /// </summary>
    void Start () {
        Animator animator = GetComponent<Animator>();
        interval = 1.0f / (float)no_frames;
        interval+=(1/2)*interval; //this serves to avoid floating point arthmetics errors
        float start_time=(float)generateRandomFrame(no_frames);

        animator.SetFloat("AnimSpeedMultiplayer", interval);
        animator.SetFloat("AnimOffset", start_time);
        animator.SetFloat("AnimSpeedMultiplayer",0);
    }

    /// <summary>
    /// Picks a random frame from all animation frames and finds timepoint during the animation when the frame is displayed.
    /// </summary>
    /// <param name="no_frames"></param>
    /// <returns>timepoint during the animation</returns>
    private double generateRandomFrame(int no_frames)
    {   double frame_time;
        double interval = 1.0 / (double)no_frames;
        double[] numbers = new double[5];
        for (int i = 0; i < numbers.Length; i++) { numbers[i] = i * interval; } //for i==5  { 0.0, 0.2, 0.4, 0.6, 0.8 };
        //Debug.Log(interval);
        int ran =Random.Range(0, numbers.Length);
        frame_time = numbers[ran];
        return frame_time;
    }

}
/* Tryied to acces animation name via scriptfrom Animator Component but failed miserably 
AnimatorClipInfo anim_name;
anim_name = a.GetCurrentAnimatorClipInfo(0)[0];
Debug.Log(anim.clip.name);
var State = GetComponent<AnimatorState>();
AnimatorStateInfo currentBaseState = a.GetCurrentAnimatorStateInfo(0);
currentBaseState.nameHash
*/
