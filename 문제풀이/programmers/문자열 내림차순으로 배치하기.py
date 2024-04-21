# -*- coding: utf-8 -*-
"""
Created on Sun Apr 21 23:15:56 2024

@author: mindo
"""

def solution(s):
    answer = ''
    answer = ''.join(sorted(s,reverse =True))
    return answer