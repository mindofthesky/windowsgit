# -*- coding: utf-8 -*-
"""
Created on Sat Mar  9 15:34:54 2024

@author: mindo
"""
number =  5
limit  =  3
power  =  2
def solution(number, limit, power):
    answer = 0
    res = []
    # while 문갈필요가없었다
    for i in range(1,number +1):
        # 이접근을 몰랐는데 
        # 그냥 수학부터 접근하는게맞았다고봐야했다 
        count = 0
        # 이중 포문은 생각안하고있었고
        # 1중 포문으로 끝낼수있지않을까 생각했음
        for j in range(1, int(i ** 0.5)+1):
            if i % j == 0:
                # 나머지가 없으면 2개
                count += 2
        if (i ** 0.5) % 1 == 0:
            
            count -=1
        if count <= limit:
            answer+= count
            
        else:
            answer+=power
    print(answer)
    return answer

solution(number, limit, power)