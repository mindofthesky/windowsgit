s = "110010101001"
s1 = "01110"
s3 = "1"
s2 = "1111111"
def solution(s):
    answer = [0,0]
    kcount = 0
    #무조건 [] 값으로나온다
    #첫번째 나온 1의값은 0으로 바꾸지않는다 
    # 회차가 res[0], 0제거 갯수 res[1]
    for i in s:
        if s == '1':
            # 만약 s가 0이라면 넣어두긴 했지만 있을수가 없다
            break
        else:
            # 오직 내가 풀어낸 문제!!!!
            kcount+=1
            answer[1] += len(s) - s.count('1')
            # 컴퓨터한태 2진법을 해달라해야됨 
            #print(format(s.count('1'),'b'))
            s = format(s.count('1'),'b')
            print(s)
            
            answer[0] = kcount
    # print(s.count('1')) 1의 카운터를 계산하게되는데 문제는 2진법으로 다시 전환은 해결 fomat쓰면됨
    print(answer) 
    return answer

solution(s)