﻿void main(int n) {
    int arr[4];
    arr[0] = 7;
    arr[1] = 13;
    arr[2] = 9;
    arr[3] = 8;
    
    int sump;
    arrsum(n, arr, &sump);
    print sump; 
}

void arrsum(int n, int arr[], int *sump) {
    int i;
    int temp;
    temp = 0;
    i = 0;
    while (i < n) {
        temp = temp + arr[i];
        i = i + 1;
    }
    *sump = temp;
}


