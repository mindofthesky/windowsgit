board = [["blue", "red", "orange", "red"], ["red", "red", "blue", "orange"], ["blue", "orange", "red", "red"], ["orange", "orange", "red", "blue"]]
board1 = [["yellow", "green", "blue"], ["blue", "green", "yellow"], ["yellow", "blue", "blue"]]
h = 1
w = 1
def solution(board, h, w):
    answer = 0
    # dh dw [0,1] [-1,0], [1,0],[0,-1] = BFS 동서남북
    m = len(board)
    dh, dw = [0,1,-1,0],[1,0,0,-1]
    h_check, w_check = 0,0
    
    for i in range(len(dw)):
        h_check = h + dh[i]
        w_check = w + dw[i]
        #print(h_check,w_check)
        # 실패 런타임이유가
        # -1 넣으면 > 무조건 dw > 무조건 -1을 반환하게되는데 이게 무한 루프임
        if (0 <= h_check <= len(board)-1) and (0 <= w_check <= len(board[0])-1):
            answer+=int(board[h][w] == board[h_check][w_check])

            
    print(board[h][w])
    print(answer)
    # dfs를 알면 이미 값을 다줬다
    # 효율성 그냥 생각안해도되는문제입니다 
    # 시간제한이없거든요 
    return answer
solution(board, h, w)
