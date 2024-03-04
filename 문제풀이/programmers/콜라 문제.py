# -*- coding: utf-8 -*-
"""
Created on Mon Mar  4 14:23:07 2024

@author: mindo
"""
a = 2
b = 1 
n = 20
# 빈병 20 개 > 콜라 10개
# 빈병 10 개 > 콜라  5개
# 빈병 5  개 > 콜라  2개
# 빈병 4  개 > 콜라  1개
# 빈병 2  개 > 콜라  1개 
def solution(a, b, n):
    answer = 0
    #cola = 0
    wait = 0
    
    # 빈병 2개당 콜라 1개를 준다
    # 20, 10, 5, 4, 2 = 41
    # 10,  5, 2, 1, 1 = 19
    # 1개가 남는 경우도 있어서 따로 빼줘야한다고!!!
    # 20 > 10 > 5 > 4 > 2 > 2 > 나머지도 생각해야함  
    # 빈병 하나 남아있음 1     
    while (n >= a):
        wait = n % a
        n = (n//a) * b 
        answer += n 
        n += wait 
    return answer

solution(a, b, n)