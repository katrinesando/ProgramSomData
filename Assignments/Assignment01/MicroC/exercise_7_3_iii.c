void main(int n) {

    int freq[7];
    freq[0] = 0;
    freq[1] = 0;
    freq[2] = 0;
    freq[3] = 0;
    freq[4] = 0;
    freq[5] = 0;
    freq[6] = 0;
    
    int ns[7];
    
    ns[0] = 1;
    ns[1] = 2;
    ns[2] = 1;
    ns[3] = 1;
    ns[4] = 1;
    ns[5] = 2;
    ns[6] = 0;

    int max;
    max = 6;
    histogram(n,ns, max, freq);
}

void histogram(int n, int ns[], int max, int freq[]) {
    int i;
    for (i = 0; i < n; i = i + 1) {
        int tmp;
        tmp = ns[i];
        freq[tmp] = freq[tmp] + 1;
    }

    int j;
    for (j = 0; j < n; j = j + 1)
        print freq[j];
}