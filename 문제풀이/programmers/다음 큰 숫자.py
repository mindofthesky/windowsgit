n = 1

def solution(n):
    answer = 0
    num = n+1
    print(n)
    while True:
        
        #print(num)
        if format(n,'b').count('1') == format(num,'b').count('1'):
            answer = num
            break
        num+=1
            #format(s.count('1'),'b')
        #if bin(n):
    #if 
    print(" A " ,format(n,'b').count('1'))
    print(" B ", format(num,'b').count('1'))
    print(answer)
    return answer

solution(n)
