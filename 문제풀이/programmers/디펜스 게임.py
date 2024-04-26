# -*- coding: utf-8 -*-
"""
Created on Fri Apr 26 22:45:29 2024

@author: mindo
"""
n =7 
k = 3
enemy = [4, 2, 4, 5, 3, 3, 1]	
def solution(n, k, enemy):
    if len(enemy) <= k:
        return len(enemy)
    if sum(enemy) <= n:
        return len(enemy)
    i = ((len(enemy)-k)//2)+k    

    r = k
    while r < i:
        s = sum(sorted(enemy[:i], reverse=True)[k:])
        if s > n:
            enemy = enemy[:i]
            i = r+((i-r)//2)
        else:
            r = i
            i = i+((len(enemy)-i)//2)
    if r == len(enemy)-1:
        if sum(sorted(enemy, reverse=True)[k:]) > n:
            return r
        else:
            return len(enemy)
    return r
