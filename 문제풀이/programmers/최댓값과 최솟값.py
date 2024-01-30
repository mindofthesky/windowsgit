s = "1 2 3 4"
s1 = "-1 -2 -3 -4"
s2 = "-1 -1"
def solution(s):
    answer = ''
    # 사실 첫접근은 split으로 시작했다 
    # 문제점은 split으로한경우 절대값으로 처리한다는점 
    # 첫접근은 max min으로 하면되지않을까? 라는 생각으로했다
    # a = min(s.split(' ')) + max(s.split(' '))  > 1 4 
    b = min(s1.split(' ')) + " " +  max(s1.split(' ')) 
    # 절대값으로 처리하기때문에 값을 처리하지못했다 
    a= s.split(' ')
    # map을 사용하지 못했던 이유는 무엇일까?
    answer = list(map(int,a))
    print(b)
    # 이유를 간단히 생각하면 
    c = [-1.2,-2.5,-3.6,-4.8]
    c = list(map(int,c))
    # 다음과 같이 int형으로 잘라주기때문에 이생각은 문제를 많이 안풀었기때문에 생각함
    print(c)
    return str(min(answer)) + " " + str(max(answer))