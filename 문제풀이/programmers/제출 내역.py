
park   =   ["OSO","OOO","OXO","OOO"] #["SOO","OOO","OOO"]#
routes =   ["E 2","S 3","W 1"] #["E 2","S 2","W 1"]
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
    # dfs 위한 모든 거리를가야하니까 
    move_m = {'E':0, 'W':0, 'N':-1, 'S':1}
    move_n = {'E':1, 'W':-1, 'N':0,'S':0}
    res =[]
    x = -1
    # 위치값 확인하는 코드
    for i in range(len(park)):
        a = list(park[i])
        for j in range(len(a)):
            if park[i][j] == 'S':
                print(park[i][j])
                res.append(i)
                res.append(j)
                break
    
    print("레스로 확인",res)
    for p in park:
        x += 1
        if 'S' in p:
            # 위치값을 알아와야하니까 i,j로 해도같습니다
            y = p.index('S')
            print("x,y값 : ",x, y,res)
            # 물론 브레이크를 하는이유는 계속가는걸막기위해서고 더이상 계산할필요가없다 
            break
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