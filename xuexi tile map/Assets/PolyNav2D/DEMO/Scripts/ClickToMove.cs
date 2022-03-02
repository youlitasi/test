using UnityEngine;
using System.Collections.Generic;

//example
[RequireComponent(typeof(PolyNavAgent))]
public class ClickToMove : MonoBehaviour{
	
	private PolyNavAgent _agent;

	//Ѳ�� ���Լ�������ķ�Χ�뾶
	public float patrolRange;

	//������ʼ��
	private Vector3 InitPos;



	//��Ŀ���ͣ�¹۲��ʱ��
	public float watchTime;

	//ͣ�¹۲��ʣ��ʱ��
	private float remainWatchTime;


	//��һ֡λ��
	private Vector3 lastPos;
	
	//Ŀ���
	private Vector3 wayPoint;


	


	//ֹͣ�ƶ���ʱ��
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

		//��Ŀ������С��ֹͣ�����ʱ��  ˵������۲�ʱ��  �۲�ʱ�������Ҫ�Ҹ��µ�Ŀ���
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

	//���һ���µ�Ŀ���
	void GetNewWayPoint()
	{
		remainWatchTime = watchTime;

		float randomX = Random.Range(-patrolRange, patrolRange);
		float randomY = Random.Range(-patrolRange, patrolRange);

		//��֤������ʼ��İ뾶
		Vector3 randomPoint = new Vector3(InitPos.x + randomX, InitPos.y+ randomY, InitPos.z );

		wayPoint = randomPoint;


	}

	//�ж��Ƿ��ƶ�
	void  isMove()
	{

		
		


		
		//��һ֡λ���뵱ǰ֡λ�����Ա� ���һ������û���ƶ�  ��һ���������ƶ� 
			
			if (lastPos != transform.position)  //�����ϴξ�ֹ��λ�ú͵�ǰλ�ò���ͬ,�͸����ϴξ�ֹ��λ�ú�ʱ��
		    {
			   IsMove = true;
			   //������һ֡��λ��
			   lastPos = transform.position;
		    }
	    	else
	    	{


			  //����û���ƶ���ʱ��    ���ͣ�µ�ʱ�䳬��Ѳ�߹۲�ʱ��   �����µ�Ŀ���
			StopMoveTime -= Time.deltaTime;

		     if (StopMoveTime <= 0) 
			  {
				IsMove = false;
				GetNewWayPoint();
				//����ʱ��
				StopMoveTime = watchTime;
			   }
				
				

			}
			





		



	}



}