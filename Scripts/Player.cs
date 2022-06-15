using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject spawn;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rof = 0.2f;
    [SerializeField] private float random = 0.5f;

    private float time;

    private void Start()
    {
        time = 0;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector3 Scaler = transform.localScale;
        if (angle < -90 && angle > 90)
        {
            Scaler.y = Mathf.Abs(Scaler.y);
        }
        else
        {
            Scaler.y = -Mathf.Abs(Scaler.y);
        }
        transform.localScale = Scaler;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        if (Input.GetMouseButton(0) && time <= 0)
        {
            GenerateBullet();

            time = rof;
        }

        time = time - Time.deltaTime;
    }

    private void GenerateBullet()
    {
        GameObject eff = Instantiate(effect, spawn.transform.position, transform.rotation);
        eff.transform.SetParent(spawn.transform);
        Vector3 bulletPosition = spawn.transform.position;
        Vector2 bulletForce;
        float x = spawn.transform.position.x - transform.position.x;
        float y = spawn.transform.position.y - transform.position.y;
        bulletForce = new Vector2(x, y);
        GameObject bulletClone = Instantiate(bullet, 
            bulletPosition, 
            transform.rotation) as GameObject;
        bulletClone.GetComponent<Rigidbody2D>().velocity = bulletForce * speed;
    }
}