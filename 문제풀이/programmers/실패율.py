# -*- coding: utf-8 -*-
"""
Created on Tue Apr 23 21:31:53 2024

@author: mindo
"""

N = 5
stages = [2, 1, 2, 6, 2, 4, 3, 3]	
#result  [3,4,2,1,5]
# 1번  스테이지 실패율 1/8  8 -1 = 7 > 4 
# 2번  스테이지 실패율 3/7  7 -3 = 4 > 3
# 3번  스테이지 실패율 2/4  4 -2 = 2 > 1
# 4번  스테이지 실패율 1/2  2 -1 = 1 > 2
# 5번  스테이지 실패율 0/1  1 -0 = 1 > 5
# n이 최종 값
# 2가 3명
# 4가 
def solution(N, stages):
    answer = []
    dic = {}
    player =len(stages)
    for i in range(1, N+1):
        if player == 0:
            dic[i] = 0
        else:
            dic[i] = stages.count(i)/player
            player -= stages.count(i)

    answer = sorted(dic,key= lambda x : dic[x], reverse=True)        
    # player 감소 하지 않으면 [5, 1, 4, 3, 2]
    # 감소해야 맞는값이나옴 [3, 4, 2, 1, 5]
    return answer
solution(N, stages)