sequence = [1, 2, 3, 4, 5]
k = 7

sequence1 = [2,2,2,2,2]
k1 = 6

sequence2 = [1, 1, 1, 2, 3, 4, 5]
k2 = 5
def solution(sequence, k):
    #맞는 답
    answer = []
    sum = 0
    l = 0 
    r= -1
    # 나의 경우는 while문의 접근을 배제하고 접근했음 큰문제는 여기라고 생각
    while True:
        if sum < k:
            r +=1
            # 1회시행
            # r = 0 
            # r = 4 > 멈춤 
            #print("r값 : ",r)
            if r >= len(sequence):
                # 0 >= 5 break 하지않음 5이후 브레이크 
                break
            sum += sequence[r]
            print("sum값 :", sum)
            #sum = 1 
            #sum = 10이 될때까지 반복
            # 10넘은 값은 볼필요가없다 > 그렇지만 이코드에서는 끝까지 갈수있게 계속 검사한다 
            # 끝까지 갈 필요가있어서 끝까지 가야한다 
        else:
             print("else절 : ", sum)
             sum -= sequence[l]
             # sum값을 줄임에 따라 좌표값이 정해진다 
             if l >= len(sequence):
                 # 값이 len보다 크면 break 
                  break
             # l를 증가시킴으로 아래 식과 성립한다 
             l +=1
             # l를 증가시켜 0,1 빼야하기때문에 다음 값을 볼수있음 
             # l의 역할은 7이라는 값이 됬을때 
             # l값을 호출해서 뺄수있게만든다 그리고 빼고나서는 l값을 증가시킨다 
             # 다음값 l를 지칭해야하기때문에 
             #print("l 값 : " ,l)
        if sum == k:
             answer.append([l,r])
             #print(l,r)
    print("소트 하기전",answer)
    answer.sort(key=lambda x:(x[1]-x[0],x[0]))
    print(answer)
    return answer[0]
    
    """
    내가 생각했던 코드 
    for i in range(len(sequence)):
        for j in range(1,len(sequence)):
            2중 포문으로 쉽게 할수 있지않을까로 계속 고민했다 
            잘못된 생각이였고 빨리 바꿔야했다 
             sum(sequence[i:j])
             이 코드의 문제점은 6:6 같은 점을 생각하지않는다 
             맞는 코드가 아님에도 계속 for문을 고집함 
             조건에 대한 생각은 맞았다고 할수있지만
             
             첫 접근방식이 틀렸기때문에 맞다고 할수없다 
             if sum(sequence[i:j]) > k:
                 #print("p값초과로 break",sequence[i:(j+1)])
                 break
             # 0 > k값에서 멈춰야함
             # k이 넘으면 다른값으로 가야함 
             elif sum(sequence[i:j]) == k:
                 나는 어팬드를 잘못접근한 부근이 이거였다
                  answer.append(i)
                  answer.append(j)
                  이렇게 된다는 생각을 안했다 >> answer.append([i,j-1])
                  # 이런 값으로 갔을경우는 5혼자인걸 계산하지 않는다 
    print(answer)
    
    
    return answer               
    """
    
    
#solution(sequence, k)
#solution(sequence1, k1)
solution(sequence2, k2)
