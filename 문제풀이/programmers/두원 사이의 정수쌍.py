r1 = 2
r2 = 3
from math import sqrt
def solution(r1, r2):
    answer = 0
    # 큰원이 가에 좌표는 4개를 갖고 나머지도 정사각형처럼 나오게된다 
    # 직접 손으로 계산했을때 두점과 원의 좌표격자 (n.0) , (-2, 0) / (0,2), (0 -2) a1 = 4 
    # a2 * 4 다 공통적으로 4배를 할수있는 알고리즘을 만드는게 문제였다 
    # 2 ,3 일때도 바깥쪽에 4개는 확정값이나오며
    # 3 ,4 도 동일하게 증가했다 
    # 16 개 10 , 6 
    # 한쪽에만 확정시키면 네배의 곱의 값과 같다
    for i in range(0,r1):
        answer += int(sqrt(r2**2 - i**2)) - int(sqrt(r1**2 - i**2 -1))
        print("r1",answer)
        # 아래쪽 중복제외 3 * 2  
    for i in range(r1, r2):
        answer += int(sqrt(r2**2 - i**2))
        print("여기까지 값",answer) 
        # 오른쪽 5 * 2 
    print(answer*4)
    return answer * 4
solution(r1, r2)