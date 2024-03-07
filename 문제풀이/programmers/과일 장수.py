# -*- coding: utf-8 -*-
"""
Created on Thu Mar  7 14:09:32 2024

@author: mindo
"""
score = [1, 2, 3, 1, 2, 3, 1]
k = 3
m = 4 
def solution(k, m, score):
    answer = 0
    score.sort(reverse=True) 
    answer = sum([score[i+m-1] for i in range(0,len(score),m) if i+m <= len(score)])*m  
    print(answer)
    return answer
solution(k, m, score)