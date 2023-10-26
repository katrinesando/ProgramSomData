void main(int n) {
    int arr[20];
    squares(n, arr);
}

void squares(int n, int arr[]) {
    int i;
    i = 0;

    while (i < n) {
        arr[i] = i * i;
        i = i + 1;
    }

    int squaresum;
    squaresum = 0;
    arrsum(n, arr, &squaresum);
    print squaresum;
}

void arrsum(int n, int arr[], int *sump) {
    int i;
    i = 0;
    while (i < n) { 
        *sump = *sump + arr[i];
        i = i + 1;
    }
}





