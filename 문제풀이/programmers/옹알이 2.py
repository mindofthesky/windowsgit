# -*- coding: utf-8 -*-
"""
Created on Sun Mar 10 14:04:57 2024

@author: mindo
"""
babbling = ["ayaye", "uuu", "yeye", "yemawoo", "ayaayaa"]
def solution(babbling):
    answer = 0
    # 연속한 같은 발음이 어렵고 > 중복값이 바로 오지않는다 
    # 네가지 발음을 조합해야한다 
    # 애초에 시작에는 ["aya", "yee", "u", "maa"] 가 무조건 가진다 
    baby = ["aya","ye","woo","ma"]
    # 흠 스택인가???
    # 스택이면 baby에서 빼고 다시 넣는게 반복되는데 
    #  
    
    for i in babbling:
        if i in baby:
            answer += 1
        else:
            comp=""
            temp=""
            for j in i:
                comp += j
                if comp!=temp and comp in baby:
                    temp=comp
                    comp=""
            if comp=="":
                answer += 1
    #for i in babbling:
    #    for j in baby:
    #        if j*2 not in i:
    #            i=i.replace(j,' ')
    #            print(len(i.strip()))
    #    if len(i.strip())==0:
    #        answer +=1
        
    return answer

solution(babbling)