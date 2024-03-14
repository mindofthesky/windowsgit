# -*- coding: utf-8 -*-
"""
Created on Wed Mar 13 14:01:01 2024

@author: mindo
"""
s= "one4seveneight"
# result 1478
# 23four5six7 > 234567
def solution(s):
    answer = 0
    dic = {"zero":0,"one":1,"two":2,"three":3,"four":4,"five":5,"six":6,"seven":7,"eight":8,"nine":9}
    print(dic.keys())
    # one, 4, seven , eight
    for key , value in dic.items():
        s = s.replace(key,str(value))
    return int(s)
solution(s)