using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [Header("References")]
    public GameObject energyBall;
    public GameObject laserStart;
    public GameObject hitParticle;
    public AudioSource lightSound;

    private LineRenderer laser;
    private Mirror mirrorScript;
    private Renderer energyBallRenderer;
    private PuzzleManager manager;
    private bool laserActive;
    private bool audioPlayed;


    private void Start()
    {
        laser = laserStart.GetComponent<LineRenderer>();
        laserStart.SetActive(false);
        hitParticle.SetActive(false);
        energyBallRenderer = energyBall.GetComponent<Renderer>();
        manager = FindObjectOfType<PuzzleManager>();
    }

    private void Update()
    {
        if (laserActive && !manager.puzzleDone)
        {
            laserStart.SetActive(true);
            if (!audioPlayed)
            {
                lightSound.Play();
                audioPlayed = true;
            }

            energyBallRenderer.material.EnableKeyword("_EMISSION");
            laser.SetPosition(0, laserStart.transform.position);
            RaycastHit hit;
            if(Physics.Raycast(laserStart.transform.position, laserStart.transform.forward, out hit))
            {
                if (hit.collider)
                {
                    laser.SetPosition(1, hit.point);

                    if(hit.collider.gameObject.tag == "Mirror")
                    {
                        mirrorScript = hit.collider.GetComponentInParent<Mirror>();
                        mirrorScript.ReflectLaser(true, Vector3.SignedAngle(hit.normal, -laserStart.transform.forward, -transform.up), hit.point);
                        hitParticle.SetActive(false);
                    }
                    else
                    {
                        if (mirrorScript != null)
                        {
                            mirrorScript.ReflectLaser(false, 0, Vector3.zero);
                        }
                        hitParticle.SetActive(true);
                        hitParticle.transform.position = hit.point + hitParticle.transform.up * 0.1f;
                    }
                }
            }
            else
            {
                laser.SetPosition(1, laserStart.transform.forward * 5000);
                hitParticle.SetActive(false);
                if(mirrorScript != null)
                {
                    mirrorScript.ReflectLaser(false, 0, Vector3.zero);
                }
            }
        }
        else if(!manager.puzzleDone)
        {
            laserStart.SetActive(false);
            energyBallRenderer.material.DisableKeyword("_EMISSION");
        }
    }

    public void LaserActive(bool state)
    {
        if (!manager.puzzleDone)
        {
            laserActive = state;
            if (mirrorScript != null)
            {
                mirrorScript.ReflectLaser(false, 0, Vector3.zero);
            }
        }
    }
}
