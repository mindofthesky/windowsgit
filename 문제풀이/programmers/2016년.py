# -*- coding: utf-8 -*-
"""
Created on Sun Apr 28 19:44:18 2024

@author: mindo
"""
a = 5
b = 24

def solution(a, b):
    answer = ''
    days = ['THU', 'FRI', 'SAT','SUN', 'MON', 'TUE','WED']
    months = [31,29,31,30,31,30, 31, 31, 30, 31, 30, 31]
    answer = days[(sum(months[:a-1])+b)%7]
    return answer
solution(a, b)