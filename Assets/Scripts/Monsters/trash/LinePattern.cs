using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePattern : MonsterPattern
{
    public override int[] calculateIndex(int currentInd)        //(���� gird ����)currentInd ���� ���� 2ĭ grid�� �ε���(��ü grid����) �迭 ��ȯ
    {
        int[] pattern = new int[3];
        int gridIndex = GetGridIndex(currentInd);
        for(int i = 0; i < 3; i++)
        {
            gridIndex -= 3;
            pattern[i] = gridIndex;

        }
        return pattern;
    }
}
