def solution(mats, park):
    mats.sort(reverse=True)
    rows = len(park)
    cols = len(park[0])

    def can_place(mat_size, r, c):
        # 현재 위치에서 mat_size 크기의 돗자리를 놓을 수 있는지 확인
        if r + mat_size > rows or c + mat_size > cols:
            return False
        for i in range(r, r + mat_size):
            for j in range(c, c + mat_size):
                if park[i][j] != "-1":  # 빈 공간이 아니면 False
                    return False
        return True

    # 큰 돗자리부터 작은 돗자리까지 시도
    for mat_size in mats:
        for i in range(rows):
            for j in range(cols):
                if can_place(mat_size, i, j):
                    return mat_size  # 가장 큰 돗자리를 반환
    return -1
