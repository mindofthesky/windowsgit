# -*- coding: cp949 -*-
class KDRTree:
    def inbox(p, box):
        return all(box[:,0] <= p) and all (p <= box[:,1])
    def __init__(self, P, d = 0) :
        
        n = len(P)
        m = n // 2
        P.sort(key = lambda x : x[0])
        self.point = P[m]
        self.d = d
        d = (d+1) % len(P[0])
        self.left = self.right = None
        if m > 0 :
            self.left =  KDRTree(P[:m],d)
        if n -(m+1) > 0:
            self.right = KDRTree(P[m+1:],d)
        def rangesearch(self, box):
            p = self.point
            if inbox(p, box):
                yield d
            split = p[self.d]
            mins, maxs = box[d]
            if self.left is not None and split >= mins:
                yield from self.left.rangesearch(box)
            if self.right is not None and split <=maxs:       
                yield from self.right.rangesearch(box)


P = [(1,2),(3,4),(5,6)]
T = KDRTree(P)
from numpy import array
print(list(T.rangesearch(array([[-3,-4],[9,9]]))))        
# 직교에 대한 거리는해답이된다...