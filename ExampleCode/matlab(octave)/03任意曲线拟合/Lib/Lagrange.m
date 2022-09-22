function result = Lagrange(x,y,xi)
    n = length(x);
    p =length(y);
    m = length(xi);
    if n ~= p
         throw("dim x not equal dim y");
    end
    for i =1:m
        z=xi(i);
        s=0.0;
        for k=1:n
            p = 1.0;
            for j =1:n
                if j~=k
                    p = p*(z-x(j))/(x(k)-x(j));
                end
            end
            s = p*y(k)+s;
        end
        result(i) = s;
    end
end

