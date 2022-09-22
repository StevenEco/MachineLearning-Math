clear
dx = [-5:0.00001:5];
dy = (1+dx.^2).^-1;

sample_x1 = [-5:10/11:5];
sample_y1 = (1+sample_x1.^2).^-1;
sample_x2 = [-5:10/6:5];
sample_y2 = (1+sample_x2.^2).^-1;

ly1 = Lagrange(sample_x1,sample_y1,dx);
ly2 = Lagrange(sample_x2,sample_y2,dx);

figure;
plot(dx,dy,'r',dx,ly1,'k--',dx,ly2,'b-.');


legend('f(x)', 'p_{10}(x)','p_5(x)');
title('Runge 5 and 10');
grid;