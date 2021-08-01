using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyController : MonoBehaviour
{
    public string state;
    public float checkRadius;
    public float attackRange;
    public Animator anim;
    public GameObject particleThrow;
    public GameObject throwHand;
    
    [HideInInspector]
    public Transform target;

    Vector3 destination;
    NavMeshAgent agent;
    Spell particle;
    bool attacked = false;

    StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        //Create states
        var wanderState = new WanderState(transform, checkRadius);
        var followPlayerState = new FollowPlayerState();
        var attackPlayerState = new AttackPlayerState(anim);

        //Specific Transitions
        At(wanderState, followPlayerState, FoundTarget(), false);
        At(followPlayerState, attackPlayerState, WithinAttackRange(), false);
        At(attackPlayerState, followPlayerState, AttackedPlayer(), false);

        //Any transitions
        _stateMachine.AddAnyTransition(wanderState, NoTarget(), false);

        //Set state to wander (default)
        _stateMachine.SetState(wanderState);

        //Method shortcuts for transitions
        void At(IState from, IState to, Func<bool> condition, bool transitionToSelf) => _stateMachine.AddTransition(from, to, condition, transitionToSelf);
        Func<bool> FoundTarget() => () =>
        {
            foreach (var item in Physics.SphereCastAll(transform.position, checkRadius, Vector3.forward))
            {
                if(item.transform.gameObject.CompareTag("Player"))
                {
                    target = item.transform;
                    return true;
                }
            }

            target = null;
            return false;
        };

        Func<bool> NoTarget() => () =>
        {
            foreach (var item in Physics.SphereCastAll(transform.position, checkRadius, Vector3.forward))
            {
                if (item.transform.gameObject.CompareTag("Player"))
                {
                    target = item.transform;
                    return false;
                }
            }

            target = null;
            return true;
        };

        Func<bool> WithinAttackRange() => () =>
        {
            if (target == null)
                return false;

            return Vector3.Distance(transform.position, target.position) <= attackRange;
        };

        Func<bool> AttackedPlayer() => () =>
        {
            if(attacked && !anim.GetBool("IsAttacking"))
            {
                print(true);
                attacked = false;
                return true;
            }

            return false;
        };
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
        state = _stateMachine._currentState.ToString();

        switch (_stateMachine._currentState.ToString().ToLower())
        {
            case "wanderstate":
                destination = ((WanderState)_stateMachine._currentState).destination;
                break;
            case "followplayerstate":
                destination = target.position;
                break;
            case "attackplayerstate":
                destination = transform.position;
                break;
            default:
                break;
        }

        if(destination != Vector3.zero)
        {
            agent.SetDestination(destination);
        }

    }

    public void CreateParticleThrow()
    {
        particle = Instantiate(particleThrow, throwHand.transform.position, particleThrow.transform.rotation, throwHand.transform).GetComponent<Spell>();
    }

    public void StopAttacking()
    {
        attacked = true;
        anim.SetBool("IsAttacking", false);

        particle.transform.rotation = particle.transform.parent.rotation;
        particle.rb.AddForce((target.position - particle.transform.position) * particle.speed);
        particle.transform.parent = null; 
    }
}
