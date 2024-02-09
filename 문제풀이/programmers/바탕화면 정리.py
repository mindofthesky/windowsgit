# -*- coding: utf-8 -*-
"""
Created on Fri Feb  9 19:48:38 2024

@author: mindo
"""
wallpaper = [".#...", "..#..", "...#."]
# ".#...",  0 1 0 0 0 
# "..#..",  0 0 1 0 0
# "...#."   0 0 0 1 0 
# 최솟값값부터 최대값으로간다 | 추론도 정답 
def solution(wallpaper):
    answer = []
    # 3 , 5 
    m , n = len(wallpaper), len(wallpaper[0])
    #print(m,n)
    x,y = [],[]
    new_wall = [[0]*n for i in range(m)] 
    # 굳이 필요없을듯? deque로 했다면 필요 
    print(new_wall)
    #print(wallpaper[2][3])
    for i in range(m) :
        for j in range(n) :
            if wallpaper[i][j] == '#':
                x.append(i)
                y.append(j)
    answer =[min(x),min(y),max(x)+1,max(y)+1]
    print(answer)
    
    return answer
solution(wallpaper)