# -*- coding: utf-8 -*-
"""
Created on Tue Apr 30 22:56:41 2024

@author: mindo
"""
n = 10
def solution(n):
    answer = 0
    answer_count_true = False
    for i in range(2,n+1):
        if n % i == 0:
            answer_count_true = True
            if answer_count_true == True:
                answer +=1
            answer_count_true = False
    return answer
solution(n)