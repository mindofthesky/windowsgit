# -*- coding: utf-8 -*-
"""
Created on Sun Apr 14 22:36:08 2024

@author: mindo
"""
sequence = [2, 3, -6, 1, 3, -1, 2, 4]	
def solution(sequence):
    answer = 0
    size = len(sequence)
    s1 = 0
    s2 = 0
    s1_min = s2_min = 0
    pulse = 1
    for i in range(size):
        s1 += sequence[i] * pulse
        s2 += sequence[i] * (-pulse)
        
        answer = max(answer, s1-s1_min, s2-s2_min)
        
        s1_min = min(s1_min, s1)
        s2_min = min(s2_min, s2)
        print(s1,s2)
        pulse *= -1
    print(answer)
    return answer

solution(sequence)