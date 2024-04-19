# -*- coding: utf-8 -*-
"""
Created on Fri Apr 19 22:19:15 2024

@author: mindo
"""
participant =["leo", "kiki", "eden"]	
completion = ["eden", "kiki"]	
# result = leo 
def solution(participant, completion):
    answer = ''
    temp = 0
    dic = {}
    for part in participant:
        dic[hash(part)] = part
        temp += int(hash(part))
    for com in completion:
        temp -= hash(com)
    answer = dic[temp]
    print(dic)
    # 해시를 쓰는게 가장적합한 방법
    return answer
solution(participant, completion)