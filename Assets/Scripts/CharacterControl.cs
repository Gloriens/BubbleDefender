using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterControl : MonoBehaviour
{
    public Animator animator;
    public float raycastLength = 1.5f; // Raycast uzunluğu
    public float moveSpeed = 5f;  // Yatay hareket hızı
    public float jumpForce = 10f; // Zıplama gücü
    public float fallThreshold = -1f; // Düşüşe geçiş için threshold
    public float attackDuration = 0.5f; // Saldırı süresi
    private Rigidbody2D rb;
    private Collider2D col;
    public AnimatorOverrideController[] skinControllers;
    public int currentSkinIndex;

    private bool isGrounded;
    private bool isAttacking;
    private float attackTime;
    public LayerMask enemyLayers;
    public GameObject weapon;

    void Start()
    {
        currentSkinIndex = 5;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        SetSkin(currentSkinIndex);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float verticalSpeed = rb.velocity.y;

        // Karakter hareketi
        MoveCharacter(horizontal);

        // Zıplama kontrolü
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
            
        }

        var isFalling = verticalSpeed < fallThreshold;

        // Düşme kontrolü
        SetFallingState(isFalling);

        // Animasyon parametrelerini güncelle
        UpdateAnimator(isFalling, horizontal, verticalSpeed);
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            CheckAndDescend();
        }
        
        // Saldırı kontrolü (Ctrl veya C tuşu)
        attackControl();
        

        
       
        
        // Saldırı durumu sonrası geçiş
        if (isAttacking && Time.time - attackTime > attackDuration)
        {
            isAttacking = false;
            animator.SetBool("isAttacking", false); // Attack bitince
        }
    }

    // Karakteri yatayda hareket ettir
    private void MoveCharacter(float horizontal)
    {
        // Karakteri sağa/sola hareket ettir
        transform.Translate(new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, 0));

        // Yön dönüşümü
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1.8f, 1.8f, 1); // Sağ yön
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1.8f, 1.8f, 1); // Sol yön
        }
    }

    // Zıplama işlemi
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Dikey hız değişir
        isGrounded = false;  // Zıplama başladığında yerle teması kaybettik
    }
    
    

    // Düşüş durumu kontrolü
    private void SetFallingState(bool isFalling)
    {
        animator.SetBool("isFalling", isFalling);
    }

    // Animasyon parametrelerini güncelle
    private void UpdateAnimator(bool isFalling, float horizontal, float verticalSpeed)
    {
        bool isRunning = Mathf.Abs(horizontal) > 0.1f;
        bool isJumping = verticalSpeed > 0.1f;

        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
        animator.SetFloat("horizontalSpeed", Mathf.Abs(horizontal)); // Koşma hızını gönder
    }
    
    void CheckAndDescend()
    {
        Vector2 bottomOfPlayer = new Vector2(transform.position.x, col.bounds.min.y - 0.1f);
        
        RaycastHit2D hit = Physics2D.Raycast(bottomOfPlayer, Vector2.down, raycastLength);

        if (hit.collider != null && hit.collider.CompareTag("Platform"))
        {
            StartCoroutine(Descend());
        }
    }

    IEnumerator Descend()
    {
        col.isTrigger = true;
        
        yield return new WaitForSeconds(0.5f);
        
        col.isTrigger = false;
    }

    // Karakterin saldırısını başlat
    

    // Yerde mi olduğunu kontrol et
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true; // Yerle temas halindeyken zıplama yapılabilir
    }

    // Yerden ayrıldığında zıplama yapılamaz
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false; // Yerden ayrıldığında zıplama yapılamaz
    }
    
    // Skin'i değiştir
    public void SetSkin(int skinIndex)
    {
        currentSkinIndex = skinIndex;
        
        animator.runtimeAnimatorController = skinControllers[currentSkinIndex];
    }
    
    
    private void Attack()
    {
        Debug.Log(currentSkinIndex);
        isAttacking = true;
        attackTime = Time.time;
        animator.SetBool("isAttacking", true); 
        Collider2D[] enemies = Physics2D.OverlapCircleAll(weapon.transform.position, 2f, enemyLayers);
        int tempindex = currentSkinIndex;

        foreach (Collider2D enemy in enemies)
        {
            
            if (enemy.gameObject.CompareTag("darkness") && tempindex == 2)
            {
                Debug.Log("ışıkla kestim");
                Destroy(enemy.gameObject);
                Debug.Log(currentSkinIndex);
            }else if (enemy.gameObject.CompareTag("light") && tempindex == 0)
            {
                Debug.Log("karanlıkla kestim");
                Destroy(enemy.gameObject);
                Debug.Log(currentSkinIndex);
                
            }else if (enemy.gameObject.CompareTag("fire") && tempindex == 5)
            {
                Debug.Log("suyla kestim");
                Destroy(enemy.gameObject);
                Debug.Log(currentSkinIndex);
            }else if(enemy.gameObject.CompareTag("water") && tempindex == 4)
            {
                Debug.Log("ateşle kestim");
                Destroy(enemy.gameObject);
                Debug.Log(currentSkinIndex);
            }else if (enemy.gameObject.CompareTag("earth") && tempindex == 1)
            {
                Debug.Log("havayla kestim");
                Destroy(enemy.gameObject);
                Debug.Log(currentSkinIndex);
            }else if (enemy.gameObject.CompareTag("air") && tempindex == 3)
            {
                Debug.Log("toprakla kestim");
                Destroy(enemy.gameObject);
                Debug.Log(currentSkinIndex);
            }
        }
        Debug.Log("Bi bok mu yedim" + currentSkinIndex);
    }

    public void attackControl()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            Attack();
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(weapon.transform.position, 2f);
    }

    
}
