# -*- coding: utf-8 -*-
"""
Created on Sat Feb 24 12:09:42 2024

@author: mindo
"""
s ="abracadabra"
s1 = "aaabbaccccabba"
def solution(s):
    answer1 = 0
    res4 = 0
    # 이전 코드 작성
    for i in range(len(s)):
        if s[i-1] == s[i]:    
            if i == len(s)-1:    
                answer1 +=1
            # 여기 코드는 상관이없지만  
        else:
            res4 +=1
            if res4 == 2:
                answer1 +=1 
                res4 = 0
    # 이전 코드에서는 1/2 안나눠지는경우에서 5로 처리가 끝나는 오류가 발생한다     
    answer = 0
    res = 0
    res1, res2 = 0 , 0
    for i in s:
        if res1 == res2:
            answer +=1
            res = i
        if res == i:
            res1 +=1
        else:
            res2 +=1
                
    print(answer,answer1)    
    return answer

solution(s)
solution(s1)