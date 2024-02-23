# -*- coding: utf-8 -*-
"""
Created on Fri Feb 23 12:38:47 2024

@author: mindo
"""
s = "banana"
# b , a , n 는 처음 왔기때문에
# -1 -1  -1
# a는 들어온상태이고 2로 
# 또다른 a를 만났지만 4,2로호출이가능하지만 최소값인 2를 선택
# n도 2 
# [-1, -1, -1, 2, 2, 2]
def solution(s):
    answer = []
    res = []
    # 딕셔너리형으로 해야될거같은데
    # 접근 정답
    # 지금도 문제인건 not in 코드 이해도가 낮다 
    # not in을 안쓰는이유는 안작성해본 코드일 확률이 크다
    # not list 형에서 특정요소 확인하기에 좋은 녀석인것을 명심하자
    dic = {}
    for i in range(len(s)):
        print(dic)
        if s[i] not in dic:
            answer.append(-1)
        
        else:
            print(i-dic[s[i]])
            answer.append(i-dic[s[i]])
        # 값 치환
        dic[s[i]] = i
            
    print(answer)
    return answer

solution(s)