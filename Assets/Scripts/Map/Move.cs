using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Move : MonoBehaviour
{   
    public bool AllowMove = true;
    public float MoveTime = 0.1f;
    public LayerMask BlockingLayer;
    public LayerMask TriggeringLayer;
    private BoxCollider2D BoxCollider, TriggerBoxCollider;
    private Rigidbody2D Rigidbody;
    private float InverseMoveTime;
    public Button ReturnButton;
    public int MovesMade = 0;
    public bool IsMoving;
    public Camera Camera;
    public GameObject Boundaries;
    public Vector2 MinBounds, MaxBounds;

    public void Boundaries_Update(){
        Renderer Renderer = Boundaries.GetComponent<Renderer>();
        MinBounds = Renderer.bounds.min;
        MaxBounds = Renderer.bounds.max;
    }

    public void Camera_Move(){
        GameObject Target = this.gameObject;
        float CamX = Mathf.Clamp(Target.transform.position.x, MinBounds.x + 8.89f, MaxBounds.x - 8.89f);
        float CamY = Mathf.Clamp(Target.transform.position.y, MinBounds.y + 5f, MaxBounds.y - 5f);
        Camera.transform.position = new Vector3(CamX, CamY, -10);
    }

    protected virtual void Start(){
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        InverseMoveTime = 1f/MoveTime;
    }

    protected bool ChangePosition(int XDir, int YDir, out RaycastHit2D Hit){
        Vector2 Start = transform.position;
        Vector2 End = Start + new Vector2(XDir, YDir);

        BoxCollider.enabled = false;
        Hit = Physics2D.Linecast(Start, End, BlockingLayer);
        BoxCollider.enabled = true;
        
        if(Hit.transform == null && !IsMoving){
            BoxCollider.enabled = false;
            Hit = Physics2D.Linecast(Start, End, TriggeringLayer);
            BoxCollider.enabled = true;
            if(TriggerBoxCollider !=null)TriggerBoxCollider.enabled = true;
            StartCoroutine(SmoothMovement(End));
            if(Hit.transform == null) return true;
            else{
                TriggerBoxCollider = Hit.transform.GetComponent<BoxCollider2D>();
                TriggerBoxCollider.enabled = false;
            }
        }

        return false;
    }

    protected IEnumerator SmoothMovement (Vector3 End){
        IsMoving = true;
        ReturnButton.interactable = false;
        float sqrRemainingDistance = (transform.position - End).sqrMagnitude;
        ++MovesMade;
        if(MovesMade == 3){
            MovesMade = 0;
            Fight.Instance.EffectsManager.TriggerEffects(1, Player.Instance);
            Fight.Instance.EffectsManager.Duration_Remove(Player.Instance, false);
            Fight.Instance.EffectsManager.TriggerEffects(0, Player.Instance);
            Player.Instance.RightHand.GetComponent<Item>().OnMove();
            Player.Instance.LeftHand.GetComponent<Item>().OnMove();
            Player.Instance.Hat.GetComponent<Item>().OnMove();
            Player.Instance.Chestplate.GetComponent<Item>().OnMove();
            Player.Instance.Boots.GetComponent<Item>().OnMove();
            Player.Instance.Trinket1.GetComponent<Item>().OnMove();
            Player.Instance.Trinket2.GetComponent<Item>().OnMove();
            Player.Instance.Health_Regenerate();
            Player.Instance.Mana_Regenerate();
            Player.Instance.ManaOverdrain.Remove();
            StartCoroutine(Player.Instance.HealthBar.HP_update());
        }
        while(sqrRemainingDistance > float.Epsilon){
            sqrRemainingDistance = (transform.position - End).sqrMagnitude;
            if(sqrRemainingDistance>1)break;
            Vector3 NewPosition = Vector3.MoveTowards(Rigidbody.position, End, InverseMoveTime * Time.deltaTime);
            Rigidbody.MovePosition (NewPosition);
            Camera_Move();
            yield return null;
        }
        //yield return null;
        IsMoving = false;
        ReturnButton.interactable = true;
    }

    protected virtual void AttemptMove(int XDir, int YDir){
        RaycastHit2D Hit;
        bool NoTriggers = ChangePosition(XDir, YDir, out Hit);
        
        if(NoTriggers || Hit.transform == null){
            AllowMove = true;
            return;
        }
        if(CheckTriggers<LocationChanger>(Hit)) return;
        AllowMove = true;
        if(CheckTriggers<Mob_MapSprite>(Hit)) return;
        if(CheckTriggers<Grass>(Hit)) return;
        if(CheckTriggers<Collectible>(Hit)) return;
        
    }

    protected bool CheckTriggers<T>(RaycastHit2D Hit)where T: Component{
        T HitComponent = Hit.transform.GetComponent<T>();
        if(HitComponent != null){
            OnCantMove(HitComponent);
            return true;
        } 
        return false;
    }

    protected abstract void OnCantMove<T>(T component) where T: Component;
}