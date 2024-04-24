# -*- coding: utf-8 -*-
"""
Created on Wed Apr 24 21:09:33 2024

@author: mindo
"""
answers = [1,2,3,4,5]	
def solution(answers):
    answer = []
    # result = 1 
    #1번  1 2 3 4 5 반복
    #2번  2, 1, 2, 3, 2, 4 ,2 ,5 2, 1, 2
    #3번  3, 3, 1, 1, 2, 2, 4, 4, 5, 5, 3,3 , 2, 2, 4, 4 , 5, 5, 3,3
    st1 = [1,2,3,4,5]
    st2 = [2, 1, 2, 3, 2, 4, 2, 5]
    st3 = [3, 3, 1, 1, 2, 2, 4, 4, 5, 5]
    st1_count , st2_count , st3_count = 0,0,0
    for i in range(len(answers)):
        # 반복되는점
        s1 = i%5
        s2 = i%8
        s3 = i%10
        # 1 5번 2는 8번 3은 10번 
        if st1[s1] == answers[i]:
            st1_count += 1
        if st2[s2] == answers[i]:
            st2_count += 1
        if st3[s3] == answers[i]:
            st3_count += 1
    k = max(st1_count , st2_count , st3_count)
    if k == st1_count:
        answer.append(1)
    if k == st2_count:
        answer.append(2)
    if k == st3_count:
        answer.append(3)
    return answer
solution(answers)