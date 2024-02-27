from collections import deque
land = [[0, 0, 0, 1, 1, 1, 0, 0], [0, 0, 0, 0, 1, 1, 0, 0], [1, 1, 0, 0, 0, 1, 1, 0], [1, 1, 1, 0, 0, 0, 0, 0], [1, 1, 1, 0, 0, 0, 1, 1]]
def solution(land):
    # land 만큼 반복 
    n, m = len(land), len(land[0])
    visited = [[-1] * m for _ in range(n)]
    space = {-1:0}
    def dfs(x, y, d):
        land, visited
        # [[-1] * m for _ in range(n)] visited
        # land = [[0, 0, 0, 1, 1, 1, 0, 0], [0, 0, 0, 0, 1, 1, 0, 0], [1, 1, 0, 0, 0, 1, 1, 0], [1, 1, 1, 0, 0, 0, 0, 0], [1, 1, 1, 0, 0, 0, 1, 1]]
        q = deque([[x, y]])
        # 초기 큐값은 여기에있다 
        visited[x][y] = d
        # dx, dy는 이동을 위한 코드 
        dx, dy = [1, -1, 0, 0], [0, 0, 1, -1]
        cnt = 1
        # 초기시작값 
        print(q)
        while q:
            #print("초기 큐 ", q)
            cx, cy = q.popleft()
            #print("popleft()이후" ,cx, cy)
            
            for i in range(4): # dx,dy은 4번 이동하고 더이상이동하지않으니 4번으로 제한 
                nx, ny = cx + dx[i], cy + dy[i] # 동서남북으로 이동 
                if 0 <= nx < n and 0 <= ny < m and land[nx][ny] == 1 and visited[nx][ny] == -1:
                    # -1 은 이동 더이상 못할경우  < m 
                    q.append([nx, ny])
                    #print("d ",d)
                    visited[nx][ny] = d
                    cnt += 1
                    # count 가 값을 계산함 시추값 

        
        print("count",cnt)
        return cnt

    f = 0
    for i in range(n):
        for j in range(m):
            if visited[i][j] == -1 and land[i][j] == 1:
                space[f] = dfs(i, j, f)
                f += 1
    # 답을 만들어야겠지?

    result = 0

    for i in list(zip(*visited)):
        temp = 0
        for j in set(i):
            temp += space[j]
        result = max(result, temp)
    #print(list(zip(*visited)))
    return(result)
solution(land)