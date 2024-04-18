using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player_MapSprite : Move
{
    public Animator MapMoveAnimator;

    protected override void Start(){
        base.Start();
        Boundaries_Update();
    }

    protected override void AttemptMove(int XDir, int YDir){
        if(!AllowMove)return;
        AllowMove = false;
        base.AttemptMove(XDir, YDir);
    }
    
    void Update(){
        if(!AllowMove || Fight.Instance.InBattle) return;
        int Horizontal = 0; 
        int Vertical = 0;
        Horizontal = (int)Input.GetAxisRaw("Horizontal");
        Vertical = (int)Input.GetAxisRaw("Vertical");

        if(Horizontal!=0)Vertical = 0;

        if(Horizontal != 0 || Vertical != 0){
            if(!IsMoving){
                if(Horizontal==1)MapMoveAnimator.Play("Base Layer.Player_Right");
                if(Horizontal==-1)MapMoveAnimator.Play("Base Layer.Player_Left");
                if(Vertical==1)MapMoveAnimator.Play("Base Layer.Player_Back");
                if(Vertical==-1)MapMoveAnimator.Play("Base Layer.Player_Front");
            }
            AttemptMove(Horizontal, Vertical);
        }
    }

    public void TouchMoveControl(int Axis){//0, 1 - right/left; 2, 3 -up/down 
        if(!AllowMove || Fight.Instance.InBattle) return;
        else {
            int Horizontal = 0, Vertical = 0;
            if(!IsMoving){
                if(Axis==0){
                    MapMoveAnimator.Play("Base Layer.Player_Right");
                    Horizontal = 1;
                }
                if(Axis==1){
                    MapMoveAnimator.Play("Base Layer.Player_Left");
                    Horizontal = -1;
                }
                if(Axis==2){
                    MapMoveAnimator.Play("Base Layer.Player_Back");
                    Vertical = 1;
                }
                if(Axis==3){
                    MapMoveAnimator.Play("Base Layer.Player_Front");
                    Vertical = -1;
                }
            }
            AttemptMove(Horizontal, Vertical);
        }
    }

    protected override async void OnCantMove<T>(T component){
        if (component is Mob_MapSprite) {
            Mob_MapSprite HitMob = component as Mob_MapSprite;
            HitMob.StartFight();
        } 
        else if (component is Grass) {
            Grass HitTile = component as Grass;
            HitTile.StartFight();
        }
        else if (component is Collectible) {
            Collectible HitItem = component as Collectible;
            HitItem.OnCollide();
        }
        else if (component is LocationChanger) {
            AllowMove = false;
            LocationChanger HitChanger = component as LocationChanger;
            HitChanger.Location_Change();
            await Task.Delay(100);
            AllowMove = true;
        }    
    }
}
