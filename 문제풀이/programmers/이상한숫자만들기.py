s = "try hello world"
def solution(s):
    answer = ''
# 리스트로 시작해서 생각할수있지만 접근은 split() 분해시켜야하는 이유는 
# 리스트의 결과물은 
# ['t', 'r', 'y', ' ', 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd'] 라는결과가 나옴 
# 이렇게 하는 경우는 빈칸도 if절로 넣어서 생각해야하는데 
# 그럼 코드가 쓸대없이 길어짐 
    print(s.split(' ')) # 0, 1 , 2 = ['try', 'hello', 'world'] 
    for i in s.split(' '):
        for j in range(len(i)):
            print(len(i)) # i1 = 3 [try] ,i2= 5 [hello] ,i3 = 5 [world] 
            if j % 2 == 0:
                print("j % 2 == 0 결과 : " + i[j].upper())
                answer += i[j].upper()
            else:
                print("else 에 나올 i[j] 값 :" + i[j].lower())
                answer += i[j].lower()
        answer += ' ' # 마지막칸 " "(빈칸원인)
        # for j 문이 끝나면 빈칸을 삽입 
        print(answer)
    return answer[0:-1]

# -1 은 마지막 j 이 끝날때 빈칸이 나오지만 -1로 빈칸없이 만들기
# "try hello world " 편의상 대문자 생략 