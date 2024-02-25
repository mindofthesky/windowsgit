# -*- coding: utf-8 -*-
"""
Created on Sun Feb 25 23:23:15 2024

@author: mindo
"""
k = 3
score = [10, 100, 20, 150, 1, 100, 200]
def solution(k, score):
    answer = []
    ans =[]
    for i in score:
        if len(answer)<k:
            ans.append(i)
        else:
            if min(ans) < i:
                ans.remove(min(ans))
                ans.append(i)
        answer.append(min(ans))
    return answer