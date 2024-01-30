A = [1,2]
B = [3,4]
A1 = [1,4,2]
B2 = [5,4,4]
def solution(A,B):
    answer = 0
    #접근 자체가 틀린문제
    # 나는 내코드의 시작은
    # 첫접근 
    # [x*y for x,y in zip(A,B)]
    # print([x*y for x,y in zip(A,B)])
    # zip 함수로 끝을 내면되겠구나였지만
    # 여기서 sort를 했다면 정답은 같았다 
    # 소트생각을 아에안했으니 [x,y 가 아닌 줄 알았다 ]
    # 돌아갔다 A[i] * A[j]로 생각한 코드로 해버림
    # 두번째접근은
    #for i in range(len(A)):
    #    for j in range(len(B)):
    #        A[i]*B[j]
    # 완전 탐색을 해야하지않을까 접근을 했던 실수 
    # 소트를 했다면 바로 나올수있는 식이였음에도 나는 바보같이 접근했다 
    A.sort(reverse = True)
    print(A)
    B.sort()
    print(B)
    for i in range(len(A)):
        answer += (A[i]*B[i])
    return answer