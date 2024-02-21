# -*- coding: utf-8 -*-
"""
Created on Wed Feb 21 14:07:57 2024

@author: mindo
"""
book_time = [["15:00", "17:00"], ["16:40", "18:20"], ["14:20", "15:20"], ["14:10", "19:20"], ["18:20", "21:20"]]
def solution(book_time):
    daytime = [0] * (24 * 60)
    answer = 0
    end =0 
    # 문자열 숫자로 변환 + 탐욕법 
    # 십분이 지나면 하나 생겨요 추가된 개념 
    # 십분 지나면 answer -= 1 
    #print(sorted(book_time))
    #for i in range(len(book_time)):
        #for j in range(len(book_time[i])):
            #h, m = map(int,book_time[i][j].split(':'))
            #st = h*60+m
            #book_time[i][j] = st
            #book_time[i][j] = int(book_time[i][j])
    
    #(key=lambda x: x[0])
    
    # 위에 나온것처럼 쉽게 접근은 가능했음 
    # 정렬하고 
    # 나는 모든값에서 len(book_time)을받고
    # 1030, 930 이생기면 -=1 하는 접근을 갈려했는데
    # 복잡도가 높아져서 문제였음
    
    start = 0
    end = 0
    #print(book_time)
    
    for start, end in book_time:
        start = start.split(":")
        end = end.split(":")
        
        start = int(start[0]) * 60 + int(start[1])
        end = int(end[0]) * 60 + int(end[1]) + 10
        
        if end > 1440:
            end = 1440
        
        for i in range(start, end):
            daytime[i] += 1
    
    return max(daytime)

solution(book_time)