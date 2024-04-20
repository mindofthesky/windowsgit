# -*- coding: utf-8 -*-
"""
Created on Sat Apr 20 22:19:36 2024

@author: mindo
"""
strings =["sun", "bed", "car"]	
n = 1
# result = ["car", "bed", "sun"]

def solution(strings, n):
    answer = []
    strings.sort()
    print(strings[0][1])
    return sorted(strings, key=lambda x:x[n])

solution(strings, n)