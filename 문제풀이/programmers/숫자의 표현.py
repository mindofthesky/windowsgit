n = 15
def solution(n):
    answer = 0
    #count를 안에 넣으면 계속 증가하기때문에 할수없다
    
    for i in range(1,n+1):   
        # sum = count 해야되니까 
        count =0
        print("범위", i)
        for j in range(i, n+1):
            # 1 부터 더해짐 > 15 가 될때까지 
            # 지금 내 머리속에서 수식화 를못했음
            count += j
            print("더해지는지 보는 카운트", count)
            if count == n:
                answer +=1
                break
            elif count > n:
                break
        print("answer 값" ,answer)            
    return answer