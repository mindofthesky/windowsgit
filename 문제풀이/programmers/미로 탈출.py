# -*- coding: utf-8 -*-
"""
Created on Sun Mar  3 17:17:58 2024

@author: mindo
"""


maps = ["SOOOL","XXXXO","OOOOO","OXXXX","OOOOE"]	
# 다른 dfs랑 다르게
# 접근은 맞음 
# L를 갔다가 가야함
# 16 

import collections 

def bfs(start_x, start_y, target_x, target_y, map1):
    # 대괄호냐 중괄호 상관없다 dx , dy로 이동하기위해 쓰는거기때문 
    move = [(-1,0),(0,1),(1,0),(0,-1)]
    
    q = collections.deque()
    q.append((start_x, start_y, 0)) # cnt : 0
    
    visited = [[0 for _ in range(len(map1[0]))] for _ in range(len(map1))]
    visited[start_x][start_y] = 1
    
    while q:
        x, y , count = q.popleft()
        if x == target_x and y == target_y:
            return count
        for tx ,ty in move:
            dx = tx + x
            dy = ty + y
            #if 0 <= mapi+dx < n and 0 <= mapj+dy < m and  maps[mapi+dx][mapj+dy] != 'X' and new_map[mapi+dx][mapj+dy] == False:
            if 0 <= dx < len(map1) and 0<= dy<len(map1[0]) and map1[dx][dy] != 'X'and visited[dx][dy] != 1:
                visited[dx][dy] = 1
                q.append((dx,dy,count+1))
    return -1
                
    
def solution(maps):
    answer = 0
    n,m = len(maps[0]), len(maps)
    new_map = [[0]*m for i in range(n)]
    #print(new_map)
    for i in range(m):
        for j in range(n):
            if maps[i][j] == 'S':
                sx,sy = i, j
                # 시작점
            if maps[i][j] == 'L':
                lx,ly = i,j
                # 레버점
            if maps[i][j] == 'E':
                ex, ey = i,j
                # 종료점
            
    before = bfs(sx,sy,lx,ly,maps)
    after = bfs(lx,ly,ex,ey,maps)
    
    if before == -1 or after == -1:
        return -1
            
 
    return after+ before

solution(maps)