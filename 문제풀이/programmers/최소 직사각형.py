# -*- coding: utf-8 -*-
"""
Created on Sat Apr 13 22:45:19 2024

@author: mindo
"""
sizes = [[60, 50], [30, 70], [60, 30], [80, 40]]	
# result = 4000 
def solution(sizes):
    answer = 0
    w = []
    h = []
    for i in sizes:
        if i[0] > i[1]:
            w.append(i[0])
            h.append(i[1])
        else:
            w.append(i[1])
            h.append(i[0])
    print(w,h)
    answer = max(w) * max(h)
    return answer 

solution(sizes)