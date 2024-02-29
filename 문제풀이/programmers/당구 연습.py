m= 10
n= 10
startX = 3
startY = 7
balls = [[7, 7], [2, 7], [7, 3]]	
def solve(x, y, startX, startY, ballX, ballY):
    wall = []
    # 위쪽 벽
    # 단, x좌표가 같고 목표의 y가 더 크면 안된다.
    if not (ballX == startX and ballY > startY):
        d2 = (ballX - startX)**2 + (ballY - 2*y+startY)**2
        wall.append(d2)
    # 아래쪽 벽
    # 단, x좌표가 같고 목표의 y가 더 작으면 안된다.
    if not (ballX == startX and ballY < startY):
        d2 = (ballX - startX)**2 + (ballY + startY)**2
        wall.append(d2)
    # 왼쪽 벽에 맞는 경우
    # 단, y좌표가 같고 목표의 x가 더 작으면 안된다.
    if not (ballY == startY and ballX < startX):
        d2 = (ballX + startX)**2 + (ballY - startY)**2
        wall.append(d2)
    # 오른쪽 벽
    # 단, y좌표가 같고 목표의 x가 더 크면 안된다.
    if not (ballY == startY and ballX > startX):
        d2 = (ballX - 2*x+startX)**2 + (ballY - startY)**2
        wall.append(d2)
    print(wall)
    return min(wall)
    
def solution(m, n, startX, startY, balls):
    answer = []
    for ballX, ballY in balls:
        answer.append(solve(m, n, startX, startY, ballX, ballY))
    print(answer)
    return answer

solution(m, n, startX, startY, balls)