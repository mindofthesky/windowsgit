s = "()()"
s1 = "(())()"
s2 = ")()("
s3 = "(()("
def solution(s):
    answer = True
    print("s값",s)
    #내코드 
    # 이상태에서는 if문에서 res == s 랑 비교하지못해서 바로 False로 넘어감 
    #for i in range(len(a)):
    #    if res == '(':
    #        res.append(i)
    #    else:
    #        if res == []:
    #            return False
    #        else:
    #            res.pop()
    #if res != []:
    #    return False
    #return True
    # [실행] 버튼을 누르면 출력 값을 볼 수 있습니다.
    a = list(s)
    res =[]
    # [실행] 버튼을 누르면 출력 값을 볼 수 있습니다.
    for i in s:
        if i == '(':
            res.append(i)
        else:
            if res == []:
                answer = False
                return False
            else:
                res.pop()
    if res != []:
        answer = False
        return False
    print(answer)
    return answer

def solution1(s):
    answer =True
    a = list(s)
    res =[]
    print("soul1 s값",s)
    #내코드 range(len(a)) > 값은 정수형 
    # s 로가면 문자형이기때문에 비교하기 더쉽다 
    # 이상태에서는 if문에서 res == s 랑 비교하지못해서 바로 False로 넘어감 
    for i in s:
        if i == '(':
            res.append(i)
        else:
           if res == []:
                return False
           else:
               res.pop()
               
        print(answer)
        return True
    #return True
    # [실행] 버튼을 누르면 출력 값을 볼 수 있습니다.
    #for i in s:
    #    print("값들어오는지 로깅")
    #    if i == '(':
    #        res.append(i)
    #    else:
    #        if res == []:
    #            print("값들어오는지 로깅1")
    #            return False
    #        else:
    #            print(res)
    #            res.pop()
    #            print("값들어오는지 로깅2")
    #    print(res)
    #if res != []:
    #    return False
    print(answer)
    return answer

    
    

solution(s2)
solution1(s3)
