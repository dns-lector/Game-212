using UnityEngine;
using UnityEngine.Audio;

public class AudioControllerScript : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    private float masterVolume;
    private float ambientVolume;
    private float effectsVolume;
    private float musicVolume;

    void Start()
    {
        audioMixer.GetFloat(nameof(masterVolume), out masterVolume);
        audioMixer.GetFloat(nameof(ambientVolume), out ambientVolume);
        audioMixer.GetFloat(nameof(effectsVolume), out effectsVolume);
        audioMixer.GetFloat(nameof(musicVolume), out musicVolume);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Minus) 
            || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            ChangeMasterVolume();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Plus) 
            || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            ChangeMasterVolume(step: 1);
        }
    }

    private void ChangeMasterVolume(float step = -1)
    {
        if (audioMixer.GetFloat(nameof(masterVolume), out masterVolume))
        {
            masterVolume = Mathf.Clamp(
                masterVolume + step * (Mathf.Abs(masterVolume + 3.0f) * 0.25f + 3.0f),
                -80f, 20f);

            audioMixer.SetFloat(nameof(masterVolume), masterVolume);
        }
        else
        {
            Debug.Log("GetFloat Error");
        }
    }
}
/* dB дБ - децибел 
 * dB = 10 log( E2 / E1 ) -- логарифм відношення (частки) - альтернативна форма
 *  для коефіцієнту між двома величинами.
 * 
 * E1 ---> |Attenuator| ---> E2
 * 
 * E2 / E1          dB
 *  1000            30
 *  100             20
 *  10              10
 *  1 (E2==E1)      0
 *  0.1            -10
 *  0.01           -20
 *  0.001          -30
 */
