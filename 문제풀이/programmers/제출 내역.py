# -*- coding: utf-8 -*-
"""
Created on Sat Feb 17 21:46:20 2024

@author: mindo
"""
park   =   ["SOO","OOO","OOO"] #["OSO","OOO","OXO","OOO"]#
routes =   ["E 2","S 2","W 1"]
# "SOO"
# "OOO"
# "OOO"
# 장애물을 만나면 다음값으로
# S는시작지점
# O는 가능한 장소
# X는 불가능한 위치
# n = 9 까지 가능 
def solution(park, routes):
    answer = []
    res = []
    for i in range(len(park)):
        list(park[i])    
        print(list(park[i]))
        for j in range(len(park)):
            if park[i][j] == 'S':
                res.append(i)
                res.append(j)
    
    move_m = {'E':0, 'W':0, 'N':-1, 'S':1}
    move_n = {'E':1, 'W':-1, 'N':0,'S':0}
    
    x = -1
    for p in park:
        x += 1
        if 'S' in p:
            y = p.index('S')
            break
    # 한 칸씩 이동해보면서 끝까지 조건 만족하면, 명령 수행
    for r in routes:
        op, n = r.split()
        for p in range(1,int(n)+1):
            nx = x + p*move_m[op]
            ny = y + p*move_n[op]
            if 0 <= nx < len(park) and 0 <= ny < len(park[0]) and park[nx][ny] != 'X':
                continue
            else:
                break
        else:
            x, y = nx, ny
    print([x,y])
    return [x,y]

solution(park, routes)