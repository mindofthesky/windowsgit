# -*- coding: utf-8 -*-
"""
Created on Sat Feb 17 16:32:39 2024

@author: mindo
"""
n = 8
m = 4
section = [2,3,6]#[1,2,3,4]
def solution(n, m, section):
    # 왜 1을 넣었을까 
    answer = 1
    # 무조건 한번은 칠하게된다 
    mincount = section[0]
    
    # n 배열크기
    # m 룰러가 칠하는 크기
    # section 칠하지 않은 배열 위치 
    # 내가 생각하는건 이건데
    # min  max값이 존재할건데
    # section에서는 무조건 최소값이 2 최대값이 6
    # res 1 2 3 4 5 6 7 8 
    # 2에서 시작하고 max를 만나면 브레이크 
    # min 을넣는순간 속도가 너무 느려진다 
    for i in section:

    # 그리고 res[i:i+m] 으로하면 너무큰수가 나온다 
    # 1,2,3,4 m =1 n= 4인경우 답을 찾지못한다
        #print(res[i:i+m])
        print(i)
        if mincount + (m-1) < i:
            mincount = i
            answer +=1
            print(i)
        #print(mincount)
    # 핵심은 mincount 같은 값을 줄것
    # answer 1 에서 시작해야한다 
    return answer

solution(n, m, section)