void main(int n) {
    int arr[20];
    squares(n, arr);
}

void squares(int n, int arr[]) {
    int i;
    for (i = 0; i < n; i = i +1)
        arr[i] = i * i;

    int squaresum;
    squaresum = 0;
    arrsum(n, arr, &squaresum);
    print squaresum;
}

void arrsum(int n, int arr[], int *sump) {
    int i;
    for (i = 0; i < n; i = i +1)
        *sump = *sump + arr[i];
}





