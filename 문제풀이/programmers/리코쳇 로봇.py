# -*- coding: utf-8 -*-
"""
Created on Fri Feb 16 01:10:34 2024

@author: mindo
"""
from collections import deque
board = ["...D..R", ".D.G...", "....D.D", "D....D.", "..D...."]
# "...D..R"
# ".D.G..."
# "....D.D"
# "D....D."
# "..D...."
# R이 시작 G가 도착지
# 장애물을 만날때까지 내려감 
# G까지가는데 7번 
# 문제는 어떻게 가게할건데?
# dfs 처럼 다가봐야한다 dx dy + 


def solution(board):
    answer = 0
    dx, dy = [0,0,-1,1], [-1,1,0,0]
    m, n = len(board), len(board[0])
    start = [-1,-1]
    visit = [list(False for i in range(n)) for i in range(m)]
    
    for i in range(m):
        for j in range(n):
            if board[i][j]== 'R':
                start = [i,j]
                break
        if start[0] != -1: 
            break
    def move(r,c,dir):
        while True:
            r += dx[dir]
            c += dy[dir]
            if r<0 or r>=m or c<0 or c>=n :
                break
            elif board[r][c] == 'D':
                break
        r -= dx[dir]
        c -= dy[dir]
        return [r, c]
    q = deque()
    q.appendleft([start[0],start[1],0])
    while q:
        r,c,dis = q.pop()
        for i in range(4):
            nr, nc = move(r,c,i)
            if visit[nr][nc]:
                continue
            elif board[nr][nc] == 'G':
                answer = dis+1
                return dis + 1
            else:
                visit[nr][nc] =True
                q.appendleft([nr,nc,dis+1])
    return answer

solution(board)