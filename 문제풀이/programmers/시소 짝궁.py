# -*- coding: utf-8 -*-
"""
Created on Sat Mar  2 17:54:14 2024

@author: mindo
"""
weights = [100,180,360,100,270]
# result =4 
# 100     = 100     (1개)
# 180 * 4 = 360 * 2 (2개)
# 180 * 3 = 270 * 2 (3개)
# 270 * 4 = 360 * 3 (4개)
# a * n1 = b * n2
def solution(weights):
    answer = 0 
    answer2 = 0
    # seat를 따로 주면 더 복잡해지네
    #seat = [2,3,4]
    dic = {}
    for i in weights:
        dic[i] = dic.get(i,0)
        dic[i] +=1
    print(dic)
    # dic 100 :2 , 180 :1 , 270 : 1 , 360 : 1 > dict 형태임
    # dic 형태로 개수를 세면 하나의 값은 처리가됨     
    for i in dic:
        x2 = i *2
        if (x2 % 3 ) == 0:
            if (int(x2/3) in dic):
                answer2 += int(dic[i] * dic[x2 / 3])
        if (x2 % 4 ) == 0:
            if (int(x2/4) in dic):
                answer2 += int(dic[i] * dic[x2 / 4])
        x3= i * 3
        if (x3 % 2 ) == 0:
            if (int(x3/2) in dic):
                answer2 += int(dic[i] * dic[x3 / 2])
        if (x3 % 4 ) == 0:
            if (int(x3/4) in dic):
                answer2 += int(dic[i] * dic[x3 / 4])
        x4= i * 4
        if (x4 % 2 ) == 0:
            if (int(x4/2) in dic):
                answer2 += int(dic[i] * dic[x4 / 2])
        if (x4 % 3 ) == 0:
            if (int(x4/3) in dic):
                answer2 += int(dic[i] * dic[x4 / 3])
        print(answer2)
        answer += int(dic[i] * (dic[i] -1) / 2)
    answer += int(answer2/2)
    print(answer)
    # dic으로 한번에 계산하기?
    # 100 
    return answer

solution(weights)