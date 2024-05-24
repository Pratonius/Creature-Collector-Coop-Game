using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        gameObject.GetComponent<Slider>().value = 100;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
