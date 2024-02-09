# 구현문제라고 생각하고 > 아니야  BFS야 
# 이중포문으로 그려주자? > 맞다 
# X를 숫자라고 생각하자 > 맞아 !  | 숫자라고 해도될것같은데 
# X=0 값에 영향을 주지않는다 
from collections import deque
maps =["X591X","X1X5X","X231X", "1XXX1"]
maps1 =["05910","01050","02310", "10001"]
maps2 =["XXX","XXX","XXX"]
def solution(maps):
    answer = []
    # 크기 조정 > 내가 [0,0,0,0,0] 한코드에서는 오직 5*5 에서만 성립하지만 아래
    # 코드로 변수를 설정해주면 어디든 성립한다
    n,m = len(maps), len(maps[0])
    # 이녀석이 지금 뭘하는지 모르겠다
    # move = 앞, 옆,뒤  
    #    0 
    # 0 기준 0
    #    0
    # 움직일수있으니까 
    # https://cccaaa.tistory.com/22 좀더 이해 
    move = [(0,1),(1,0),(-1,0),(0,-1)] # 북 , 동 , 서 , 남 
    #new_map = [ [0,0,0,0,0] for _ in range((len(maps)))]
    # 이게 수정이 필요하다 생각했는데 바로 접근을 못했다     
    # 꼭 False 일필요없는거같은데 ? 
    new_map = [[0]*m for i in range(n)]
    # 편의상 False 넣은것 같고 나는 X = 0 으로 취급한다면 0을 넣자 
    # 접근한 답에선 이렇게 시작
    #print(new_map)

#    from collections import deque

#    N = 3 # MAP 크기

#    MAP = [[0 for _ in range(N)] for _ in range(N)]
#    visited = [[0 for _  in range(N)] for _ in range(N)]

#    start_row, start_column = 0,0 # 시작 행,열 인덱스
#    target_row, target_column = 1, 2 # 도착 행, 열 인덱스
#    move = {(-1,0),(0,1),(1,0),(0,-1)} #북동남서
#    cnt = 0
#
#    q = deque()
#    q.append((start_row, start_column, cnt))
#    visited[start_row][start_column] = 1

#   while q:
#       cur_row, cur_column, cnt = q.popleft()
#       if cur_row == target_row and cur_column == target_column:
#           break
#       for next_r, next_c in move:
#           next_row = cur_row + next_r
#           next_column = cur_column + next_c
#
#           if 0<=next_row<N and 0<=next_column<N \
#               and visited[next_row][next_column] != 1:
#                   q.append((next_row, next_column, cnt + 1))
#                    visited[next_row][next_column] = 1

#    print(cnt)
    
    
    for i in range(n):
        for j in range(m):
            #print(maps[i][j],new_map[i][j])
            if maps[i][j] == 'X' or new_map[i][j]:
                continue
            q = deque()
            
            q.append((i,j))
            
            new_map[i][j] = True
            mes_answer = 0
            
            while q:
                mapi,mapj = q.popleft()
                 
                mes_answer += int(maps[mapi][mapj])
                #print(mes_answer) # 모든값을 더한다 
                # 이게 아직 이해못하겠어 == https://cccaaa.tistory.com/22 이해완료 
                # 모든 움직임을 계산해야하기때문에 깊이우선으로 처리
                # 물론 for 2중은 설레발로 맞았다 할수있지만
                # move의 함수 (-1,0),(0,1),(1,0),(0,-1) 
                # 모든값에 움직임을 추측 
                # dx,dy는 동서 남북 방향으로 이동하는 값이다 
                for dx, dy in move:
                    if 0 <= mapi+dx < n and 0 <= mapj+dy < m and  maps[mapi+dx][mapj+dy] != 'X' and new_map[mapi+dx][mapj+dy] == False:
                        q.append((mapi+dx, mapj+dy))
                        print(q)
                        new_map[mapi+dx][mapj+dy] = True
                        print(mapi+dx,mapj+dy)
            if mes_answer:
                answer.append(mes_answer)
                
    # X는 0이다 
    if answer:
        answer.sort()
        return answer
   
    #for i in maps:
    #    for j in maps:
    else:
         return [-1]
    return answer

solution(maps1)