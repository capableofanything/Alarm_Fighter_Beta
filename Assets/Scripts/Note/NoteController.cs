using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour     //Note2 ��ü(�� ��)�� �����ǰ� �ı� �Ǵ� ���� ���
{
    double currentTime = 0;
    [SerializeField] Transform noteAppearLocation = null;//notePrefab�� ������ ��ġ
    //[SerializeField] GameObject notePrefab = null;//������ Note ������ ����

    
    public void Update()
    {
        //Ư�� �ð� �������� ��Ʈ ����
        currentTime += Time.deltaTime;
        if (currentTime >= 60d / Managers.Bpm.BPM)
        {
            Debug.Log("Note2 created"+currentTime);
            GameObject t_note = Managers.Resource.Instantiate("Notes/Note2",gameObject.transform);//------------------------------
            
            //GameObject t_note = ObjectPool.objectPool.noteQueue.Dequeue();//notePool���� obj(Note) �ϳ� ����      //--------------
            t_note.transform.position = noteAppearLocation.position;//obj�� Scene�� Ȱ��ȭ�� �ڸ� ����
            
            Managers.Timing.noteList.Add(t_note);//TimingManager2�� noteList�� ������ Note �߰�
            currentTime -= 60d / Managers.Bpm.BPM;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)      //��Ʈ�� ȭ�� ������ ������ ����
    {
        if (collision.CompareTag("Note2"))
        {
            Managers.Resource.Destroy(collision.gameObject);        
            Managers.Timing.noteList.Remove(collision.gameObject); //TimingManager�� noteList���� ����
        }
    }
}
