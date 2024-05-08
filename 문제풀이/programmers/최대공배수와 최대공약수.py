# -*- coding: utf-8 -*-
"""
Created on Wed May  8 23:50:06 2024

@author: mindo
"""

def gcd(n,m):
    if n%m == 0:
        return m
    else:
        return gcd(m,n%m)
def solution(n, m):
    answer = [gcd(m,n),n * m // gcd(m,n)]
    return answer