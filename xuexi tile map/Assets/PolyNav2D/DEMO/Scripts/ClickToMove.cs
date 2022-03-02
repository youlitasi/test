using UnityEngine;
using System.Collections.Generic;

//example
[RequireComponent(typeof(PolyNavAgent))]
public class ClickToMove : MonoBehaviour{
	
	private PolyNavAgent _agent;

	//巡逻 离自己出生点的范围半径
	public float patrolRange;

	//出生起始点
	private Vector3 InitPos;



	//到目标点停下观察的时间
	public float watchTime;

	//停下观察的剩余时间
	private float remainWatchTime;


	//上一帧位置
	private Vector3 lastPos;
	
	//目标点
	private Vector3 wayPoint;


	


	//停止移动的时间
	float  StopMoveTime;


	private bool IsMove=true;

     void Start()
	{
		lastPos = transform.position;
		remainWatchTime = watchTime;
		InitPos = transform.position;
		StopMoveTime = watchTime;
		GetNewWayPoint();
	}
    public PolyNavAgent agent
	{
		get
		{
			if (!_agent)
				_agent = GetComponent<PolyNavAgent>();
			return _agent;			
		}
	}

	void Update()
	{


		isMove();

		//离目标点距离小于停止距离的时候  说明进入观察时间  观察时间结束就要找个新的目标点
		if (Vector3.Distance(wayPoint, transform.position) <= agent.stoppingDistance )
		{

			if (remainWatchTime > 0)
			{
				remainWatchTime -= Time.deltaTime;
			}
			else
			{
				GetNewWayPoint();
			}
		}
		else
		{

			agent.SetDestination(wayPoint);

		}
		//if (Input.GetMouseButton(0))
		//agent.SetDestination( Camera.main.ScreenToWorldPoint(Input.mousePosition) );

		
	}

	//获得一个新的目标点
	void GetNewWayPoint()
	{
		remainWatchTime = watchTime;

		float randomX = Random.Range(-patrolRange, patrolRange);
		float randomY = Random.Range(-patrolRange, patrolRange);

		//保证是离起始点的半径
		Vector3 randomPoint = new Vector3(InitPos.x + randomX, InitPos.y+ randomY, InitPos.z );

		wayPoint = randomPoint;


	}

	//判断是否移动
	void  isMove()
	{

		
		


		
		//上一帧位置与当前帧位置做对比 如果一样就是没有移动  不一样就是在移动 
			
			if (lastPos != transform.position)  //若是上次静止的位置和当前位置不相同,就更新上次静止的位置和时间
		    {
			   IsMove = true;
			   //更新上一帧数位置
			   lastPos = transform.position;
		    }
	    	else
	    	{


			  //计算没有移动的时间    如果停下的时间超过巡逻观察时间   就找新的目标点
			StopMoveTime -= Time.deltaTime;

		     if (StopMoveTime <= 0) 
			  {
				IsMove = false;
				GetNewWayPoint();
				//重置时间
				StopMoveTime = watchTime;
			   }
				
				

			}
			





		



	}



}