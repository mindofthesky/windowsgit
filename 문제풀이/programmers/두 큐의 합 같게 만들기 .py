# -*- coding: utf-8 -*-
"""
Created on Mon Apr 29 23:14:48 2024

@author: mindo
"""
from collections import deque
queue1 = [3, 2, 7, 2]	
queue2 = [4, 6, 5, 1]
def solution(queue1, queue2):
    answer = -2
    # que1 == que2 같게 만들어야한다
    # 그러나 최저의 횟수가 행해야한다
    # que1,2 값을 계속 확인한다? 
    # 값은 두큐의 합값에서 /2 
    # (que1+que2) / 2
    # 불가능하면 -1 
    # 4 >
    queue1, queue2 = deque(queue1), deque(queue2)
    sum1, sum2 = sum(queue1), sum(queue2)
    
    for _ in range(3*len(queue1)):
        if sum1 > sum2:
            sum1 -= queue1[0]
            sum2 += queue1[0]
            queue2.append(queue1.popleft())
        elif sum1 < sum2:
            sum1 += queue2[0]
            sum2 -= queue2[0]
            queue1.append(queue2.popleft())
        else:
            return answer
        answer += 1
    return -1