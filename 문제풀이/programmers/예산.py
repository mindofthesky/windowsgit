d= [1,3,2,5,4]
budget = 9
result = 3
def solution(d, budget):
    answer = 0
    # 정렬해도되고 안해도됨 정렬하는경우 budget이 좀더 편해진다 
    # 아닌경우 조금 계산해야되는 부분이 나온다 
    d.sort()
    # for문은 범위는 range >  len(d)까지 연산하면되니까 
    for i in range(len(d)):
        budget -= d[i]
        # 0 이되면 종료되는 코드가 필요 
        answer+= 1
        # result > answer 값이기때문에 
        # 원래는 무조건 상승하는 코드라서 좋은 코드는 아니지만 
        # 넘어가는경우에는 if문에 걸리기때문에 
        print("빼기전 : ",budget)
        print("answer : ", answer)
        if budget < 0:
            print("빼고나서 : ",budget)
            answer -= 1 
            # 감소처리가 된다 
            return answer
    return len(d)

#def solution(d, budget):
#    answer = 0
#    num = 0
#    for i in range(len(d)):
#        num += d[i]
#        answer+= 1
#        print("빼기전 : ",num)
#        print("answer : ", answer)
#        if num > budget:
#            num -= d[i]
#            print("빼고나서 : ",num)
#            answer -= 1 
#            return answer
#    return len(d)
# 이게 위에 조건에서 무조건 참을 찾는다 