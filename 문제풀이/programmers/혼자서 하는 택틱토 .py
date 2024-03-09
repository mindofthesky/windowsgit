# -*- coding: utf-8 -*-
"""
Created on Sun Mar  3 14:56:17 2024

@author: mindo
"""
board  = ["O.X", ".O.", "..X"]
board1 = ["OOO", "...", "XXX"]	
board2 = ["...", ".X.", "..."]	
board3 = ["...", "...", "..."]	
# 정상적인 상황이면 1 
# 아니면 -1 
# case 1
# "O.X"
# ".O."
# "..X"
# 1
# case 2 
# "OOO"
# "..."
# "XXX"
# 0
# case 3
# "..."
# ".X."
# "..."
# 0
# case 4 
# "..."
# "..."
# "..."
# 1
def solution(board):
    answer = -1
    m, n = len(board), len(board[0])
    
    # dfs?
    dic = {}
    # 9번 밖에 시행하지않는다 
    # x= 4 o = 5 개 끝
    o, x = sum([oi.count('O') for oi in board]), sum([xi.count('X') for xi in board])
    print(board)
    if 0 <= o-x <= 1:
        rb = [board[0][i] + board[1][i] + board[2][i] for i in range(3)]
        
        winO, winX = 0, 0
        
        for i,j in zip(board, rb):
            if 'OOO' in [i,j] : winO += 1
            if 'XXX' in [i,j] : winX += 1
        classifer = [board[0][0] + board[1][1] + board[2][2], board[0][2] + board[1][1] + board[2][0]]
        winO += classifer.count('OOO')
        winX += classifer.count('XXX')
        
        if winX and winO: return 0
        if winO and winX == 0 and o==x: return 0
        if winX and winO == 0 and o!=x: return 0
        
    return answer

solution(board)