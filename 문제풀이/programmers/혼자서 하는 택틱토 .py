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
    count, xcount, ocount = 0 
    # dfs?
    dic = {}
    # 9번 밖에 시행하지않는다 
    # x= 4 o = 5 개 끝
    
    print(board)
    return answer

solution(board)