using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class ScripteFSM : MonoBehaviour
{
    public CollisionDetector EyeDetector;
    public EffectAciver EffectAciver;
    public float DestinationThreashHolde;
    public State CurrentState;
    public float SearchDistance;
    public float SearchWaitTime;
    public float SignalRange;
    public LayerMask AlliezMask;
    public float PostAttackWait;

    private int _incrémentasionIndex;
    private IndividualSondManager _soundPlayer;
    private GameObject[] _destinations ;
    private GameObject _CurrentDestination;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _lastePosKnow;
    private float _timer;

    private void Awake()
    {
        _navMeshAgent=GetComponent<NavMeshAgent>();
        _soundPlayer = GetComponent<IndividualSondManager>();
    }

    void Start()
    {
        if (_destinations==null)
        {
            _destinations = GameObject.FindGameObjectsWithTag("Destination");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        switch (CurrentState)
        {
            case State.PickDestination:
                PickDestination();
                break;
            case State.MoveToDestination:
                MoveToDesctination();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Search:
                Search();
                break;
            case State.SearchWait:
                SearchWait();
                break;
            case State.searchWonder:
                SearchWandering();
                break;
            case State.AttckWait:
                AttackWait();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        //Debug.DrawRay(transform.position , _CurrentDestination.transform.position-transform.position);
    }

    public void ComSetDestination(GameObject[] newDestination)
    {
        _destinations = newDestination;
    }

    public void ComPlaySee(GameObject player)
    {
        CurrentState = State.Chase;
        _CurrentDestination = player;
    }

    public GameObject ComGetPositionKnow()
    {
        if (CurrentState == State.Chase)
        {
            return _CurrentDestination;
        }
        return null;
    }

    private void PickDestination()
    {
        int rndIndex = Random.Range(0, _destinations.Length);
        _CurrentDestination = _destinations[rndIndex];
        if (_CurrentDestination != null) CurrentState = State.MoveToDestination;
    }

    private void MoveToDesctination()
    {
        _navMeshAgent.destination = _CurrentDestination.transform.position;
        if (Vector3.Distance(transform.position, _CurrentDestination.transform.position) < DestinationThreashHolde)
        {
            CurrentState = State.PickDestination;
        }
        GameObject player = EyeDetector.GetFirstInTheList();
        if (player != null)
        {
                _CurrentDestination = player;
                CurrentState = State.Chase;
                _soundPlayer.PlaySound(0);

                Collider[] cols = Physics.OverlapBox(transform.position, Vector3.one * SignalRange, Quaternion.identity,
                    AlliezMask);

                foreach (var col in cols)
                {
                    if (col.GetComponent<ScripteFSM>()!=null)
                    {
                        col.GetComponent<ScripteFSM>().ComPlaySee(player);
                        Debug.DrawLine(transform.position, col.transform.position, Color.green, 3);
                    }
                }
        }
        
    }

    private void Chase()
    {
        _navMeshAgent.destination = _CurrentDestination.transform.position;
        if (!EyeDetector.IsInView(_CurrentDestination))
        {
            CurrentState = State.Search;
            _lastePosKnow = _CurrentDestination.transform.position;
            _incrémentasionIndex = 0;
            _navMeshAgent.destination = _lastePosKnow;
        }
        

        if (Vector3.Distance(transform.position, _CurrentDestination.transform.position) < DestinationThreashHolde)
        {
            Attack();
        }
    }

    private void Attack()
    {
        EffectAciver.MakeAttack(_CurrentDestination);
        Debug.Log("Attack");
        _timer = 0;
        CurrentState = State.AttckWait;
        _soundPlayer.PlaySound(2);
    }

    private void AttackWait()
    {
        _timer += Time.deltaTime;
        if (_timer > PostAttackWait)
        {
            CurrentState = State.PickDestination;
        }
    }

    private void Search() {
       Debug.DrawLine(transform.position , _lastePosKnow);
        if (Vector3.Distance(transform.position, _lastePosKnow) < DestinationThreashHolde)
        {
            Collider[] cols = Physics.OverlapBox(transform.position, Vector3.one * SignalRange, Quaternion.identity,
                AlliezMask);
            _soundPlayer.PlaySound(1);

            foreach (var col in cols)
            {
                if (col.GetComponent<ScripteFSM>()!=null)
                {
                    GameObject player = col.GetComponent<ScripteFSM>().ComGetPositionKnow();
                    if (player != null)
                    {
                        CurrentState = State.Chase;
                        _CurrentDestination = player;
                        Debug.DrawLine(transform.position, col.transform.position, Color.blue, 3);
                        return;
                    }
                    Debug.DrawLine(transform.position, col.transform.position, Color.cyan, 3);
                }
            }
            CurrentState = State.SearchWait;
            _timer = 0;
            _incrémentasionIndex = 0;
        }
    }

    private void SearchWait()
    {
        _timer += Time.deltaTime;
        if (_timer > SearchWaitTime)
        {
            _lastePosKnow = transform.position+new Vector3(Random.Range(-SearchDistance,SearchDistance),0,Random.Range(-SearchDistance,SearchDistance));
            _navMeshAgent.destination = _lastePosKnow;
            _incrémentasionIndex++;
            CurrentState = State.searchWonder;
        }
        GameObject player = EyeDetector.GetFirstInTheList();
        if (player != null)
        {
            _CurrentDestination = player;
            CurrentState = State.Chase;
        }
    }

    private void SearchWandering()
    {
        if (Vector3.Distance(transform.position, _lastePosKnow) < DestinationThreashHolde)
        {
            if (_incrémentasionIndex <= 3)
            {
                _timer = 0;
                CurrentState = State.SearchWait;
            }
            else
            {
                CurrentState = State.MoveToDestination;
            }
        }


        GameObject player = EyeDetector.GetFirstInTheList();
        if (player != null)
        {
            _CurrentDestination = player;
            CurrentState = State.Chase;
        }
    }

    

    public enum State
    {
        PickDestination,
        MoveToDestination,
        Chase, 
        Search,
        SearchWait,
        searchWonder,
        Attack,
        AttckWait
    }
}